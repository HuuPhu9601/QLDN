using QLDN.Models.BaseModels;
using System.Data;

namespace QLDN.Models.OrgUnitModels
{
    public class OrgReport : BaseReportTemplate
    {
        private readonly IObjectIO<OrgUnit> _org;

        public OrgReport()
        {
            _org = OrgUnit.Ins;
        }

        public override void GetData(out DataTable table)
        {
            //Thực hiện lấy dữ liệu chung
            base.GetData(out table);

            table = _org.GetAll();
        }

        public override void SetTemplateReport(DataTable table)
        {
            base.SetTemplateReport(table);

            //Tạo ra template và gán dữ liệu datatable vào để lên 1 form báo cáo
        }
    }
}