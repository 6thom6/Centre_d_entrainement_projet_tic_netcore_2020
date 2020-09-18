using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Employé
    {
        public int Id_Employe { get; set; }
        public string Nom_Employe  { get; set; }
        public string Statut_Employe { get; set; }
        public DateTime? Employe_Embauche { get; set; }

    }
}
