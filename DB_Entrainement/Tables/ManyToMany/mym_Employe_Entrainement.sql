CREATE TABLE [dbo].[mym_Employe_Entrainement]
(
    [EmployeID_Employe] INT NOT NULL, 
    [EntrainementID_Entrainement] INT NOT NULL, 
    CONSTRAINT [FK_mym_Employe_Entrainement_ToEntrainement] FOREIGN KEY ([EntrainementID_Entrainement]) REFERENCES [dbo].[Entrainement]([Id_Entrainement]), 
    CONSTRAINT [FK_mym_Employe_Entrainement_ToEmploye] FOREIGN KEY ([EmployeID_Employe]) REFERENCES [dbo].[Employe]([Id_Employe])
)
