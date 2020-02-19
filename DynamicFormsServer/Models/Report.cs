using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string FetchDataUrl { get; set; }
        public string Title { get; set; }
        public string RDL { get; set; }
        public List<ControlBasic> Controls { get; set; }
        public List<Relationship> RelationshipsList { get; set; }
        public Report()
        {
            Controls = new List<ControlBasic>();
            RelationshipsList = new List<Relationship>();
        }
    }
}
