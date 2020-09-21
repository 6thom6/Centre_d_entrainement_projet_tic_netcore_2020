using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Employe
    {
        public int Id_Employe { get; set; }
        public string Nom_Employe { get; set; }
        public string Statuts_Employe { get; set; }
        public DateTime? Date_Embauche { get; set; }

    }
}
