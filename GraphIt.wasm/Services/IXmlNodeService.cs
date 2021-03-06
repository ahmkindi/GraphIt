﻿using GraphIt.wasm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace GraphIt.wasm.Services
{
    public interface IXmlNodeService
    {
        void CreateNode(Node node, XmlTextWriter writer);
        void CreateNode(Edge edge, XmlTextWriter writer);
        void CreateNode(Graph graph, XmlTextWriter writer);
        void CreateNode(Options d, XmlTextWriter writer);
    }
}
