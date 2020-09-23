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

        internal static ChevalComplet DALChevalToAPI(this Cheval cheval)
        {
            return new ChevalComplet()
            {
                Id_Cheval = cheval.Id_Cheval,
                NomCheval = cheval.NomCheval,
                PereCheval = cheval.PereCheval,
                MereCheval = cheval.MereCheval,
                SortieProvisoire = cheval.SortieProvisoire,
                RaisonSortie = cheval.RaisonSortie,
                Proprietaire = chevalRepository.GetProprietaire(cheval.Id_Proprietaire),
                Id_Soins = cheval.Id_Soins,
                Poids = cheval.Poids,
                Race = cheval.Race,
                Age = cheval.Age,
                Sexe = cheval.Sexe,
                Entrainements = chevalRepository.GetAllEntrainementById(cheval.Id_Cheval),
                Employes = chevalRepository.GetAllEmployeById(cheval.Id_Cheval),
                Courses = chevalRepository.GetallCoursesById(cheval.Id_Cheval)
            };
        }
    }
}
