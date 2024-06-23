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
    public class OrgUnitStaffsController : Controller
    {
        private readonly OrgUnitService orgUnitService;
        private readonly StaffService staffService;
        private readonly OrgStaffService orgStaffService;
        public OrgUnitStaffsController()
        {
            orgUnitService = new OrgUnitService();
            staffService = new StaffService();
            orgStaffService = new OrgStaffService();
        }

        // GET: OrgUnitStaffs
        public ActionResult Index()
        {
            return View(orgStaffService.GetAll());
        }

        // GET: OrgUnitStaffs/Details/5
        public ActionResult Details(int id)
        {
            OrgUnitStaff orgUnitStaff = orgStaffService.GetOne(id);
            if (orgUnitStaff == null)
            {
                return HttpNotFound();
            }
            return View(orgUnitStaff);
        }

        // GET: OrgUnitStaffs/Create
        public ActionResult Create()
        {
            ViewBag.OrgUnitID = new SelectList(orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName");
            ViewBag.StaffID = new SelectList(staffService.GetAll(), "StaffID", "StaffName");
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
                string msg = orgStaffService.Insert(orgUnitStaff);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }

            ViewBag.OrgUnitID = new SelectList(orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName", orgUnitStaff.OrgUnitID);
            ViewBag.StaffID = new SelectList(staffService.GetAll(), "StaffID", "StaffName", orgUnitStaff.StaffID);
            return View(orgUnitStaff);
        }

        // GET: OrgUnitStaffs/Edit/5
        public ActionResult Edit(int id)
        {
            OrgUnitStaff orgUnitStaff = orgStaffService.GetOne(id);
            if (orgUnitStaff == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrgUnitID = new SelectList(orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName", orgUnitStaff.OrgUnitID);
            ViewBag.StaffID = new SelectList(staffService.GetAll(), "StaffID", "StaffName", orgUnitStaff.StaffID);
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
               string msg = orgStaffService.Update(orgUnitStaff.OrgUnitStaffID, orgUnitStaff);
                if(msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }
            ViewBag.OrgUnitID = new SelectList(orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName", orgUnitStaff.OrgUnitID);
            ViewBag.StaffID = new SelectList(staffService.GetAll(), "StaffID", "StaffName", orgUnitStaff.StaffID);
            return View(orgUnitStaff);
        }

        // GET: OrgUnitStaffs/Delete/5
        public ActionResult Delete(int id)
        {
            OrgUnitStaff orgUnitStaff = orgStaffService.GetOne(id);
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
            string msg = orgStaffService.Remove(id);
            if(msg.Length > 0) return View(msg);
            return RedirectToAction("Index");
        }

    }
}
