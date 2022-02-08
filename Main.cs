using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitAPITrainingRibbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Моя вкладка";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\RevitAPITraining\";

            var panel = application.CreateRibbonPanel(tabName, "Инструменты");

            var button = new PushButtonData("1", "Смена типа стен",
                Path.Combine(utilsFolderPath, "RevitAPI_App5_2.dll"),
                "RevitAPI_App5_2.Main");

            Uri uriImage = new Uri(@"C:\RevitAPITraining\RevitAPITrainingRibbon\Images\2.png", UriKind.Absolute);
            BitmapImage largeImage = new BitmapImage(uriImage);
            button.LargeImage = largeImage;

            panel.AddItem(button);

            var button2 = new PushButtonData("2", "Количество и объем",
                         Path.Combine(utilsFolderPath, "Task_5_1.dll"),
                         "App5_1.Main");

            Uri uriImage2 = new Uri(@"C:\RevitAPITraining\RevitAPITrainingRibbon\Images\1.png", UriKind.Absolute);
            BitmapImage largeImage2 = new BitmapImage(uriImage2);
            button2.LargeImage = largeImage2;

            panel.AddItem(button2);

            return Result.Succeeded;
        }


    }
}
