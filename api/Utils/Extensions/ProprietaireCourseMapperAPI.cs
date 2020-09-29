using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class ProprietaireCourseMapperAPI
    {
        private static ProprietaireRepository _proprietaireRepository;
        public static ProprietaireRepository ProprietaireRepository
        {
            get
            {
                return new ProprietaireRepository();
            }
        }
        internal static ProprietaireCourseAPI DALProprietaireToAPI(this Proprietaire proprietaire)
        {
            return new ProprietaireCourseAPI()
            {
                Nom_Proprietaire = proprietaire.Nom_Proprietaire,
                Nom_Cheval = ProprietaireRepository.ChevalCouruParProprietaire(proprietaire.Id_Proprietaire),
                Distance = ProprietaireRepository.DistanceParProprio(proprietaire.Id_Proprietaire),
                Hippodrome = ProprietaireRepository.HippordromeParProprio(proprietaire.Id_Proprietaire),
                Jockey = ProprietaireRepository.JockeyParProprio(proprietaire.Id_Proprietaire),
                Corde = ProprietaireRepository.CordeParProprio(proprietaire.Id_Proprietaire),
                Discipline = ProprietaireRepository.DisciplineCourrueParProprio(proprietaire.Id_Proprietaire),
                Terrain = ProprietaireRepository.TerrainParProprio(proprietaire.Id_Proprietaire),
                Avis = ProprietaireRepository.AvisParProprio(proprietaire.Id_Proprietaire),
                Poids_De_Course = ProprietaireRepository.Poids_De_CourseParProprio(proprietaire.Id_Proprietaire),
                Date_Courses = ProprietaireRepository.Date_CoursesParProprio(proprietaire.Id_Proprietaire)


            };
        }
    }
}
