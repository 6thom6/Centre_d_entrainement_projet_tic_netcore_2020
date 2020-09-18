CREATE PROCEDURE [dbo].[CreateCheval]
	@Nom_Cheval NVARCHAR(50),
    @Pere_Cheval NVARCHAR(50),
    @Mere_Cheval NVARCHAR(50),
    @Sortie_Provisoire NVARCHAR(50),
    @raison_sortie NVARCHAR(MAX),
    @Id_Proprietaire INT,
    @Id_Soins INT,
    @Poids INT,
    @Race NVARCHAR(50),
    @Age INT,            
    @Sexe NVARCHAR(50)
AS
BEGIN
    INSERT INTO Cheval (Nom_cheval, Pere_cheval, Mere_cheval, Sortie_provisoire, Raison_Sortie, Id_Proprietaire, Id_Soins, Poids, Race, Age, Sexe)
    VALUES (@Nom_Cheval, @Pere_Cheval, @Mere_Cheval, @Sortie_Provisoire, @raison_sortie, @Id_Proprietaire, @Id_Soins, @Poids, @Race, @Age, @Sexe);
END