using System.Data;

namespace QLDN.Models.BaseModels
{
    public interface IReportGenerator
    {
        void GetData(out DataTable table);

        void SetTemplateReport(DataTable table);
        void ReportGenerator(DataTable table);
    }
}