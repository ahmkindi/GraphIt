using Syncfusion.Blazor.Navigations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.models
{
    public class ContextMenus
    {
        public List<MenuItem> NodeItems { get; set; } = new List<MenuItem>
        {
            new MenuItem{Text="Edit"},
            new MenuItem{Text="Delete"},
            new MenuItem{Text="Insert Edge"}
        };
        public List<MenuItem> CanvasItems { get; set; } = new List<MenuItem>
        {
            new MenuItem{Text="Insert Node"},
            new MenuItem{Text="Zoom In"},
            new MenuItem{Text="Zoom Out"}
        };
        public List<MenuItem> EdgeItems { get; set; } = new List<MenuItem>
        {
            new MenuItem{Text="Edit"},
            new MenuItem{Text="Delete"}
        };
        public SfContextMenu<MenuItem> NodeMenu;
        public SfContextMenu<MenuItem> CanvasMenu;
        public SfContextMenu<MenuItem> EdgeMenu;
    }
}
