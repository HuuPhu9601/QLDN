using System.Collections.Generic;

namespace QLDN.Models
{
    public class Staff
    {
        public int StaffID { get; set; }

        public int ManagerID { get; set; }

        public string StaffName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int StatusID { get; set; }

        public Manager Manager { get; set; }

        public ICollection<OrgUnitStaff> OrgUnitStaffs { get; set;}

        public Staff()
        {
            StatusID = StatusType.Acctive;
        }
    }
}