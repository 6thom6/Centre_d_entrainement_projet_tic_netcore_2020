CREATE TABLE [dbo].[Cheval]
(
	[Id_Cheval] INT NOT NULL IDENTITY,
    [Nom_cheval]NVARCHAR(50) NOT NULL,
    [Pere_cheval] NVARCHAR(50) NOT NULL, 
    [Mere_cheval] NVARCHAR(50) NOT NULL, 
    [Sortie_provisoire] NVARCHAR(50) NULL, 
    [Raison_Sortie] NVARCHAR(MAX) NULL, 
    [Id_Proprietaire] INT NULL, 
    [Id_Soins] INT NULL,
    [Poids] INT NULL, 
    [Race] NVARCHAR(50) NOT NULL,
    [Age] INT NOT NULL, 
    [Sexe] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Cheval_Proprietaire] FOREIGN KEY ([Id_Proprietaire]) REFERENCES [dbo].[Proprietaire](Id_Proprietaire), 
    CONSTRAINT [PK_Cheval] PRIMARY KEY ([Id_Cheval]),
    


)
