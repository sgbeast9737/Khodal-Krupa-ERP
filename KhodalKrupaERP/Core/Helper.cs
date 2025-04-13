using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhodalKrupaERP.Core
{
    class Helper
    {
        public static void hideColumn(SfDataGrid grid,params string[] columnNames)
        {
            foreach (string columnName in columnNames)
            {
                GridColumn column = grid.Columns[columnName];

                if (column != null)
                    column.Visible = false;
            }
        }

        public static void setAnalysisConfig(SfDataGrid dataGrid, bool showGroupDropArea = true)
        {
            dataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;

            //grouping setting
            dataGrid.ShowGroupDropArea = showGroupDropArea;
            dataGrid.AllowGrouping = true;

            //sorting setting
            dataGrid.AllowTriStateSorting = true;
            dataGrid.ShowSortNumbers = true;

            dataGrid.AllowDraggingColumns = true;
            dataGrid.AllowFiltering = true;

            dataGrid.AllowResizingColumns = true;

            dataGrid.AllowDeleting = false;
            dataGrid.AllowEditing = false;
        }

        public static void setDataInputConfig(SfDataGrid dataGrid,bool addNewRowBottom = true)
        {
            dataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            
            dataGrid.AllowEditing = true;
            dataGrid.AllowDeleting = true;

            dataGrid.AllowSorting = false;
            dataGrid.AddNewRowPosition = addNewRowBottom ? Syncfusion.WinForms.DataGrid.Enums.RowPosition.Bottom : Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
        } 

        public static void addGrouping(SfDataGrid dataGrid, params string[] columnNames)
        {
            dataGrid.ClearGrouping();
            foreach (string column  in columnNames)
            {
                dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription()
                {
                    ColumnName = column
                });
            }

            dataGrid.ExpandAllGroup();
        }

        public static void addSummary(SfDataGrid dataGrid, string columnName,string formate = "Grand Total: {Sum:C}")
        {
            GridTableSummaryRow summaryRow = new GridTableSummaryRow()
            {
                Name = "Total summary",
                ShowSummaryInRow = false,
                CalculationUnit = Syncfusion.Data.SummaryCalculationUnit.Mixed,
                Title = "Grand Total {ColumnName} : {Key}",
                TitleColumnCount = 1,
                SummaryColumns = new System.Collections.ObjectModel.ObservableCollection<ISummaryColumn>()
                {
                    new GridSummaryColumn()
                    {
                        MappingName= columnName,
                        Format= formate,
                        Name = columnName,
                        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate
                    }
                }
            };

            dataGrid.TableSummaryRows.Add(summaryRow);
        }

        //public static void addSummary(SfDataGrid dataGrid, string columnName,string formate = "Grand Total: {Sum:C}")
        //{
        //    GridTableSummaryRow summaryRow = new GridTableSummaryRow()
        //    {
        //        Name = "TableSummary",
        //        ShowSummaryInRow = false,
        //    };

        //    // Add Summary Column for "Total"
        //    summaryRow.SummaryColumns.Add(new GridSummaryColumn()
        //    {
        //        Name = columnName,
        //        MappingName = columnName,
        //        Format = formate,
        //        SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate
        //    });

        //    dataGrid.TableSummaryRows.Add(summaryRow);
        //}

        public static void addGroupSummary(SfDataGrid dataGrid,string columnName,string formate = "Total: {Sum:C}")
        {
            // Group Summary Row
            GridSummaryRow groupSummaryRow = new GridSummaryRow()
            {
                Name = "GroupSummary",
                ShowSummaryInRow = false
            };

            groupSummaryRow.SummaryColumns.Add(new GridSummaryColumn()
            {
                Name = columnName,
                MappingName = columnName,
                Format = formate,
                SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate
            });

            // Add the Summary Row to SFDataGrid
            dataGrid.GroupSummaryRows.Add(groupSummaryRow);
        }
    }
}
