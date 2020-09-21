using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
   public interface IProprietaireRepository
    {
        IEnumerable<Proprietaire> GetallProprietaire();
        Proprietaire Get(int id);
        int Create(Proprietaire proprietaire);
        int Update(int id, Proprietaire proprietaire);
        int Delete(int id);

   

    }
}