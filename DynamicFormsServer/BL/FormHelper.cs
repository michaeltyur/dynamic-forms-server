using DynamicFormsServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormsServer.BL
{
    public class FormHelper
    {
        public static Random Random = new Random();
        public static List<FormControlObject> FormControlObjectList { get; set; }

        public static FormControlObject GetReportForm(int reportId)
        {
            if (FormControlObjectList==null || FormControlObjectList.Count==0)
            {
                GetAllReportFormTitles();
            }

            foreach (var item in FormControlObjectList)
            {
                if (item.Report.Id == reportId)
                {
                    return item;
                }
            }
            return new FormControlObject();

        }
        public static List<string> GetAllReportFormTitles()
        {
            FormControlObjectList = new List<FormControlObject>();
            List<string> titleList = new List<string>();
            FormControlObjectList.Add(new FormControlObject { Report = GetForm1() });
            FormControlObjectList.Add(new FormControlObject { Report = GetForm2() });
            FormControlObjectList.Add(new FormControlObject { Report = GetForm3() });
            FormControlObjectList.Add(new FormControlObject { Report = GetForm4() });
            foreach (var item in FormControlObjectList)
            {
                titleList.Add(item.Report.Title);
            }
            return titleList;
        }
        public static DataSource FillDataSource(int id)
        {
            List<string> list = new List<string>();
            list.Add("Cat");
            list.Add("Camel");
            list.Add("Horse");
            list.Add("Dog");
            list.Add("Elefant");
            list.Add("Donkey");
            list.Add("Spaniel");
            list.Add("Crocodile");
            list.Add("Armadillo");
            list.Add("Heron");
            list.Add("Insect");
            list.Add("Goose");
            DataSource dataSource = new DataSource { Data = list };
            dataSource.Id = id;
            return dataSource;
        }
        public static DataSource FillDataSource2(int id)
        {
            List<string> list = new List<string>();
            list.Add("January");
            list.Add("February");
            list.Add("March");
            list.Add("April");
            list.Add("July");
            list.Add("August");
            list.Add("September");
            list.Add("October");
            list.Add("November");
            list.Add("December");
            DataSource dataSource = new DataSource { Data = list };
            dataSource.Id = id;
            return dataSource;
        }

        public static DataSource FillDataSource3(int id)
        {
            List<string> list = new List<string>();
            list.Add("Acura");
            list.Add("Alfa Romeo");
            list.Add("Aston Martin");
            list.Add("Infiniti");
            list.Add("Renault");
            list.Add("Jeep");
            list.Add("Peugeot");
            list.Add("Ford");
            list.Add("Suzuki");
            list.Add("Lexus");
            list.Add("Kia");
            list.Add("Volkswagen");
            list.Add("Volvo");
            list.Add("Toyota");
            list.Add("Mazda");
            DataSource dataSource = new DataSource { Data = list };
            dataSource.Id = id;
            return dataSource;
        }

        private static Report GetForm1()
        {
            Report report = new Report();
            report.Id = 1;
            report.Title = "Report " + report.Id;

            report.Controls.Add(GetSelectControl(1, 7, 1));
            report.Controls.Add(GetInputTextControl(2, 2));
            report.Controls.Add(GetCheckboxControl(3, 3));
            report.Controls.Add(GetMultipleSelectControl(4, 4));
            var from = GetDatePickerControl(5, 5, "Date From");
            report.Controls.Add(from);
            var to = GetDatePickerControl(6, 6, "Date To");
            to.ValidatorConfig.Params.Add("from", "5");
            to.ValidatorConfig.Params.Add("to", "6");
            report.Controls.Add(to);
            report.Controls.Add(GetButtonControl(7, 1, InputType.submit, "Get Report", ButtonColor.Success));
            return report;
        }

        private static Report GetForm2()
        {
            Report report = new Report();
            report.Id = 2;
            report.Title = "Report " + report.Id; ;

            report.Controls.Add(GetSelectControl(1, 1, 3));
            report.Controls.Add(GetInputTextControl(2, 2));
            report.Controls.Add(GetCheckboxControl(3, 2));
            report.Controls.Add(GetMultipleSelectControl(4, 2));
            report.Controls.Add(GetButtonControl(5, 5, InputType.button, "Stam Button", ButtonColor.Warning));
            report.Controls.Add(GetInputTextControl(6, 6));
            report.Controls.Add(GetMultipleSelectControl(7, 7));
            report.Controls.Add(GetButtonControl(8, 8, InputType.submit, "Get Report", ButtonColor.Success));
            return report;
        }

        private static Report GetForm3()
        {
            Report report = new Report();
            report.Id = 3;
            report.Title = "Report " + report.Id; ;

            report.Controls.Add(GetMultipleSelectControl(1, 11));
            report.Controls.Add(GetSelectControl(2, 2, 1));
            report.Controls.Add(GetInputTextControl(3, 3));
            report.Controls.Add(GetCheckboxControl(4, 4));
            report.Controls.Add(GetSelectControl(5, 5, 2));
            report.Controls.Add(GetMultipleSelectControl(6, 6));
            report.Controls.Add(GetButtonControl(7, 7, InputType.button, "Stam Button Plus", ButtonColor.Dark));
            report.Controls.Add(GetInputTextControl(8, 8));
            report.Controls.Add(GetInputTextControl(9, 9));
            report.Controls.Add(GetInputTextControl(10, 10));
            report.Controls.Add(GetButtonControl(11, 1, InputType.submit, "Get Report", ButtonColor.Secondary, 101));
            report.Controls.Add(GetDatePickerControl(12, 12, "Date"));
            return report;
        }

        private static Report GetForm4()
        {
            Report report = new Report();
            report.Id = 4;
            report.Title = "Report " + report.Id;
            List<SelectControl> selectsList = new List<SelectControl>();

            SelectControl selectControl1 = GetSelectControl(1, 1, 1);
            SelectControl selectControl2 = GetSelectControl(2, 2, 2);
            SelectControl selectControl3 = GetSelectControl(3, 3, 3);
            selectsList.Add(selectControl1);
            selectsList.Add(selectControl2);
            selectsList.Add(selectControl3);

            report.Controls.Add(selectControl1);
            report.Controls.Add(selectControl2);
            report.Controls.Add(selectControl3);
            report.Controls.Add(GetButtonControl(4, 4, InputType.submit, "Get Report", ButtonColor.Danger, 101));


            SetRelationships(report, selectsList);

            return report;
        }

        #region GetControls
        private static SelectControl GetSelectControl(int id, int orderNumber, int dataNumber)
        {
            string controlClass = "form-control";
            var control = new SelectControl(id, "select", controlClass, orderNumber);
            switch (dataNumber)
            {
                case 1:
                    control.DataSource = FillDataSource(1);
                    break;
                case 2:
                    control.DataSource = FillDataSource2(2);
                    break;
                case 3:
                    control.DataSource = FillDataSource3(3);
                    break;
                default:
                    control.DataSource = FillDataSource(1);
                    break;
            }

            control.ValidatorConfig.IsNeedValidation = true;
            control.ValidatorConfig.IsRequired = true;
            control.ControlStyle.ContainerBorderStyle = "border border-warning rounded";
            return control;
        }

        private static SelectControl GetMultipleSelectControl(int id, int orderNumber)
        {
            string controlClass = "form-control";
            var control = new SelectControl(id, "multiple select", controlClass, orderNumber);
            control.DataSource = FillDataSource2(2);
            control.Parameters.ParamDictionary.Add("multiple", "true");
            control.ValidatorConfig.IsNeedValidation = true;
            control.ValidatorConfig.IsRequired = true;
            control.ControlStyle.Width = 100;
            control.ControlStyle.ContainerBorderStyle = "border border-warning rounded";
            return control;
        }
        private static InputeControl GetInputTextControl(int id, int orderNumber)
        {
            string controlClass = "form-control";
            var control = new InputeControl(id, "input text", InputType.text, controlClass, orderNumber);
            control.DataSource.SingleData = (object)"input text";
            control.ValidatorConfig.IsNeedValidation = true;
            control.ValidatorConfig.IsRequired = true;
            control.ControlStyle.ContainerBorderStyle = "border border-warning rounded";
            return control;
        }
        private static InputeControl GetCheckboxControl(int id, int orderNumber)
        {
            string controlClass = "form-control";
            var control = new InputeControl(id, "checkbox", InputType.checkbox, controlClass, orderNumber);
            control.ControlStyle.Width = 15;
            control.ControlStyle.Height = 15;
            control.ValidatorConfig.IsNeedValidation = true;
            control.ValidatorConfig.IsRequired = true;
            control.ControlStyle.ContainerBorderStyle = "border border-warning rounded";
            return control;
        }
        private static InputeControl GetButtonControl(int id, int orderNumber, InputType inputType, string buttonContent, ButtonColor buttonColor, int buttonWith = 0)
        {
            string controlClass = "form-control " + GetButtonClassByEnum(buttonColor);
            var control = new InputeControl(id, "", inputType, controlClass, orderNumber);
            control.DataSource.SingleData = (object)buttonContent;
            control.ValidatorConfig.IsRequired = false;
            control.Label = null;
            if (buttonWith > 0) control.ControlStyle.Width = buttonWith;
            return control;
        }
        private static DatePickerControl GetDatePickerControl(int id, int orderNumber, string label)
        {
            string controlClass = "form-control ";
            var control = new DatePickerControl(id, label, controlClass, orderNumber);
            control.ControlStyle.ContainerBorderStyle = "border border-warning rounded";
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

        private static void SetRelationships(Report report, List<SelectControl> selectsList)
        {

            // Select 1 => select 2
            var relationShipsSelect1ToSelect2 = new Relationship();
            relationShipsSelect1ToSelect2.ControlID = 1;
            relationShipsSelect1ToSelect2.FKControlID = 2;
            relationShipsSelect1ToSelect2.FKValuesIDs = new List<RelationshipValue>
               {
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 2},
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 3 },
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 5 },
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 7},

                new RelationshipValue { ControlValueID = 2, FKControlValueID = 1 },
                new RelationshipValue { ControlValueID = 2, FKControlValueID = 2 },
                new RelationshipValue { ControlValueID = 2, FKControlValueID = 3 },

                new RelationshipValue { ControlValueID = 3, FKControlValueID = 8 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 9},
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 10 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 11 }
            };

            report.RelationshipsList.Add(relationShipsSelect1ToSelect2);

            // Select 1 => select 3
            var relationShipsSelect1ToSelect3 = new Relationship();
            relationShipsSelect1ToSelect3.ControlID = 1;
            relationShipsSelect1ToSelect3.FKControlID = 3;
            relationShipsSelect1ToSelect3.FKValuesIDs = new List<RelationshipValue>
               {
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 1},
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 4 },
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 5 },
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 10},

                new RelationshipValue { ControlValueID = 2, FKControlValueID = 8 },
                new RelationshipValue { ControlValueID = 2, FKControlValueID = 9 },
                new RelationshipValue { ControlValueID = 2, FKControlValueID = 10 },

                new RelationshipValue { ControlValueID = 3, FKControlValueID = 1 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 2 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 5 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 10 }
            };

            report.RelationshipsList.Add(relationShipsSelect1ToSelect3);


            // Select 2 => select 1
            var relationShipsSelect2ToSelect1 = new Relationship();
            relationShipsSelect2ToSelect1.ControlID = 2;
            relationShipsSelect2ToSelect1.FKControlID = 1;
            relationShipsSelect2ToSelect1.FKValuesIDs = new List<RelationshipValue>
               {
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 1},
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 4 },
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 5 },
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 10},

                new RelationshipValue { ControlValueID = 2, FKControlValueID = 8 },
                new RelationshipValue { ControlValueID = 2, FKControlValueID = 9 },
                new RelationshipValue { ControlValueID = 2, FKControlValueID = 10 },

                new RelationshipValue { ControlValueID = 3, FKControlValueID = 1 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 2 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 5 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 10 }
            };
            report.RelationshipsList.Add(relationShipsSelect2ToSelect1);

            // Select 2 => select 3
            var relationShipsSelect2ToSelect3 = new Relationship();
            relationShipsSelect2ToSelect3.ControlID = 2;
            relationShipsSelect2ToSelect3.FKControlID = 3;
            relationShipsSelect2ToSelect3.FKValuesIDs = new List<RelationshipValue>
               {
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 1},
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 4 },
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 5 },
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 10},

                new RelationshipValue { ControlValueID = 2, FKControlValueID = 8 },
                new RelationshipValue { ControlValueID = 2, FKControlValueID = 9 },
                new RelationshipValue { ControlValueID = 2, FKControlValueID = 10 },

                new RelationshipValue { ControlValueID = 3, FKControlValueID = 1 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 2 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 5 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 10 }
            };
            report.RelationshipsList.Add(relationShipsSelect2ToSelect3);

            // Select 3 => select 1
            var relationShipsSelect3ToSelect1 = new Relationship();
            relationShipsSelect3ToSelect1.ControlID = 3;
            relationShipsSelect3ToSelect1.FKControlID = 1;
            relationShipsSelect3ToSelect1.FKValuesIDs = new List<RelationshipValue>
               {
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 1},
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 4 },
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 5 },
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 10},

                new RelationshipValue { ControlValueID = 2, FKControlValueID = 8 },
                new RelationshipValue { ControlValueID = 2, FKControlValueID = 9 },
                new RelationshipValue { ControlValueID = 2, FKControlValueID = 10 },

                new RelationshipValue { ControlValueID = 3, FKControlValueID = 1 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 2 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 5 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 10 }
            };
            report.RelationshipsList.Add(relationShipsSelect3ToSelect1);

            // Select 3 => select 2
            var relationShipsSelect3ToSelect2 = new Relationship();
            relationShipsSelect3ToSelect2.ControlID = 3;
            relationShipsSelect3ToSelect2.FKControlID = 2;
            relationShipsSelect3ToSelect1.FKValuesIDs = new List<RelationshipValue>
               {
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 1},
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 7},
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 10 },
                new RelationshipValue { ControlValueID = 1, FKControlValueID = 11},

                new RelationshipValue { ControlValueID = 2, FKControlValueID = 1 },
                new RelationshipValue { ControlValueID = 2, FKControlValueID = 5 },
                new RelationshipValue { ControlValueID = 2, FKControlValueID = 11 },

                new RelationshipValue { ControlValueID = 3, FKControlValueID = 4 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 7 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 9 },
                new RelationshipValue { ControlValueID = 3, FKControlValueID = 10 }
            };
            report.RelationshipsList.Add(relationShipsSelect3ToSelect2);

        }
    }


}
