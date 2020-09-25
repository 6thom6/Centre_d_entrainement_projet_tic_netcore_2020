using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class EntrainementEmployer
    {
        public string Nom_Employe { get; set; }
        public string Statuts_Employe { get; set; }
        public IEnumerable<Entrainement> Entrainements { get; set; }

    }
}
