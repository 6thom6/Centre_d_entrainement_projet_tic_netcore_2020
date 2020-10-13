using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class ChevalComplet
  {
    public int Id_Cheval { get; set; }
    public string Nom_Cheval { get; set; }
    public string PereCheval { get; set; }
    public string MereCheval { get; set; }
    public string SortieProvisoire { get; set; }
    public string RaisonSortie { get; set; }
    public int Id_Proprietaire { get; set; }
    public int? Id_Soins { get; set; }
    public int? Poids { get; set; }
    public string Race { get; set; }
    private int _Age;
    public int Age
    {
      get { return DateTime.Now.Year - _Age; }
    }
    public int AnneeDeNaissance {
      get => _Age;
      set => _Age = value; }
    public string Sexe { get; set; }
  
}
}
