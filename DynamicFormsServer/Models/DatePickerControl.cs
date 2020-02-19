using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public class DatePickerControl : ControlBasic
    {
        // public DateTime BindingData{ get; set; }
        public DatePickerControl(int id, string label, string htmlClass, int orderNumber) : base(id, label, htmlClass, orderNumber)
        {
            base.ControlType = ControlTypeEnum.datepicker.ToString();
        }
    }

}
