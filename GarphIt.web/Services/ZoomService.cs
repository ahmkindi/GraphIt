using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public class ZoomService : IZoomService
    {
        private readonly double MaxScale = 3.5;
        public string GetPercentageString(double scale)
        {
            return $"{(int)Math.Round((MaxScale - scale) * 100)}%";
        }

        public double GetPercentage(double scale)
        {
            return ((int) Math.Round((MaxScale - scale) * 100))/100.0;
        }

        public double GetDefaultScale()
        {
            return MaxScale - 1;
        }

        public double GetMaxScale()
        {
            return MaxScale;
        }

        public bool ZoomIn(SVGControl svgControl)
        {
            if (Math.Round(svgControl.Scale, 1) > 0.1)
            {
                svgControl.Scale = Math.Round(svgControl.Scale, 1) - 0.1;
                return true;
            }
            return false;
        }

        public bool ZoomOut(SVGControl svgControl)
        {
            if (Math.Round(svgControl.Scale,1) < MaxScale)
            {
                svgControl.Scale = Math.Round(svgControl.Scale, 1) + 0.1;
                return true;
            }
            return false;
        }

        public void NewInput(string value, SVGControl svgControl)
        {
            var x = double.Parse(value);
            if (x > 3.49) x = 3.49;
            else if (x < 0.01) x = 0.01;
            svgControl.Scale = Math.Round(MaxScale - (x / 100), 2);
        }
    }
}
