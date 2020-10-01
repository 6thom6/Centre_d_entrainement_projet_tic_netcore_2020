using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ChevalEntrainement
    {
        public string Nom_Employe { get; set; }
        public DateTime Date_Entrainement { get; set; }
        public string Nom_Cheval { get; set; }
        public string Race { get; set; }
        public string Sexe { get; set; }
        public int Age { get; set; }
        public string Plat { get; set; }
        public string Obstacle { get; set; }
        public string Marcheur { get; set; }
        public string Pre { get; set; }
        public string Duree { get; set; }
    }
}
