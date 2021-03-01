﻿using GraphIt.wasm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Services
{
    public interface IZoomService
    {
        string GetPercentageString(double scale);
        double GetPercentage(double scale);
        public double GetDefaultScale();
        double GetMaxScale();
        bool ZoomIn(SVGControl svgControl);
        bool ZoomOut(SVGControl svgControl);
        void NewInput(string vlaue, SVGControl svgControl);
    }
}