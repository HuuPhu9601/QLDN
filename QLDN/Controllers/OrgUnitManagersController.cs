using QLDN.Models;
using QLDN.Services;
using System.Linq;
using System.Web.Mvc;

namespace QLDN.Controllers
{
    public class OrgUnitManagersController : Controller
    {
        #region Nguyên tắc 5: Đảo ngược phụ thuộc

        private readonly IAccept _accept;
        private readonly IOrgUnitService _orgUnitService;
        private readonly IManagerService _managerService;
        private readonly IOrgManagerService _orgManagerService;

        public OrgUnitManagersController()
        {
            _accept = OrgUnitAccept.Init();
            _orgUnitService = OrgUnitService.Init();
            _managerService = ManagerService.Init();
            _orgManagerService = OrgManagerService.Init(_accept);
        }
        #endregion

        // GET: OrgUnitManagers
        public ActionResult Index()
        {
            var orgUnitManagers = _orgManagerService.GetAll();
            return View(orgUnitManagers.ToList());
        }

        // GET: OrgUnitManagers/Details/5
        public ActionResult Details(int id)
        {
            OrgUnitManager orgUnitManager = _orgManagerService.GetOne(id);
            if (orgUnitManager == null) return HttpNotFound();
            return View(orgUnitManager);
        }

        // GET: OrgUnitManagers/Create
        public ActionResult Create()
        {
            ViewBag.ManagerID = new SelectList(_managerService.GetAll(), "ManagerID", "ManagerName");
            ViewBag.OrgUnitID = new SelectList(_orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName");
            return View();
        }

        // POST: OrgUnitManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrgUnitManagerID,OrgUnitID,ManagerID,StatusID")] OrgUnitManager orgUnitManager)
        {
            if (ModelState.IsValid)
            {
                string msg = _orgManagerService.Insert(orgUnitManager);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = new SelectList(_managerService.GetAll(), "ManagerID", "ManagerName", orgUnitManager.ManagerID);
            ViewBag.OrgUnitID = new SelectList(_orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName", orgUnitManager.OrgUnitID);
            return View(orgUnitManager);
        }

        // GET: OrgUnitManagers/Edit/5
        public ActionResult Edit(int id)
        {
            OrgUnitManager orgUnitManager = _orgManagerService.GetOne(id);
            if (orgUnitManager == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerID = new SelectList(_managerService.GetAll(), "ManagerID", "ManagerName", orgUnitManager.ManagerID);
            ViewBag.OrgUnitID = new SelectList(_orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName", orgUnitManager.OrgUnitID);
            return View(orgUnitManager);
        }

        // POST: OrgUnitManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrgUnitManagerID,OrgUnitID,ManagerID,StatusID")] OrgUnitManager orgUnitManager)
        {
            if (ModelState.IsValid)
            {
                string msg = _orgManagerService.Update(orgUnitManager.OrgUnitManagerID, orgUnitManager);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }
            ViewBag.ManagerID = new SelectList(_managerService.GetAll(), "ManagerID", "ManagerName", orgUnitManager.ManagerID);
            ViewBag.OrgUnitID = new SelectList(_orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName", orgUnitManager.OrgUnitID);
            return View(orgUnitManager);
        }

        // GET: OrgUnitManagers/Delete/5
        public ActionResult Delete(int id)
        {
            OrgUnitManager orgUnitManager = _orgManagerService.GetOne(id);
            if (orgUnitManager == null)
            {
                return HttpNotFound();
            }
            return View(orgUnitManager);
        }

        // POST: OrgUnitManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string msg = _orgManagerService.Remove(id);
            if (msg.Length > 0) return View(msg);
            return RedirectToAction("Index");
        }

    }
}
