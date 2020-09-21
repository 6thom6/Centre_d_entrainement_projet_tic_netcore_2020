CREATE TABLE [dbo].[Employe]
(
	[Id_Employe] INT NOT NULL IDENTITY, 
    [Nom_Employe] NVARCHAR(50) NOT NULL, 
    [Date_Embauche] DATE NULL, 
    [Statuts_Employe] NVARCHAR(max) NOT NULL, 
    CONSTRAINT [PK_Employe] PRIMARY KEY ([Id_Employe]), 


)
