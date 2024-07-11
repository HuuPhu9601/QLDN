using QLDN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QLDN.Services
{
    public class OrgStaffService : IOrgStaffService
    {
        #region Design partten: Singoten

        private static OrgStaffService _ins;

        #region Nguyên tắc 5: Đảo ngược phụ thuộc
        private readonly IAccept _accept;

        private OrgStaffService(IAccept accept)
        {
            _accept = accept;
        }
        #endregion

        public static OrgStaffService Init(IAccept accept)
        {
            return _ins == null ? new OrgStaffService(accept) : _ins;
        }
        #endregion

        public List<OrgUnitStaff> GetAll()
        {
            return DataProvider.Ins.DB.OrgUnitStaffs.Where(x => x.StatusID != StatusType.Blocked).ToList();
        }

        public OrgUnitStaff GetOne(int id)
        {
            return DataProvider.Ins.DB.OrgUnitStaffs.Find(id);
        }

        public string Insert(OrgUnitStaff orgUnitStaff)
        {
            string msg = string.Empty;
            if (orgUnitStaff == null) return "Org Unit is null";

            bool isAccepted = _accept.CheckAccept(orgUnitStaff.OrgUnitID);
            if (!isAccepted) return "org unit overload human";
            try
            {
                DataProvider.Ins.DB.OrgUnitStaffs.Add(orgUnitStaff);
                DataProvider.Ins.DB.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return msg;
        }

        public string Update(int id, OrgUnitStaff orgUnitStaff)
        {
            string msg = string.Empty;
            if (orgUnitStaff == null) return "Org Unit is null";

            OrgUnitStaff findResult = DataProvider.Ins.DB.OrgUnitStaffs.Find(id);
            if (findResult == null) return "Org Unit not found";

            bool isAccepted = _accept.CheckAccept(orgUnitStaff.OrgUnitID);
            if (!isAccepted) return "org unit overload human";

            findResult.OrgUnitID = orgUnitStaff.OrgUnitID;
            findResult.StaffID = orgUnitStaff.StatusID;

            try
            {
                DataProvider.Ins.DB.Entry(orgUnitStaff).State = EntityState.Modified;
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
            OrgUnitStaff findResult = DataProvider.Ins.DB.OrgUnitStaffs.Find(id);
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