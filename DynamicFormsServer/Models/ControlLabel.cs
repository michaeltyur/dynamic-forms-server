using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public class ControlLabel
    {
        public string LabelName { get; set; }
        public string ForControl { get; set; }
        public ControlLabel(string label, string forControl)
        {
            LabelName = label;
            ForControl = forControl;
        }
    }
}
