using Gestion_des_etudiants.Models;
using Gestion_des_etudiants.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_des_etudiants.Controllers
{
    public class SchoolController : Controller
    {
        private ISchoolRepository ischoolRepository;

        public SchoolController( ISchoolRepository ischoolRepository) {
            this.ischoolRepository = ischoolRepository;
        }
        // GET: SchoolController
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
            return View();
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
              
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
