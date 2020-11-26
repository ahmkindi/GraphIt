using GraphIt.models;
using GraphIt.web.models;
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
            writer.WriteStartElement("NodeId");
            writer.WriteString(node.NodeId.ToString());
            writer.WriteEndElement();
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

        public void CreateNode(Edge edge, XmlTextWriter writer)
        {
            writer.WriteStartElement("Edge");
            writer.WriteStartElement("EdgeId");
            writer.WriteString(edge.EdgeId.ToString());
            writer.WriteEndElement();
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
            writer.WriteString(edge.HeadNodeId.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("TailNodeId");
            writer.WriteString(edge.TailNodeId.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Weight");
            writer.WriteString(edge.Weight.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Width");
            writer.WriteString(edge.Width.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public void Draw(Node node, XmlTextWriter writer)
        {
            writer.WriteStartElement("g");

            writer.WriteStartElement("circle");
            writer.WriteAttributeString("cx", node.Xaxis.ToString());
            writer.WriteAttributeString("cy", node.Yaxis.ToString());
            writer.WriteAttributeString("r", node.Radius.ToString());
            writer.WriteAttributeString("stroke", node.NodeColor);
            writer.WriteAttributeString("stroke-width", "2");
            writer.WriteAttributeString("fill", node.NodeColor);
            writer.WriteEndElement();

            writer.WriteStartElement("text");
            writer.WriteAttributeString("text-anchor", "middle");
            writer.WriteAttributeString("x", node.Xaxis.ToString());
            writer.WriteAttributeString("y", node.Yaxis.ToString());
            writer.WriteAttributeString("stroke", node.NodeColor);
            writer.WriteAttributeString("stroke-width", "1");
            writer.WriteAttributeString("fill", node.LabelColor);
            writer.WriteAttributeString("font-size", (node.Radius/2).ToString());
            writer.WriteAttributeString("font-family", "Verdana");
            writer.WriteString(node.Label);
            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        public void Draw(Edge edge, Node head, Node tail, XmlTextWriter writer, bool weighted, bool directed)
        {
            var showEdge = new ShowEdge(edge, head, tail);
            writer.WriteStartElement("g");

            writer.WriteStartElement("path");
            writer.WriteAttributeString("id", edge.EdgeId.ToString());
            writer.WriteAttributeString("stroke", edge.EdgeColor);
            writer.WriteAttributeString("stroke-width", edge.Width.ToString());
            writer.WriteAttributeString("fill", "none");
            if (edge.HeadNodeId == edge.TailNodeId)
            {
                writer.WriteAttributeString("d", showEdge.Path);
            }
            else
            {
                writer.WriteAttributeString("d", showEdge.Path);
            }
            if (directed) writer.WriteAttributeString("marker-end", $"url(#arrowhead{edge.EdgeId})");
            writer.WriteEndElement();

            writer.WriteStartElement("text");
            writer.WriteAttributeString("text-anchor", "middle");
            writer.WriteAttributeString("dy", (showEdge.Yoffset).ToString());
            writer.WriteAttributeString("fill", edge.EdgeColor);
            writer.WriteAttributeString("font-size", (showEdge.FontSize).ToString());
            writer.WriteStartElement("textPath");
            writer.WriteAttributeString("href", $"#{edge.EdgeId}");
            writer.WriteAttributeString("startOffset", "50%");
            writer.WriteString(showEdge.Label);
            writer.WriteEndElement();
            writer.WriteEndElement();

            if (weighted)
            {
                writer.WriteStartElement("text");
                writer.WriteAttributeString("text-anchor", "middle");
                writer.WriteAttributeString("dy", (-edge.Width).ToString());
                writer.WriteAttributeString("fill", edge.EdgeColor);
                writer.WriteAttributeString("font-size", (showEdge.FontSize).ToString());
                writer.WriteStartElement("textPath");
                writer.WriteAttributeString("href", $"#{edge.EdgeId}");
                writer.WriteAttributeString("startOffset", "50%");
                writer.WriteString(showEdge.Weight);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }

            writer.WriteStartElement("defs");
            writer.WriteStartElement("marker");
            writer.WriteAttributeString("id", $"arrowhead{edge.EdgeId}");
            writer.WriteAttributeString("markerWidth", showEdge.EdgeArrow.Width.ToString());
            writer.WriteAttributeString("markerHeight", showEdge.EdgeArrow.Height.ToString());
            writer.WriteAttributeString("refX", showEdge.EdgeArrow.ArrowOffset[0].ToString());
            writer.WriteAttributeString("refY", showEdge.EdgeArrow.ArrowOffset[1].ToString());
            writer.WriteAttributeString("orient", "auto");
            writer.WriteStartElement("polygon");
            writer.WriteAttributeString("points", $"{showEdge.EdgeArrow.Points[0]} {showEdge.EdgeArrow.Points[1]}, " +
                                        $"{showEdge.EdgeArrow.Points[2]} {showEdge.EdgeArrow.Points[3]}, " +
                                        $"{showEdge.EdgeArrow.Points[4]} {showEdge.EdgeArrow.Points[5]}");
            writer.WriteAttributeString("fill", edge.EdgeColor);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}
