using QLDN.Models;
using QLDN.Services;
using System.Linq;
using System.Web.Mvc;

namespace QLDN.Controllers
{
    public class ManagersController : Controller
    {
        #region Nguyên tắc 5: Đảo ngược phụ thuộc

        private IManagerService _managerService;
        public ManagersController()
        {
            _managerService = ManagerService.Init();
        }
        #endregion

        // GET: Managers
        public ActionResult Index()
        {
            var managers = _managerService.GetAll();
            return View(managers.ToList());
        }

        // GET: Managers/Details/5
        public ActionResult Details(int id)
        {
            var manager = _managerService.GetOne(id);
            return View(manager);
        }

        // GET: Managers/Create
        public ActionResult Create()
        {
            ViewBag.OrgUnitID = new SelectList(DataProvider.Ins.DB.OrgUnits, "OrgUnitID", "OrgUnitName");
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManagerID,OrgUnitID,ManagerName,Age,Address,StatusID")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                string msg = _managerService.Insert(manager);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }
            return View(manager);
        }

        // GET: Managers/Edit/5
        public ActionResult Edit(int id)
        {

            Manager manager = _managerService.GetOne(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManagerID,OrgUnitID,ManagerName,Age,Address,StatusID")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                string msg = _managerService.Update(manager.ManagerID, manager);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }
            return View(manager);
        }

        // GET: Managers/Delete/5
        public ActionResult Delete(int id)
        {
            Manager manager = _managerService.GetOne(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string msg = _managerService.Remove(id);
            if (msg.Length > 0) return View(msg);
            return RedirectToAction("Index");
        }

    }
}
