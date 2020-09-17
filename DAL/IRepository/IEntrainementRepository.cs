using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
    interface IEntrainementRepository
    {
        void Create(Entrainement NouvelEntrainement);
        void Delete(int idADelete);
        Entrainement Get(int idAChercher);
        List<Entrainement> GetallEntrainement();
        void Update(Entrainement EntrainementAModifier);
    }
}