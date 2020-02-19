using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public class Parameters
    {
        public string Id { get; set; }
        public IDictionary<string, string> ParamDictionary { get; set; }
        public Parameters()
        {
            ParamDictionary = new Dictionary<string, string>();
        }
    }
}
