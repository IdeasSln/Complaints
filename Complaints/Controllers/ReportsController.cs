using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.IO;
using System.Web.Mvc;
namespace Complaints.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
       [HttpGet]
        public FileStreamResult PrintReport(int  RptId)
        {

            DataTable dtReport = SQLFUNC.GetIncidentReport(RptId);
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/ProjectReports"), "CrystalReport1.rpt"));
            rd.SetDataSource(dtReport);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "IncidentReport.pdf");
        }
       
    }
}