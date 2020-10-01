using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ChevalVaccination
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
