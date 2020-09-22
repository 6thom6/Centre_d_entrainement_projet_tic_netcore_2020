using System;
using System.Collections.Generic;
using System.Text;
using Tools.Database;

namespace DAL.Repository
{
    public class MYMChevalEntrainementRepository
    {
        private static Connection _connection;

        public MYMChevalEntrainementRepository(Connection connection)
        {
            _connection = connection;
        }


    }
}
