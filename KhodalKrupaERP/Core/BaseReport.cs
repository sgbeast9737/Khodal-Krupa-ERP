using FastReport;
using FastReport.Export.PdfSimple;
using System.Data;

namespace KhodalKrupaERP.Core
{
    class BaseReport
    {
        protected Report createReport(string designFilePath,DataSet dataSet)
        {
            // create report instance
            Report report = new Report();

            // load the existing report
            report.Load(designFilePath); // Load your designed invoice

            // register the dataset
            report.RegisterData(dataSet);

            // prepare the report
            report.Prepare();

            return report;
        }

        protected void savePdf(DataSet dataSet, string designFilePath, string storagePath)
        {
            Report report = createReport(designFilePath,dataSet);

            PDFSimpleExport pdfExport = new PDFSimpleExport();
            pdfExport.Export(report, storagePath);
        }

        protected void savePdf(Report report, string storagePath)
        {
            PDFSimpleExport pdfExport = new PDFSimpleExport();
            pdfExport.Export(report, storagePath);
        }
    }
}
