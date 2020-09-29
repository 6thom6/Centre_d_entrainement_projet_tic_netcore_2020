using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ChevalVaccinationAPI
    {
        public string Nom_Cheval { get; set; }
        public string Race { get; set; }
        public string Sexe { get; set; }
        public int Age { get; set; }
        public int Id_Vaccination { get; set; }
        public string Nom_Vaccin { get; set; }
        public DateTime? Delai_Indisponibilite { get; set; }
    }
}
