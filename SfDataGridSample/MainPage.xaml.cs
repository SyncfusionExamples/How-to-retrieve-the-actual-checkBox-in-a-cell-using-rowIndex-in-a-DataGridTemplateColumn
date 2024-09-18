using Microsoft.Maui.Controls;
using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.Themes;
using System.Reflection;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            GetCellContent(2, "EmployeeStatus");
        }

        View? GetCellContent(int rowIndex, string mappingName)
        {
            var row = dataGrid.GetRowGenerator().Items?.FirstOrDefault(item => item.RowIndex == rowIndex);

            if (row != null)
            {
                var columns = row.GetType().GetRuntimeProperties().FirstOrDefault(data => data.Name.Equals("VisibleColumns"))?.GetValue(row) as List<DataColumnBase>;
                if (columns != null)
                {
                    var column = columns.FirstOrDefault(column => column.DataGridColumn != null && column.DataGridColumn.MappingName.Equals(mappingName));
                    if (column != null)
                    {
                        return column.ColumnElement?.Content;
                    }
                }
            }

            return null;
        }
    }
}
