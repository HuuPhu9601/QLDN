using QLDN.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLDN.Services
{
    public class OrgManagerService : IOrgManagerService
    {
        #region Design partten: singleton

        private readonly IAccept _accept;
        #region Nguyên tắc 5: Đảo ngược phụ thuộc

        private static OrgManagerService _orgManagerService;
        private OrgManagerService(IAccept accept)
        {
            _accept = accept;
        }
        #endregion

        public static OrgManagerService Init(IAccept accept)
        {
            return _orgManagerService == null ? new OrgManagerService(accept) : _orgManagerService;
        }
        #endregion

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
            bool isAccepted = _accept.CheckAccept(OrgUnitManager.OrgUnitID);
            if (!isAccepted) return "org unit overload human";
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

            bool isAccepted = _accept.CheckAccept(OrgUnitManager.OrgUnitID);
            if (!isAccepted) return "org unit overload human";

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