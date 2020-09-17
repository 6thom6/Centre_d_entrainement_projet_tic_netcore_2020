CREATE TABLE [dbo].[Employé]
(
	[Id_Employe] INT NOT NULL IDENTITY, 
    [Nom_Employe] NVARCHAR(50) NOT NULL, 
    [Date_Embauche] DATE NULL, 
    [Statuts_Employe] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Employé] PRIMARY KEY ([Id_Employe]), 


)
