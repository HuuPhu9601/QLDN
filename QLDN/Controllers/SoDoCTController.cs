using QLDN.Models;
using QLDN.Services;
using QLDN.Services.StaffServices;
using System.Collections.Generic;
using System.Web.Mvc;

namespace QLDN.Controllers
{
    public class SoDoCTController : Controller
    {
        #region Nguyên tắc 5: Đảo ngược phụ thuộc

        private readonly OrgUnitService _orgUnitService;
        private readonly IManagerService _managerService;
        private readonly IStaffService _staffService;
        private readonly SoDoTCService _soDoTCService;

        public SoDoCTController()
        {
            _orgUnitService = OrgUnitService.Init();
            _managerService = ManagerService.Init();
            _staffService = StaffService.Init();
            _soDoTCService = SoDoTCService.Init(_orgUnitService, _managerService, _staffService);
        }
        #endregion

        // GET: SoDoCT
        public ActionResult Index()
        {
            return View(_orgUnitService.GetAll());
        }

        // GET: SoDoCT/Details/5
        public ActionResult Details(int id)
        {
            string msg = _soDoTCService.SoDo(id, out OrgUnit orgUnit, out List<OrgUnit> childOrgUnit, out List<Manager> managers, out List<Staff> staffs);
            if (msg.Length > 0) return View(msg);
            ViewBag.childOrgUnit = childOrgUnit;
            ViewBag.managers = managers;
            ViewBag.staffs = staffs;
            return View(orgUnit);
        }

    }
}
