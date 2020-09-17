CREATE TABLE [dbo].[Proprietaire]
(
	[Id_Proprietaire] INT NOT NULL IDENTITY, 
    [Nom_Proprietaire] NVARCHAR(MAX) NOT NULL, 
    [Date_Arrivee] DATE NOT NULL, 
    [Dernier_Resultat] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_Proprietaire] PRIMARY KEY ([Id_Proprietaire])

)
