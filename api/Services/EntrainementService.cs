using DAL.IRepository;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
  public class EntrainementService

  {
    private PeceRepository peceRepository;
    private EntrainementRepository entrainementrepository;
    private ChevalRepository chevalrepository;
    private EmployeRepository employerepository;
    public EntrainementService(PeceRepository Prepo, EntrainementRepository Erepo, ChevalRepository Crepo, EmployeRepository Emprepo)
    {
      peceRepository = Prepo;
      entrainementrepository = Erepo;
      chevalrepository = Crepo;
      employerepository = Emprepo;

      
    }
    public int createEntrainement (Entrainement entrainement) 
      {
      return entrainementrepository.Create(entrainement);
      }

    public void associateEntrainementChevalEmploye(int Id_entrainement, int Id_cheval, int id_employe)
    {
      Pece pece = new Pece()
      {
        Id_Entrainement = Id_entrainement,
        Id_Cheval = Id_cheval,
        Id_Employe = id_employe
      };
      if (!(entrainementrepository.GetById(pece.Id_Entrainement) is null)
        &&
        !(chevalrepository.GetById(pece.Id_Cheval) is null)
        &&
        !(employerepository.GetById(pece.Id_Employe) is null))

        peceRepository.Create(pece);

    }
  }
}
