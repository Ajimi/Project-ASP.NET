using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class CandidatController : Controller
    {
        CandidatService CS = new CandidatService();

        // GET: Candidat
        public ActionResult Index()
        {
            return View();
        }

        // GET: Candidat/Details/5
        public ActionResult Details(int i)
        {
            return View();
        }

        // GET: Candidat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidat/Create
        [HttpPost]
        public ActionResult Create(CandidatViewModel CVM, HttpPostedFileBase file)
        {

            // TODO: Add insert logic here
            Candidat c = new Candidat {
                CIN = CVM.CIN,
                Email = CVM.Email,
                Nom = CVM.Nom,
                Prenom = CVM.Prenom,
                Password = CVM.Password,
                Image = file.FileName
            };
            CS.Add(c);
            CS.Commit();

            var fileName = "";
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index","Formation", new { id = c.IdCandidat });
            
        }

        // GET: Candidat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Candidat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Candidat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
