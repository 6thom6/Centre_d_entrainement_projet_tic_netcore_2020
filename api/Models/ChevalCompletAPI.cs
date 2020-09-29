using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ChevalCompletAPI
    {
        public int Id_Cheval { get; set; }
        public string Nom_Cheval { get; set; }
        public string PereCheval { get; set; }
        public string MereCheval { get; set; }
        public string SortieProvisoire { get; set; }
        public string RaisonSortie { get; set; }
        public ProprietaireSimpleAPI Proprietaire { get; set; }
        public int? Id_Soins { get; set; }
        public int? Poids { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public string Sexe { get; set; }
        public IEnumerable<Entrainement> Entrainements { get; set; }
        public IEnumerable<Employe> Employes { get; set; }
        public IEnumerable <Course> Courses { get; set; }
        public IEnumerable <Soins> Soinss { get; set; }
        public IEnumerable<Vaccination> Vaccinations { get; set; }
        public Historique Historique { get; set; }
    }
}
