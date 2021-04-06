using SigortaMusTakipProjesi.BusinessProcess;
using SigortaMusTakipProjesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigortaMusTakipProjesi.Controllers
{
    public class MusteriGorusmeController : Controller
    {

        MusteriGorusmeManager musteriGorusmeManager = new MusteriGorusmeManager();
        // GET: MusteriGorusme
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewMusteriGorusme(int id)
        {

            ViewBag.musId = id;
            return View();
        }

        [HttpPost]
        public ActionResult NewMusteriGorusme(MusteriGorusme mg)
        {

            musteriGorusmeManager.Save(mg);

            //return View("~/Views/Musteri/index.cshtml");
            return RedirectToAction("Index", "Musteri");
        }

        public ActionResult Delete(int id)
        {

            musteriGorusmeManager.Delete(id);

            return RedirectToAction("Index", "Musteri");
        }

        public ActionResult Edit(MusteriGorusme mg)
        {

            musteriGorusmeManager.Edit(mg);
            return RedirectToAction("Index", "Musteri");
        }

        public ActionResult FindMusteriGorusme(int id)
        {


            return View(musteriGorusmeManager.FindById(id));
        }
    }
}