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
    public class StaffsController : Controller
    {
        private readonly StaffService staffService;
        private readonly ManagerService managerService;
        public StaffsController()
        {
            managerService = new ManagerService();
            staffService = new StaffService();
        }

        // GET: Staffs
        public ActionResult Index()
        {
            var staffs = staffService.GetAll();
            return View(staffs.ToList());
        }

        // GET: Staffs/Details/5
        public ActionResult Details(int id)
        {
            Staff staff = staffService.GetOne(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            ViewBag.ManagerID = new SelectList(managerService.GetAll(), "ManagerID", "ManagerName");
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
               string msg = staffService.Insert(staff);
                if(msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = new SelectList(managerService.GetAll(), "ManagerID", "ManagerName", staff.ManagerID);
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(int id)
        {
            Staff staff = staffService.GetOne(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerID = new SelectList(managerService.GetAll(), "ManagerID", "ManagerName", staff.ManagerID);
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
                string msg = staffService.Update(staff.StaffID, staff);
                if (msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }
            ViewBag.ManagerID = new SelectList(managerService.GetAll(), "ManagerID", "ManagerName", staff.ManagerID);
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(int id)
        {
            Staff staff = staffService.GetOne(id);
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
            string msg = staffService.Remove(id);
            if(msg.Length > 0) return View(msg);
            return RedirectToAction("Index");
        }

    }
}
