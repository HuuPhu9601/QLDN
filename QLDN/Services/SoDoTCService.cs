using QLDN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDN.Services
{
    public class SoDoTCService
    {
        private readonly OrgUnitService orgUnitService;
        public SoDoTCService()
        {
            orgUnitService = new OrgUnitService();
        }

        public string SoDo(int id, out OrgUnit orgUnit, out List<OrgUnit> childOrgUnit, out List<Manager> managers, out List<Staff> staffs)
        {
            orgUnit = null;
            childOrgUnit = null;
            managers = null;
            staffs = null;

            orgUnit = orgUnitService.GetOne(id);
            if (orgUnit == null) return "Org Unit not found";

            childOrgUnit = orgUnitService.GetOneByParentOrg(orgUnit.OrgUnitID);

            managers = (from org in DataProvider.Ins.DB.OrgUnits
                         join orgmanager in DataProvider.Ins.DB.OrgUnitManagers on org.OrgUnitID equals orgmanager.OrgUnitID
                         join manager in DataProvider.Ins.DB.Managers on orgmanager.ManagerID equals manager.ManagerID
                         join orgstaff in DataProvider.Ins.DB.OrgUnitStaffs on org.OrgUnitID equals orgstaff.OrgUnitID
                         join staff in DataProvider.Ins.DB.Staffs on orgstaff.StaffID equals staff.StaffID
                         where org.OrgUnitID == id
                         select manager).ToList();

            staffs = (from org in DataProvider.Ins.DB.OrgUnits
                              join orgmanager in DataProvider.Ins.DB.OrgUnitManagers on org.OrgUnitID equals orgmanager.OrgUnitID
                              join manager in DataProvider.Ins.DB.Managers on orgmanager.ManagerID equals manager.ManagerID
                              join orgstaff in DataProvider.Ins.DB.OrgUnitStaffs on org.OrgUnitID equals orgstaff.OrgUnitID
                              join staff in DataProvider.Ins.DB.Staffs on orgstaff.StaffID equals staff.StaffID
                              where org.OrgUnitID == id
                              select staff).ToList();

            return string.Empty;
        }


    }
}