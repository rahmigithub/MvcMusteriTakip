using SigortaMusTakipProjesi.BusinessProcess;
using SigortaMusTakipProjesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigortaMusTakipProjesi.Controllers
{
    public class MusteriController : Controller
    {

       MusteriManager musteriManager = new MusteriManager();
        MusteriGorusmeManager MusteriGorusmeManager = new MusteriGorusmeManager();
        // GET: Musteri
        public ActionResult Index()
        {
            var list = musteriManager.List();
            return View(list);
        }

        [HttpGet]
        public ActionResult NewMusteri() {

            return View();
        }

        [HttpPost]
        public ActionResult NewMusteri(Musteri m)
        {

            musteriManager.Save(m);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) {

            musteriManager.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Musteri m) {

            musteriManager.Edit(m);
            return RedirectToAction("Index");
        }

        public ActionResult FindMusteri(int id) {


            return View(musteriManager.FindById(id));
        }

        public ActionResult MusteriDetay(int id) {

            List<MusteriGorusme> musteriGorusmelist = MusteriGorusmeManager.List().Where(m => m.MusId == id).ToList();
            ViewBag.MusteriBilgileri = musteriManager.FindById(id).MusAdı + " " + musteriManager.FindById(id).MusSoyad;
            ViewBag.MusteriId = id;
            
            return View(musteriGorusmelist);
        }
    }
}