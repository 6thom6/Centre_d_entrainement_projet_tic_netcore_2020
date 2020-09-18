using System.Collections.Generic;
using DAL.Models;

namespace DAL.IRepository
{
    public interface IChevalRepository
    {
        IEnumerable<Cheval> Get();
        Cheval GetById(int id);
        int Create(Cheval cheval);
        int Update(int id, Cheval cheval);
        int Delete(int id);
    }
}