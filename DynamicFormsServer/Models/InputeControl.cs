using DynamicFormsServer.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public class InputeControl : ControlBasic
    {
        public InputeControl(
            int id,
            string label,
            InputType inputType,
            string htmlClass,
            int orderNumber) : base(id, label, htmlClass, orderNumber)
        {
            base.InputType = inputType.ToString();
            base.ControlType = "input";
        }

    }
}
