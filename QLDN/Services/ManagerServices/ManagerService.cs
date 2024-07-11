using QLDN.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLDN.Services
{
    public class ManagerService : IManagerService
    {
        #region Design partten: Singoten

        public static ManagerService _managerService;

        private ManagerService()
        {
        }

        public static ManagerService Init()
        {
            return _managerService == null ? new ManagerService() : _managerService;
        }
        #endregion

        public List<Manager> GetAll()
        {
            return DataProvider.Ins.DB.Managers.Where(x => x.StatusID != StatusType.Blocked).ToList();
        }

        public Manager GetOne(int id)
        {
            return DataProvider.Ins.DB.Managers.Find(id);
        }

        public string Insert(Manager Manager)
        {
            string msg = string.Empty;
            if (Manager == null) return "Org Unit is null";

            try
            {
                DataProvider.Ins.DB.Managers.Add(Manager);
                DataProvider.Ins.DB.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return msg;
        }

        public string Update(int id, Manager manager)
        {
            string msg = string.Empty;
            if (manager == null) return "Org Unit is null";

            Manager findResult = DataProvider.Ins.DB.Managers.Find(id);
            if (findResult == null) return "Org Unit not found";

            findResult.ManagerName = manager.ManagerName;
            findResult.Age = manager.Age;
            findResult.Address = manager.Address;

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
            Manager findResult = DataProvider.Ins.DB.Managers.Find(id);
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

        public List<Manager> GetByParent(int id)
        {
            return (from org in DataProvider.Ins.DB.OrgUnits
                    join orgmanager in DataProvider.Ins.DB.OrgUnitManagers on org.OrgUnitID equals orgmanager.OrgUnitID
                    join manager in DataProvider.Ins.DB.Managers on orgmanager.ManagerID equals manager.ManagerID
                    where org.OrgUnitID == id
                    select manager).ToList();
        }
    }
}