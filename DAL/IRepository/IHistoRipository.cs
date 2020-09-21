using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
   public interface IHistoRipository
    {
        IEnumerable<Historique> GetallHistorique();
        Historique Get(int id);
        int Create(Historique historique);
        int Update(int id, Historique historique);
        int Delete(int id);

 

    }
}