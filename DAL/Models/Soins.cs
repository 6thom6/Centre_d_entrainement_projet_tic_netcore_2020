using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Soins
    {
        public int? Id_Soins { get; set; }
        public int Id_Cheval { get; set; }
        public int? Id_Employe { get; set; }
        public string Alimentation { get; set; }
        public string Complement_Alimentation { get; set; }
        public DateTime? Marechal_Derniere_Visite { get; set; }
        public DateTime? Vermifuge { get; set; }
        public string Note_Libre { get; set; }
        public string Type_De_Soin { get; set; }
        public string Durree_Indisponibilite { get; set; }
        public DateTime? Date_De_Soin { get; set; }


    }
}
