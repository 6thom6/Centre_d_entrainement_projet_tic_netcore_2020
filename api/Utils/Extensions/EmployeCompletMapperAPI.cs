using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class EmployeCompletMapperAPI
    {
        private static EmployeRepository _employeRepository;
        public static EmployeRepository EmployeRepository
        {
            get
            {
                return new EmployeRepository();
            }
        }
        internal static EmployeComplet DALEmployerCompletToAPi(this Employe employe)
        {
            return new EmployeComplet()
            {
                Id_Employe = employe.Id_Employe,
                Nom_Employe = employe.Nom_Employe,
                Statuts_Employe = employe.Statuts_Employe,
                Date_Embauche = employe.Date_Embauche,

            };
        }
            
    }
}
