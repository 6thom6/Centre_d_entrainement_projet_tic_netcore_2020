using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ChevalComplet
    {
        public int IdCheval { get; set; }
        public string NomCheval { get; set; }
        public string PereCheval { get; set; }
        public string MereCheval { get; set; }
        public string SortieProvisoire { get; set; }
        public string RaisonSortie { get; set; }
        public Proprietaire Proprietaire { get; set; }
        public int? IdSoins { get; set; }
        public int? Poids { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public string Sexe { get; set; }
        public IEnumerable<Entrainement> Entrainements { get; set; }
    }
}
