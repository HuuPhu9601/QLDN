using QLDN.Models;
using QLDN.Services.StaffServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLDN.Services
{
    public class StaffService : IStaffService
    {
        private static StaffService _staffService;

        private StaffService()
        {
        }

        public static StaffService Init()
        {
            return _staffService == null ? new StaffService() : _staffService;
        }

        public List<Staff> GetAll()
        {
            return DataProvider.Ins.DB.Staffs.Where(x => x.StatusID != StatusType.Blocked).ToList();
        }

        public Staff GetOne(int id)
        {
            return DataProvider.Ins.DB.Staffs.Find(id);
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

        public List<Staff> GetByParent(int id)
        {
            return (from org in DataProvider.Ins.DB.OrgUnits
                    join orgstaff in DataProvider.Ins.DB.OrgUnitStaffs on org.OrgUnitID equals orgstaff.OrgUnitID
                    join staff in DataProvider.Ins.DB.Staffs on orgstaff.StaffID equals staff.StaffID
                    where org.OrgUnitID == id
                    select staff).ToList();
        }
    }
}