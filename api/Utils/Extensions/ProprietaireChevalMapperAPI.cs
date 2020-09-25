using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class ProprietaireChevalMapperAPI
    {
        private static ProprietaireRepository _proprietaireRepository;

        public static ProprietaireRepository proprietaireRepository
        {
            get
            {
                return new ProprietaireRepository();
            }
        }

        internal static ProprietaireCheval DALProprietaireChevalToAPI(this Proprietaire proprietaire)
        {
            return new ProprietaireCheval()
            {
                Nom_Proprietaire = proprietaire.Nom_Proprietaire,
                Date_Arrivee = proprietaire.Date_Arrivee,
                NomCheval = proprietaireRepository.ChevauxParProprio(proprietaire.Id_Proprietaire),
                PereCheval = proprietaireRepository.PereChevalParProprio(proprietaire.Id_Proprietaire),
                MereCheval = proprietaireRepository.MereChevalParProprio(proprietaire.Id_Proprietaire),
                SortieProvisoire = proprietaireRepository.SortieProvisoirParProprio(proprietaire.Id_Proprietaire),
                RaisonSortie = proprietaireRepository.RaisonSortieProviParProprio(proprietaire.Id_Proprietaire),
                Race = proprietaireRepository.RaceParProprio(proprietaire.Id_Proprietaire),
                Age = proprietaireRepository.AgeChevauxParProprio(proprietaire.Id_Proprietaire),
                Sexe = proprietaireRepository.SexeChevParProprio(proprietaire.Id_Proprietaire)

            };
        }

    }
}
