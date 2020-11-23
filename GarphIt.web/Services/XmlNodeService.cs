using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace GraphIt.web.Services
{
    public class XmlNodeService
    {
        public void CreateNode(Node node, XmlTextWriter writer)
        {
            writer.WriteStartElement("Node");
            writer.WriteStartElement("Label");
            writer.WriteString(node.Label);
            writer.WriteEndElement();
            writer.WriteStartElement("LabelColor");
            writer.WriteString(node.LabelColor);
            writer.WriteEndElement();
            writer.WriteStartElement("NodeColor");
            writer.WriteString(node.NodeColor);
            writer.WriteEndElement();
            writer.WriteStartElement("Radius");
            writer.WriteString(node.Radius.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Xaxis");
            writer.WriteString(node.Xaxis.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Yaxis");
            writer.WriteString(node.Yaxis.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public void CreateNode(Edge edge, XmlTextWriter writer, int smallestId)
        {
            writer.WriteStartElement("Edge");
            writer.WriteStartElement("Label");
            writer.WriteString(edge.Label);
            writer.WriteEndElement();
            writer.WriteStartElement("LabelColor");
            writer.WriteString(edge.LabelColor);
            writer.WriteEndElement();
            writer.WriteStartElement("EdgeColor");
            writer.WriteString(edge.EdgeColor);
            writer.WriteEndElement();
            writer.WriteStartElement("Curve");
            writer.WriteString(edge.Curve.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("HeadNodeId");
            writer.WriteString((edge.HeadNodeId - smallestId).ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("TailNodeId");
            writer.WriteString((edge.TailNodeId - smallestId).ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Weight");
            writer.WriteString(edge.Weight.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Width");
            writer.WriteString(edge.Width.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
