using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public interface IZoomService
    {
        string GetPercentage(double scale);
        int GetPercentageInt(double scale);
        public double GetDefaultScale();
        double GetMaxScale();
        bool ZoomIn(SVGControl svgControl);
        bool ZoomOut(SVGControl svgControl);
        void NewInput(string vlaue, SVGControl svgControl);
    }
}
