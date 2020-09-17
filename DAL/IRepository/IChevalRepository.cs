using System.Collections.Generic;
using DAL.Models;

namespace DAL.IRepository
{
    public interface IChevalRepository
    {
        void Create(Cheval NouveauCheval);
        void Delete(int idADelete);
        List<Cheval> Get();
        Cheval GetById(int idAChercher);
        void Update(Cheval ChevalAModifier);

    }
}