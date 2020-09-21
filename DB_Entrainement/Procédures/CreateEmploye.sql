CREATE PROCEDURE [dbo].[CreateEmploye]
	@Nom_Employe Nvarchar (50),
	@Date_Embauche date,
	@Statuts_Employe nvarchar (max)
AS
BEGIN
		INSERT INTO Employe (Nom_Employe, Date_Embauche, Statuts_Employe)
		VALUES (@Nom_Employe, @Date_Embauche, @Statuts_Employe)
END
