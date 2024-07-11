using QLDN.Models.BaseModels;
using System.Data;

namespace QLDN.Models.ManagerModels
{
    public class ManagerExportExcel : ExportExcel
    {
        private readonly IObjectIO<Manager> _manager;

        public ManagerExportExcel()
        {
            _manager = Manager.Ins;
        }
        public override void GetData(out DataTable table)
        {
            //Thực hiện lấy dữ liệu
            table = _manager.GetAll();
        }

        public override void ColumnConfigure(DataTable table)
        {
            base.ColumnConfigure(table);

            //Cấu hính tên cột
            table.Columns["ManagerName"].ColumnName = "Tên quản lý";
            table.Columns["Age"].ColumnName = "Tuổi";
            table.Columns["Address"].ColumnName = "Địa chỉ";
        }
    }
}