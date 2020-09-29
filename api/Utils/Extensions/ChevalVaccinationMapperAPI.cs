using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class ChevalVaccinationMapperAPI
    {
        private static ChevalRepository _ChevalRepository;
        public static ChevalRepository chevalRepository
        {
            get
            {
                return new ChevalRepository();
            }
        }
        internal static ChevalVaccinationAPI DalChevalVaccinToApi (this Cheval cheval)
        {
            return new ChevalVaccinationAPI()
            {
                Nom_Cheval = cheval.Nom_Cheval,
                Race = cheval.Race,
                Age = cheval.Age,
                Sexe = cheval.Sexe,
                Id_Vaccination = chevalRepository.GetIDVaccinParCheval(cheval.Id_Cheval),
                Nom_Vaccin = chevalRepository.GetVaccinParCheval(cheval.Id_Cheval),
                Delai_Indisponibilite = chevalRepository.GetDelaiVaccinParCheval(cheval.Id_Cheval)
            };
        }
    }
}
