namespace QLDN.Models
{
    public class OrgUnitManager
    {
        public int OrgUnitManagerID { get; set; }

        public int OrgUnitID { get; set; }

        public int ManagerID { get; set; }

        public int StatusID { get; set; }

        public OrgUnit OrgUnit { get; set; }

        public Manager Manager { get; set; }

        public OrgUnitManager()
        {
            StatusID = StatusType.Acctive;
        }
    }
}