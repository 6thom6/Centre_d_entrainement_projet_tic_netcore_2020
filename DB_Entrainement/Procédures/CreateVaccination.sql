CREATE PROCEDURE [dbo].[CreateVaccination]
	@Nom_vaccin NVARCHAR (50),
	@Delai_Indisponibilite DATETIME
AS
	BEGIN
		INSERT INTO Vaccination(Nom_vaccin,Delai_Indisponibilite)
		VALUES (@Nom_vaccin,@Delai_Indisponibilite)
	END
