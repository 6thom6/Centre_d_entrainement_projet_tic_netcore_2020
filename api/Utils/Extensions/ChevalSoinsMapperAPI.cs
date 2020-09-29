using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class ChevalSoinsMapperAPI
    {
        private static ChevalRepository _chevalRepository;
        public static ChevalRepository chevalRepository
        {
            get
            {
                return new ChevalRepository();
            }
        }
        internal static SoinsChevalAPI DalChevalSoinToAPI (this Cheval cheval)
        {
            return new SoinsChevalAPI()
            {
                Nom_Cheval = cheval.Nom_Cheval,
                Age = cheval.Age,
                Sexe = cheval.Sexe,
                Type_De_Soin = chevalRepository.GetTypeDeSoinsParCheval(cheval.Id_Cheval),
                Vermifuge = chevalRepository.GetDateVermifugeParCheval(cheval.Id_Cheval),
                Marechal_Derniere_Visite = chevalRepository.GetDateMarechalParCheval(cheval.Id_Cheval),
                Date_De_Soin = chevalRepository.GetDateSoinsParCheval(cheval.Id_Cheval),
                Alimentation = chevalRepository.GetAlimentationParCheval(cheval.Id_Cheval),
                Complement_Alimentation = chevalRepository.GetComplementAlimentationParCheval(cheval.Id_Cheval),
                Durree_Indisponibilite = chevalRepository.GetDureeIndisponibiliteParCheval(cheval.Id_Cheval)

            };
        }
    }
}
