using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class VaccinationChevalMapper
    {
        private static VaccinationRepository _vaccinationRepository;
        public static VaccinationRepository VaccinationRepository
        {
            get
            {
                return new VaccinationRepository();
            }
        }
        internal static ChevalVaccinationAPI DALVaccinatinChevalToApi(this Vaccination vaccination)
        {
            return new ChevalVaccinationAPI()
            {
                Nom_Cheval = VaccinationRepository.GetNomChevalVaccin(vaccination.Id_Vaccination),
                Race = VaccinationRepository.GetRaceChevalVaccin(vaccination.Id_Vaccination),
                Age = VaccinationRepository.GetAgeChevalParVaccin(vaccination.Id_Vaccination),
                Sexe = VaccinationRepository.GetSexeChevalVaccin(vaccination.Id_Vaccination),
                Id_Vaccination = vaccination.Id_Vaccination,
                Nom_Vaccin = vaccination.Nom_Vaccin,
                Delai_Indisponibilite = vaccination.Delai_Indisponibilite
                


            };
        }
    }
}
