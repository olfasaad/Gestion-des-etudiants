using Gestion_des_etudiants.Models;
using Gestion_des_etudiants.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Gestion_des_etudiants.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository istudentRepository;
        private ISchoolRepository ischoolRepository;
        public StudentController (IStudentRepository istudent , ISchoolRepository ischool)
        {
            this.istudentRepository = istudent;
            this.ischoolRepository = ischool;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            ViewBag.SchooldID = new SelectList(ischoolRepository.GetAll(), "SchoolID", "SchoolName");
            var student = istudentRepository.GetAll();
            return View(student);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = istudentRepository.GetById(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.SchooldID = new SelectList(ischoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student s)
        {
            try
            {
                istudentRepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SchooldID = new SelectList(ischoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student s )
        {
            try
            {
                ViewBag.SchooldID = new SelectList(ischoolRepository.GetAll(), "SchoolID", "SchoolName");
                istudentRepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = istudentRepository.GetById(id);
            return View();
        }

        // POST: StudentController/Delete/5
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
        public ActionResult Search(string name, int? schoolid)
        {
            var result = istudentRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = istudentRepository.FindByName(name);
            else
            if (schoolid != null)
                result = istudentRepository.GetStudentsBySchoolID(schoolid);
            ViewBag.SchoolID = new SelectList(ischoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View("Index", result);
        }
    }
}
