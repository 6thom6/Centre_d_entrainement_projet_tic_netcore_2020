CREATE PROCEDURE [dbo].[CreateEmploye]
	@Nom_Employe Nvarchar (50),
	@Date_Embauche date,
	@Statuts_Employe nvarchar (50)
AS
BEGIN
		INSERT INTO Employé (Nom_Employe, Date_Embauche, Statuts_Employe)
		VALUES (@Nom_Employe, @Date_Embauche, @Statuts_Employe)
END
