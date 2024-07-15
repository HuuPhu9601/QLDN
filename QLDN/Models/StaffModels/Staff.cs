using QLDN.Models.StaffModels;
using System.Collections.Generic;
using System.Data;

namespace QLDN.Models
{
    //Thực hiện nguyên tắc số 1: "Nguyên tắc trách nhiệm đơn lẻ" cho model đơn vị để làm rõ trách nhiệm của model
    //Thực hiện nguyên tắc số 2: "Nguyên tắc đóng/ mở" cho model đơn vị để thực hiện CRUD cho cho model
    public class Staff : IStaff
    {
        private static Staff _ins;
        public static Staff Ins { get { if (_ins == null) _ins = new Staff(); return _ins; } set { _ins = value; } }
        public int StaffID { get; set; }

        public int ManagerID { get; set; }

        public int JobPositionID { get; set; }

        public string StaffName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int StatusID { get; set; }

        public Manager Manager { get; set; }

        public ICollection<OrgUnitStaff> OrgUnitStaffs { get; set; }

        public Staff()
        {
            StatusID = StatusType.Acctive;
        }

        #region Nhân viên
        public override void AssignMultiStaffToAOrgUnit()
        {
            //Thực hiện thêm nhiều nhân viên vào một đơn vị
        }

        public override void AssignStaffToMultiOrgUnit()
        {
            //Thêm một nhân viên vào nhiều đơn vị
        }

        public override void MoveStaffToAOtherOrgUnit()
        {
            //Điều chuyển nhân viên từ đơn vị này sang đơn vị khác
        }

        public void AssignStaffToAManager()
        {
            //Thêm nhân viên cho một quản lý
        }
        public List<Staff> GetOtherStaffOfStaff()
        {
            //Lấy ra danh sách đồng nghiệp của nhân viên
            return new List<Staff>();
        }

        public bool CheckExistedStaffInAOrgUnit()
        {
            //Kiểm tra nhân viên đã có trong đơn vị chưa?
            return true;
        }

        public bool HasManagerOfStaff()
        {
            //Kiểm tra nhân viên đã có quản lý chưa?
            return true;
        }

        public List<Staff> GetStaffOfOrgUnit()
        {
            //Lấy ra danh sách nhân viên của một đơn vị
            return new List<Staff>();
        }

        public List<Staff> GetStaffsOfManager()
        {
            //Lấy ra danh sách nhân viên của một manager
            return new List<Staff>();
        }
        #endregion

        #region CRUD
        public DataTable GetAll()
        {
            return new DataTable();
        }

        public Staff GetOne(int id)
        {
            return new Staff();
        }

        public string Insert(Staff obj)
        {
            return string.Empty;
        }

        public string Update(Staff obj)
        {
            return string.Empty;
        }

        public string Delete(Staff obj)
        {
            return string.Empty;
        }
        #endregion
    }
}