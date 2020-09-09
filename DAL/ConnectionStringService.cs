using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public static class  ConnectionStringService
    {
        public static string ConnString { get; private set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Entrainement;Integrated Security=True;";
    }



}
