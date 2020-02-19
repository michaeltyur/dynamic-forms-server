using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public class ControlStyle
    {
        public string HtmlClass { get; set; }
        public string FontColor { get; set; }
        public string BackgroundColor { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ContainerBorderStyle { get; set; }
        public int ContainerWidth { get; set; }

        public ControlStyle()
        {
            ContainerWidth = 20;
            Width = -1;
            Height = -1;
        }

    }
}
