using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class EntrainementEmployeChevalAPI
    {
        public DateTime Date_Entrainement { get; set; }
        public string Nom_Employe { get; set; }
        public string Nom_Cheval { get; set; }
        public int Age { get; set; }
        public string Sexe { get; set; }
        public string Plat { get; set; }
        public string Obstacle { get; set; }
        public string Marcheur { get; set; }
        public string Pre { get; set; }
        public string Duree { get; set; }

    }
}
