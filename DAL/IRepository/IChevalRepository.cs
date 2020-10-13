using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.IRepository
{
    public interface IChevalRepository
    {
        IEnumerable<Cheval> Get();
        Cheval GetById(int id);
        int Create(Cheval cheval);
        int Update(int id, Cheval cheval);
        int Delete(int id);
        string GetObstacleParCheval(int id);
        string GetPlatParCheval(int id);
        string GetMarcheurParCheval(int id);
        string GetPreParCheval(int id);
        string GetDureeParCheval(int id);
        DateTime GetDateEntrainementParCheval(int id);
        DateTime GetDateCourseParCheval(int id);
        DateTime GetDateSoinsParCheval(int id);
        DateTime GetDateVermifugeParCheval(int id);
        DateTime GetDateMarechalParCheval(int id);
        string GetTypeDeSoinsParCheval(int id);
        string GetNoteLibreDeSoinsParCheval(int id);
        string GetAlimentationParCheval(int id);
        string GetDureeIndisponibiliteParCheval(int id);
        string GetHippodromeCourseParCheval(int id);
        int GetIdCourseParCheval(int id);
        string GetCordeCourseParCheval(int id);
        string GetPre_EntrainementChevalParcheval(int id);
        string GetDebourrageChevalParcheval(int id);
        string GetProprietaire_PrecedentCheval(int id);
        string GetElevageCheval(int id);
        int GetIDVaccinParCheval(int id);
        string GetVaccinParCheval(int id);
        DateTime GetDelaiVaccinParCheval(int id);
        float GetPoidsDeCourseParCheval(int id);
        string GetJockeyParCheval(int id);
        string GetAvisCourseParCheval(int id);
        string GetDisciplineCourseParCheval(int id);
        int GetDistanceCourseParCheval(int id);
        string GetTerrainCourseParCheval(int id);
        IEnumerable<SoinsCheval> SoinsParCheval(int id);
        IEnumerable<ChevalEntrainement> chevalEntrainements(int id);
        IEnumerable<SoinEmployeCheval> soinEmployeChevals(int id);
        IEnumerable<EmployeCheval> EntrainementEmployeChevals(int id);
        IEnumerable<ChevalVaccination> chevalVaccinations(int id);
        IEnumerable<ChevalCourse> chevalCourses(int id);
        IEnumerable<ChevalHistorique> chevalHistoriques(int id);
        IEnumerable<ProprietaireCheval> proprietaireChevals(int id);
    string GetproprietaireParCheval(int id);
  }
}
