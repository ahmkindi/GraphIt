using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GraphIt.web.Pages
{
    public class FileBase : ComponentBase
    {
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public SVGControl SVGControl { get; set; }
        [Parameter] public EventCallback<bool> UpdateCanvas { get; set; }
        [Parameter] public List<Node> Nodes { get; set; }
        [Parameter] public List<Edge> Edges { get; set; }
        [Parameter] public EventCallback<List<Node>> NodesChanged { get; set; }
        [Parameter] public EventCallback<List<Edge>> EdgesChanged { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public NavigationManager UriHelper { get; set; }
        [Inject] public IXmlNodeService XmlNodeService { get; set; }
        public bool ErrorOpening { get; set; } = false;
        public bool OpenPreference { get; set; } = false;
        public bool NewGraphCheck { get; set; } = false;
        public async Task SaveSVGFile(bool screenView)
        {
            string result;
            MemoryStream stream = new MemoryStream();
            using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument(false);
                writer.WriteStartElement(null, "svg", "http://www.w3.org/2000/svg");
                writer.WriteAttributeString("version", "1.1");
                if (screenView) writer.WriteAttributeString("viewBox", $"{SVGControl.Xaxis} {SVGControl.Yaxis} {SVGControl.Width} {SVGControl.Height}");
                else writer.WriteAttributeString("viewBox", FullView(Nodes));
                foreach (Edge edge in Edges) XmlNodeService.Draw(edge, edge.HeadNode(Nodes), edge.TailNode(Nodes), writer, DefaultOptions.Weighted, DefaultOptions.Directed);
                foreach (Node node in Nodes) XmlNodeService.Draw(node, writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8, true);
                stream.Seek(0, SeekOrigin.Begin);
                result = reader.ReadToEnd();
            }
            await JSRuntime.InvokeVoidAsync("BlazorDownloadFile", "MyGraph.svg", "image/svg+xml", Encoding.UTF8.GetBytes(result));
        }

        public string FullView(IEnumerable<Node> nodes)
        {
            if (nodes.Any())
            {
                var x = nodes.Min(n => n.Xaxis - n.Radius);
                var y = nodes.Min(n => n.Yaxis - n.Radius);
                var width = nodes.Max(n => n.Xaxis + n.Radius) - x;
                var height = nodes.Max(n => n.Yaxis + n.Radius) - y;
                return $"{x} {y} {width} {height}";
            }
            return "0 0 0 0";
        }
        public async Task SaveGraphItFile()
        {
            string result;
            MemoryStream stream = new MemoryStream();
            using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Graph");
                foreach (Node node in Nodes) XmlNodeService.CreateNode(node, writer);
                foreach (Edge edge in Edges) XmlNodeService.CreateNode(edge, writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8, true);
                stream.Seek(0, SeekOrigin.Begin);
                result = reader.ReadToEnd();
            }
            await JSRuntime.InvokeVoidAsync("BlazorDownloadFile", "MyGraph.graphit", "application/octet-stream", DeflateAndEncode(result));
        }

        public async Task OpenGraphItFile(InputFileChangeEventArgs e, bool overwrite)
        {
            OpenPreference = false;
            try
            {
                byte[] temp;
                IList<Node> newNodes = new List<Node>();
                IList<Edge> newEdges = new List<Edge>();
                DefaultOptions tempDef = new DefaultOptions();

                using (var streamReader = new MemoryStream())
                {
                    await e.File.OpenReadStream().CopyToAsync(streamReader);
                    temp = streamReader.ToArray();
                }
                string graph = DecodeAndInflate(temp);
                XmlDocument xmlData = new XmlDocument();
                xmlData.LoadXml(graph);
                if (overwrite)
                {
                    Nodes.Clear();
                    Edges.Clear();
                }
                Traverse(xmlData, NodeService.NextId(Nodes), EdgeService.NextId(Edges));
            }
            catch (Exception)
            {
                ErrorOpening = true;
            }
            await NodesChanged.InvokeAsync(Nodes);
            await EdgesChanged.InvokeAsync(Edges);
        }

        private byte[] DeflateAndEncode(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            using (var output = new MemoryStream())
            {
                using (var zip = new DeflateStream(output, CompressionMode.Compress))
                {
                    zip.Write(bytes, 0, bytes.Length);
                }
                return output.ToArray();
            }
        }

        private static string DecodeAndInflate(byte[] bytes)
        {
            var utf8 = Encoding.UTF8;
            using (var output = new MemoryStream())
            {
                using (var input = new MemoryStream(bytes))
                {
                    using (var unzip = new DeflateStream(input, CompressionMode.Decompress))
                    {
                        unzip.CopyTo(output, bytes.Length);
                        unzip.Close();
                    }
                    return utf8.GetString(output.ToArray());
                }
            }
        }

        private void Traverse(XmlDocument xmlData, int nextNodeId, int nextEdgeId)
        {
            foreach (XmlNode i in xmlData.DocumentElement.ChildNodes)
            {
                if (i.Name == "Node")
                {
                    Node newNode = new Node();
                    foreach (XmlNode node in i.ChildNodes)
                    {
                        switch (node.Name)
                        {
                            case "NodeId":
                                newNode.NodeId = int.Parse(node.InnerText) + nextNodeId;
                                break;
                            case "NodeColor":
                                newNode.NodeColor = node.InnerText;
                                break;
                            case "Label":
                                newNode.Label = node.InnerText;
                                break;
                            case "LabelColor":
                                newNode.LabelColor = node.InnerText;
                                break;
                            case "Radius":
                                newNode.Radius = int.Parse(node.InnerText);
                                break;
                            case "Xaxis":
                                newNode.Xaxis = double.Parse(node.InnerText);
                                break;
                            case "Yaxis":
                                newNode.Yaxis = double.Parse(node.InnerText);
                                break;
                        }
                    }
                    Nodes.Add(newNode);
                }
                else if (i.Name == "Edge")
                {
                    Edge newEdge = new Edge();
                    foreach (XmlNode edge in i.ChildNodes)
                    {
                        switch (edge.Name)
                        {
                            case "EdgeId":
                                newEdge.EdgeId = int.Parse(edge.InnerText) + nextEdgeId;
                                break;
                            case "Label":
                                newEdge.Label = edge.InnerText;
                                break;
                            case "LabelColor":
                                newEdge.LabelColor = edge.InnerText;
                                break;
                            case "Width":
                                newEdge.Width = int.Parse(edge.InnerText);
                                break;
                            case "HeadNodeId":
                                newEdge.HeadNodeId = int.Parse(edge.InnerText) + nextNodeId;
                                break;
                            case "TailNodeId":
                                newEdge.TailNodeId = int.Parse(edge.InnerText) + nextNodeId;
                                break;
                            case "Curve":
                                newEdge.Curve = double.Parse(edge.InnerText);
                                break;
                            case "EdgeColor":
                                newEdge.EdgeColor = edge.InnerText;
                                break;
                            case "Weight":
                                newEdge.Weight = double.Parse(edge.InnerText);
                                break;
                        }
                    }
                    Edges.Add(newEdge);
                }
            }
        }
    }
}
