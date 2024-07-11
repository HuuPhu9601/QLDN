using QLDN.Models.BaseModels;
using System.Collections.Generic;
using System.Data;

namespace QLDN.Models
{
    public class OrgUnit : IObjectIO<OrgUnit>
    {
        private static OrgUnit _ins;
        public static OrgUnit Ins { get { if (_ins == null) _ins = new OrgUnit(); return _ins; } set { _ins = value; } }

        public int OrgUnitID { get; set; }

        public string OrgUnitName { get; set; }

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

        public string UnInsert(OrgUnit obj)
        {
            //Thực hiện hành động update
            return string.Empty;
        }

        public string Delete(OrgUnit obj)
        {
            //Thực hiện hành động delete
            return string.Empty;
        }

    }
}