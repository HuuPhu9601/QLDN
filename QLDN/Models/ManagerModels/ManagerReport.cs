using QLDN.Models.BaseModels;
using System.Data;

namespace QLDN.Models.ManagerModels
{
    public class ManagerReport : BaseReportTemplate
    {
        private readonly IObjectIO<Manager> _manager;

        public ManagerReport()
        {
            _manager = Manager.Ins;
        }

        public override void GetData(out DataTable table)
        {
            //Thực hiện lấy dữ liệu chung
            base.GetData(out table);

            table = _manager.GetAll();
        }

        public override void SetTemplateReport(DataTable table)
        {
            base.SetTemplateReport(table);

            //Tạo ra template và gán dữ liệu datatable vào để lên 1 form báo cáo
        }
    }
}