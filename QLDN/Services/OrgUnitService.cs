using QLDN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLDN.Services
{
    public class OrgUnitService : IBaseServices<OrgUnit>
    {
        public List<OrgUnit> GetAll()
        {
            return DataProvider.Ins.DB.OrgUnits.Where(x => x.StatusID != StatusType.Blocked).ToList();
        }

        public OrgUnit GetOne(int id)
        {
            return DataProvider.Ins.DB.OrgUnits.Find(id);
        }

        public bool AccessInsert(int id)
        {
            int maxQty = DataProvider.Ins.DB.OrgUnits.Find(id).MaxQty;
            var currManagerAndStaff = from org in DataProvider.Ins.DB.OrgUnits join orgmanager in DataProvider.Ins.DB.OrgUnitManagers on org.OrgUnitID equals orgmanager.OrgUnitID join orgstaff in DataProvider.Ins.DB.OrgUnitStaffs on org.OrgUnitID equals orgstaff.OrgUnitID where org.OrgUnitID == id select org;
            
            int currCount = currManagerAndStaff == null ? 0: currManagerAndStaff.Count();
            return currCount < maxQty;
        }

        public List<OrgUnit> GetOneByParentOrg(int parentOrgID)
        {
            return DataProvider.Ins.DB.OrgUnits.Where(x => x.OrgUnitParent == parentOrgID).ToList();
        }

        public string Insert(OrgUnit orgUnit)
        {
            string msg = string.Empty;
            if (orgUnit == null) return "Org Unit is null";
            int ExistOrg = DataProvider.Ins.DB.OrgUnits.Where(x => x.OrgUnitName == orgUnit.OrgUnitName).ToList().Count;
            if (ExistOrg > 0) return "Org Unit name already exist";
            try
            {
                DataProvider.Ins.DB.OrgUnits.Add(orgUnit);
                DataProvider.Ins.DB.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return msg;
        }

        public string Update(int id, OrgUnit orgUnit)
        {
            string msg = string.Empty;
            if (orgUnit == null) return "Org Unit is null";

            OrgUnit findResult = DataProvider.Ins.DB.OrgUnits.Find(id);
            if (findResult == null) return "Org Unit not found";

            findResult.OrgUnitName = orgUnit.OrgUnitName;
            findResult.ManagerName = orgUnit.ManagerName;
            findResult.MaxQty = orgUnit.MaxQty;
            findResult.OrgUnitParent = orgUnit.OrgUnitParent;

            try
            {
                DataProvider.Ins.DB.Entry(orgUnit).State = EntityState.Modified;
                DataProvider.Ins.DB.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return msg;
        }

        public string Remove(int id)
        {
            string msg = string.Empty;
            OrgUnit findResult = DataProvider.Ins.DB.OrgUnits.Find(id);
            if (findResult == null) return "Org Unit not found";

            try
            {
                findResult.StatusID = StatusType.Blocked;
                DataProvider.Ins.DB.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return msg;
        }
    }
}