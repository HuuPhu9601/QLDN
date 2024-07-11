using QLDN.Models;
using QLDN.Services;
using QLDN.Services.StaffServices;
using System.Web.Mvc;

namespace QLDN.Controllers
{
    public class OrgUnitStaffsController : Controller
    {
        private readonly IAccept _accept;
        private readonly IOrgUnitService _orgUnitService;
        private readonly IStaffService _staffService;
        private readonly IOrgStaffService _orgStaffService;
        public OrgUnitStaffsController()
        {
            _accept = OrgUnitAccept.Init();
            _orgUnitService = OrgUnitService.Init();
            _staffService = StaffService.Init();
            _orgStaffService = OrgStaffService.Init(_accept);
        }

        // GET: OrgUnitStaffs
        public ActionResult Index()
        {
            return View(_orgStaffService.GetAll());
        }

        // GET: OrgUnitStaffs/Details/5
        public ActionResult Details(int id)
        {
            OrgUnitStaff orgUnitStaff = _orgStaffService.GetOne(id);
            if (orgUnitStaff == null)
            {
                return HttpNotFound();
            }
            return View(orgUnitStaff);
        }

        // GET: OrgUnitStaffs/Create
        public ActionResult Create()
        {
            ViewBag.OrgUnitID = new SelectList(_orgStaffService.GetAll(), "OrgUnitID", "OrgUnitName");
            ViewBag.StaffID = new SelectList(_staffService.GetAll(), "StaffID", "StaffName");
            return View();
        }

        // POST: OrgUnitStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrgUnitStaffID,OrgUnitID,StaffID,StatusID")] OrgUnitStaff orgUnitStaff)
        {
            if (ModelState.IsValid)
            {
                string msg = _orgStaffService.Insert(orgUnitStaff);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }

            ViewBag.OrgUnitID = new SelectList(_orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName", orgUnitStaff.OrgUnitID);
            ViewBag.StaffID = new SelectList(_staffService.GetAll(), "StaffID", "StaffName", orgUnitStaff.StaffID);
            return View(orgUnitStaff);
        }

        // GET: OrgUnitStaffs/Edit/5
        public ActionResult Edit(int id)
        {
            OrgUnitStaff orgUnitStaff = _orgStaffService.GetOne(id);
            if (orgUnitStaff == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrgUnitID = new SelectList(_orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName", orgUnitStaff.OrgUnitID);
            ViewBag.StaffID = new SelectList(_staffService.GetAll(), "StaffID", "StaffName", orgUnitStaff.StaffID);
            return View(orgUnitStaff);
        }

        // POST: OrgUnitStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrgUnitStaffID,OrgUnitID,StaffID,StatusID")] OrgUnitStaff orgUnitStaff)
        {
            if (ModelState.IsValid)
            {
                string msg = _orgStaffService.Update(orgUnitStaff.OrgUnitStaffID, orgUnitStaff);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }
            ViewBag.OrgUnitID = new SelectList(_orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName", orgUnitStaff.OrgUnitID);
            ViewBag.StaffID = new SelectList(_staffService.GetAll(), "StaffID", "StaffName", orgUnitStaff.StaffID);
            return View(orgUnitStaff);
        }

        // GET: OrgUnitStaffs/Delete/5
        public ActionResult Delete(int id)
        {
            OrgUnitStaff orgUnitStaff = _orgStaffService.GetOne(id);
            if (orgUnitStaff == null)
            {
                return HttpNotFound();
            }
            return View(orgUnitStaff);
        }

        // POST: OrgUnitStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string msg = _orgStaffService.Remove(id);
            if (msg.Length > 0) return View(msg);
            return RedirectToAction("Index");
        }

    }
}
