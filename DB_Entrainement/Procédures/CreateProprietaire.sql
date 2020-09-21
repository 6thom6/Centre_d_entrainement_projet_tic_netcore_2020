CREATE PROCEDURE [dbo].[CreateProprietaire]
	@Nom_Proprietaire NVARCHAR (max),
	@Date_Arrivee date,
	@Dernier_Resultat NVARCHAR (50)
AS

BEGIN
	INSERT INTO Proprietaire (Nom_Proprietaire, Date_Arrivee, Dernier_Resultat)
	VALUES (@Nom_Proprietaire, @Date_Arrivee, @Dernier_Resultat)

END
