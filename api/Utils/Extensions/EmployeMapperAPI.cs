using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class EmployeMapperAPI
    {
        private static EmployeRepository _employeRepository;

        public static EmployeRepository EmployeRepository
        {
            get
            {
                return new EmployeRepository();
            }
        }
        internal static EmployeCompletAPI DALEmployeToAPI (this Employe employe)
        {
            return new EmployeCompletAPI()
            {
                Id_Employe = employe.Id_Employe,
                Nom_Employe = employe.Nom_Employe,
                Date_Embauche = employe.Date_Embauche,
                Statuts_Employe = employe.Statuts_Employe,
                entrainements = EmployeRepository.GetAllEntrainementById(employe.Id_Employe),
                soins = EmployeRepository.GetAllSoinsById(employe.Id_Employe),


            };
        }

    }
   


}
