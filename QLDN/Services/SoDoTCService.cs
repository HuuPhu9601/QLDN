using QLDN.Models;
using QLDN.Services.StaffServices;
using System.Collections.Generic;

namespace QLDN.Services
{
    public class SoDoTCService
    {


        #region Nguyên tắc 5: đảo ngược phụ thuộc
        private readonly IOrgUnitService _orgUnitService;
        private readonly IManagerService _managerService;
        private readonly IStaffService _staffService;
        private SoDoTCService(IOrgUnitService orgUnitService, IManagerService managerService, IStaffService staffService)
        {
            _orgUnitService = orgUnitService;
            _managerService = managerService;
            _staffService = staffService;
        }
        #endregion

        #region Desgin Partten: singleton
        public static SoDoTCService _soDoTCService;
        public static SoDoTCService Init(IOrgUnitService orgUnitService, IManagerService managerService, IStaffService staffService)
        {
            return _soDoTCService == null ? new SoDoTCService(orgUnitService, managerService, staffService) : _soDoTCService;
        }
        #endregion

        public string SoDo(int id, out OrgUnit orgUnit, out List<OrgUnit> childOrgUnit, out List<Manager> managers, out List<Staff> staffs)
        {
            orgUnit = null;
            childOrgUnit = null;
            managers = null;
            staffs = null;

            orgUnit = _orgUnitService.GetOne(id);
            if (orgUnit == null) return "Org Unit not found";

            childOrgUnit = _orgUnitService.GetByParent(orgUnit.OrgUnitID);

            managers = _managerService.GetByParent(id);

            staffs = _staffService.GetByParent(id);

            return string.Empty;
        }


    }
}