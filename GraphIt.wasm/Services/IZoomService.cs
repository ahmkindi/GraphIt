using GraphIt.wasm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Services
{
    public interface IZoomService
    {
        string GetPercentageString(double scale);
        int GetPercentage(double scale);
        double GetDefaultScale();
        double GetMaxScale();
        bool ZoomIn(SVGControl svgControl);
        bool ZoomOut(SVGControl svgControl);
        void NewInput(string vlaue, SVGControl svgControl);
    }
}
