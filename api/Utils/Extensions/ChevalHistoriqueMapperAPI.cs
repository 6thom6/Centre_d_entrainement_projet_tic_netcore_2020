using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class ChevalHistoriqueMapperAPI
    {
        private static ChevalRepository _ChevalRepository;

        public static ChevalRepository chevalRepository
        {
            get
            {
                return new ChevalRepository();
            }
        }
        internal static ChevalHistoriqueAPI DALChevalSoinsToAPI(this Cheval cheval)
        {
            return new ChevalHistoriqueAPI()
            {
                Nom_Cheval = cheval.Nom_Cheval,
                Pere_Cheval = cheval.PereCheval,
                Mere_Cheval = cheval.MereCheval,
                Race = cheval.Race,
                Age = cheval.Age,
                Sexe = cheval.Sexe,
                Debourage = chevalRepository.GetDebourrageChevalParcheval(cheval.Id_Cheval),
                Pre_Entrainement = chevalRepository.GetPre_EntrainementChevalParcheval(cheval.Id_Cheval),
                Entraineur_Precedent = chevalRepository.GetEntraineur_PrecedentChevalParcheval(cheval.Id_Cheval),
                Proprietaire_Precedent = chevalRepository.GetProprietaire_PrecedentCheval(cheval.Id_Cheval),
                Elevage = chevalRepository.GetElevageCheval(cheval.Id_Cheval)
            };
        }
    }
}
