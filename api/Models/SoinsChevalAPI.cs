using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class SoinsChevalAPI
    {
        public string Nom_Cheval { get; set; }
        public string Type_De_Soin { get; set; }
        public DateTime? Date_De_Soin { get; set; }
        public string Durree_Indisponibilite { get; set; }
        public int Age { get; set; }
        public string Sexe { get; set; }
        public DateTime? Marechal_Derniere_Visite { get; set; }
        public DateTime? Vermifuge { get; set; }
        public string Alimentation { get; set; }
        public string Complement_Alimentation { get; set; }
    }
}
