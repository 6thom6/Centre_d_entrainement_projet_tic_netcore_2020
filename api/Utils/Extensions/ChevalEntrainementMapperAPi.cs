using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class ChevalEntrainementMapperAPi
    {
        private static ChevalRepository _ChevalRepository;

        public static ChevalRepository chevalRepository
        {
            get
            {
                return new ChevalRepository();
            }
        }
        internal static ChevalEntrainementAPI DALChevalHistoToAPI(this Cheval cheval)
        {
            return new ChevalEntrainementAPI()
            {
               Date_Entrainement = chevalRepository.GetDateEntrainementParCheval(cheval.Id_Cheval),
                Nom_Cheval = cheval.Nom_Cheval,
                Race = cheval.Race,
                Sexe = cheval.Sexe,
                Age = cheval.Age,
                Plat = chevalRepository.GetPlatParCheval(cheval.Id_Cheval),
                Obstacle = chevalRepository.GetObstacleParCheval(cheval.Id_Cheval),
                Marcheur = chevalRepository.GetMarcheurParCheval(cheval.Id_Cheval),
                Pre = chevalRepository.GetPreParCheval(cheval.Id_Cheval),
                Duree = chevalRepository.GetDureeParCheval(cheval.Id_Cheval),
               
            };
        }
    }
    
}
