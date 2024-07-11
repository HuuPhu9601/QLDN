using QLDN.Models;
using QLDN.Services;
using QLDN.Services.StaffServices;
using System.Linq;
using System.Web.Mvc;

namespace QLDN.Controllers
{
    public class StaffsController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IManagerService _managerService;
        public StaffsController()
        {
            _managerService = ManagerService.Init();
            _staffService = StaffService.Init();
        }

        // GET: Staffs
        public ActionResult Index()
        {
            var staffs = _staffService.GetAll();
            return View(staffs.ToList());
        }

        // GET: Staffs/Details/5
        public ActionResult Details(int id)
        {
            Staff staff = _staffService.GetOne(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            ViewBag.ManagerID = new SelectList(_managerService.GetAll(), "ManagerID", "ManagerName");
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffID,ManagerID,StaffName,Age,Address,StatusID")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                string msg = _staffService.Insert(staff);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = new SelectList(_managerService.GetAll(), "ManagerID", "ManagerName", staff.ManagerID);
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(int id)
        {
            Staff staff = _staffService.GetOne(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerID = new SelectList(_managerService.GetAll(), "ManagerID", "ManagerName", staff.ManagerID);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,ManagerID,StaffName,Age,Address,StatusID")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                string msg = _staffService.Update(staff.StaffID, staff);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }
            ViewBag.ManagerID = new SelectList(_managerService.GetAll(), "ManagerID", "ManagerName", staff.ManagerID);
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(int id)
        {
            Staff staff = _staffService.GetOne(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string msg = _staffService.Remove(id);
            if (msg.Length > 0) return View(msg);
            return RedirectToAction("Index");
        }

    }
}
