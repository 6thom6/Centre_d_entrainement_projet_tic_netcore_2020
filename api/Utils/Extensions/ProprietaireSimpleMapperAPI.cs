using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class ProprietaireSimpleMapperAPI
    {
        private static ProprietaireRepository _ProprietaireRepository;

        public static ProprietaireRepository proprietaireRepository
        {
            get
            {
                return new ProprietaireRepository();
            }
        }
        internal static ProprietaireSimpleAPI DALProprietaireToAPI(this Proprietaire proprietaire)
        {
            return new ProprietaireSimpleAPI()
            {
                Nom_Proprietaire = proprietaire.Nom_Proprietaire,
                Date_Arrivee = proprietaire.Date_Arrivee,

            };
        }
    }

}
