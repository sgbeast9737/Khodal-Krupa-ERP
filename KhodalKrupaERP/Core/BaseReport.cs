using FastReport;
using FastReport.Export.PdfSimple;
using System;
using System.Data;

namespace KhodalKrupaERP.Core
{
    class BaseReport
    {
        protected Report report;

        protected void createReport(string designFilePath,DataSet dataSet)
        {
            // create report instance
            Report report = new Report();

            // load the existing report
            report.Load(designFilePath); // Load your designed invoice

            // register the dataset
            report.RegisterData(dataSet);

            // prepare the report
            report.Prepare();
            this.report = report;
        }

        protected void savePdf(DataSet dataSet, string designFilePath, string storagePath)
        {
            if(this.report == null)
                createReport(designFilePath,dataSet);

            PDFSimpleExport pdfExport = new PDFSimpleExport();
            pdfExport.Export(this.report, storagePath);
        }
    }
}
