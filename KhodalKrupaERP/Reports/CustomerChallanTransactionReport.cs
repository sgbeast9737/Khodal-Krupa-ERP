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
        private string designFilePath = $@"{Environment.CurrentDirectory}\Report Design\transaction_test.frx"; // Load your designed invoice
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
            DataSet dataSet = getDataSource();
            createReport(this.designFilePath, dataSet);

            this.report.SetParameterValue("FromDate", fromDate.ToString("yyyy-MM-dd"));
            this.report.SetParameterValue("ToDate", toDate.ToString("yyyy-MM-dd"));

            string storagePath = $@"{Environment.CurrentDirectory}\Invoices\Customer_challan_Invoice_{this.customerId}_{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}_({DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}).pdf";

            savePdf(dataSet,designFilePath,storagePath);
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
