using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
    interface IHistoRipository
    {
        void Create(Historique NouvelHistorique);
        void Delete(int idADelete);
        Historique Get(int idAChercher);
        List<Historique> GetallHistorique();
        void Update(Historique HistoriqueAModifier);
    }
}