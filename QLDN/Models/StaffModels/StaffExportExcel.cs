using QLDN.Models.BaseModels;
using System.Data;

namespace QLDN.Models.StaffModels
{
    public class StaffExportExcel : ExportExcel
    {
        private readonly IObjectIO<Staff> _staff;

        public StaffExportExcel()
        {
            _staff = Staff.Ins;
        }
        public override void GetData(out DataTable table)
        {
            //Thực hiện lấy dữ liệu
            table = _staff.GetAll();
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