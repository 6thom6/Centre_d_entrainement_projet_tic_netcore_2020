﻿/*
Script de déploiement pour Entrainement

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Entrainement"
:setvar DefaultFilePrefix "Entrainement"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
La colonne [dbo].[mym_Cheval_Entrainement].[Id] est en cours de suppression, des données risquent d'être perdues.
*/

IF EXISTS (select top 1 1 from [dbo].[mym_Cheval_Entrainement])
    RAISERROR (N'Lignes détectées. Arrêt de la mise à jour du schéma en raison d''''un risque de perte de données.', 16, 127) WITH NOWAIT

GO
/*
La colonne [dbo].[mym_Course_cheval].[Id] est en cours de suppression, des données risquent d'être perdues.
*/

IF EXISTS (select top 1 1 from [dbo].[mym_Course_cheval])
    RAISERROR (N'Lignes détectées. Arrêt de la mise à jour du schéma en raison d''''un risque de perte de données.', 16, 127) WITH NOWAIT

GO
/*
La colonne [dbo].[mym_Employé_Entrainement].[Id] est en cours de suppression, des données risquent d'être perdues.
*/

IF EXISTS (select top 1 1 from [dbo].[mym_Employé_Entrainement])
    RAISERROR (N'Lignes détectées. Arrêt de la mise à jour du schéma en raison d''''un risque de perte de données.', 16, 127) WITH NOWAIT

GO
/*
La colonne [dbo].[mym_Vaccination_Cheval].[Id] est en cours de suppression, des données risquent d'être perdues.
*/

IF EXISTS (select top 1 1 from [dbo].[mym_Vaccination_Cheval])
    RAISERROR (N'Lignes détectées. Arrêt de la mise à jour du schéma en raison d''''un risque de perte de données.', 16, 127) WITH NOWAIT

GO
PRINT N'Suppression de contrainte sans nom sur [dbo].[mym_Cheval_Entrainement]...';


GO
ALTER TABLE [dbo].[mym_Cheval_Entrainement] DROP CONSTRAINT [PK__mym_Chev__3214EC07E4C8F31C];


GO
PRINT N'Suppression de contrainte sans nom sur [dbo].[mym_Course_cheval]...';


GO
ALTER TABLE [dbo].[mym_Course_cheval] DROP CONSTRAINT [PK__mym_Cour__3214EC07CB74C522];


GO
PRINT N'Suppression de contrainte sans nom sur [dbo].[mym_Employé_Entrainement]...';


GO
ALTER TABLE [dbo].[mym_Employé_Entrainement] DROP CONSTRAINT [PK__mym_Empl__3214EC07ABADD540];


GO
PRINT N'Suppression de contrainte sans nom sur [dbo].[mym_Vaccination_Cheval]...';


GO
ALTER TABLE [dbo].[mym_Vaccination_Cheval] DROP CONSTRAINT [PK__mym_Vacc__3214EC07378D2FAD];


GO
PRINT N'Modification de [dbo].[mym_Cheval_Entrainement]...';


GO
ALTER TABLE [dbo].[mym_Cheval_Entrainement] DROP COLUMN [Id];


GO
PRINT N'Modification de [dbo].[mym_Course_cheval]...';


GO
ALTER TABLE [dbo].[mym_Course_cheval] DROP COLUMN [Id];


GO
PRINT N'Modification de [dbo].[mym_Employé_Entrainement]...';


GO
ALTER TABLE [dbo].[mym_Employé_Entrainement] DROP COLUMN [Id];


GO
PRINT N'Modification de [dbo].[mym_Vaccination_Cheval]...';


GO
ALTER TABLE [dbo].[mym_Vaccination_Cheval] DROP COLUMN [Id];


GO
/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

insert into [dbo].[Entrainement] ([dbo].[Entrainement].[Id_Entainement],[dbo].[Entrainement].[Cheval],[dbo].[Entrainement].[Plat],[dbo].[Entrainement].[Obstacle],[dbo].[Entrainement].[Marcheur],[dbo].[Entrainement].[Durée],[dbo].[Entrainement].[Pré])
values 
('1','dala','1000m','2tours','none','2h','none'),
('2','khani','1500m','3tours','none','2h','none'),
('3','zarkandar','2000m','6tours','none','2h30','none'),
('4','dubawi','3500m','2tours','none','2h','none'),
('5','alpha spirit','3000m','none','2h','1h','none')

insert into [dbo].[Course] ([dbo].[Course].[Id_Courses], [dbo].[Couse].[Hippodrome], [dbo].[Couse].[Date_Courses],[dbo].[Couse].[Distance],[dbo].[Couse].[Corde],[dbo].[Couse].[Discipline],
                    [dbo].[Couse].[Terrain],[dbo].[Couse].[Avis],[dbo].[Couse].[Jockey],[dbo].[Couse].[Poids_De_Course])
Values 
('1','Auteuil','2020-09-01','4600','8','steeple','lourd','pas degueux','gueguen','68'),
('2','Auteuil','2020-09-02','3600','gauche','haie','tres lourd','bien','obrian','68'),
('3','Dieppe','2020-10-03','3800','droite','steeple','bon','bof','zuliani','68'),
('4','Longchamps','2020-09-04','1600','droite','plat','léger','passable','lestrade','68'),
('5','Compiegne','2020-09-05','3900','gauche','steeple','lourd','degueux','masure','68')

insert into [dbo].[Employé] ([dbo].[Employé].[Id_Employé], [dbo].[Employé].[Nom_Employé], [dbo].[Employé].[Date_Embauche], [dbo].[Employé].[Statuts_Employé])
values
('1','zuliani','2020-10-01','jockey'),
('2','Lemagnen','2020-10-02','apprenti'),
('3','Nabet','2020-10-03','garcon_decurie'),
('4','Lestrade','2020-10-04','garcon_de_voyage'),
('5','Gallon','2020-10-05','jockey')


insert [dbo].[Vaccination]([dbo].[Vaccination].[Id_vaccination],[dbo].[Vaccination].[Nom_vaccin],[dbo].[Vaccination].[Delai_Indisponibilité])
values
('1','polyo','2020-10-10'),
('5','polyo','2020-10-12'),
('3','polyo','2020-10-13'),
('4','polyo','2020-10-14'),
('2','polyo','2020-10-15')




SET IDENTITY_INSERT [Proprietaire] ON
insert [dbo].[Proprietaire]([dbo].[Proprietaire].[Id_Proprietaire],[dbo].[Proprietaire].[Nom_Proprietaire],[dbo].[Proprietaire].[Effectif],[dbo].[Proprietaire].[Date_Arrivée],[dbo].[Proprietaire].[Dernier_Resultat])
values
('10','nicole','35','2020-12-05','1er'),
('20','papot','20','2020-06-03','1er'),
('30','schule','10','2020-08-04','2eme'),
('40','Delay','5','2020-07-05','np'),
('50','deWaele','1','2020-10-15','np')



INSERT INTO [dbo].[Cheval] ([dbo].[Cheval].[Id_Cheval],[dbo].[Cheval].[Nom_cheval],[dbo].[Cheval].[Pere_cheval],[dbo].[Cheval].[Mere_cheval],
[dbo].[Cheval].[Sortie_provisoire],[dbo].[Cheval].[Raison_Sortie],[dbo].[Cheval].[Id_Proprietaire],[dbo].[Cheval].[Id_Soins],[dbo].[Cheval].[Poids],[dbo].[Cheval].[Race],[dbo].[Cheval].[Alimentation],[dbo].[Cheval].[complement_Alimentation])
VALUES  
('1','dala','dalakhani','zarkava','2020-07-02','repos','10','10','450','PS','3litres','none'),
('2','khani','dalakhani','zarkava','2020-07-12','repos','20','20','450','PS','1litres','warning'),
('3','zarkandar','dalakhani','zarkava','2020-11-02','repos','30','30','450','PS','2litres','none'),
('4','dubawi','dalakhani','zarkava','2020-05-02','repos','10','40','450','PS','1litres','none'),
('5','alpha spirit','zarak','zarkava','2020-09-24','repos','30','50','450','PS','2litres','none');

insert [dbo].[Soins]([dbo].[Soins].[Id_Cheval],[dbo].[Soins].[Id_Soins],
[dbo].[Soins].[Id_Employe],[dbo].[Soins].[Vermifuge],[dbo].[Soins].[Marechal_derniere_visite],[dbo].[Soins].[Note_Libre],
date_de_soin,Type_de_soin,durrée_indisponibilité)
values
('1','10','4','2020-01-25','2020-09-10','complet','6_mars','infiltration_ant_d','7j'),
('1','20','2','2020-04-07','2020-08-11','complet','8_mai','fracture_ant_g','15mois'),
('2','30','2','2020-03-25','2020-07-15','complet','5_avril','tendinite_pos_d','1mois'),
('4','40','4','2020-01-15','2020-06-04','complet','9_decembre','infiltration_ant_d','12j'),
('3','50','5','2020-06-25','2020-09-10','complet','3_fevrier','fracture_pos_g','1an'),
('1','11','5','2020-05-23','2020-05-23','complet','24_juillet','tendinite_pos_d','12j'),
('1','12','2','2020-05-23','2020-06-12','complet','4_juin','fracture_pos_g',''),
('1','13','1','2020-05-23','2020-07-11','complet','25_septembre','tendinite_Ant_g','1mois'),
('1','14','3','2020-05-23','2020-08-12','complet','14_janvier','infiltration_Pos_d','15j'),
('1','15','3','2020-05-23','2020-05-13','complet','15_octobre','fracture_Anterieur_g','6mois')




insert [dbo].[Historique] ([dbo].[Historique].[Id_historique],[dbo].[Historique].[Id_Cheval],[dbo].[Historique].[Debourage],[dbo].[Historique].[Pré-entrainement],[dbo].[Historique].[Entraineur_précédent],[dbo].[Historique].[Proprietaire_précédent])
values
('1','2','malenfant','malenfant','dubois','dubuisson'),
('2','4','perceval','perceval','nami','dubuisson'),
('3','3','caradoc','perceval','dubois','leona'),
('4','5','dugarry','marion','leblanc','dubuisson'),
('5','2','malenfant','malenfant','dubois','kartus');

insert mym_Vaccination_Cheval (ChevalId_Cheval, VaccinationId_Vaccination)
values

('5','1'),
('4','2'),
('3','4'),
('1','5'),
('2','3')


insert mym_Cheval_Entrainement (MYM_ChevaliId_Cheval,MYM_Entrainementid_Entrainement)
values
('5','1'),
('4','2'),
('3','4'),
('1','5'),
('2','3')


insert mym_Course_cheval (ChevalId_Cheval, CoursesId_Course)
values
('5','1'),
('4','2'),
('3','4'),
('1','5'),
('2','3')

insert mym_Cheval_Entrainement (MYM_ChevaliId_Cheval,MYM_Entrainementid_Entrainement)
values 
('5','1'),
('4','2'),
('3','4'),
('1','5'),
('2','3')
GO

GO
PRINT N'Mise à jour terminée.';


GO
