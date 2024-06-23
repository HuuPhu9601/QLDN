using QLDN.Models;
using QLDN.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDN.Controllers
{
    public class SoDoCTController : Controller
    {
        private readonly OrgUnitService orgUnitService;
        private readonly SoDoTCService soDoTCService;

        public SoDoCTController()
        {
            orgUnitService = new OrgUnitService();
            soDoTCService = new SoDoTCService();
        }
        // GET: SoDoCT
        public ActionResult Index()
        {
            return View(orgUnitService.GetAll());
        }

        // GET: SoDoCT/Details/5
        public ActionResult Details(int id)
        {
            string msg = soDoTCService.SoDo(id, out OrgUnit orgUnit, out List<OrgUnit> childOrgUnit, out List<Manager> managers, out List<Staff> staffs);
            if(msg.Length > 0) return View(msg);
            ViewBag.childOrgUnit = childOrgUnit;
            ViewBag.managers = managers;
            ViewBag.staffs = staffs;
            return View(orgUnit);
        }
        
    }
}
