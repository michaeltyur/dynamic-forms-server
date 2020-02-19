using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public class Content
    {
        public string DataSource { get; set; }
        public string DisplayColumn { get; set; }
        public string OrderColumn { get; set; }
        public string Table { get; set; }
    }
}
