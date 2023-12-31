﻿using Gestion_des_etudiants.Models;
using Gestion_des_etudiants.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_des_etudiants.Controllers
{
    [Authorize]
    public class SchoolController : Controller
    {
        private ISchoolRepository ischoolRepository;

        public SchoolController( ISchoolRepository ischoolRepository) {
            this.ischoolRepository = ischoolRepository;
        }
        // GET: SchoolController
        [AllowAnonymous]
        public ActionResult Index()
        {
            var school = ischoolRepository.GetAll();
            return View(school);
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            var school = ischoolRepository.GetById(id);
            return View(school);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School s)
        {
            try
            {
                ischoolRepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( School s)
        {
            try
            {
                ViewBag.SchoolName = s.SchoolName;
                ischoolRepository.Edit( s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var school = ischoolRepository.GetById(id);
            return RedirectToAction("Index");
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, School s)
        {
            try
            {
                ischoolRepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
