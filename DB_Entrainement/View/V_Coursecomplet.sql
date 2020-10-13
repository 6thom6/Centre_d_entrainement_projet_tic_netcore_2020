CREATE VIEW [dbo].[V_Coursecomplet]
	AS SELECT co.Id_Courses, CO.Date_Courses, c.Nom_cheval, c.Age, c.Sexe,c.Race , CO.Discipline, co.Distance, co.Hippodrome, co.Jockey, co.Poids_De_Course, co.Terrain, co.Corde, co.Avis from Cheval C join mym_Course_cheval mym on c.Id_Cheval = mym.ChevalId_Cheval join Course CO on mym.CoursesId_Course = CO.Id_Courses
