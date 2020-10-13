using DAL.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DAL.IRepository
{
  interface IPeceRepository
  {
    IEnumerable <Pece> getByChevalId(int id) ;
    IEnumerable<Pece> getByEmployeId(int id);
    IEnumerable<Pece> getByEntrainementId(int id);
    IEnumerable<Pece> GetAll();
    int Create(Pece pece);
    int Update(Pece pece);
    int delete(Pece pece);


  }
}
