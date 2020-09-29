using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class EmployeEntrainementChevalMapperAPI
    {
        private static EmployeRepository _employeRepository;
        public static EmployeRepository EmployeRepository
        {
            get
            {
                return new EmployeRepository();
            }
        }
        internal static EntrainementEmployeChevalAPI DALEmployeEntrainementChevalToAPI (this Employe employe)
        {
            return new EntrainementEmployeChevalAPI()
            {
                Date_Entrainement = EmployeRepository.DateEntrainementParEmploye(employe.Id_Employe) ,
                Nom_Employe = employe.Nom_Employe,
                Nom_Cheval = EmployeRepository.ChevalEntrainerParEmploye(employe.Id_Employe),
                Age = EmployeRepository.ChevalEntrainerAgeParEmploye(employe.Id_Employe),
                Sexe = EmployeRepository.ChevalEntrainerSexeParEmploye(employe.Id_Employe),
                Plat = EmployeRepository.ChevalEntrainementPlatParEmploye(employe.Id_Employe),
                Obstacle = EmployeRepository.ChevalEntrainementObstacleParEmploye(employe.Id_Employe),
                Marcheur = EmployeRepository.ChevalEntrainementMarcheurParEmploye(employe.Id_Employe),
                Pre = EmployeRepository.ChevalEntrainementPreParEmploye(employe.Id_Employe),
                Duree = EmployeRepository.ChevalEntrainementDureeParEmploye(employe.Id_Employe)

                
            };
        }
    }
}
