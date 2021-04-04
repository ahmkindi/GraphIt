using GraphIt.wasm.Models;
using GraphIt.wasm.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GraphIt.wasm.Pages
{
    public class FileBase : ComponentBase
    {
        [Parameter] public Options Options { get; set; }
        [Parameter] public EventCallback<Options> OptionsChanged { get; set; }
        [Parameter] public SVGControl SVGControl { get; set; }
        [Parameter] public Graph Graph { get; set; }
        [Parameter] public EventCallback<Graph> GraphChanged { get; set; }
        [Parameter] public SaveAs SaveAs { get; set; }
        [Parameter] public EventCallback<SaveAs> SaveAsChanged { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public NavigationManager UriHelper { get; set; }
        [Inject] public IXmlNodeService XmlNodeService { get; set; }
        public bool ErrorOpening { get; set; } = false;
        public bool OpenPreference { get; set; } = false;
        public bool NewGraphCheck { get; set; } = false;
        public bool Overwrite { get; set; } = false;

        public async Task SaveGraphItFile()
        {
            string result;
            MemoryStream stream = new MemoryStream();
            using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Graph");
                XmlNodeService.CreateNode(Graph, writer);
                XmlNodeService.CreateNode(Options, writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8, true);
                stream.Seek(0, SeekOrigin.Begin);
                result = reader.ReadToEnd();
            }
            await JSRuntime.InvokeVoidAsync("BlazorDownloadFile", "Gra.phanatic", "application/octet-stream", DeflateAndEncode(result));
        }

        public async Task OpenGraphItFile(InputFileChangeEventArgs e, bool overwrite)
        {
            Overwrite = overwrite;
            try
            {
                byte[] temp;
                Options newOptions = new Options();
                using (var streamReader = new MemoryStream())
                {
                    await e.File.OpenReadStream().CopyToAsync(streamReader);
                    temp = streamReader.ToArray();
                }
                OpenPreference = false;
                string graph = DecodeAndInflate(temp);
                XmlDocument xmlData = new XmlDocument();
                xmlData.LoadXml(graph);
                if (Overwrite)
                {
                    Graph = new Graph();
                }
                Traverse(xmlData, NodeService.NextId(Graph.Nodes), EdgeService.NextId(Graph.Edges));
                await GraphChanged.InvokeAsync(Graph);
                if (Overwrite) await OptionsChanged.InvokeAsync(Options);
            }
            catch (ObjectDisposedException)
            {
                ErrorOpening = true;
            }
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
                                newNode.Id = int.Parse(node.InnerText) + nextNodeId;
                                break;
                            case "NodeColor":
                                newNode.Color = node.InnerText;
                                break;
                            case "Label":
                                newNode.Label = node.InnerText;
                                break;
                            case "LabelColor":
                                newNode.LabelColor = node.InnerText;
                                break;
                            case "Radius":
                                newNode.Size = int.Parse(node.InnerText);
                                break;
                            case "Xaxis":
                                newNode.Xaxis = double.Parse(node.InnerText);
                                break;
                            case "Yaxis":
                                newNode.Yaxis = double.Parse(node.InnerText);
                                break;
                        }
                    }
                    Graph.Nodes.Add(newNode);
                }
                else if (i.Name == "Edge")
                {
                    Edge newEdge = new Edge();
                    foreach (XmlNode edge in i.ChildNodes)
                    {
                        switch (edge.Name)
                        {
                            case "EdgeId":
                                newEdge.Id = int.Parse(edge.InnerText) + nextEdgeId;
                                break;
                            case "Label":
                                newEdge.Label = edge.InnerText;
                                break;
                            case "LabelColor":
                                newEdge.LabelColor = edge.InnerText;
                                break;
                            case "Width":
                                newEdge.Size = int.Parse(edge.InnerText);
                                break;
                            case "HeadNodeId":
                                newEdge.Head = Graph.Nodes.First(n => n.Id == int.Parse(edge.InnerText) + nextNodeId);
                                break;
                            case "TailNodeId":
                                newEdge.Tail = Graph.Nodes.First(n => n.Id == int.Parse(edge.InnerText) + nextNodeId);
                                break;
                            case "Curve":
                                newEdge.Curve = double.Parse(edge.InnerText);
                                break;
                            case "EdgeColor":
                                newEdge.Color = edge.InnerText;
                                break;
                            case "Weight":
                                newEdge.Weight = double.Parse(edge.InnerText);
                                break;
                        }
                    }
                    Graph.Edges.Add(newEdge);
                }
                else if (i.Name == "Settings")
                {
                    foreach (XmlNode option in i.ChildNodes)
                    {
                        switch (option.Name)
                        {
                            case "MultiGraph":
                                Graph.MultiGraph = bool.Parse(option.InnerText);
                                break;
                            case "Weighted":
                                if (!Overwrite) break;
                                Graph.Weighted = bool.Parse(option.InnerText);
                                break;
                            case "Directed":
                                if (!Overwrite) break;
                                Graph.Directed = bool.Parse(option.InnerText);
                                break;
                        }
                    }
                }

                else if (i.Name == "Default")
                {
                    if (!Overwrite) break;
                    foreach (XmlNode option in i.ChildNodes)
                    {
                        switch (option.Name)
                        {
                            case "NodeColor":
                                Options.Default.NodeColor = option.InnerText;
                                break;
                            case "NodeLabelColor":
                                Options.Default.NodeColor = option.InnerText;
                                break;
                            case "NodeRadius":
                                Options.Default.NodeRadius = int.Parse(option.InnerText);
                                break;
                            case "EdgeColor":
                                Options.Default.EdgeColor = option.InnerText;
                                break;
                            case "EdgeLabelColor":
                                Options.Default.EdgeLabelColor = option.InnerText;
                                break;
                            case "EdgeWidth":
                                Options.Default.EdgeWidth = int.Parse(option.InnerText);
                                break;
                        }
                    }
                }
                else if (i.Name == "Algorithm")
                {
                    foreach (XmlNode option in i.ChildNodes)
                    {
                        switch (option.Name)
                        {
                            case "NodeColor":
                                Options.Algorithm.NodeColor = option.InnerText;
                                break;
                            case "NodeLabelColor":
                                Options.Algorithm.NodeColor = option.InnerText;
                                break;
                            case "NodeRadius":
                                Options.Algorithm.NodeRadius = int.Parse(option.InnerText);
                                break;
                            case "EdgeColor":
                                Options.Algorithm.EdgeColor = option.InnerText;
                                break;
                            case "EdgeLabelColor":
                                Options.Algorithm.EdgeLabelColor = option.InnerText;
                                break;
                            case "EdgeWidth":
                                Options.Algorithm.EdgeWidth = int.Parse(option.InnerText);
                                break;
                        }
                    }
                }
            }
        }
    }
}
