using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public class ValidatorConfig
    {
        public string CompareTo { get; set; }
        public string Restriction { get; set; }
        public bool IsNeedValidation { get; set; }
        public bool IsRequired { get; set; }
        public Dictionary<string, string> Params { get; set; }
        public ValidatorConfig()
        {
            Params = new Dictionary<string, string>();
        }

    }
}
