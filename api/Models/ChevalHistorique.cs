using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
   public class ChevalHistorique
    {
        public string Nom_Cheval { get; set; }
        public string PereCheval { get; set; }
        public string MereCheval { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public string Sexe { get; set; }
        public string Debourage { get; set; }
        public string Pre_Entrainement { get; set; }
        public string Entraineur_Precedent { get; set; }
        public string Proprietaire_Precedent { get; set; }
        public string Elevage { get; set; }


    }
}
