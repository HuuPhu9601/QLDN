using QLDN.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLDN.Models
{
    public class OrgUnitStaff
    {
        public int OrgUnitStaffID { get; set; }

        public int OrgUnitID { get; set; }

        public int StaffID { get; set; }

        public int StatusID { get; set; }

        public OrgUnit OrgUnit { get; set; }

        public Staff Staff { get; set; }

        public OrgUnitStaff()
        {
            StatusID = StatusType.Acctive;
        }
    }
}