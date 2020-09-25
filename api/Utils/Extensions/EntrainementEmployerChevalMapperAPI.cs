using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class EntrainementEmployerChevalMapperAPI
    {
        private static EntrainementRepository _entrainementRepository;

        public static EntrainementRepository entrainementRepository
        {
            get
            {
                return new EntrainementRepository();
            }
        }
        internal static EntrainementEmployeCheval DALEntrainementEmployeChevalToAPI (this Entrainement entrainement)
        {
            return new EntrainementEmployeCheval()
            {
                Nom_Cheval = entrainementRepository.GetNomChevalParEntrainement(entrainement.Id_Entrainement),
                Date_Entrainement = entrainement.Date_Entrainement,
                Nom_Employe = entrainementRepository.GetEmployeByEntrainementId(entrainement.Id_Entrainement),
                Age = entrainementRepository.GetAgeChevalParEntrainement(entrainement.Id_Entrainement),
                Sexe = entrainementRepository.GetSexParEntrainement(entrainement.Id_Entrainement),
                Plat = entrainement.Plat,
                Obstacle = entrainement.Obstacle,
                Marcheur = entrainement.Marcheur,
                Pre = entrainement.Pre,
                Duree = entrainement.Duree

            };
        }

    }
}
