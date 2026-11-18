using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using TaskDialog = Autodesk.Revit.UI.TaskDialog;

namespace ClassLibrary3
{
    [Transaction(TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();

            if (selectedIds.Count == 0)
            {
                TaskDialog.Show("Revit", "Bạn chưa chọn đối tượng nào.");
                return Result.Cancelled;
            }

            List<ElementId> selectedWallIds = new List<ElementId>();
            List<ElementId> selectedFloorIds = new List<ElementId>();
            List<ElementId> selectedColumnIds = new List<ElementId>();


            foreach (ElementId id in selectedIds)
            {
                Element elem = doc.GetElement(id);

                if (elem is Wall)
                {
                    selectedWallIds.Add(id);
                }
                else if (elem is Floor)
                {
                    selectedFloorIds.Add(id);
                }
                else if (elem.Category != null && elem.Category.Id.Value == (long)BuiltInCategory.OST_StructuralColumns)
                {
                    selectedColumnIds.Add(id);
                }
            }

            string resultMessage = $"Tổng số đối tượng đang chọn: {selectedIds.Count}\n" +
                                   $"- Tường (Wall): {selectedWallIds.Count}\n" +
                                   $"- Sàn (Floor): {selectedFloorIds.Count}\n" +
                                   $"- Cột kết cấu (Column): {selectedColumnIds.Count}";

            TaskDialog.Show("Revit", resultMessage);

            return Result.Succeeded;
        }
    }
}