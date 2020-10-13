using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL.IRepository
{
   public interface IProprietaireRepository
    {
        Proprietaire Get(int id);
        int Create(Proprietaire proprietaire);
        int Update(int id, Proprietaire proprietaire);
        int Delete(int id);
        string SexeChevParProprio(int id);
        int AgeChevauxParProprio(int id);
        string RaceParProprio(int id);
        string RaisonSortieProviParProprio(int id);
        string SortieProvisoirParProprio(int id);
        string MereChevalParProprio(int id);
        string ChevauxParProprio(int id);
        string PereChevalParProprio(int id);
        DateTime Date_CoursesParProprio(int id);
        double Poids_De_CourseParProprio(int id);
        string AvisParProprio(int id);
        string TerrainParProprio(int id);
        string DisciplineParProprio(int id);
        string CordeParProprio(int id);
        string JockeyParProprio(int id);
        string HippordromeParProprio(int id);
        int DistanceParProprio(int id);
        string DisciplineCourrueParProprio(int id);
        string ChevalCouruParProprietaire(int id);
        Proprietaire ProprietaireParChevalId(int id, Proprietaire proprietaire);
        IEnumerable<ProprietaireCheval> proprietaireChevals(int id);
        IEnumerable<ProprietaireCourse> proprietaireCourses(int id);
        IEnumerable<SoinsCheval> soinChevals(int id);
        IEnumerable<ProprietaireCheval> GetallProprietaire();
  }
}
