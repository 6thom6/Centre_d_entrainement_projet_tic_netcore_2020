using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
    public interface IEntrainementRepository
    {
        IEnumerable<Entrainement> GetallEntrainement();
        Entrainement GetById(int id);
        int Create(Entrainement entrainement);
        int Update(int id, Entrainement entrainement);
        int Delete(int id);
        IEnumerable<EmployeCheval> GetAllEmployeAndChevalByEntrainementId(int id);
        IEnumerable<Employe> GetAllEmployeByEntrainementId(int id);
        string GetEmployeByEntrainementId(int id);
        string GetSexParEntrainement(int id);
        int GetAgeChevalParEntrainement(int id);
        string GetNomChevalParEntrainement(int id);
    }
}