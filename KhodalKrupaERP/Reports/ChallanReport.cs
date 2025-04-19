using System;
using System.Data;
using System.Data.SQLite;
using KhodalKrupaERP.Models.Analysis;
using KhodalKrupaERP.Core;

namespace KhodalKrupaERP.Reports
{
    class ChallanReport : BaseReport
    {
        private string designFilePath = $@"{Environment.CurrentDirectory}\Report Design\report.frx"; // Load your designed invoice
        private ChallanInfo challanInfo;

        public ChallanReport(ChallanInfo challanInfo)
        {
            this.challanInfo = challanInfo;
        }

        public void savePdf()
        {
            // load the existing report
            string timestamp = DateTime.Now.ToString("dd_MM_yyyy_(HH_mm_ss)");
            string fileName = $"Invoice_{challanInfo.DesignNo}_{challanInfo.CustomerName.Replace(" ","_")}_{timestamp}.pdf";

            string storagePath = $@"{Environment.CurrentDirectory}\Invoices\Challan_invoice\{fileName}";

            savePdf(getDataSource(), this.designFilePath, storagePath);
        }

        private DataSet getDataSource()
        {
            // create simple dataset with one table
            DataSet dataSet = new DataSet();

            DataTable table = new DataTable();
            table.TableName = "Employees";
            dataSet.Tables.Add(table);

            string query = @"SELECT
                                C.ChallanId,
                                trans.DesignNo,
                                ser.Name AS `ServiceName`,
                                cust.Name,
                                cust.PhoneNo,
                                trans.Diamond,
                                trans.Rate,
                                trans.Paper,
                                trans.Total
                            FROM
                                `Challans` C
                                INNER JOIN `ChallanTransactions` trans ON trans.`ChallanId` = C.`ChallanId`
                                INNER JOIN `Customers` cust ON cust.`CustomerId` = C.`CustomerId`
                                INNER JOIN `Services` ser ON ser.`ServiceId` = trans.`ServiceId`	
                            where
                                C.`ChallanId` = " + challanInfo.ChallanId;

            string connectionString = $@"Data Source={Environment.CurrentDirectory}\Database\KhodalKrupaDB.sqlite;Version=3;";
            using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, connectionString))
            {
                dataAdapter.Fill(table);
            }

            return dataSet;
        }
    }
}