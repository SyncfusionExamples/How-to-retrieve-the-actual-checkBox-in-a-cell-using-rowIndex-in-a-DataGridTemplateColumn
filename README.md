# How to retrieve the actual checkBox in a cell using rowIndex in a DataGridTemplateColumn?
In this article, we will show you how to retrieve the actual checkBox in a cell using rowIndex in a DataGridTemplateColumn in [.Net Maui DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid).

## xaml
```
<ContentPage.BindingContext>
    <local:EmployeeViewModel x:Name="viewModel"/>
</ContentPage.BindingContext>

<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="*"/>
        <RowDefinition Height="50"/>
    </Grid.RowDefinitions>

    <syncfusion:SfDataGrid x:Name="dataGrid"
                           GridLinesVisibility="Both"
                           HeaderGridLinesVisibility="Both"
                           ColumnWidthMode="Auto"
                           Grid.Row="0"
                           Grid.Column="0"
                           AutoGenerateColumnsMode="None"
                           ItemsSource="{Binding Employees}">

        <syncfusion:SfDataGrid.Columns>
        <syncfusion:DataGridTemplateColumn MappingName="EmployeeStatus"
                               HeaderText="EmployeeStatus">
            <syncfusion:DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <StackLayout>
                        <CheckBox IsChecked="{Binding EmployeeStatus}"
                            ></CheckBox>
                    </StackLayout>
                </DataTemplate>
            </syncfusion:DataGridTemplateColumn.CellTemplate>
        </syncfusion:DataGridTemplateColumn>
        <syncfusion:DataGridNumericColumn MappingName="EmployeeID"
                                              HeaderText="Employee ID"
                                              Format="#" />
            <syncfusion:DataGridTextColumn MappingName="Name"
                                           HeaderText="Employee Name" />
            <syncfusion:DataGridTextColumn MappingName="Title"
                                           HeaderText="Designation" />
            <syncfusion:DataGridDateColumn MappingName="HireDate"
                                           HeaderText="Hire Date" />

        </syncfusion:SfDataGrid.Columns>
    </syncfusion:SfDataGrid>
    <Button Clicked="Button_Clicked" 
            Grid.Row="1"
            Grid.Column="0"
            Text="Click"/>
</Grid>
```

## C#
The below code illustrates how to retrieve the actual checkBox in a cell using rowIndex in a DataGridTemplateColumn in DataGrid.
```
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
```
[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-retrieve-the-actual-checkBox-in-a-cell-using-rowIndex-in-a-DataGridTemplateColumn)

Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).
 
##### Conclusion
 
I hope you enjoyed learning about how to retrieve the actual checkBox in a cell using rowIndex in a DataGridTemplateColumn in .NET MAUI DataGrid (SfDataGrid).
 
You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.
 
If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!
  
