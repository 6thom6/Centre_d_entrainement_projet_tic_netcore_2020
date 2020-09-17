using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
    interface IEmployeRepository
    {
        void Create(Employé NouvelEmploye);
        void Delete(int idADelete);
        Employé Get(int idAChercher);
        List<Employé> GetallEmploye();
        void Update(Employé EmployéAModifier);
    }
}