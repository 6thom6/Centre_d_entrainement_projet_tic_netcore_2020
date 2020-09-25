using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
   internal static class SoinsChevalEmployeMapperAPI
    {
        private static SoinsRepository _soinsRepository;

        public static SoinsRepository soinsRepository
        {
            get
            {
                return new SoinsRepository();
            }
        }
        internal static SoinEmployeCheval DalSoinEmployeChevalToAPI (this Soins soins)
        {
            return new SoinEmployeCheval()
            {
                Nom_Cheval = soinsRepository.GetNomCheval(soins.Id_Soins??0),
                Type_De_Soin = soins.Type_De_Soin,
                Date_De_Soin = soins.Date_De_Soin,
                Durree_Indisponibilite = soins.Durree_Indisponibilite,
                Nom_Employe = soinsRepository.GetNomEmploye(soins.Id_Cheval),
                Statuts_Employe = soinsRepository.GetStatutsEmploye(soins.Id_Cheval)

            };
        }


    };
}
