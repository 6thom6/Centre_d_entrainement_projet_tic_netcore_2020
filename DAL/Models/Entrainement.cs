using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Entrainement
    {
        public int Id_Entrainement { get; set; }
        public string Cheval { get; set; }
        public string Plat { get; set; }
        public string Obstacle { get; set; }
        public string Marcheur { get; set; }
        public string Pre { get; set; }
        public string Duree { get; set; }
        public int Id_Employe { get; set; }
        public DateTime Date_Entrainement { get; set; }
    }
}
