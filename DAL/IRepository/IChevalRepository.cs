﻿using System;
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
        string GetPre_EntrainementChevalParHisto(int id);
        string GetDebourrageChevalParHisto(int id);
        string GetProprietaire_PrecedentCheval(int id);
        string GetElevageCheval(int id);
        int GetIDVaccinParCheval(int id);
        string GetVaccinParCheval(int id);
        DateTime GetDelaiVaccinParCheval(int id);
        float GetPoidsDeCourseParCheval(int id);
        string GetJockeyParCheval(int id);
        string GetAvisCourseParCheval(int id);
        string GetTerrainCourseParCheval(Cheval id);
        string GetDisciplineCourseParCheval(int id);
        int GetDistanceCourseParCheval(int id);
    }
}