CREATE TABLE [dbo].[Soins]
(
	[Id_Soins] INT NOT NULL identity, 
    [Id_Cheval] INT NOT NULL, 
    [Id_Employe] INT NULL, 
    [Vermifuge] DATE NULL, 
    [Marechal_Derniere_Visite] DATE NULL, 
    [Note_Libre] NVARCHAR(MAX) NULL, 
    [Type_De_Soin] NVARCHAR(50) NULL, 
    [Durree_Indisponibilite] NVARCHAR(50) NULL, 
    [Date_De_Soin] DATE NULL, 
    [Alimentation] NVARCHAR(50) NOT NULL, 
    [Complement_Alimentation] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Soins_ToCheval] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval]), 
    CONSTRAINT [FK_Soins_ToEmploye] FOREIGN KEY ([Id_Employe]) REFERENCES[dbo].[Employe]([Id_Employe]), 
    CONSTRAINT [PK_Soins] PRIMARY KEY ([Id_Soins]),







)
