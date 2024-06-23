using System.Collections.Generic;

namespace QLDN.Models
{
    public class Manager
    {
        public int ManagerID { get; set; }

        public string ManagerName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int StatusID { get; set; }

        public ICollection<Staff> Staffs { get; set;}

        public ICollection<OrgUnitManager> OrgManagers { get; set; }

        public Manager()
        {
            StatusID = StatusType.Acctive;
        }
    }

}