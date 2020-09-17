SELECT * 
FROm Vaccination v 
	JOIN mym_Vaccination_Cheval m 
	ON m.VaccinationId_Vaccination = v.Id_vaccination
WHERE m.ChevalId_Cheval = (SELECT Id_Cheval FROM Cheval WHERE Nom_cheval = 'khani')

Select * 
From 
