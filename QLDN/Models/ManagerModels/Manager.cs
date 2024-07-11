using QLDN.Models.BaseModels;
using System.Collections.Generic;
using System.Data;

namespace QLDN.Models
{
    public class Manager : IObjectIO<Manager>
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

        public string UnInsert(Manager obj)
        {
            return string.Empty;
        }

        public string Delete(Manager obj)
        {
            return string.Empty;
        }
    }

}