using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class EmployeChevalMapperAPI
    {
        private static EmployeRepository _EmployeRepository;
        public static EmployeRepository employeRepository
        {
            get
            {
                return new EmployeRepository();
            }
        }
        internal static EmployeChevalAPI DalEmployeChevalToApi(this Employe employe)
        {
            return new EmployeChevalAPI()
            {
                Nom_Employe = employe.Nom_Employe,
                Statuts_Employe = employe.Statuts_Employe,
                Nom_Cheval = employeRepository.NomChevalParEmploye(employe.Id_Employe)
            };
        }
    }
}
