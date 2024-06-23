using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLDN.Models;
using QLDN.Services;

namespace QLDN.Controllers
{
    public class OrgUnitsController : Controller
    {
        private readonly OrgUnitService orgUnitService;

        public OrgUnitsController()
        {
            orgUnitService = new OrgUnitService();
        }

        // GET: OrgUnits
        public ActionResult Index()
        {
            return View(orgUnitService.GetAll());
        }

        // GET: OrgUnits/Details/5
        public ActionResult Details(int id)
        {
            OrgUnit orgUnit =orgUnitService.GetOne(id);
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
                string msg = orgUnitService.Insert(orgUnit);
                if(msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }

            return View(orgUnit);
        }

        // GET: OrgUnits/Edit/5
        public ActionResult Edit(int id)
        {
            OrgUnit orgUnit = orgUnitService.GetOne(id);
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
                string msg = orgUnitService.Update(orgUnit.OrgUnitID, orgUnit);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }
            return View(orgUnit);
        }

        // GET: OrgUnits/Delete/5
        public ActionResult Delete(int id)
        {
            OrgUnit orgUnit = orgUnitService.GetOne(id);
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
            string msg = orgUnitService.Remove(id);
            if (msg.Length > 0) return View(msg);
            return RedirectToAction("Index");
        }

    }
}
