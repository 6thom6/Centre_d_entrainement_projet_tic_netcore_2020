CREATE VIEW [dbo].[V_entrainementcomplet]
	AS select E.Date_Entrainement, em.Nom_Employe, c.Nom_cheval, c.Age, c.Sexe, E.Plat, e.Obstacle, e.Marcheur, e.Pre, e.Duree from Entrainement E left join Participe_Entrainement_cheval_employé PECE on e.Id_Entrainement = PECE.Id_Entrainement left join Cheval c on PECE.Id_Cheval = c.Id_Cheval left join Employe EM on PECE.Id_Employe = em.Id_Employe
