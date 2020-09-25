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
        internal static ChevalVaccination DALVaccinatinChevalToApi(this Vaccination vaccination)
        {
            return new ChevalVaccination()
            {

            };
        }
    }
}
