CREATE PROCEDURE [dbo].[CreateHistorique]
	@Id_Cheval int,
	@Debourage NVARCHAR (50),
	@Pre_Entrainement NVARCHAR (50),
	@Entraineur_Precedent NVARCHAR (50),
	@Proprietaire_Precedent NVARCHAR (50)
AS
BEGIN
	INSERT INTO Historique (Id_Cheval, Debourage, Pre_Entrainement, Entraineur_precedent, Proprietaire_precedent)
	VALUES (@Id_Cheval, @Debourage,@Pre_Entrainement,@Entraineur_Precedent,@Proprietaire_Precedent)

END
