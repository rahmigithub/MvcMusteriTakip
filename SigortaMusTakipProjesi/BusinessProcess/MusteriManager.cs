using SigortaMusTakipProjesi.Interfaces;
using SigortaMusTakipProjesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigortaMusTakipProjesi.BusinessProcess
{
    public class MusteriManager : IProcess<Musteri>
    {

        private SigortaMusTakipEntities db = new SigortaMusTakipEntities();

        public void Save(Musteri t)
        {

            t.IsActive = true;
            t.KayıtTarihi = DateTime.Today;
            db.Musteri.Add(t);
            db.SaveChanges();
           
        }

        public void Delete(int id)
        {
            var tempMus = db.Musteri.Find(id);
            tempMus.IsActive = false;
            db.SaveChanges();
        }

        public void Edit(Musteri t)
        {
            var tempMus = db.Musteri.Find(t.Id);
            tempMus.MusAdı = t.MusAdı;
            tempMus.MusSoyad = t.MusSoyad;
            tempMus.Isyeri = t.Isyeri;
            tempMus.Adres = t.Adres;
            tempMus.Tel = t.Tel;
            tempMus.KayıtTarihi = t.KayıtTarihi;
            tempMus.IsActive = t.IsActive;
            db.SaveChanges();
        }

        public Musteri FindById(int id)
        {

            return db.Musteri.Find(id);
        }

        public List<Musteri> List()
        {
            return db.Musteri.ToList();
        }

        
    }
}