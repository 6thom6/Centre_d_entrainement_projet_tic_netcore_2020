using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
   public interface IVaccinationRepository
    {
        IEnumerable<Vaccination> GetallVaccination();
        Vaccination GetById(int id);
        int Update(int id, Vaccination vaccination);
        int Create(Vaccination vaccination);
        int Delete(int id);



    }
}