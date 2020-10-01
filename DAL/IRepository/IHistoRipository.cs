using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
   public interface IHistoRipository
    {
        IEnumerable<Historique> GetallHistorique();
        Historique Get(int id);
        int Create(Historique historique);
        int Update(int id, Historique historique);
        int Delete(int id);
        string GetSexeChevalParHisto(int id);
        int GetAgeChevalParHisto(int id);
        string GetRaceChevalParHisto(int id);
        string GetNomMereChevalParHisto(int id);
        string GetNomPereChevalParHisto(int id);
        string GetNomChevalParHisto(int id);
    }
}