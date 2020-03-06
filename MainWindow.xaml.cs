using Syncfusion.UI.Xaml.Spreadsheet.Helpers;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DisableHeader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //Event Subscription
            spreadsheet.WorkbookLoaded += Spreadsheet_WorkbookLoaded;
            spreadsheet.Open("..\\..\\Data\\sample excel file.xlsx");
            this.spreadsheet.WorksheetAdded += Spreadsheet_WorksheetAdded;
        }
        //Event Customization
        private void Spreadsheet_WorksheetAdded(object sender, WorksheetAddedEventArgs args)
        {
            //To hide header cells visibility 
            spreadsheet.SetRowColumnHeadersVisibility(false);
        }
        private void Spreadsheet_WorkbookLoaded(object sender, WorkbookLoadedEventArgs args)
        {
            //To hide the Header cells visibility 

            foreach (var worksheet in spreadsheet.Workbook.Worksheets)
            {
                var grid = spreadsheet.GridCollection[worksheet.Name];
                grid.RowHeights.SetHidden(0, 0, true);
                grid.ColumnWidths.SetHidden(0, 0, true);
            }

        }
    }
}
