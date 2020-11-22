using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
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
    public class HomeBase : ComponentBase
    {
        [Parameter] public Representation Rep { get; set; }
        [Parameter] public EventCallback<Representation> RepChanged { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public NavigationManager uriHelper { get; set; }
        public XmlNodeService XmlNodeService { get; set; } = new XmlNodeService();
        public async Task OnMatrixClick()
        {
            Rep = Representation.Matrix;
            await RepChanged.InvokeAsync(Rep);
        }
        public async Task OnWeightMatrixClick()
        {
            Rep = Representation.WeightedMatrix;
            await RepChanged.InvokeAsync(Rep);
        }

        public async Task SaveGraphItFile()
        {
            string result;
            MemoryStream stream = new MemoryStream();
            using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Graph");
                foreach (Node node in await NodeService.GetNodes()) XmlNodeService.CreateNode(node, writer);
                foreach (Edge edge in await EdgeService.GetEdges()) XmlNodeService.CreateNode(edge, writer);
                XmlNodeService.CreateNode(DefaultOptions, writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8, true);
                stream.Seek(0, SeekOrigin.Begin);
                result = reader.ReadToEnd();
            }
            await JSRuntime.InvokeAsync<string>("console.log", result);
            await JSRuntime.InvokeVoidAsync("BlazorDownloadFile", "MyGraph.graphit", "application/octet-stream", DeflateAndEncode(result));
        }

        public void OpenGraphItFile()
        {
            return;
        }

        public async Task NewGraph()
        {
            foreach (Node node in await NodeService.GetNodes()) await NodeService.DeleteNode(node.NodeId);
            uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true);
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

        private static string DecodeAndInflate(string str)
        {
            var utf8 = Encoding.UTF8;
            var bytes = Convert.FromBase64String(str);
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
    }
}
