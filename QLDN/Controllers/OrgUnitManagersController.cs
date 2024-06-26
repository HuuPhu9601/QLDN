﻿using System;
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
    public class OrgUnitManagersController : Controller
    {
        private readonly OrgUnitService orgUnitService;
        private readonly ManagerService managerService;
        private readonly OrgManagerService orgManagerService;

        public OrgUnitManagersController()
        {
            orgUnitService = new OrgUnitService();
            managerService = new ManagerService();
            orgManagerService = new OrgManagerService();
        }
        // GET: OrgUnitManagers
        public ActionResult Index()
        {
            var orgUnitManagers = orgManagerService.GetAll();
            return View(orgUnitManagers.ToList());
        }

        // GET: OrgUnitManagers/Details/5
        public ActionResult Details(int id)
        {
            OrgUnitManager orgUnitManager = orgManagerService.GetOne(id);
            if (orgUnitManager == null) return HttpNotFound();
            return View(orgUnitManager);
        }

        // GET: OrgUnitManagers/Create
        public ActionResult Create()
        {
            ViewBag.ManagerID = new SelectList(managerService.GetAll(), "ManagerID", "ManagerName");
            ViewBag.OrgUnitID = new SelectList(orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName");
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
                string msg = orgManagerService.Insert(orgUnitManager);
                if(msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = new SelectList(managerService.GetAll(), "ManagerID", "ManagerName", orgUnitManager.ManagerID);
            ViewBag.OrgUnitID = new SelectList(orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName", orgUnitManager.OrgUnitID);
            return View(orgUnitManager);
        }

        // GET: OrgUnitManagers/Edit/5
        public ActionResult Edit(int id)
        {
            OrgUnitManager orgUnitManager = orgManagerService.GetOne(id);
            if (orgUnitManager == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerID = new SelectList(managerService.GetAll(), "ManagerID", "ManagerName", orgUnitManager.ManagerID);
            ViewBag.OrgUnitID = new SelectList(orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName", orgUnitManager.OrgUnitID);
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
                string msg = orgManagerService.Update(orgUnitManager.OrgUnitManagerID, orgUnitManager);
                if(msg.Length > 0) return View(msg);
                return RedirectToAction("Index");
            }
            ViewBag.ManagerID = new SelectList(managerService.GetAll(), "ManagerID", "ManagerName", orgUnitManager.ManagerID);
            ViewBag.OrgUnitID = new SelectList(orgUnitService.GetAll(), "OrgUnitID", "OrgUnitName", orgUnitManager.OrgUnitID);
            return View(orgUnitManager);
        }

        // GET: OrgUnitManagers/Delete/5
        public ActionResult Delete(int id)
        {
            OrgUnitManager orgUnitManager = orgManagerService.GetOne(id);
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
            string msg = orgManagerService.Remove(id);
            if(msg.Length > 0) return View(msg);
            return RedirectToAction("Index");
        }

    }
}
