using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public class SelectControl : ControlBasic
    {
        public SelectControl(
            int id,
            string label,
            string htmlClass,
            int orderNumber) : base(id, label, htmlClass, orderNumber)
        {
            base.ControlType = "select";

            var optionList = new List<string>();
            optionList.Add("option 1");
            optionList.Add("option 2");
            optionList.Add("option 3");

            base.DataSource = new DataSource { Data = optionList };
        }

    }
}
