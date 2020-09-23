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
                IdCheval = cheval.IdCheval,
                NomCheval = cheval.NomCheval,
                PereCheval = cheval.PereCheval,
                MereCheval = cheval.MereCheval,
                SortieProvisoire = cheval.SortieProvisoire,
                RaisonSortie = cheval.RaisonSortie,
                Proprietaire = chevalRepository.GetProprietaire(cheval.IdProprietaire),
                IdSoins = cheval.IdSoins,
                Poids = cheval.Poids,
                Race = cheval.Race,
                Age = cheval.Age,
                Sexe = cheval.Sexe,
                Entrainements = chevalRepository.GetAllEntrainementById(cheval.IdCheval)
            };
        }
    }
}
