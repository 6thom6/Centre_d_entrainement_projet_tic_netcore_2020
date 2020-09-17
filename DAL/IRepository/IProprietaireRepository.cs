﻿using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
    interface IProprietaireRepository
    {
        void Create(Proprietaire NouveauProprietaire);
        void Delete(int idADelete);
        Proprietaire Get(int idAChercher);
        List<Proprietaire> GetallProprietaire();
        void Update(Proprietaire EntrainementAModifier);
    }
}