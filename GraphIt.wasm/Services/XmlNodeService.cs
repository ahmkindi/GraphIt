using GraphIt.wasm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace GraphIt.wasm.Services
{
    public class XmlNodeService : IXmlNodeService
    {
        public void CreateNode(Node node, XmlTextWriter writer)
        {
            writer.WriteStartElement("Node");
            writer.WriteStartElement("NodeId");
            writer.WriteString(node.Id.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Label");
            writer.WriteString(node.Label);
            writer.WriteEndElement();
            writer.WriteStartElement("LabelColor");
            writer.WriteString(node.LabelColor);
            writer.WriteEndElement();
            writer.WriteStartElement("NodeColor");
            writer.WriteString(node.Color);
            writer.WriteEndElement();
            writer.WriteStartElement("Radius");
            writer.WriteString(node.Size.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Xaxis");
            writer.WriteString(node.Xaxis.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Yaxis");
            writer.WriteString(node.Yaxis.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public void CreateNode(Edge edge, XmlTextWriter writer)
        {
            writer.WriteStartElement("Edge");
            writer.WriteStartElement("EdgeId");
            writer.WriteString(edge.Id.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Label");
            writer.WriteString(edge.Label);
            writer.WriteEndElement();
            writer.WriteStartElement("LabelColor");
            writer.WriteString(edge.LabelColor);
            writer.WriteEndElement();
            writer.WriteStartElement("EdgeColor");
            writer.WriteString(edge.Color);
            writer.WriteEndElement();
            writer.WriteStartElement("Curve");
            writer.WriteString(edge.Curve.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("HeadNodeId");
            writer.WriteString(edge.Head.Id.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("TailNodeId");
            writer.WriteString(edge.Tail.Id.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Weight");
            writer.WriteString(edge.Weight.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Width");
            writer.WriteString(edge.Size.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public void CreateNode(Graph graph, XmlTextWriter writer)
        {
            foreach (Node node in graph.Nodes) CreateNode(node, writer);
            foreach (Edge edge in graph.Edges) CreateNode(edge, writer);
            writer.WriteStartElement("Settings");
            writer.WriteStartElement("MultiGraph");
            writer.WriteString(graph.MultiGraph.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Weighted");
            writer.WriteString(graph.Weighted.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Directed");
            writer.WriteString(graph.Directed.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public void CreateNode(Options o, XmlTextWriter writer)
        {
            writer.WriteStartElement("Default");
            writer.WriteStartElement("NodeColor");
            writer.WriteString(o.Default.NodeColor);
            writer.WriteEndElement();
            writer.WriteStartElement("NodeLabelCOlor");
            writer.WriteString(o.Default.NodeLabelColor);
            writer.WriteEndElement();
            writer.WriteStartElement("NodeRadius");
            writer.WriteString(o.Default.NodeRadius.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("EdgeColor");
            writer.WriteString(o.Default.EdgeColor);
            writer.WriteEndElement();
            writer.WriteStartElement("EdgeLabelColor");
            writer.WriteString(o.Default.EdgeLabelColor);
            writer.WriteEndElement();
            writer.WriteStartElement("EdgeWidth");
            writer.WriteString(o.Default.EdgeWidth.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("Algorithm");
            writer.WriteStartElement("NodeColor");
            writer.WriteString(o.Algorithm.NodeColor);
            writer.WriteEndElement();
            writer.WriteStartElement("NodeLabelCOlor");
            writer.WriteString(o.Algorithm.NodeLabelColor);
            writer.WriteEndElement();
            writer.WriteStartElement("NodeRadius");
            writer.WriteString(o.Algorithm.NodeRadius.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("EdgeColor");
            writer.WriteString(o.Algorithm.EdgeColor);
            writer.WriteEndElement();
            writer.WriteStartElement("EdgeLabelColor");
            writer.WriteString(o.Algorithm.EdgeLabelColor);
            writer.WriteEndElement();
            writer.WriteStartElement("EdgeWidth");
            writer.WriteString(o.Algorithm.EdgeWidth.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public void Draw(Node node, XmlTextWriter writer)
        {
            writer.WriteStartElement("g");

            writer.WriteStartElement("circle");
            writer.WriteAttributeString("cx", node.Xaxis.ToString());
            writer.WriteAttributeString("cy", node.Yaxis.ToString());
            writer.WriteAttributeString("r", node.Size.ToString());
            writer.WriteAttributeString("stroke", node.Color);
            writer.WriteAttributeString("stroke-width", "2");
            writer.WriteAttributeString("fill", node.Color);
            writer.WriteEndElement();

            writer.WriteStartElement("text");
            writer.WriteAttributeString("text-anchor", "middle");
            writer.WriteAttributeString("x", node.Xaxis.ToString());
            writer.WriteAttributeString("y", node.Yaxis.ToString());
            writer.WriteAttributeString("stroke", node.Color);
            writer.WriteAttributeString("stroke-width", "1");
            writer.WriteAttributeString("fill", node.LabelColor);
            writer.WriteAttributeString("font-size", (node.Size/2).ToString());
            writer.WriteAttributeString("font-family", "Verdana");
            writer.WriteString(node.Label);
            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        public void Draw(Edge edge, XmlTextWriter writer, bool weighted, bool directed)
        {
            var showEdge = new ShowEdge(edge);
            writer.WriteStartElement("g");

            writer.WriteStartElement("path");
            writer.WriteAttributeString("id", edge.Id.ToString());
            writer.WriteAttributeString("stroke", edge.Color);
            writer.WriteAttributeString("stroke-width", edge.Size.ToString());
            writer.WriteAttributeString("fill", "none");
            if (edge.Head == edge.Tail)
            {
                writer.WriteAttributeString("d", showEdge.Path);
            }
            else
            {
                writer.WriteAttributeString("d", showEdge.Path);
            }
            if (directed) writer.WriteAttributeString("marker-end", $"url(#arrowhead{edge.Id})");
            writer.WriteEndElement();

            writer.WriteStartElement("text");
            writer.WriteAttributeString("text-anchor", "middle");
            writer.WriteAttributeString("dy", (showEdge.Yoffset).ToString());
            writer.WriteAttributeString("fill", edge.Color);
            writer.WriteAttributeString("font-size", (showEdge.FontSize).ToString());
            writer.WriteStartElement("textPath");
            writer.WriteAttributeString("href", $"#{edge.Id}");
            writer.WriteAttributeString("startOffset", "50%");
            writer.WriteString(showEdge.Label);
            writer.WriteEndElement();
            writer.WriteEndElement();

            if (weighted)
            {
                writer.WriteStartElement("text");
                writer.WriteAttributeString("text-anchor", "middle");
                writer.WriteAttributeString("dy", (-edge.Size).ToString());
                writer.WriteAttributeString("fill", edge.Color);
                writer.WriteAttributeString("font-size", (showEdge.FontSize).ToString());
                writer.WriteStartElement("textPath");
                writer.WriteAttributeString("href", $"#{edge.Id}");
                writer.WriteAttributeString("startOffset", "50%");
                writer.WriteString(showEdge.Weight);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }

            writer.WriteStartElement("defs");
            writer.WriteStartElement("marker");
            writer.WriteAttributeString("id", $"arrowhead{edge.Id}");
            writer.WriteAttributeString("markerWidth", showEdge.EdgeArrow.Width.ToString());
            writer.WriteAttributeString("markerHeight", showEdge.EdgeArrow.Height.ToString());
            writer.WriteAttributeString("refX", showEdge.EdgeArrow.ArrowOffset[0].ToString());
            writer.WriteAttributeString("refY", showEdge.EdgeArrow.ArrowOffset[1].ToString());
            writer.WriteAttributeString("orient", "auto");
            writer.WriteStartElement("polygon");
            writer.WriteAttributeString("points", $"{showEdge.EdgeArrow.Points[0]} {showEdge.EdgeArrow.Points[1]}, " +
                                        $"{showEdge.EdgeArrow.Points[2]} {showEdge.EdgeArrow.Points[3]}, " +
                                        $"{showEdge.EdgeArrow.Points[4]} {showEdge.EdgeArrow.Points[5]}");
            writer.WriteAttributeString("fill", edge.Color);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}
