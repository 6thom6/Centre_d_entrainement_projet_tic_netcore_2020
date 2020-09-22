CREATE PROCEDURE [dbo].[CreateEntrainement]
	@Id_Employe int,
	@Cheval NVARCHAR (50),
	@Plat NVARCHAR (50),
	@Obstacle NVARCHAR (50),
	@Marcheur NVARCHAR (50),
	@Duree NVARCHAR (50),
	@Pre NVARCHAR (50),
	@Date_Entrainement DATE
AS
	
BEGIN
		INSERT INTO Entrainement (Id_Employe, Cheval,Plat,Obstacle,Marcheur,Duree,Pre,Date_Entrainement)
		VALUES (@Id_Employe, @Cheval, @Plat, @Obstacle,@Marcheur,@Duree,@Pre,@Date_Entrainement)
END