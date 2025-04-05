using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using FastReport;
using FastReport.Export.PdfSimple;
using KhodalKrupaERP.Models;

namespace KhodalKrupaERP.Reports
{
    class ChallanReport
    {
        private ChallanInfo challanInfo;
        private Report report;

        public ChallanReport(ChallanInfo challanInfo)
        {
            this.challanInfo = challanInfo;
        }

        public void createReport()
        {
            try
            {
                // create report instance
                Report report = new Report();

                // load the existing report
                report.Load($@"{Environment.CurrentDirectory}\Report Design\report.frx"); // Load your designed invoice

                // register the dataset
                report.RegisterData(getDataSource());

                // prepare the report
                report.Prepare();

                this.report = report;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        public void savePdf()
        {
            try
            {
                if (this.report is null)
                    createReport();

                string storagePath = $@"{Environment.CurrentDirectory}\Invoices\Invoice_{this.challanInfo.CustomerName}_{this.challanInfo.DesignNo}.pdf";

                PDFSimpleExport pdfExport = new PDFSimpleExport();
                pdfExport.Export(this.report, storagePath);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private DataSet getDataSource()
        {
            try
            {
                // create simple dataset with one table
                DataSet dataSet = new DataSet();

                DataTable table = new DataTable();
                table.TableName = "Employees";
                dataSet.Tables.Add(table);

                string query = @"SELECT
                                    C.ChallanId,
                                    C.DesignNo,
                                    C2.Name,
                                    C2.PhoneNo,
                                    C1.Diamond,
                                    C1.Rate,
                                    C1.Paper,
                                    C1.Total
                                FROM
                                    `Challans` C
                                    INNER JOIN `ChallanTransactions` C1 ON C1.`ChallanId` = C.`ChallanId`
                                    INNER JOIN `Customers` C2 ON C2.`CustomerId` = C.`CustomerId`
                                where
                                    C.`ChallanId` = " + challanInfo.ChallanId;

                string connectionString = $@"Data Source={Environment.CurrentDirectory}\Database\KhodalKrupaDB.sqlite;Version=3;";
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, connectionString))
                {
                    dataAdapter.Fill(table);
                }

                return dataSet;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(),"Data source not created");
                return null;
            }
        }
    }
}
