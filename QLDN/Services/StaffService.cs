using QLDN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLDN.Services
{
    public class StaffService : IBaseServices<Staff>
    {
        public List<Staff> GetAll()
        {
            return DataProvider.Ins.DB.Staffs.Where(x => x.StatusID != StatusType.Blocked).ToList();
        }

        public Staff GetOne(int id)
        {
            return DataProvider.Ins.DB.Staffs.Find(id);
        }

        public List<Staff> GetOneByOrgManagerID(int ManagerID)
        {
            return DataProvider.Ins.DB.Staffs.Where(x => x.ManagerID == ManagerID).ToList();
        }

        public string Insert(Staff staff)
        {
            string msg = string.Empty;
            if (staff == null) return "Org Unit is null";
            try
            {
                DataProvider.Ins.DB.Staffs.Add(staff);
                DataProvider.Ins.DB.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return msg;
        }

        public string Update(int id, Staff Staff)
        {
            string msg = string.Empty;
            if (Staff == null) return "Org Unit is null";

            Staff findResult = DataProvider.Ins.DB.Staffs.Find(id);
            if (findResult == null) return "Org Unit not found";

            findResult.StaffName = Staff.StaffName;
            findResult.Age = Staff.Age;
            findResult.Address = Staff.Address;
            findResult.ManagerID = Staff.ManagerID;

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
            Staff findResult = DataProvider.Ins.DB.Staffs.Find(id);
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