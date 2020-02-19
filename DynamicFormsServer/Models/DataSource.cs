using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public class DataSource
    {
        public int Id { get; set; }
        public List<string> Data { get; set; }

        public Object SingleData { get; set; }

        public DataSource()

        {
            Data = new List<string>();
        }
    }
}
