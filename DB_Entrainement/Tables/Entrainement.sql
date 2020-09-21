CREATE TABLE [dbo].[Entrainement]
(
	[Id_Entainement] INT NOT NULL IDENTITY, 
    [Id_Employe] INT NOT NULL,
    [Cheval] NVARCHAR(50) NOT NULL, 
    [Plat] NVARCHAR(50) NULL, 
    [Obstacle] NVARCHAR(50) NULL, 
    [Marcheur] NVARCHAR(50) NULL, 
    [Duree] NVARCHAR(50) NULL, 
    [Pre] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_Entrainement] PRIMARY KEY ([Id_Entainement]), 


)
