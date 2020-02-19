using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public class Relationship
    {
        public int ControlID { get; set; }
        public int FKControlID { get; set; }
        public List<RelationshipValue> FKValuesIDs;
        public Relationship()
        {
            FKValuesIDs = new List<RelationshipValue>();
        }

    }
    public class RelationshipValue
    {
        public int ControlValueID { get; set; }
        public int FKControlValueID { get; set; }
    }
}
