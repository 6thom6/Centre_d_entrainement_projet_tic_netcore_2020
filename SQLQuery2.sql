SELECT E.Id_Entrainement,
	   E.Date_Entrainement,
	   E.Plat,
	   E.Obstacle,
	   E.Marcheur,
	   E.Duree,
	   E.Pre
FROM Cheval C JOIN Participe_Entrainement_cheval_employé CE
		ON C.Id_Cheval = CE.Id_Cheval
	JOIN Entrainement E
		ON CE.Id_Entrainement = E.Id_Entrainement
WHERE C.Id_Cheval = 1

--SELECT S.Vermifuge,
--	...
--FROM Cheval C JOIN Soins S
--		ON C.Id_Cheval = S.Id_Cheval
--WHERE C.Id_Cheval = 1