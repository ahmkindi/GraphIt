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
    }
}
