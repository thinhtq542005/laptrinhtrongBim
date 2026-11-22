using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary3
{
    // 1. Bổ sung khai báo Class và kế thừa IExternalCommand
    [Transaction(TransactionMode.Manual)]
    public class GetFramingParameters : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming);

            IList<Element> wallList = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();

            StringBuilder sb = new StringBuilder();
            foreach (Element wall in wallList) //for each wall
            {
                sb.AppendLine(wall.Name + "::" + wall.Id);
                foreach (Parameter para in wall.Parameters) //for each parameter
                {
                    sb.Append(this.getParameterInfomation(para, doc, ":")); //print parameter information
                    sb.AppendLine();
                }
                sb.AppendLine();
            }
            MessageBox.Show(sb.ToString());
            return Result.Succeeded;
        }
        private string getParameterInfomation(Parameter para, Document doc, string seperator)
        {
            string defName = para.Definition.Name;
            switch (para.StorageType)
            {
                case StorageType.Double: //if the parameter is a double, use AsValueString() to return the value
                    return defName + seperator + para.AsValueString();
                case StorageType.ElementId:
                    //if the parameter is a element id, its IntegerValue would be either a positive integer or -1
                    //-1 means an invalid element id
                    ElementId id = para.AsElementId();
                    if (id.IntegerValue >= 0) //if IntegerValue is not -1, we can get the parameter by Element.Name
                        return defName + seperator + doc.GetElement(id).Name;
                    else //if IntegerValue is -1, print -1 because it is an invalid ElementId
                        return defName + seperator + id.IntegerValue.ToString();
                //case StorageType.Integer: //if the parameter is an integer, it would be a boolean or an integer
                //    if (ParameterType.YesNo == para.Definition.ParameterType)//if it is a boolean (0 or 1)
                //    {
                //        //we must use true or false to represent the parameter instead of 0 or 1
                //        if (para.AsInteger() == 0)
                //            return defName + seperator + "False";
                //        else //para.AsInteger() == 1
                //            return defName + seperator + "True";
                //    }
                //    else //if it is an integer, just use AsInteger().ToString() to get the string value
                //    {
                //        return defName + seperator + para.AsInteger().ToString();
                //    }
                case StorageType.String: //if it is a string, we can return it by AsString()
                    return defName + seperator + para.AsString();
                default:
                    return "unknown parameter";
            }
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            //ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);
            ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_Walls);

            IList<Element> columnList = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();
            //StringBuilder output = new StringBuilder("Tất cả các Structural Column trong BIM model :"+columnList.Count()+"\r\n");
            StringBuilder output = new StringBuilder("Tất cả các Walls trong BIM model :" + columnList.Count() + "\r\n");

            foreach (Element e1 in columnList)
            {
                string elemName = e1.Id.ToString() + "\n";
                ElementType type = doc.GetElement(e1.GetTypeId()) as ElementType;
                AnalyticalModelColumn colLocatoin = e1.GetAnalyticalModel() as AnalyticalModelColumn;
                Parameter h1 = type.LookupParameter("Width");
                double hh1 = ChangeUnitFeetToMillimeter(h1.AsDouble());
                //Parameter b = type.LookupParameter("b");
                //double bb1 = ChangeUnitFeetToMillimeter(b.AsDouble());
                elemName = elemName + "Width = " + hh1.ToString() + "\n";
                //elemName = elemName + "b = " + bb1.ToString() + "\n";
                output.Append(elemName);
                output.AppendLine();
            }
            MessageBox.Show(output.ToString());
            return Result.Succeeded;
        }
        static double ChangeUnitFeetToMillimeter(double Value)
        {
            double value;
            value = Math.Round(UnitUtils.Convert(Value, DisplayUnitType.DUT_DECIMAL_FEET, DisplayUnitType.DUT_MILLIMETERS), 2);
            return value;
        }
    }
}