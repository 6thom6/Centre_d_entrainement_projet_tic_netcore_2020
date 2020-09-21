CREATE TABLE [dbo].[Historique]
(
	[Id_historique] INT NOT NULL IDENTITY, 
    [Id_Cheval] INT NOT NULL, 
    [Debourage] NVARCHAR(50) NULL, 
    [Pre_Entrainement] NVARCHAR(50) NULL, 
    [Entraineur_precedent] NVARCHAR(50) NULL, 
    [Proprietaire_precedent] NVARCHAR(50) NULL, 
 
    CONSTRAINT [FK_Historique_ToCheval] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval]), 
    CONSTRAINT [PK_Historique] PRIMARY KEY ([Id_historique]), 


)
