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
                Id_Cheval = (int)record["Id_Cheval"],
                NomCheval = (string)record["Nom_cheval"],
                PereCheval = (string)record["Pere_Cheval"],
                MereCheval = (string)record["Mere_Cheval"],
                SortieProvisoire = record["Sortie_Provisoire"] is DBNull ? null : (string)record["Sortie_Provisoire"],
                RaisonSortie = record["Raison_Sortie"] is DBNull ? null : (string)record["Raison_Sortie"],
                Id_Proprietaire = (int)record["Id_Proprietaire"],
                Id_Soins = record["Id_Soins"] == DBNull.Value ? null : (int?)record["Id_Soins"],
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
            //    Id_Courses = (int)record["Id_Courses"],
                Distance = (int)record["Distance"],
                Hippodrome = (string)record["Hippodrome"],
                Jockey = (string)record["Jockey"],
                Corde = (string)record["Corde"],
                Discipline = (string)record["Discipline"],
                Terrain = (string)record["Terrain"],
                Avis = record["Avis"] == DBNull.Value ? null :(string)record["Avis"],
                Poids_De_Course = (double)record["Poids_De_Course"],
                Date_Courses = (DateTime)record["Date_Courses"]
            };
        }
        internal static Employe EmployeToDal (this IDataRecord record)
        {
            return new Employe()
            {
                Id_Employe = (int)record["Id_Employe"],
                Nom_Employe = (string)record["Nom_Employe"],
                Date_Embauche = record["Date_Embauche"] == DBNull.Value ? null : (DateTime?)record["Date_Embauche"],
                Statuts_Employe = (string)record["Statuts_Employe"]
            };
        }
        internal static Entrainement EntrainementToDal (this IDataRecord record)
        {
            return new Entrainement()
            {
                Id_Entrainement = (int)record["Id_Entrainement"],
                Plat = record["Plat"] == DBNull.Value ? null : (string)record["Plat"],
                Obstacle = record["Obstacle"] == DBNull.Value ? null : (string)record["Obstacle"],
                Marcheur = record["Marcheur"] == DBNull.Value ? null : (string)record["Marcheur"],
                Duree = record["Duree"] == DBNull.Value ? null : (string)record["Duree"],
                Pre = record["Pre"] == DBNull.Value ? null : (string)record["Pre"],
                Date_Entrainement = (DateTime)record["Date_Entrainement"]

            };
        }
        internal static Historique HistoriqueToDal(this IDataRecord record)
        {
            return new Historique()
            {
                Id_Historique = (int)record["Id_Historique"],
                Id_Cheval = (int)record["Id_Cheval"],
                Debourage = record["Debourage"] == DBNull.Value ? null : (string)record["Debourage"],
                Pre_Entrainement = record["Pre_Entrainement"] == DBNull.Value ? null : (string)record["Pre_Entrainement"],
                Entraineur_Precedent = record["Entraineur_Precedent"] == DBNull.Value ? null : (string)record["Entraineur_Precedent"],
                Proprietaire_Precedent = record["Proprietaire_Precedent"] == DBNull.Value ? null : (string)record["Proprietaire_Precedent"],
                Elevage = record ["Elevage"] == DBNull.Value    ?   null : (string)record ["Elevage"]
            };
        }
        internal static Proprietaire ProprietaireToDal(this IDataRecord record)
        {
            return new Proprietaire()
            {
                Id_Proprietaire = (int)record["Id_Proprietaire"],
                Nom_Proprietaire = (string)record["Nom_Proprietaire"],
                Date_Arrivee = (DateTime)record["Date_Arrivee"],
                Dernier_Resultat = record ["Dernier_Resultat"] == DBNull.Value ? null : (string)record["Dernier_Resultat"]
            };
        }
        internal static Soins SoinsToDAl(this IDataRecord record)
        {
            return new Soins()
            {
                Id_Soins = (int)record["Id_Soins"],
                Id_Cheval = (int)record["Id_Cheval"],
                Id_Employe = (int)record["Id_Employe"],
                Vermifuge = record["Vermifuge"] == DBNull.Value ? null : (DateTime?)record["Vermifuge"],
                Marechal_Derniere_Visite = record["Marechal_Derniere_Visite"] == DBNull.Value ? null : (DateTime?)record["Marechal_Derniere_Visite"],
                Note_Libre = record["Note_Libre"] == DBNull.Value ? null : (string)record["Note_Libre"],
                Type_De_Soin = record["Type_De_Soin"] == DBNull.Value ? null : (string)record["Type_De_Soin"],
                Durree_Indisponibilite = record["Durree_Indisponibilite"] == DBNull.Value ? null : (string)record["Durree_Indisponibilite"],
                Date_De_Soin = record["Date_De_Soin"] == DBNull.Value ? null : (DateTime?)record["Date_De_Soin"],
                Alimentation = (string)record["Alimentation"],
                Complement_Alimentation = record ["Complement_Alimentation"] == DBNull.Value ? null : (String)record["Complement_Alimentation"],
            };

            
        }
        internal static Vaccination VaccinationToDal(this IDataRecord record)
        {
            return new Vaccination()
            {
                Id_Vaccination = (int)record["Id_Vaccination"],
                Nom_Vaccin = record["Nom_Vaccin"] == DBNull.Value ? null : (string)record["Nom_Vaccin"],
                Delai_Indisponibilite = record ["Delai_Indisponibilite"] == DBNull.Value ? null : (DateTime?)record["Delai_Indisponibilite"],
            };
        }

    }
}
