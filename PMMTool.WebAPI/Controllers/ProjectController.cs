using Newtonsoft.Json;
using PMMTool.Data;
using PMMTool.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMMTool.WebAPI.Controllers
{
    public class ProjectController : Controller
    {
        IProjectRepository _projectRepo = new ProjectRepository();
        // GET: Project
        public IList<M_Project> Index()
        {
            return _projectRepo.GetAll();
        }

        // GET: Project/Details/5
        public M_Project Details(int id)
        {
            return _projectRepo.GetAll().Where(x=>x.Project_Id == id).FirstOrDefault();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<M_Project>(collection.ToString());
              
                _projectRepo.Add(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                
                var obj = JsonConvert.DeserializeObject<M_Project>(collection.ToString());               
                _projectRepo.Update(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var obj = _projectRepo.GetAll().Where(x => x.Project_Id == id).FirstOrDefault();
                _projectRepo.Remove(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
