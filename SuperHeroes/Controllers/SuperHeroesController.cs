using SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class SuperHeroesController : Controller
    {
        // GET: SuperHeroes
        ApplicationDbContext context;

        public SuperHeroesController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View(context.SuperHeroes.ToList());
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            var detailHeroes = context.SuperHeroes.Where(x => x.ID == id).FirstOrDefault();

            return View(detailHeroes);
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            SuperHeroesClass superHeroes = new SuperHeroesClass();

            return View(superHeroes);
        }

        // POST: SuperHeroes/Create
        [HttpPost]
        public ActionResult Create(SuperHeroesClass superHeroes)
        {
            try
            {
                context.SuperHeroes.Add(superHeroes);
                context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            var heroEdit = context.SuperHeroes.Where(x => x.ID == id).FirstOrDefault();

            return View(heroEdit);
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SuperHeroesClass superHeroes)
        {
            try
            {
                var heroEdit = context.SuperHeroes.Where(x => x.ID == id).FirstOrDefault();
                heroEdit.ID = superHeroes.ID;
                heroEdit.Name = superHeroes.Name;
                heroEdit.PrimaryAbility = superHeroes.PrimaryAbility;
                heroEdit.SecondaryAbility = superHeroes.SecondaryAbility;
                heroEdit.CatchPhrase = superHeroes.CatchPhrase;

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            var deletedHero = context.SuperHeroes.Where(x => x.ID == id).FirstOrDefault();

            return View(deletedHero);
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SuperHeroesClass superHeroes)
        {
            try
            {
                var deletedHero = context.SuperHeroes.Where(x => x.ID == id).FirstOrDefault();
                context.SuperHeroes.Remove(deletedHero);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
