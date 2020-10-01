using DAL.Models;
using System;
using System.Data;

namespace DAL.Repository.Extensions
{
    internal static class DataRecordExtensions
    {
        internal static Proprietaire ProprietaireSimpleToDal (this IDataRecord record)
        {
            return new Proprietaire()
            {
                Nom_Proprietaire = (string)record["Nom_Proprietaire"],
                Date_Arrivee = (DateTime)record["Date_Arrivee"],
            };
        }
        internal static Employe EmployeSimpleToDal (this IDataRecord record)
        {
            return new Employe()
            {
                Nom_Employe = (string)record["Nom_Employe"],
                Statuts_Employe = (string)record["Statuts_Employe"]
            };
        }

        internal static EmployeCheval EmployeChevalToDAL(this IDataRecord record)
        {
            return new EmployeCheval()
            {
                Nom_Employe = (string)record["Nom_Employe"],
                Nom_Cheval = (string)record["Nom_Cheval"],
                Statuts_Employe = (string)record["Statuts_Employe"]
            };
        }

        internal static Cheval ChevalToDAL(this IDataRecord record)
        {
            return new Cheval()
            {
                Id_Cheval = (int)record["Id_Cheval"],
                Nom_Cheval = (string)record["Nom_cheval"],
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
        internal static Entrainement EntrainementSimpleToDal(this IDataRecord record)
        {
            return new Entrainement()
            {
                Plat = record["Plat"] == DBNull.Value ? null : (string)record["Plat"],
                Obstacle = record["Obstacle"] == DBNull.Value ? null : (string)record["Obstacle"],
                Marcheur = record["Marcheur"] == DBNull.Value ? null : (string)record["Marcheur"],
                Duree = record["Duree"] == DBNull.Value ? null : (string)record["Duree"],
                Pre = record["Pre"] == DBNull.Value ? null : (string)record["Pre"],
                Date_Entrainement = (DateTime)record["Date_Entrainement"]

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
        internal static Historique HistoriqueSimpleToDal(this IDataRecord record)
        {
            return new Historique()
            {

                Debourage = record["Debourage"] == DBNull.Value ? null : (string)record["Debourage"],
                Pre_Entrainement = record["Pre_Entrainement"] == DBNull.Value ? null : (string)record["Pre_Entrainement"],
                Entraineur_Precedent = record["Entraineur_Precedent"] == DBNull.Value ? null : (string)record["Entraineur_Precedent"],
                Proprietaire_Precedent = record["Proprietaire_Precedent"] == DBNull.Value ? null : (string)record["Proprietaire_Precedent"],
                Elevage = record["Elevage"] == DBNull.Value ? null : (string)record["Elevage"]
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
        internal static Soins SoinsSimpleToDAl(this IDataRecord record)
        {
            return new Soins()
            {
                Vermifuge = record["Vermifuge"] == DBNull.Value ? null : (DateTime?)record["Vermifuge"],
                Marechal_Derniere_Visite = record["Marechal_Derniere_Visite"] == DBNull.Value ? null : (DateTime?)record["Marechal_Derniere_Visite"],
                Note_Libre = record["Note_Libre"] == DBNull.Value ? null : (string)record["Note_Libre"],
                Type_De_Soin = record["Type_De_Soin"] == DBNull.Value ? null : (string)record["Type_De_Soin"],
                Durree_Indisponibilite = record["Durree_Indisponibilite"] == DBNull.Value ? null : (string)record["Durree_Indisponibilite"],
                Date_De_Soin = record["Date_De_Soin"] == DBNull.Value ? null : (DateTime?)record["Date_De_Soin"],
                Alimentation = (string)record["Alimentation"],
                Complement_Alimentation = record["Complement_Alimentation"] == DBNull.Value ? null : (String)record["Complement_Alimentation"],
            };


        }
        internal static Soins SoinsParEmployeToDAl(this IDataRecord record)
        {
            return new Soins()
            {

                Note_Libre = record["Note_Libre"] == DBNull.Value ? null : (string)record["Note_Libre"],
                Type_De_Soin = record["Type_De_Soin"] == DBNull.Value ? null : (string)record["Type_De_Soin"],
                Durree_Indisponibilite = record["Durree_Indisponibilite"] == DBNull.Value ? null : (string)record["Durree_Indisponibilite"],
                Date_De_Soin = record["Date_De_Soin"] == DBNull.Value ? null : (DateTime?)record["Date_De_Soin"],
                Alimentation = (string)record["Alimentation"],
                Complement_Alimentation = record["Complement_Alimentation"] == DBNull.Value ? null : (String)record["Complement_Alimentation"],
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
        internal static Vaccination VaccinationSimpleToDal(this IDataRecord record)
        {
            return new Vaccination()
            {
                Nom_Vaccin = record["Nom_Vaccin"] == DBNull.Value ? null : (string)record["Nom_Vaccin"],
                Delai_Indisponibilite = record["Delai_Indisponibilite"] == DBNull.Value ? null : (DateTime?)record["Delai_Indisponibilite"],
            };
        }
        internal static ChevalCourse ChevalCourseToDal (this IDataRecord record)
        {
            return new ChevalCourse()
            {
                Date_Courses = (DateTime)record["Date_Courses"],
                Nom_Cheval = (string)record["Nom_Cheval"],
                Race = (string)record ["Race"],
                Age = (int)record["Age"],
                Sexe = (string)record["Sexe"],
                Distance = (int)record["Distance"],
                Hippodrome = (string)record["Hippodrome"],
                Jockey = (string)record["Jockey"],
                Corde = (string)record["Corde"],
                Discipline = (string)record["Discipline"],
                Terrain = (string)record["Terrain"],
                Avis = record["Avis"] == DBNull.Value ? null : (string)record["Avis"],
                Poids_De_Course = (double)record["Poids_De_Course"],
                Id_Courses = (int)record["Id_Courses"],

            };
        }
        internal static ChevalEntrainement ChevalEntrainementToDal (this IDataRecord record)
        {
            return new ChevalEntrainement()
            {
                Nom_Cheval = (string)record["Nom_Cheval"],
                Race = record["Race"].ToString(),
                Age = (int)record["Age"],
                Sexe = (string)record["Sexe"],
                Plat = record["Plat"] == DBNull.Value ? null : (string)record["Plat"],
                Obstacle = record["Obstacle"] == DBNull.Value ? null : (string)record["Obstacle"],
                Marcheur = record["Marcheur"] == DBNull.Value ? null : (string)record["Marcheur"],
                Duree = record["Duree"] == DBNull.Value ? null : (string)record["Duree"],
                Pre = record["Pre"] == DBNull.Value ? null : (string)record["Pre"],
                Date_Entrainement = (DateTime)record["Date_Entrainement"]
            };
        }
        internal static ChevalVaccination ChevalVaccinationToDal (this IDataRecord record)
        {
            return new ChevalVaccination()
            {
                Nom_Cheval = (string)record["Nom_Cheval"],
                Race = record["Race"].ToString(),
                Age = (int)record["Age"],
                Sexe = (string)record["Sexe"],
                Id_Vaccination = (int)record["Id_Vaccination"],
                Nom_Vaccin = record["Nom_Vaccin"] == DBNull.Value ? null : (string)record["Nom_Vaccin"],
                Delai_Indisponibilite = record["Delai_Indisponibilite"] == DBNull.Value ? null : (DateTime?)record["Delai_Indisponibilite"],

            };

        }
        internal static EntrainementEmployeCheval EntrainementEmployeChevalToDal(this IDataRecord record)
        {
            return new EntrainementEmployeCheval()
            {
                Nom_Cheval = (string)record["Nom_Cheval"],
                Age = (int)record["Age"],
                Sexe = (string)record["Sexe"],
                Nom_Employe = (string)record["Nom_Employe"],
                Plat = record["Plat"] == DBNull.Value ? null : (string)record["Plat"],
                Obstacle = record["Obstacle"] == DBNull.Value ? null : (string)record["Obstacle"],
                Marcheur = record["Marcheur"] == DBNull.Value ? null : (string)record["Marcheur"],
                Duree = record["Duree"] == DBNull.Value ? null : (string)record["Duree"],
                Pre = record["Pre"] == DBNull.Value ? null : (string)record["Pre"],
                Date_Entrainement = (DateTime)record["Date_Entrainement"],
                
            };
        }
        internal static ProprietaireCheval ProprietaireChevalTodDal(this IDataRecord record)
        {
            return new ProprietaireCheval()
            {
                Nom_Proprietaire = (string)record["Nom_Proprietaire"],
                Date_Arrivee = (DateTime)record["Date_Arrivee"],
                NomCheval = (string)record["Nom_cheval"],
                PereCheval = (string)record["Pere_Cheval"],
                MereCheval = (string)record["Mere_Cheval"],
                SortieProvisoire = record["Sortie_Provisoire"] is DBNull ? null : (string)record["Sortie_Provisoire"],
                RaisonSortie = record["Raison_Sortie"] is DBNull ? null : (string)record["Raison_Sortie"],
                Race = record["Race"].ToString(),
                Age = (int)record["Age"],
                Sexe = (string)record["Sexe"]
            };
        }
        internal static ProprietaireCourse ProprietaireCourseToDal(this IDataRecord record)
        {
            return new ProprietaireCourse()
            {
                Nom_Proprietaire = (string)record["Nom_Proprietaire"],
                Date_Courses = (DateTime)record["Date_Courses"],
                Nom_Cheval = (string)record["Nom_Cheval"],
                Distance = (int)record["Distance"],
                Hippodrome = (string)record["Hippodrome"],
                Jockey = (string)record["Jockey"],
                Corde = (string)record["Corde"],
                Discipline = (string)record["Discipline"],
                Terrain = (string)record["Terrain"],
                Avis = record["Avis"] == DBNull.Value ? null : (string)record["Avis"],
                Poids_De_Course = (double)record["Poids_De_Course"],

            };
        }
        internal static ProprietaireCourseCheval ProprietaireCourseChevalToDal(this IDataRecord record)
        {
            return new ProprietaireCourseCheval()
            {
                Nom_Proprietaire = (string)record["Nom_Proprietaire"],
                Date_Courses = (DateTime)record["Date_Courses"],
                Nom_Cheval = (string)record["Nom_Cheval"],
                Distance = (int)record["Distance"],
                Hippodrome = (string)record["Hippodrome"],
                Jockey = (string)record["Jockey"],
                Corde = (string)record["Corde"],
                Discipline = (string)record["Discipline"],
                Terrain = (string)record["Terrain"],
                Avis = record["Avis"] == DBNull.Value ? null : (string)record["Avis"],
                Poids_De_Course = (double)record["Poids_De_Course"],
                Race = record["Race"].ToString(),
                Age = (int)record["Age"],
                Sexe = (string)record["Sexe"]
            };
        }
        internal static SoinEmployeCheval SoinEmployeChevalToDal(this IDataRecord record)
        {
            return new SoinEmployeCheval()
            {
                Nom_Cheval = (string)record["Nom_Cheval"],
                Type_De_Soin = record["Type_De_Soin"] == DBNull.Value ? null : (string)record["Type_De_Soin"],
                Durree_Indisponibilite = record["Durree_Indisponibilite"] == DBNull.Value ? null : (string)record["Durree_Indisponibilite"],
                Date_De_Soin = record["Date_De_Soin"] == DBNull.Value ? null : (DateTime?)record["Date_De_Soin"],
                Nom_Employe = (string)record["Nom_Employe"],
                Statuts_Employe = (string)record["Statuts_Employe"],
            };
        }
         
        internal static SoinsCheval SoinsChevalToDal (this IDataRecord record)
        {
            return new SoinsCheval()
            {
                Nom_Cheval = (string)record["Nom_Cheval"],
                Vermifuge = record["Vermifuge"] == DBNull.Value ? null : (DateTime?)record["Vermifuge"],
                Marechal_Derniere_Visite = record["Marechal_Derniere_Visite"] == DBNull.Value ? null : (DateTime?)record["Marechal_Derniere_Visite"],
                Type_De_Soin = record["Type_De_Soin"] == DBNull.Value ? null : (string)record["Type_De_Soin"],
                Durree_Indisponibilite = record["Durree_Indisponibilite"] == DBNull.Value ? null : (string)record["Durree_Indisponibilite"],
                Date_De_Soin = record["Date_De_Soin"] == DBNull.Value ? null : (DateTime?)record["Date_De_Soin"],
                Alimentation = (string)record["Alimentation"],
                Complement_Alimentation = record["Complement_Alimentation"] == DBNull.Value ? null : (String)record["Complement_Alimentation"],
                Age = (int)record["Age"],
                Sexe = (string)record["Sexe"],
                

            };
        }
        internal static ChevalHistorique ChevalHistoriqueToDal (this IDataRecord record)
        {
            return new ChevalHistorique()
            {

                Debourage = record["Debourage"] == DBNull.Value ? null : (string)record["Debourage"],
                Pre_Entrainement = record["Pre_Entrainement"] == DBNull.Value ? null : (string)record["Pre_Entrainement"],
                Entraineur_Precedent = record["Entraineur_Precedent"] == DBNull.Value ? null : (string)record["Entraineur_Precedent"],
                Proprietaire_Precedent = record["Proprietaire_Precedent"] == DBNull.Value ? null : (string)record["Proprietaire_Precedent"],
                Elevage = record["Elevage"] == DBNull.Value ? null : (string)record["Elevage"],
                Nom_Cheval = (string)record["Nom_cheval"],
                Pere_Cheval = (string)record["Pere_Cheval"],
                Mere_Cheval = (string)record["Mere_Cheval"],
                Race = record["Race"].ToString(),
                Age = (int)record["Age"],
                Sexe = (string)record["Sexe"],

            };
        }
    }
}
