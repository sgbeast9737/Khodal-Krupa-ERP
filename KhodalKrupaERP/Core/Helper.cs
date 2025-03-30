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

        public static void setDefaultConfig(SfDataGrid dataGrid,bool addAnalysisTool = false)
        {
            dataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;

            if (addAnalysisTool)
            {
                dataGrid.ShowGroupDropArea = true;
                dataGrid.AllowGrouping = true;
                dataGrid.AllowSorting = true;
                dataGrid.AllowFiltering = true;

                dataGrid.AllowDeleting = false;
                dataGrid.AllowEditing = false;
            }
            else
            {
                dataGrid.AllowEditing = true;
                dataGrid.AllowDeleting = true;
            }
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
                Name = "TableSummary",
                ShowSummaryInRow = false,
            };

            // Add Summary Column for "Total"
            summaryRow.SummaryColumns.Add(new GridSummaryColumn()
            {
                Name = columnName,
                MappingName = columnName,
                Format = formate,
                SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate
            });

            dataGrid.TableSummaryRows.Add(summaryRow);
        }

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
