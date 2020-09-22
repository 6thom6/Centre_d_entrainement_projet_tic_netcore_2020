CREATE PROCEDURE [dbo].[CreateSoins]
	@Id_Cheval int,
 	@Id_Employe int,
	@Vermifuge DATE,
	@Marechal_Derniere_Visite DATE,
	@Note_Libre NVARCHAR (max),
	@Type_De_Soin NVARCHAR (50),
	@Durree_Indisponibilite NVARCHAR (50),
	@Date_De_Soin DATE,
	@Alimentation NVARCHAR (50),
	@Complement_Alimentation NVARCHAR (50)
AS
	BEGIN
			INSERT INTO Soins (Id_Cheval, Id_Employe, Vermifuge, Marechal_Derniere_Visite, Note_Libre, Type_De_Soin, Durree_Indisponibilite, Date_De_Soin, Alimentation, Complement_Alimentation)
			VALUES (@Id_Cheval, @Id_Employe, @Vermifuge, @Marechal_Derniere_Visite, @Note_Libre, @Type_De_Soin, @Durree_Indisponibilite, @Date_De_Soin, @Alimentation, @Complement_Alimentation)
	END
