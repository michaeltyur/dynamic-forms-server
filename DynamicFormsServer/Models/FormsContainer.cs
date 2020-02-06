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
        string Type { get; set; }
        ControlStyle ControlStyle { get; set; }
        DataSource DataSource { get; set; }
        ValidatorConfig ValidatorConfig { get; set; }
        Parameters Parameters { get; set; }
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
        public string Title { get; set; }
        public string RDL { get; set; }
        public List<IControl> Controls { get; set; }
        public Report()
        {
            Controls = new List<IControl>();

            string controlClass = "form-control";
            Controls.Add(new SelectControl(1, "select", controlClass));
            Controls.Add(new InputeControl(2, "input","text", controlClass));
            Controls.Add(new CheckBoxControl(3, "checkbox", controlClass));
            Id = 2;
            Title = "Report Title";
        }
    }
    public class ControlBasic : IControl
    {

        public int Id { get; set; }
        public string Type { get; set; }

        public ControlStyle ControlStyle { get; set; }
        public DataSource DataSource { get; set; }
        public ValidatorConfig ValidatorConfig { get; set; }
        public Parameters Parameters { get; set; }
        public ControlLabel Label { get; set; }
        public string ControlType { get; set; }

        public ControlBasic(int id, string label, string htmlClass)
        {
            Id = id;
            Label = new ControlLabel( label,id.ToString());
            DataSource = new DataSource(null);
            ControlStyle = new ControlStyle();
            ControlStyle.HtmlClass = htmlClass;
            ValidatorConfig = new ValidatorConfig();
            Parameters = new Parameters();
        }

    }


    public class InputeControl : ControlBasic
    {
        public string InputType { get; set; }

        public InputeControl(
            int id,
            string label,
            string inputType,
            string htmlClass) : base(id, label, htmlClass) 
        {
            InputType = inputType;
            base.ControlType = "input";
        }

    }
    public class SelectControl : ControlBasic
    {
        public SelectControl(
            int id,
            string label,
            string htmlClass) : base(id,label, htmlClass) {
            base.ControlType = "select";
        }

    }
    public class CheckBoxControl : ControlBasic
    {
        public CheckBoxControl(
             int id,
            string label,
            string htmlClass) : base(id, label, htmlClass) {
            base.ControlType = "checkbox";
        }

    }

    public class ControlStyle
    {
        public string HtmlClass { get; set; }
        public string FontColor { get; set; }
        public string BackgroundColor { get; set; }

    }

    public class ControlLabel
    {
        public string Label { get; set; }
        public string For { get; set; }
        public ControlLabel(string label,string forControl)
        {
            Label = label;
            For = forControl;
        }
    }


    public class DataSource
    {
        public string Id { get; set; }
        public List<object> Data { get; set; }
        public DataSource(object[] data)
        {
            if (data == null)
                Data = new List<object>();
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
        public string displayColumn { get; set; }
        public string orderColumn { get; set; }
        public string table { get; set; }
    }



    public class ValidatorConfig
    {
        public string CompareTo { get; set; }
        public string Restriction { get; set; }

        public bool IsRequired { get; set; }
        public ValidatorConfig()
        {
            IsRequired = true;
        }
    }

}
