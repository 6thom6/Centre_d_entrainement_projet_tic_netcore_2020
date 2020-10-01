using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
   public interface ISoinsRepository
    {
        IEnumerable<Soins> GetallSoins();
        Soins GetById(int id);
        int Create(Soins Soins);
        int Update(int id, Soins Soin);
        int Delete(int id);
        int GetAgeCheval(int id);
        string GetSexCheval(int id);
        string GetStatutsEmploye(int id);
        string GetNomEmploye(int id);
        string GetNomCheval(int id);
    }
}