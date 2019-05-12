using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class FormationController : Controller
    {
        IFormationService FS = new FormationService();
        IFormateurService FrS = new FormateurService();
        ICandidatService CS = new CandidatService();

        // GET: Formation
        public ActionResult Index(int id)
        {
            List<FormationViewModel> formationViewModels = new List<FormationViewModel>();

            foreach (var item in FS.getTodayFormation())
            {
                FormationViewModel FVM = new FormationViewModel()
                {
                    CodeFormateur = item.CodeFormateur,
                    Date = item.Date,
                    Description = item.Description,
                    Duree = item.Duree,
                    IdFormation = item.IdFormation,
                    NbParticipants = item.NbParticipants,
                    NomFormation = item.NomFormation,
                    Prix = item.Prix,
                    TypeFormation = item.TypeFormation
                };
                formationViewModels.Add(FVM);
            }

            ViewBag.idCandidat = id;

            return View(formationViewModels);
        }

        // GET: Formation/Details/5
        public ActionResult Details(int id,int idCandidat)
        {
            Formation f = FS.GetById(id);

            if (f.NbParticipants > 0)
            {
                ViewBag.confirmed = true;
                f.NbParticipants -= 1;
                FS.Update(f);
                FS.Commit();
            }
            else
                ViewBag.confirmed = false;

            FormationViewModel formation = new FormationViewModel()
            {
                CodeFormateur = f.CodeFormateur,
                Date = f.Date,
                Description = f.Description,
                Duree = f.Duree,
                IdFormation = f.IdFormation,
                NbParticipants = f.NbParticipants,
                NomFormation = f.NomFormation,
                Prix = f.Prix,
                TypeFormation = f.TypeFormation
            };

            Candidat c = CS.GetById(idCandidat);

            ViewBag.nomCandidat = c.Nom;
            ViewBag.prenomCandidat = c.Prenom;

            return View(formation);

        }

        // GET: Formation/Create
        public ActionResult Create()
        {
            var Formateurs = FrS.GetAll();
            ViewBag.Formateur = new SelectList(Formateurs, "CodeFormateur","CodeFormateur");

            return View();
        }

        // POST: Formation/Create
        [HttpPost]
        public ActionResult Create(FormationViewModel FVM)
        {
            try
            {
                Formation f = new Formation();

                f.CodeFormateur = FVM.FormateurViewModel.CodeFormateur;
                //taw narj3oulha
                Formateur formateur = FrS.GetById(FVM.FormateurViewModel.CodeFormateur);
                f.Formateur = formateur;
                f.Date = FVM.Date;
                f.Description = FVM.Description;
                f.Duree = FVM.Duree;
                f.Prix = FVM.Prix;
                f.TypeFormation = FVM.TypeFormation;
                f.NomFormation = FVM.NomFormation;
                f.NbParticipants = FVM.NbParticipants;

                FS.Add(f);
                FS.Commit();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Formation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Formation/Edit/5
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

        // GET: Formation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Formation/Delete/5
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
