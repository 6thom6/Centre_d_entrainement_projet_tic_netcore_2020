CREATE TABLE [dbo].[Entrainement]
(
	[Id_Entrainement] INT NOT NULL IDENTITY, 
    [Plat] NVARCHAR(50) NULL, 
    [Obstacle] NVARCHAR(50) NULL, 
    [Marcheur] NVARCHAR(50) NULL, 
    [Duree] NVARCHAR(50) NULL, 
    [Pre] NVARCHAR(50) NULL, 
    [Date_Entrainement] DATE NOT NULL, 
    CONSTRAINT [PK_Entrainement] PRIMARY KEY ([Id_Entrainement]),


)
