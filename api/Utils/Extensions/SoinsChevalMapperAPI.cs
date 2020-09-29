using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class SoinsChevalMapperAPI
    {
        private static SoinsRepository _soinsRepository;

        public static SoinsRepository soinsRepository
        {
            get
            {
                return new SoinsRepository();
            }
        }
        internal static SoinsChevalAPI DalSoinsChevalToAPI(this Soins soins)
        {
            return new SoinsChevalAPI()
            {
               Nom_Cheval = soinsRepository.GetNomCheval(soins.Id_Soins ?? 0),
               Age = soinsRepository.GetAgeCheval(soins.Id_Soins??0),
               Sexe = soinsRepository.GetSexCheval(soins.Id_Soins??0),
               Type_De_Soin = soins.Type_De_Soin,
               Date_De_Soin = soins.Date_De_Soin,
               Durree_Indisponibilite = soins.Durree_Indisponibilite,
               Marechal_Derniere_Visite = soins.Marechal_Derniere_Visite,
               Vermifuge = soins.Vermifuge,
               Alimentation = soins.Alimentation,
               Complement_Alimentation = soins.Complement_Alimentation,
              
            };
        }

    }
}
