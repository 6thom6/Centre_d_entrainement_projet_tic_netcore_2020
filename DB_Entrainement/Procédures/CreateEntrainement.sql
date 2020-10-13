CREATE PROCEDURE [dbo].[CreateEntrainement]
	@Plat NVARCHAR (50),
	@Obstacle NVARCHAR (50),
	@Marcheur NVARCHAR (50),
	@Duree NVARCHAR (50),
	@Pre NVARCHAR (50),
	@Date_Entrainement DATE
AS
	
BEGIN
		INSERT INTO Entrainement (Plat,Obstacle,Marcheur,Duree,Pre,Date_Entrainement)
    OUTPUT inserted.Id_Entrainement
		VALUES (@Plat, @Obstacle,@Marcheur,@Duree,@Pre,@Date_Entrainement)
END
