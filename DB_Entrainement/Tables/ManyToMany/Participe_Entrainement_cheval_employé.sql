CREATE TABLE [dbo].[Participe_Entrainement_cheval_employé]
(
	[Id_Entrainement] INT NOT NULL , 
    [Id_Cheval] INT NOT NULL, 
    [Id_Employe] INT NOT NULL, 
    CONSTRAINT [PK_Participe_Entrainement_cheval_employé] PRIMARY KEY ([Id_Entrainement],[Id_Cheval],[Id_Employe]),
    CONSTRAINT [FK_Participe_Entrainement] FOREIGN KEY ([Id_Entrainement]) REFERENCES [dbo].[Entrainement]([Id_Entrainement]),
    CONSTRAINT [FK_Participe_Cheval] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval]),
    CONSTRAINT [FK_Participe_Employe] FOREIGN KEY ([Id_Employe]) REFERENCES [dbo].[Employe] ([Id_Employe])
)
