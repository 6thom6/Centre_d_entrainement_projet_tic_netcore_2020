using DAL.Models;
using System;
using System.Data;

namespace DAL.Repository.Extensions
{
    internal static class DataRecordExtensions
    {
        internal static Cheval ChevalToDAL(this IDataRecord record)
        {
            return new Cheval()
            {
                IdCheval = (int)record["Id_Cheval"],
                NomCheval = (string)record["Nom_cheval"],
                PereCheval = (string)record["Pere_Cheval"],
                MereCheval = (string)record["Mere_Cheval"],
                SortieProvisoire = record["Sortie_Provisoire"] is DBNull ? null : (string)record["Sortie_Provisoire"],
                RaisonSortie = record["Raison_Sortie"] is DBNull ? null : (string)record["Raison_Sortie"],
                IdProprietaire = (int)record["Id_Proprietaire"],
                IdSoins = record["Id_Soins"] == DBNull.Value ? null : (int?)record["Id_Soins"],
                Poids = record["Poids"] == DBNull.Value ? null : (int?)record["Poids"],
                Race = record["Race"].ToString(),
                Age = (int)record["Age"],
                Sexe = (string)record ["Sexe"]
            };
        }
        internal static Course CourseToDal(this IDataRecord record)
        {
            return new Course()
            {
                Id_Course = (int)record["Id_Course"],
                Distance = (int)record["Distance"],
                Hippodrome = (string)record["Hippodrome"],
                Jockey = (string)record["Jockey"],
                Corde = (string)record["Corde"],
                Discipline = (string)record["Discipline"],
                Terrain = (string)record["Terrain"],
                Avis = (string)record["Avis"],
                Poids_De_Course = (float)record["Poids_De_Course"],
                Date_Course = (DateTime)record["Date_Course"]
            };
        }
    }
}
