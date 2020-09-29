using api.Models;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Utils.Extensions
{
    internal static class ChevalCourseMapperAPI
    {
        private static ChevalRepository _chevalRepository;
        public static ChevalRepository chevalRepository
        {
            get
            {
                return new ChevalRepository();
            }
        }
        internal static ChevalCourseAPI DalChevalCourseToApi(this Cheval cheval)
        {
            return new ChevalCourseAPI()
            {
                Date_Courses = chevalRepository.GetDateCourseParCheval(cheval.Id_Cheval),
                Nom_Cheval = cheval.Nom_Cheval,
                Race = cheval.Race,
                Sexe = cheval.Sexe,
                Age = cheval.Age,
                Id_Courses = chevalRepository.GetIdCourseParCheval (cheval.Id_Cheval),
                Discipline = chevalRepository.GetDisciplineCourseParCheval(cheval.Id_Cheval),
                Distance = chevalRepository.GetDistanceCourseParCheval(cheval.Id_Cheval),
                Hippodrome = chevalRepository.GetHippodromeCourseParCheval(cheval.Id_Cheval),
                Jockey = chevalRepository.GetJockeyParCheval(cheval.Id_Cheval),
                Poids_De_Course = chevalRepository.GetPoidsDeCourseParCheval(cheval.Id_Cheval),
                Terrain = chevalRepository.GetTerrainCourseParCheval(cheval.Id_Cheval),
                Avis = chevalRepository.GetAvisCourseParCheval(cheval.Id_Cheval),
                Corde = chevalRepository.GetCordeCourseParCheval(cheval.Id_Cheval)
            };
        }
    }
}
