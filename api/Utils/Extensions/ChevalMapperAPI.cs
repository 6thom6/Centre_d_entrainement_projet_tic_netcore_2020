using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class ChevalMapperAPI
    {
        private static ChevalRepository _chevalRepository;

        public static ChevalRepository chevalRepository
        {
            get
            {
                return new ChevalRepository();
            }
        }

        internal static Cheval DALChevalToAPI(this Cheval cheval)
        {
            return new Cheval()
            {
                Id_Cheval = cheval.Id_Cheval,
                Nom_Cheval = cheval.Nom_Cheval,
                PereCheval = cheval.PereCheval,
                MereCheval = cheval.MereCheval,
                SortieProvisoire = cheval.SortieProvisoire,
                Id_Proprietaire = cheval.Id_Proprietaire,
                RaisonSortie = cheval.RaisonSortie,
                Id_Soins = cheval.Id_Soins,
                Poids = cheval.Poids,
                Race = cheval.Race,
                Age = cheval.Age,
                Sexe = cheval.Sexe,
                //Entrainements = chevalRepository.GetAllEntrainementById(cheval.Id_Cheval),
                //Employes = chevalRepository.GetAllEmployeById(cheval.Id_Cheval),
                //Courses = chevalRepository.GetallCoursesById(cheval.Id_Cheval),
                //Soinss = chevalRepository.GetAllSoinsById(cheval.Id_Cheval),
                //Vaccinations= chevalRepository.GetAllVaccinationsById(cheval.Id_Cheval),
                //Historique = chevalRepository.Gethistorique(cheval.Id_Cheval)
            };
        }
    }
}
