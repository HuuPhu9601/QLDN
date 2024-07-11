using QLDN.Models.BaseModels;
using System;
using System.Data;

namespace QLDN.Models.StaffModels
{
    public class StaffImportExcel : Excelmport
    {
        private IObjectIO<Staff> _staff;

        public StaffImportExcel()
        {
            _staff = Staff.Ins;
        }

        public override void ConvertDataTableToObjectType(DataTable dataTable)
        {
            base.ConvertDataTableToObjectType(dataTable);
            //Thực hiện gán dữ liệu
            var staff = SetStaff(dataTable);

            //lưu dữ liệu
            _staff.Insert(staff);
        }

        public Staff SetStaff(DataTable dataTable)
        {
            Staff staff = new Staff();
            staff.StaffName = dataTable.Columns["StaffName"].ToString();
            staff.Age = Convert.ToInt32(dataTable.Columns["Age"]);
            staff.Address = dataTable.Columns["Address"].ToString();
            return staff;
        }
    }
}