using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class HistoriqueChevalMapperAPI
    {
        private static HistoRipository _histoRipository;
        public static HistoRipository histoRipository
        {
            get
            {
                return new HistoRipository();
            }
        }
        internal static ChevalHistoriqueAPI DALHistoriqueChevalToAPI(this Historique historique)
        {
            return new ChevalHistoriqueAPI()
            {
                Nom_Cheval = histoRipository.GetNomChevalParHisto(historique.Id_Historique),
                Pere_Cheval = histoRipository.GetNomPereChevalParHisto(historique.Id_Historique),
                Mere_Cheval = histoRipository.GetNomMereChevalParHisto(historique.Id_Historique),
                Race = histoRipository.GetRaceChevalParHisto(historique.Id_Historique),
                Age = histoRipository.GetAgeChevalParHisto(historique.Id_Historique),
                Sexe = histoRipository.GetSexeChevalParHisto(historique.Id_Historique),
                Debourage = historique.Debourage,
                Pre_Entrainement = historique.Pre_Entrainement,
                Entraineur_Precedent = historique.Entraineur_Precedent,
                Proprietaire_Precedent = historique.Pre_Entrainement,
                Elevage = historique.Elevage
            };
        }


    }
}
