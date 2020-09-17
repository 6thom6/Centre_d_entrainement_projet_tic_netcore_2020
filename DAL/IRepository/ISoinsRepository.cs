﻿using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
    interface ISoinsRepository
    {
        void Create(Soins NouveauSoins);
        void Delete(int idADelete);
        Soins Get(int idAChercher);
        List<Soins> GetallSoins();
        void Update(Soins SoinsAModifier);
    }
}