using DynamicFormsServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.BL
{
    public class FormHelper
    {
        public static FormControlObject GetReportForm(int reportNumber)
        {
            switch (reportNumber)
            {
                case 1:
                    return new FormControlObject { Report = GetForm1() };
                case 2:
                    return new FormControlObject { Report = GetForm2() };
                case 3:
                    return new FormControlObject { Report = GetForm3() };

                default:
                    return new FormControlObject();
            }

        }
        public static DataSource FillDataSource(int id)
        {
            List<string> list = new List<string>();
            list.Add("cat");
            list.Add("camel");
            list.Add("horse");
            list.Add("dog");
            list.Add("elefant");
            DataSource dataSource = new DataSource { Data = list };
            dataSource.Id = id;
            return dataSource;
        }

        private static Report GetForm1()
        {
            Report report = new Report();
            report.Id = 1;
            report.Title = "Report 1";

            report.Controls.Add(GetSelectControl(1));
            report.Controls.Add(GetInputTextControl(2));
            report.Controls.Add(GetCheckboxControl(3));
            report.Controls.Add(GetMultipleSelectControl(4));
            report.Controls.Add(GetDatePickerControl(5,"Date From"));
            report.Controls.Add(GetDatePickerControl(6, "Date To"));
            report.Controls.Add(GetButtonControl(7, "Get Report", ButtonColor.Success));
            return report;
        }

        private static Report GetForm2()
        {
            Report report = new Report();
            report.Id = 2;
            report.Title = "Report 2";

            report.Controls.Add(GetSelectControl(1));
            report.Controls.Add(GetInputTextControl(2));
            report.Controls.Add(GetCheckboxControl(3));
            report.Controls.Add(GetMultipleSelectControl(4));
            report.Controls.Add(GetButtonControl(5,"Stam Button",ButtonColor.Warning));
            report.Controls.Add(GetInputTextControl(6));
            report.Controls.Add(GetMultipleSelectControl(7));
            report.Controls.Add(GetButtonControl(8, "Get Report", ButtonColor.Success));
            return report;
        }

        private static Report GetForm3()
        {
            Report report = new Report();
            report.Id = 3;
            report.Title = "Report 3";

            report.Controls.Add(GetMultipleSelectControl(1));
            report.Controls.Add(GetSelectControl(2));
            report.Controls.Add(GetInputTextControl(3));
            report.Controls.Add(GetCheckboxControl(4));
            report.Controls.Add(GetSelectControl(5));
            report.Controls.Add(GetMultipleSelectControl(6));
            report.Controls.Add(GetButtonControl(7, "Stam Button Plus", ButtonColor.Dark));
            report.Controls.Add(GetInputTextControl(8));
            report.Controls.Add(GetInputTextControl(9));
            report.Controls.Add(GetInputTextControl(10));
            report.Controls.Add(GetButtonControl(11, "Get Report", ButtonColor.Secondary,101));
            return report;
        }

        #region GetControls
        private static SelectControl GetSelectControl(int id)
        {
            string controlClass = "form-control";
            var control = new SelectControl(id, "select", controlClass);
            control.DataSource = FillDataSource(1);
            control.ValidatorConfig.IsNeedValidation = true;
            control.ValidatorConfig.IsRequired = true;
            control.ControlStyle.ContainerBorderStyle = "border border-warning rounded";
            return control;
        }
        private static SelectControl GetMultipleSelectControl(int id)
        {
            string controlClass = "form-control";
            var control = new SelectControl(id, "multiple select", controlClass);
            control.DataSource = FillDataSource(1);
            control.Parameters.ParamDictionary.Add("multiple", "true");
            control.ValidatorConfig.IsNeedValidation = true;
            control.ValidatorConfig.IsRequired = true;
            control.ControlStyle.Width = 100;
            control.ControlStyle.ContainerBorderStyle = "border border-warning rounded";
            return control;
        }
        private static InputeControl GetInputTextControl(int id)
        {
            string controlClass = "form-control";
            var control = new InputeControl(id, "input text", "text", controlClass);
            control.DataSource.SingleData = (object)"input text";
            control.ValidatorConfig.IsNeedValidation = true;
            control.ValidatorConfig.IsRequired = true;
            control.ControlStyle.ContainerBorderStyle = "border border-warning rounded";
            return control;
        }
        private static InputeControl GetCheckboxControl(int id)
        {
            string controlClass = "form-control";
            var control = new InputeControl(id, "checkbox", "checkbox", controlClass);
            control.ControlStyle.Width = 15;
            control.ControlStyle.Height = 15;
            control.ValidatorConfig.IsNeedValidation = true;
            control.ValidatorConfig.IsRequired = true;
            control.ControlStyle.ContainerBorderStyle = "border border-warning rounded";
            return control;
        }
        private static InputeControl GetButtonControl(int id,string buttonContent,ButtonColor buttonColor,int buttonWith = 0)
        {
            string controlClass = "form-control "+ GetButtonClassByEnum(buttonColor);
            var control = new InputeControl(id, "", "button", controlClass);
            control.DataSource.SingleData = (object)buttonContent;
            control.ValidatorConfig.IsRequired = false;
            control.Label = null;
            if (buttonWith > 0) control.ControlStyle.Width = buttonWith;
            return control;
        }
        private static DatePickerControl GetDatePickerControl(int id,string label)
        {
            string controlClass = "form-control ";
            var control = new DatePickerControl(id, label, controlClass);
            return control;
        }
        #endregion

        private static string GetButtonClassByEnum(ButtonColor buttonColor)
        {
            switch (buttonColor)
            {
                case ButtonColor.Primary:
                    return "btn btn-primary";
                case ButtonColor.Secondary:
                    return "btn btn-secondary";
                case ButtonColor.Success:
                    return "btn btn-success";
                case ButtonColor.Danger:
                    return "btn btn-danger";
                case ButtonColor.Warning:
                    return "btn btn-warning";
                case ButtonColor.Info:
                    return "btn btn-info";
                case ButtonColor.Light:
                    return "btn btn-light";
                case ButtonColor.Dark:
                    return "btn btn-dark";
                default:
                    return "";
            }
        }

    }
    public enum ButtonColor
    {
        Primary = 1,
        Secondary,
        Success,
        Danger ,
        Warning,
        Info,
        Light,
        Dark
    }
}
