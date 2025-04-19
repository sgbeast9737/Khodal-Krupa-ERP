using FastReport;
using FastReport.Export.PdfSimple;
using KhodalKrupaERP.Core;
using System;
using System.Data;
using System.Data.SQLite;

namespace KhodalKrupaERP.Reports
{
    class CustomerChallanTransactionReport : BaseReport
    {
        private string designFilePath = $@"{Environment.CurrentDirectory}\Report Design\Monthly_invoice.frx"; // Load your designed invoice
        private int customerId;
        DateTime fromDate, toDate;

        public CustomerChallanTransactionReport(int customerId, DateTime fromDate, DateTime toDate)
        {
            this.customerId = customerId;
            this.fromDate = fromDate;
            this.toDate = toDate;
        }

        public void savePdf()
        {
            Report report = createReport(this.designFilePath, getDataSource());

            report.SetParameterValue("FromDate", fromDate.ToString("yyyy-MM-dd"));
            report.SetParameterValue("ToDate", toDate.ToString("yyyy-MM-dd"));

            string timestamp = DateTime.Now.ToString("dd_MM_yyyy_(HH_mm_ss)");
            string fileName = $"Monthly_{this.customerId}_invoice_{timestamp}.pdf";

            string storagePath = $@"{Environment.CurrentDirectory}\Invoices\Monthly_invoice\{fileName}";

            savePdf(report,storagePath);
        }

        private DataSet getDataSource()
        {

            // create simple dataset with one table
            DataSet dataSet = new DataSet();

            DataTable table = new DataTable();
            table.TableName = "Employees";
            dataSet.Tables.Add(table);

            string query = $@"SELECT 
	                    cus.CustomerId,
                        cus.PhoneNo,
                        cus.Name,
                        s.Name as `ServiceName`,
	                    trans.*
                    FROM
	                    ChallanTransactions trans
	                    LEFT JOIN Challans c ON c.ChallanId = trans.ChallanId
	                    LEFT JOIN Services s ON s.ServiceId = trans.ServiceId
	                    LEFT JOIN Customers cus ON c.CustomerId = cus.CustomerId
                    WHERE
                        1 = 1
	                    AND c.CustomerId = {customerId}  
                        AND Date(c.ChallanDate) BETWEEN '{fromDate.ToString("yyyy-MM-dd")}' AND '{toDate.ToString("yyyy-MM-dd")}' 
                    ORDER BY c.ChallanDate DESC";

            string connectionString = $@"Data Source={Environment.CurrentDirectory}\Database\KhodalKrupaDB.sqlite;Version=3;";
            using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, connectionString))
            {
                dataAdapter.Fill(table);
            }

            return dataSet;
        }
    }
}