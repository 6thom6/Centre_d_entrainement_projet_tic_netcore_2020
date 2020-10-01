using DAL.Models;
using System;
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
        int ChevalEntrainerAgeParEmploye(int id);
        string ChevalEntrainerSexeParEmploye(int id);
        string ChevalEntrainerParEmploye(int id);
        string ChevalEntrainementDureeParEmploye(int id);
        string ChevalEntrainementPreParEmploye(int id);
        string ChevalEntrainementMarcheurParEmploye(int id);
        string ChevalEntrainementObstacleParEmploye(int id);
        string ChevalEntrainementPlatParEmploye(int id);
        string ChevalEntrainementAgeParEmploye(int id);
        DateTime DateEntrainementParEmploye(int id);
        IEnumerable<Cheval> ChevalParEmploye(int id);
        IEnumerable<Soins> GetAllSoinsById(int id);
        IEnumerable<Entrainement> GetAllEntrainementById(int id);
        string NomChevalParEmploye(int id);
    }
}