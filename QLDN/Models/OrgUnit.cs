using System.Collections.Generic;

namespace QLDN.Models
{
    public class OrgUnit
    {
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
    }
}