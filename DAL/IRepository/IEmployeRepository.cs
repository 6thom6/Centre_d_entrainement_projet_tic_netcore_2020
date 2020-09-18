using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
   public interface IEmployeRepository
    {
        IEnumerable<Employé> GetallEmploye();
        Employé GetById(int id);
        int Create(Employé NouvelEmploye);
        int Update(int di, Employé Employe);
        int Delete(int id);

    }
}