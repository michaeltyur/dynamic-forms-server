using DynamicFormsServer.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public interface IControl
    {
        int Id { get; set; }
        int OrderNumber { get; set; }
        ControlLabel Label { get; set; }
        string ControlType { get; set; }
        ControlStyle ControlStyle { get; set; }
        DataSource DataSource { get; set; }
        ValidatorConfig ValidatorConfig { get; set; }
        Parameters Parameters { get; set; }
        string InputType { get; set; }
    }


    public class FormControlObject
    {
        public Report Report { get; set; }
        public FormControlObject()
        {
            Report = new Report();
        }
    }

}

public enum ControlTypeEnum
{
    input = 1,
    select,
    datepicker
}

public enum ButtonColor
{
    Primary = 1,
    Secondary,
    Success,
    Danger,
    Warning,
    Info,
    Light,
    Dark
}
public enum InputType
{
    submit = 1,
    button,
    checkbox,
    date,
    email,
    file,
    number,
    password,
    text,
    time,
    datepicker
}
