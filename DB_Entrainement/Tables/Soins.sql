CREATE TABLE [dbo].[Soins]
(
	[Id_Soins] INT NOT NULL identity, 
    [Id_Cheval] INT NOT NULL, 
    [Id_Employe] INT NULL, 
    [Vermifuge] DATE NULL, 
    [Marechal_derniere_visite] DATE NULL, 
    [Note_Libre] NVARCHAR(MAX) NULL, 
    [Type_de_soin] NVARCHAR(50) NULL, 
    [durree_indisponibilite] NVARCHAR(50) NULL, 
    [date_de_soin] DATE NULL, 
    [Alimentation] NVARCHAR(50) NOT NULL, 
    [Complement_Alimentation] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Soins_ToCheval] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval]), 
    CONSTRAINT [FK_Soins_ToEmploye] FOREIGN KEY ([Id_Employe]) REFERENCES[dbo].[Employé]([Id_Employe]), 
    CONSTRAINT [PK_Soins] PRIMARY KEY ([Id_Soins]),







)
