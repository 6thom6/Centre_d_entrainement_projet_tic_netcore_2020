CREATE TABLE [dbo].[mym_Cheval_Entrainement]
( 
    [MYM_ChevaliId_Cheval] INT NULL, 
    [MYM_Entrainementid_Entrainement] INT NULL, 
    CONSTRAINT [FK_mym_Cheval_Entrainement_ToCheval] FOREIGN KEY ([MYM_ChevaliId_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval]),
    CONSTRAINT [FK_mym_Cheval_Entrainement_ToEntrainement] FOREIGN KEY ([MYM_Entrainementid_Entrainement]) REFERENCES [dbo].[Entrainement]([Id_Entainement])



)
