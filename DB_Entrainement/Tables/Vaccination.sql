CREATE TABLE [dbo].[Vaccination]
(
	[Id_vaccination] INT NOT NULL IDENTITY, 
    [Nom_vaccin] NVARCHAR(50) NULL, 
    [Delai_Indisponibilite] DATE NULL, 
    CONSTRAINT [PK_Vaccination] PRIMARY KEY ([Id_vaccination])
)
