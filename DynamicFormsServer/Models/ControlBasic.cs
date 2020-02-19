using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public class ControlBasic //: IControl
    {

        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public ControlLabel Label { get; set; }
        public string ControlType { get; set; }
        public ControlStyle ControlStyle { get; set; }
        public DataSource DataSource { get; set; }
        public ValidatorConfig ValidatorConfig { get; set; }
        public Parameters Parameters { get; set; }
        public string InputType { get; set; }
        public Object BindingData { get; set; }


        public ControlBasic(int id, string label, string htmlClass, int orderNumber)
        {
            Id = id;
            OrderNumber = orderNumber;
            Label = new ControlLabel(label, id.ToString());
            DataSource = new DataSource();
            ControlStyle = new ControlStyle();
            ControlStyle.HtmlClass = htmlClass;
            ValidatorConfig = new ValidatorConfig();
            Parameters = new Parameters();

        }

    }
}
