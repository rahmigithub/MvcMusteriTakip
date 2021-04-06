using SigortaMusTakipProjesi.Interfaces;
using SigortaMusTakipProjesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigortaMusTakipProjesi.BusinessProcess
{
    public class MusteriGorusmeManager : IProcess<MusteriGorusme>
    {

        private SigortaMusTakipEntities db = new SigortaMusTakipEntities();
        public void Save(MusteriGorusme t)
        {
            t.IsActive = true;
            t.GorusmeTarihi = DateTime.Today;
            db.MusteriGorusme.Add(t);
            db.SaveChanges();

        }
        public void Delete(int id)
        {
            var tempMusGorusme = db.MusteriGorusme.Find(id);
            tempMusGorusme.IsActive = false;
            db.SaveChanges();
        }

        public void Edit(MusteriGorusme t)
        {
            var tempMusGorusme = db.MusteriGorusme.Find(t.Id);
            tempMusGorusme.MusId = t.MusId;
            tempMusGorusme.GorusmeTarihi = t.GorusmeTarihi;
            tempMusGorusme.GorusmeKonusu = t.GorusmeKonusu;
            tempMusGorusme.IsActive = t.IsActive;
            db.SaveChanges();
        }

        public MusteriGorusme FindById(int id)
        {
            return db.MusteriGorusme.Find(id);
        }

        public List<MusteriGorusme> List()
        {
            return db.MusteriGorusme.ToList();
        }


    }
}