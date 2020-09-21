using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
   public interface IEmployeRepository
    {
        IEnumerable<Employe> GetallEmploye();
        Employe GetById(int id);
        int Create(Employe NouvelEmploye);
        int Update(int id, Employe Employe);
        int Delete(int id);

    }
}