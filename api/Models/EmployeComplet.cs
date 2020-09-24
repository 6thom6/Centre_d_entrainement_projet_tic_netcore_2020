using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class EmployeComplet
    {
        public int Id_Employe { get; set; }
        public string Nom_Employe { get; set; }
        public string Statuts_Employe { get; set; }
        public DateTime? Date_Embauche { get; set; }
        public IEnumerable<Entrainement> entrainements { get; set; }
        public IEnumerable <Soins> soins { get; set; }
        


    }
}
