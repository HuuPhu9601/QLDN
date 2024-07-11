using QLDN.Models.BaseModels;
using System.Collections.Generic;
using System.Data;

namespace QLDN.Models
{
    public class Staff : IObjectIO<Staff>
    {
        private static Staff _ins;
        public static Staff Ins { get { if (_ins == null) _ins = new Staff(); return _ins; } set { _ins = value; } }
        public int StaffID { get; set; }

        public int ManagerID { get; set; }

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

        public string UnInsert(Staff obj)
        {
            return string.Empty;
        }

        public string Delete(Staff obj)
        {
            return string.Empty;
        }
    }
}