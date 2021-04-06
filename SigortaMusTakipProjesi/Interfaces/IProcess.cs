using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigortaMusTakipProjesi.Interfaces
{
    public interface IProcess<T>
    {

        void Save(T t);

        void Edit(T t);

        void Delete(int id);

        List<T> List();

        T FindById(int id);
    }
}