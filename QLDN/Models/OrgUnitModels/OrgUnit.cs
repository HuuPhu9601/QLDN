using QLDN.Models.JobPositionModels;
using QLDN.Models.OrgUnitModels;
using System.Collections.Generic;
using System.Data;

namespace QLDN.Models
{
    public class OrgUnit : AssignJobPositon, IOrgUnit
    {
        private static OrgUnit _ins;
        public static OrgUnit Ins { get { if (_ins == null) _ins = new OrgUnit(); return _ins; } set { _ins = value; } }

        public int OrgUnitID { get; set; }

        public string OrgUnitName { get; set; }

        public int ManagerID { get; set; }

        public string ManagerName { get; set; }

        public int MaxQty { get; set; }

        public int StatusID { get; set; }

        public int OrgUnitParent { get; set; }

        public ICollection<Manager> Managers { get; set; }

        public ICollection<Staff> Staffs { get; set; }

        public OrgUnit()
        {
            MaxQty = 100;
            StatusID = StatusType.Acctive;
        }

        #region Đơn vị
        public bool CheckOnlyManagerOfOrg()
        {
            //Thực hiện kiểm tra khi thêm manager thì chỉ thêm đc một manager vào một org
            return true;
        }

        public bool CheckOnlyParentOrg()
        {
            //Thực hiện kiểm tra một đơn vị chỉ có một đơn vị cha
            return true;
        }

        public bool CheckExistedOrg()
        {
            //Thực hiện kiểm tra đơ vị đã tồn tại hay chưa?
            return true;
        }

        public void AddMultiChildrenOrgToAOrgUnit()
        {
            //Thực hiện thêm nhiều đơn vị con vào trong một đơn vị
        }

        public void AddParentOrgToAOrgUnit()
        {
            //Thực hiện thêm đơn cha vào một đơn vị
        }

        public List<Staff> GetStaffOfOrgUnit()
        {
            //Lấy ra danh sách nhân viên trong đơn vị
            return new List<Staff>();
        }

        public Manager GetManagerOfOrgUnit()
        {
            //Lấy ra thông tin manager của đơn vị
            return new Manager();
        }

        public List<OrgUnit> GetOrgUnitsOfStaff()
        {
            //Lấy ra danh sách đơn vị của nhân viên
            return new List<OrgUnit>();
        }
        #endregion

        #region Vị trí công việc: //Thực hiện ghi đè theo nghiệp vụ org
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

        public OrgUnit GetOne(int id)
        {
            return new OrgUnit();
        }

        public string Insert(OrgUnit obj)
        {
            //Thực hiện hành động insert
            return string.Empty;
        }

        public string Update(OrgUnit obj)
        {
            //Thực hiện hành động update
            return string.Empty;
        }

        public string Delete(OrgUnit obj)
        {
            //Thực hiện hành động delete
            return string.Empty;
        }

        #endregion

    }
}