using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;
using System.Windows;

namespace ClassLibrary2
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        
        
            public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
            {
                //bài 1
                // MessageBox.Show("chill ");
                //for(int i=0;i<6; i++)
                // {
                //     MessageBox.Show(i.ToString());
                // }
                // return Result.Succeeded;


                {

                    //bài 2
                    //UIDocument uIDocument = commandData.Application.ActiveUIDocument;
                    //ICollection<ElementId> selectedIds = uIDocument.Selection.GetElementIds();
                    //int totalCount= selectedIds.Count;
                    //MessageBox.Show(" Bạn đã chọn mấy thg nguuu " + totalCount.ToString() + " elements");

                    //string IDList = "danh sách đối tượng:\n";

                    //foreach (ElementId id in selectedIds)
                    //{
                    //    IDList += id.ToString() + "\n";
                    //}

                    //MessageBox.Show(IDList);


                    //UIDocument uidoc = commandData.Application.ActiveUIDocument;
                    //XYZ point1 = uidoc.Selection.PickPoint();
                    //XYZ point2 = uidoc.Selection.PickPoint();
                    //XYZ point3 = uidoc.Selection.PickPoint();

                    //StringBuilder sb = new StringBuilder();
                    //sb.AppendLine("Point 1: " + point1.ToString());
                    //sb.AppendLine("Point 2: " + point2.ToString());
                    //sb.AppendLine("Point 3: " + point3.ToString());

                    //MessageBox.Show("mấy thg nu:\n" + sb.ToString());
                    //return Result.Succeeded;
                    UIDocument uidoc = commandData.Application.ActiveUIDocument;
                    IList<Reference> referencecollection = uidoc.Selection.PickObjects(ObjectType.Edge);
                    MessageBox.Show("selected total" + referencecollection.Count.ToString() + "edges.");
                    return Result.Succeeded;

                }

            }

        
    }
}
