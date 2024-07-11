using QLDN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QLDN.Services
{
    //Nguyên tắc 2: Đóng mở
    public interface IAccept
    {
        bool CheckAccept(int id);
    }

    public class OrgUnitAccept : IAccept
    {
        #region Design partten: Singoten

        private static OrgUnitAccept _orgUnitAccept;
        private OrgUnitAccept()
        {
        }

        public static OrgUnitAccept Init()
        {
            if (_orgUnitAccept == null) _orgUnitAccept = new OrgUnitAccept();
            return _orgUnitAccept;
        }
        #endregion

        //Nguyên tắc 2: Đóng mở
        public bool CheckAccept(int id)
        {
            int maxQty = DataProvider.Ins.DB.OrgUnits.Find(id).MaxQty;
            var currManagerAndStaff = from org in DataProvider.Ins.DB.OrgUnits join orgmanager in DataProvider.Ins.DB.OrgUnitManagers on org.OrgUnitID equals orgmanager.OrgUnitID join orgstaff in DataProvider.Ins.DB.OrgUnitStaffs on org.OrgUnitID equals orgstaff.OrgUnitID where org.OrgUnitID == id select org;

            int currCount = currManagerAndStaff == null ? 0 : currManagerAndStaff.Count();
            return currCount < maxQty;
        }
    }

    public class OrgUnitService : IOrgUnitService
    {
        public static OrgUnitService _orgUnitService;
        private OrgUnitService()
        {
        }

        public static OrgUnitService Init()
        {
            return _orgUnitService == null ? new OrgUnitService() : _orgUnitService;
        }

        public List<OrgUnit> GetAll()
        {
            return DataProvider.Ins.DB.OrgUnits.Where(x => x.StatusID != StatusType.Blocked).ToList();
        }

        public OrgUnit GetOne(int id)
        {
            return DataProvider.Ins.DB.OrgUnits.Find(id);
        }

        public List<OrgUnit> GetByParent(int id)
        {
            return DataProvider.Ins.DB.OrgUnits.Where(x => x.OrgUnitParent == id).ToList();
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