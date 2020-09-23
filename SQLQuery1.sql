--SELECT C.Nom_cheval, E.Plat, E.Obstacle, E.Marcheur, E.Duree, E.Pre
--FROM Cheval C JOIN mym_Cheval_Entrainement CE
--	ON C.Id_Cheval = CE.MYM_ChevaliId_Cheval
--	JOIN Entrainement E
--	ON CE.MYM_Entrainementid_Entrainement = E.Id_Entrainement
--WHERE C.Id_Cheval = 1

SELECT P.Nom_Proprietaire
FROM Cheval C JOIN Proprietaire P
	ON C.Id_Proprietaire = P.Id_Proprietaire
WHERE C.Id_Cheval = 1