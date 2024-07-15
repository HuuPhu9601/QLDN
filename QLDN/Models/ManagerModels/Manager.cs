using QLDN.Models.BaseModels;
using QLDN.Models.ManagerModels;
using System.Collections.Generic;
using System.Data;

namespace QLDN.Models
{
    //Thực hiện nguyên tắc số 1: "Nguyên tắc trách nhiệm đơn lẻ" cho model quản lý để làm rõ trách nhiệm của model
    //Thực hiện nguyên tắc số 2: "Nguyên tắc đóng/ mở" cho model quản lý để thực hiện CRUD cho cho model
    //Thực hiện nguyên tắc số 3: "Nguyên tắc thay thế liskow" cho model Manager để sử dụng đc các hàm base của abstract class "AssignStaffOrgUnit" và có thể ghi đè lại
    public class Manager : AssignStaffOrgUnit, IManager
    {
        private static Manager _ins;
        public static Manager Ins { get { if (_ins == null) _ins = new Manager(); return _ins; } set { _ins = value; } }
        public int ManagerID { get; set; }

        public string ManagerName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int StatusID { get; set; }

        public ICollection<Staff> Staffs { get; set; }

        public ICollection<OrgUnitManager> OrgManagers { get; set; }

        public Manager()
        {
            StatusID = StatusType.Acctive;
        }

        #region Quản lý
        public override void AddJobPosition()
        {
            base.AddJobPosition();//thêm vị trí công việc
        }

        public override bool CheckMaxQtyStaff()
        {
            return base.CheckMaxQtyStaff(); //kiểm tra vị trí công việc đã đủ người chưa
        }

        public override void CheckMaxQtyOfOrgToAcceptInsert()
        {
            //Thực hiện kiểm tra còn vị trí để thêm manager không
            base.CheckMaxQtyOfOrgToAcceptInsert();
        }

        public override void AssignStaffToMultiOrgUnit()
        {
            //ghi đè: Thêm một quản lý vào nhiều đơn vị
        }

        public override void MoveStaffToAOtherOrgUnit()
        {
            //ghi đè: Điều chuyển quản lý từ đơn vị này sang đơn vị khác
        }

        public void AssignManagerToAOrgUnit()
        {
            //Thực hiện thêm manager vào một đơn vị
        }

        public void MoveManagerToAOtherOrgUnit()
        {
            //Chuyển manager giữa các đơn vị
        }

        public void AssignMultiStaffToAManager()
        {
            //Thực hiện thêm nhiều nhân viên cho quản lý
        }

        public Manager GetManagerOfOrgUnit()
        {
            //Lấy ra thông tin quản lý của một đơn vị
            return new Manager();
        }

        public Manager GetManagerOfStaff()
        {
            //Lấy ra thông tin quản lý của một nhân viên
            return new Manager();
        }

        public bool CheckExistedManager()
        {
            //Kiểm tra manager đã tồn tại chưa
            return true;
        }
        #endregion

        #region Vị trí công việc: //Thực hiện ghi đè theo nghiệp vụ manager
        public override bool CheckExistedPositionInOrgUnit()
        {
            return base.CheckExistedPositionInOrgUnit();
        }

        public override void AssignMultiStaffToAPosition()
        {
            base.AssignMultiStaffToAPosition();
        }

        public override void AssignStaffToAPosition()
        {
            base.AssignStaffToAPosition();
        }

        public override void AssignStaffToMultiPosition()
        {
            base.AssignStaffToMultiPosition();
        }
        #endregion

        #region CRUD
        public DataTable GetAll()
        {
            return new DataTable();
        }

        public Manager GetOne(int id)
        {
            return new Manager();
        }

        public string Insert(Manager obj)
        {
            return string.Empty;
        }

        public string Update(Manager obj)
        {
            return string.Empty;
        }

        public string Delete(Manager obj)
        {
            return string.Empty;
        }

        #endregion
    }

}