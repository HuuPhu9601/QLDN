using QLDN.Models.BaseModels;
using System.Data;

namespace QLDN.Models.OrgUnitModels
{
    public class StaffExportExcel : ExportExcel
    {
        private readonly IObjectIO<OrgUnit> _org;

        public StaffExportExcel()
        {
            _org = OrgUnit.Ins;
        }
        public override void GetData(out DataTable table)
        {
            //Thực hiện lấy dữ liệu
            table = _org.GetAll();
        }

        public override void ColumnConfigure(DataTable table)
        {
            base.ColumnConfigure(table);

            //Cấu hính tên cột
            table.Columns["OrgUnitName"].ColumnName = "Name";
            table.Columns["ManagerName"].ColumnName = "Manager";
        }
    }
}