CREATE TABLE [dbo].[mym_Vaccination_Cheval]
(
    [Id_Vaccination] INT NOT NULL, 
    [Id_Cheval] INT NOT NULL, 
    CONSTRAINT [PK_mym_Vaccination_Cheval] PRIMARY KEY ([Id_Vaccination]),
    CONSTRAINT [FK_mym_Vaccination_ToVaccination] FOREIGN KEY ([Id_Vaccination]) REFERENCES [dbo].[Vaccination]([Id_vaccination]), 
    CONSTRAINT [FK_mym_Vaccination_ToCheval] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval]), 
   

)
