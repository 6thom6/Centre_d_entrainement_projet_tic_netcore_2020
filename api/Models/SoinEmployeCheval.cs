using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class SoinEmployeCheval
    {
        public string Type_De_Soin { get; set; }
        public DateTime? Date_De_Soin { get; set; }
        public string Durree_Indisponibilite { get; set; }
        public string Nom_Employe { get; set; }
        public string Statuts_Employe { get; set; }
        public string Nom_Cheval { get; set; }
    }
}
