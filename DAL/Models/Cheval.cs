namespace DAL.Models
{
    public class Cheval
    {
        public int Id_Cheval { get; set; }
        public string Nom_Cheval { get; set; }
        public string PereCheval { get; set; }
        public string MereCheval { get; set; }
        public string SortieProvisoire { get; set; }
        public string RaisonSortie { get; set; }
        public int? Id_Proprietaire { get; set; }
        public int? Id_Soins { get; set; }
        public int? Poids { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public string Sexe { get; set; }
    }
}
