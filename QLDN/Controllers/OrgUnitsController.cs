using QLDN.Models;
using QLDN.Services;
using System.Web.Mvc;

namespace QLDN.Controllers
{
    public class OrgUnitsController : Controller
    {
        #region Nguyên tắc 5: Đảo ngược phụ thuộc

        private readonly IOrgUnitService _orgUnitService;

        public OrgUnitsController()
        {
            _orgUnitService = OrgUnitService.Init();
        }
        #endregion

        // GET: OrgUnits
        public ActionResult Index()
        {
            return View(_orgUnitService.GetAll());
        }

        // GET: OrgUnits/Details/5
        public ActionResult Details(int id)
        {
            OrgUnit orgUnit = _orgUnitService.GetOne(id);
            if (orgUnit == null)
            {
                return HttpNotFound();
            }
            return View(orgUnit);
        }

        // GET: OrgUnits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrgUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrgUnitID,OrgUnitName,ManagerName,MaxQty,StatusID,OrgUnitParent")] OrgUnit orgUnit)
        {
            if (ModelState.IsValid)
            {
                string msg = _orgUnitService.Insert(orgUnit);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }

            return View(orgUnit);
        }

        // GET: OrgUnits/Edit/5
        public ActionResult Edit(int id)
        {
            OrgUnit orgUnit = _orgUnitService.GetOne(id);
            if (orgUnit == null)
            {
                return HttpNotFound();
            }
            return View(orgUnit);
        }

        // POST: OrgUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrgUnitID,OrgUnitName,ManagerName,MaxQty,StatusID,OrgUnitParent")] OrgUnit orgUnit)
        {
            if (ModelState.IsValid)
            {
                string msg = _orgUnitService.Update(orgUnit.OrgUnitID, orgUnit);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }
            return View(orgUnit);
        }

        // GET: OrgUnits/Delete/5
        public ActionResult Delete(int id)
        {
            OrgUnit orgUnit = _orgUnitService.GetOne(id);
            if (orgUnit == null)
            {
                return HttpNotFound();
            }
            return View(orgUnit);
        }

        // POST: OrgUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string msg = _orgUnitService.Remove(id);
            if (msg.Length > 0) return View(msg);
            return RedirectToAction("Index");
        }

    }
}
