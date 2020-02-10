using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.Models
{
    public interface IControl
    {
        int Id { get; set; }
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

    public class Report
    {
        public int Id { get; set; }
        public string FetchDataUrl { get; set; }
        public string Title { get; set; }
        public string RDL { get; set; }
        public List<IControl> Controls { get; set; }
        public Report()
        {
            Controls = new List<IControl>();
        }
    }
    public class ControlBasic : IControl
    {

        public int Id { get; set; }
        public ControlLabel Label { get; set; }
        public string ControlType { get; set; }
        public ControlStyle ControlStyle { get; set; }
        public DataSource DataSource { get; set; }
        public ValidatorConfig ValidatorConfig { get; set; }
        public Parameters Parameters { get; set; }
        public string InputType { get; set; }

        public ControlBasic(int id, string label, string htmlClass)
        {
            Id = id;
            Label = new ControlLabel(label, id.ToString());
            DataSource = new DataSource();
            ControlStyle = new ControlStyle();
            ControlStyle.HtmlClass = htmlClass;
            ValidatorConfig = new ValidatorConfig();
            Parameters = new Parameters();
        }

    }

    public class InputeControl : ControlBasic
    {
        public InputeControl(
            int id,
            string label,
            string inputType,
            string htmlClass) : base(id, label, htmlClass)
        {
            base.InputType = inputType;
            base.ControlType = "input";
        }

    }

    public class SelectControl : ControlBasic
    {
        public SelectControl(
            int id,
            string label,
            string htmlClass) : base(id, label, htmlClass)
        {
            base.ControlType = "select";

            var optionList = new List<string>();
            optionList.Add("option 1");
            optionList.Add("option 2");
            optionList.Add("option 3");

            base.DataSource = new DataSource { Data = optionList };
        }

    }

    public class DatePickerControl : ControlBasic
    {
        public DatePickerControl(int id,string label,string htmlClass) : base(id, label, htmlClass)
        {
            base.ControlType = ControlTypeEnum.datepicker.ToString();
        }
    }

    public class ControlStyle
    {
        public string HtmlClass { get; set; }
        public string FontColor { get; set; }
        public string BackgroundColor { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ContainerBorderStyle { get; set; }
        public int ContainerWidth { get; set; }

        public ControlStyle()
        {
            ContainerWidth = 20;
            Width = -1;
            Height = -1;
        }

    }

    public class ControlLabel
    {
        public string LabelName { get; set; }
        public string ForControl { get; set; }
        public ControlLabel(string label, string forControl)
        {
            LabelName = label;
            ForControl = forControl;
        }
    }

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

    public class Parameters
    {
        public string Id { get; set; }
        public IDictionary<string, string> ParamDictionary { get; set; }
        public Parameters()
        {
            ParamDictionary = new Dictionary<string, string>();
        }
    }

    public class Content
    {
        public string DataSource { get; set; }
        public string DisplayColumn { get; set; }
        public string OrderColumn { get; set; }
        public string Table { get; set; }
    }

    public class ValidatorConfig
    {
        public string CompareTo { get; set; }
        public string Restriction { get; set; }
        public bool IsNeedValidation { get; set; }
        public bool IsRequired { get; set; }

    }

}

public enum ControlTypeEnum
{
    input =1,
    select ,
    datepicker
}
