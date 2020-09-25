using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ProprietaireSimple
    {
        public string Nom_Proprietaire { get; set; }
        public string Dernier_Resultat { get; set; }
        public DateTime Date_Arrivee { get; set; }

    }
}
