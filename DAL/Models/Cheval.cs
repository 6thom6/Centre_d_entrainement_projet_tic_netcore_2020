namespace DAL.Models
{
    public class Cheval
    {
        public int IdCheval { get; set; }
        public string NomCheval { get; set; }
        public string PereCheval { get; set; }
        public string MereCheval { get; set; }
        public string SortieProvisoire { get; set; }
        public string RaisonSortie { get; set; }
        public int IdProprietaire { get; set; }
        public int? IdSoins { get; set; }
        public int? Poids { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public string Sexe { get; set; }
    }
}
