﻿using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class ProprietaireMapperAPI
    {
        private static ProprietaireRepository _proprietaireRepository;

        public static ProprietaireRepository ProprietaireRepository
        {
            get
            {
                return new ProprietaireRepository();
            }
        }
        internal static ProprietaireSimpleAPI DALProprietaireSimpleToAPI(this Proprietaire ProprietaireSimple)
        {
            return new ProprietaireSimpleAPI()
            {
                Nom_Proprietaire = ProprietaireSimple.Nom_Proprietaire,
                Date_Arrivee = ProprietaireSimple.Date_Arrivee,
            };
        }
    }
    
}
