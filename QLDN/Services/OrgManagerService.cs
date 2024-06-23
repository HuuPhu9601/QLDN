using QLDN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLDN.Services
{
    public class OrgManagerService : IBaseServices<OrgUnitManager>
    {
        private readonly OrgUnitService orgUnitService;
        public OrgManagerService()
        {
            orgUnitService = new OrgUnitService();
        }
        public List<OrgUnitManager> GetAll()
        {
            return DataProvider.Ins.DB.OrgUnitManagers.Where(x => x.StatusID != StatusType.Blocked).ToList();
        }

        public OrgUnitManager GetOne(int id)
        {
            return DataProvider.Ins.DB.OrgUnitManagers.Find(id);
        }

        
        public string Insert(OrgUnitManager OrgUnitManager)
        {
            string msg = string.Empty;
            if (OrgUnitManager == null) return "Org Unit is null";
            if (!orgUnitService.AccessInsert(OrgUnitManager.OrgUnitID)) return "org unit overload human";
            try
            {
                DataProvider.Ins.DB.OrgUnitManagers.Add(OrgUnitManager);
                DataProvider.Ins.DB.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return msg;
        }

        public string Update(int id, OrgUnitManager OrgUnitManager)
        {
            string msg = string.Empty;
            if (OrgUnitManager == null) return "Org Unit is null";

            OrgUnitManager findResult = DataProvider.Ins.DB.OrgUnitManagers.Find(id);
            if (findResult == null) return "Org Unit not found";
            if (!orgUnitService.AccessInsert(OrgUnitManager.OrgUnitID)) return "org unit overload human";

            findResult.OrgUnitID = OrgUnitManager.OrgUnitID;
            findResult.ManagerID = OrgUnitManager.StatusID;

            try
            {
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
            OrgUnitManager findResult = DataProvider.Ins.DB.OrgUnitManagers.Find(id);
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