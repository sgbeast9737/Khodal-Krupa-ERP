using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KhodalKrupaERP.Forms
{
    public partial class Temp : Form
    {
        private SfDataGrid dataGrid;
        private TextBox searchBox;
        private Button searchButton;

        public Temp()
        {
            InitializeComponent();

            // Create DataGrid
            dataGrid = new SfDataGrid { Dock = DockStyle.Bottom, Height = 300 };
            dataGrid.DataSource = GetData();
            dataGrid.AllowSorting = true;
            dataGrid.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;
            this.Controls.Add(dataGrid);

            // Search Box
            searchBox = new TextBox { Dock = DockStyle.Top, Height = 30 };
            this.Controls.Add(searchBox);

            // Search Button
            searchButton = new Button { Text = "Search", Dock = DockStyle.Top };
            searchButton.Click += SearchButton_Click;
            this.Controls.Add(searchButton);
        }

        private void Temp_Load(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string keyword = searchBox.Text.ToLower();
            dataGrid.View.Filter = item =>
            {
                var data = item as Product;
                return data.Name.ToLower().Contains(keyword) || data.Price.ToString().Contains(keyword);
            };
            dataGrid.View.RefreshFilter();
        }

        private List<Product> GetData()
        {
            return new List<Product>
            {
                new Product { ID = 1, Name = "Laptop", Price = 800 },
                new Product { ID = 2, Name = "Mouse", Price = 20 },
                new Product { ID = 3, Name = "Keyboard", Price = 50 }
            };
        }
    }

    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}

//TODO : convert sfDataGrid data to excel code

//using Syncfusion.WinForms.DataGridConverter;

//private void ExportToExcel()
//{
//    var excelEngine = dataGrid.ExportToExcel(dataGrid.View, new ExcelExportingOptions());
//    excelEngine.SaveAs("DataGrid.xlsx");
//}

//using Syncfusion.WinForms.DataGridConverter;
//using Syncfusion.WinForms.DataGrid;
//using Syncfusion.XlsIO;
//using System;
//using System.Windows.Forms;

//public partial class Form1 : Form
//{
//    private SfDataGrid dataGrid;

//    public Form1()
//    {
//        InitializeComponent();

//        // Create DataGrid
//        dataGrid = new SfDataGrid { Dock = DockStyle.Fill };
//        dataGrid.DataSource = GetData();
//        this.Controls.Add(dataGrid);

//        // Export Button
//        Button exportButton = new Button { Text = "Export to Excel", Dock = DockStyle.Bottom };
//        exportButton.Click += ExportButton_Click;
//        this.Controls.Add(exportButton);
//    }

//    private void ExportButton_Click(object sender, EventArgs e)
//    {
//        using (var excelEngine = new ExcelEngine())
//        {
//            var application = excelEngine.Excel;
//            application.DefaultVersion = ExcelVersion.Excel2016;
//            var workbook = application.Workbooks.Create(1);
//            var sheet = workbook.Worksheets[0];

//            dataGrid.ExportToExcel(sheet);

//            workbook.SaveAs("DataGrid.xlsx");
//            MessageBox.Show("Exported to DataGrid.xlsx!");
//        }
//    }

//    private List<Product> GetData()
//    {
//        return new List<Product>
//        {
//            new Product { ID = 1, Name = "Laptop", Price = 800 },
//            new Product { ID = 2, Name = "Mouse", Price = 20 },
//            new Product { ID = 3, Name = "Keyboard", Price = 50 }
//        };
//    }
//}


//TODO : eager loading all required data at once (joins)

//using (var context = new SchoolContext())
//{
//    var students = context.Students
//                          .Include(s => s.Department)  // Join Student with Department
//                          .ToList();

//    foreach (var student in students)
//    {
//        Console.WriteLine($"Student: {student.Name}, Department: {student.Department.DepartmentName}");
//    }
//}

/*
 
    //TODO : Query Using LINQ Join (Explicit Join)
    using (var context = new SchoolContext())
{
    var studentsWithDepartments = from student in context.Students
                                  join dept in context.Departments
                                  on student.DepartmentId equals dept.Id
                                  select new
                                  {
                                      StudentName = student.Name,
                                      DepartmentName = dept.DepartmentName
                                  };

    foreach (var item in studentsWithDepartments)
    {
        Console.WriteLine($"Student: {item.StudentName}, Department: {item.DepartmentName}");
    }
}


    //TODO : Query Using Select() for Custom Objects
    using (var context = new SchoolContext())
{
    var students = context.Students
        .Select(s => new
        {
            s.Name,
            DepartmentName = s.Department.DepartmentName
        }).ToList();

    foreach (var student in students)
    {
        Console.WriteLine($"Student: {student.Name}, Department: {student.DepartmentName}");
    }
}

 


    //TODO : join example and set data to SFDataGrid

    using (var context = new SchoolContext())
{
    var studentsWithDepartments = (from student in context.Students
                                   join dept in context.Departments
                                   on student.DepartmentId equals dept.Id
                                   where student.Id == 1 // Filter condition
                                   select new
                                   {
                                       StudentName = student.Name,
                                       DepartmentName = dept.DepartmentName
                                   }).ToList();  // Convert to list

    sfDataGrid1.DataSource = studentsWithDepartments; // Bind to sfDataGrid
}


    //TODO : customer wise challan transaction retrive query

    public List<object> getCustomerChallanTransactions(int id)
{
    using (var db = new TestERPContext())
    {
        var custoerWiseChallanInfo = (from challanTransaction in db.ChallanTransactions
                                      join challan in db.Challans
                                      on challanTransaction.ChallanId equals challan.ChallanId
                                      where challan.CustomerId == id
                                      select new
                                      {
                                          challan.ChallanDate,
                                          CustomerName = challan.Customer.Name, // Named properly
                                          challan.DesignNo,
                                          challanTransaction.Diamond,
                                          challanTransaction.Rate,
                                          challanTransaction.Paper,
                                          challanTransaction.Total
                                      }).ToList();  // ✅ Execute query inside `using` block

        return custoerWiseChallanInfo.Cast<object>().ToList();  // Ensure return type compatibility
    }
}


    //TODO : how to add grouping to sf data grid

    // Enable Grouping in SFDataGrid
sfDataGrid1.AllowGrouping = true;

// Group by "CustomerId"
sfDataGrid1.GroupColumnDescriptions.Add(new GroupColumnDescription()
{
    ColumnName = "CustomerId"
});

    //TODO : how to add summary in sf Data grid

    // Create Summary Row
GridTableSummaryRow summaryRow = new GridTableSummaryRow()
{
    Name = "TableSummary",
    ShowSummaryInRow = true,
    Position = Syncfusion.WinForms.DataGrid.Enums.HorizontalPosition.Bottom
};

// Add Summary Column for "Total"
summaryRow.SummaryColumns.Add(new GridSummaryColumn()
{
    Name = "TotalSum",
    MappingName = "Total",
    Format = "Total: {Sum}",
    SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate
});

// Add the Summary Row to SFDataGrid
sfDataGrid1.TableSummaryRows.Add(summaryRow);

    //TODO : how to add group summary in sf data grid

    // Create Group Summary Row
GridSummaryRow groupSummaryRow = new GridSummaryRow()
{
    Name = "GroupSummary",
    ShowSummaryInRow = false
};

// Add Summary Column for "Total" in each group
groupSummaryRow.SummaryColumns.Add(new GridSummaryColumn()
{
    Name = "GroupTotal",
    MappingName = "Total",
    Format = "Group Total: {Sum}",
    SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate
});

// Add Group Summary to SFDataGrid
sfDataGrid1.GroupSummaryRows.Add(groupSummaryRow);


    //TODO : sf data grid analysis config (group,summary,group summary)

    // Enable Grouping
sfDataGrid1.AllowGrouping = true;
sfDataGrid1.GroupColumnDescriptions.Add(new GroupColumnDescription()
{
    ColumnName = "CustomerId"
});

// Table Summary Row
GridTableSummaryRow summaryRow = new GridTableSummaryRow()
{
    Name = "TableSummary",
    ShowSummaryInRow = true,
    Position = Syncfusion.WinForms.DataGrid.Enums.HorizontalPosition.Bottom
};
summaryRow.SummaryColumns.Add(new GridSummaryColumn()
{
    Name = "TotalSum",
    MappingName = "Total",
    Format = "Total: {Sum}",
    SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate
});
sfDataGrid1.TableSummaryRows.Add(summaryRow);

// Group Summary Row
GridSummaryRow groupSummaryRow = new GridSummaryRow()
{
    Name = "GroupSummary",
    ShowSummaryInRow = false
};
groupSummaryRow.SummaryColumns.Add(new GridSummaryColumn()
{
    Name = "GroupTotal",
    MappingName = "Total",
    Format = "Group Total: {Sum}",
    SummaryType = Syncfusion.Data.SummaryType.DoubleAggregate
});
sfDataGrid1.GroupSummaryRows.Add(groupSummaryRow);


*/
