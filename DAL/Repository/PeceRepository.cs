using DAL.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tools.Database;

namespace DAL.Repository
{
  public class PeceRepository : IPeceRepository
  {
    private Connection _Connection;
    public PeceRepository(Connection connection)
    {
      _Connection = connection;
    }
    public int Create(Pece pece)
    {
      Command command = new Command("insert into [Participe_Entrainement_cheval_employé] values ( @Id_Entrainement, @Id_Cheval, @Id_Employe) ");
      command.AddParameter("Id_Entrainement", pece.Id_Entrainement);
      command.AddParameter("Id_Cheval", pece.Id_Cheval);
      command.AddParameter("Id_Employe", pece.Id_Employe);

      return  _Connection.ExecuteNonQuery(command);
      
    }

    public int delete(Pece pece)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Pece> GetAll()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Pece> getByChevalId(int id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Pece> getByEmployeId(int id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Pece> getByEntrainementId(int id)
    {
      throw new NotImplementedException();
    }

    public int Update(Pece pece)
    {
      throw new NotImplementedException();
    }
  }
}
