using QLDN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLDN.Services
{
    public class ManagerService : IBaseServices<Manager>
    {
        
        public List<Manager> GetAll()
        {
            return DataProvider.Ins.DB.Managers.Where(x=>x.StatusID != StatusType.Blocked).ToList();
        }

        public Manager GetOne(int id)
        {
            return DataProvider.Ins.DB.Managers.Find(id);
        }

        public List<Manager> GetOneByOrgUnitID(int OrgUnitID)
        {
            var managers = from manager in DataProvider.Ins.DB.Managers join orgmanager in DataProvider.Ins.DB.OrgUnitManagers on manager.ManagerID equals orgmanager.ManagerID where orgmanager.OrgUnitID == OrgUnitID select manager;
            return managers.ToList();
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
    }
}