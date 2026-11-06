using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;

namespace ClassLibrary1
{

        [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
        public class Class1 : IExternalCommand
        {
            public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
            {
                MessageBox.Show("Hello World"); return Result.Succeeded;
            }

        }
    
}
