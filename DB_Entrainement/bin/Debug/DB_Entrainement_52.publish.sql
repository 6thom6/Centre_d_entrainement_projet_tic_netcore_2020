﻿/*
Script de déploiement pour DB_Entrainement

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DB_Entrainement"
:setvar DefaultFilePrefix "DB_Entrainement"
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
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Création de $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de [dbo].[Cheval]...';


GO
CREATE TABLE [dbo].[Cheval] (
    [Id_Cheval]               INT            NOT NULL,
    [Nom_cheval]              NVARCHAR (50)  NOT NULL,
    [Pere_cheval]             NVARCHAR (50)  NOT NULL,
    [Mere_cheval]             NVARCHAR (50)  NOT NULL,
    [Sortie_provisoire]       NVARCHAR (50)  NULL,
    [Raison_Sortie]           NVARCHAR (MAX) NULL,
    [Id_Proprietaire]         INT            NOT NULL,
    [Id_Soins]                INT            NULL,
    [Poids]                   NVARCHAR (50)  NULL,
    [Race]                    NVARCHAR (50)  NOT NULL,
    [Alimentation]            NVARCHAR (50)  NOT NULL,
    [complement_Alimentation] NVARCHAR (50)  NULL,
    [Age]                     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Cheval] ASC)
);


GO
PRINT N'Création de [dbo].[Course]...';


GO
CREATE TABLE [dbo].[Course] (
    [Id_Courses]      INT            NOT NULL,
    [Hippodrome]      NVARCHAR (50)  NOT NULL,
    [Date_Courses]    DATE           NOT NULL,
    [Distance]        INT            NOT NULL,
    [Corde]           NVARCHAR (50)  NOT NULL,
    [Discipline]      NVARCHAR (50)  NOT NULL,
    [Terrain]         NVARCHAR (50)  NOT NULL,
    [Avis]            NVARCHAR (MAX) NULL,
    [Jockey]          NVARCHAR (50)  NOT NULL,
    [Poids_De_Course] FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED ([Id_Courses] ASC)
);


GO
PRINT N'Création de [dbo].[Employé]...';


GO
CREATE TABLE [dbo].[Employé] (
    [Id_Employé]      INT           NOT NULL,
    [Nom_Employé]     NVARCHAR (50) NOT NULL,
    [Date_Embauche]   DATE          NULL,
    [Statuts_Employé] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Employé] ASC)
);


GO
PRINT N'Création de [dbo].[Entrainement]...';


GO
CREATE TABLE [dbo].[Entrainement] (
    [Id_Entainement] INT           NOT NULL,
    [Cheval]         NVARCHAR (50) NOT NULL,
    [Plat]           NVARCHAR (50) NULL,
    [Obstacle]       NVARCHAR (50) NULL,
    [Marcheur]       NVARCHAR (50) NULL,
    [Durée]          NVARCHAR (50) NULL,
    [Pré]            NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id_Entainement] ASC)
);


GO
PRINT N'Création de [dbo].[Historique]...';


GO
CREATE TABLE [dbo].[Historique] (
    [Id_historique]          INT           NOT NULL,
    [Id_Cheval]              INT           NULL,
    [Debourage]              NVARCHAR (50) NULL,
    [Pré-entrainement]       NVARCHAR (50) NULL,
    [Entraineur_précédent]   NVARCHAR (50) NULL,
    [Proprietaire_précédent] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id_historique] ASC)
);


GO
PRINT N'Création de [dbo].[mym_Cheval_Entrainement]...';


GO
CREATE TABLE [dbo].[mym_Cheval_Entrainement] (
    [MYM_ChevaliId_Cheval]            INT NULL,
    [MYM_Entrainementid_Entrainement] INT NULL
);


GO
PRINT N'Création de [dbo].[mym_Course_cheval]...';


GO
CREATE TABLE [dbo].[mym_Course_cheval] (
    [ChevalId_Cheval]  INT NULL,
    [CoursesId_Course] INT NULL
);


GO
PRINT N'Création de [dbo].[mym_Employé_Entrainement]...';


GO
CREATE TABLE [dbo].[mym_Employé_Entrainement] (
    [EmployéID_Employé]           INT NOT NULL,
    [EntrainementID_Entrainement] INT NOT NULL
);


GO
PRINT N'Création de [dbo].[mym_Vaccination_Cheval]...';


GO
CREATE TABLE [dbo].[mym_Vaccination_Cheval] (
    [VaccinationId_Vaccination] INT NOT NULL,
    [ChevalId_Cheval]           INT NOT NULL
);


GO
PRINT N'Création de [dbo].[Proprietaire]...';


GO
CREATE TABLE [dbo].[Proprietaire] (
    [Id_Proprietaire]  INT            IDENTITY (1, 1) NOT NULL,
    [Nom_Proprietaire] NVARCHAR (MAX) NULL,
    [Effectif]         INT            NOT NULL,
    [Date_Arrivée]     DATETIME       NOT NULL,
    [Dernier_Resultat] NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id_Proprietaire] ASC)
);


GO
PRINT N'Création de [dbo].[Soins]...';


GO
CREATE TABLE [dbo].[Soins] (
    [Id_Soins]                 INT            NOT NULL,
    [Id_Cheval]                INT            NOT NULL,
    [Id_Employe]               INT            NOT NULL,
    [Vermifuge]                DATE           NOT NULL,
    [Marechal_derniere_visite] DATE           NOT NULL,
    [Note_Libre]               NVARCHAR (MAX) NULL,
    [Type_de_soin]             NVARCHAR (50)  NULL,
    [durrée_indisponibilité]   NVARCHAR (50)  NULL,
    [date_de_soin]             NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id_Soins] ASC)
);


GO
PRINT N'Création de [dbo].[Vaccination]...';


GO
CREATE TABLE [dbo].[Vaccination] (
    [Id_vaccination]        INT           NOT NULL,
    [Nom_vaccin]            NVARCHAR (50) NOT NULL,
    [Delai_Indisponibilité] DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_vaccination] ASC)
);


GO
PRINT N'Création de [dbo].[FK_Cheval_Proprietaire]...';


GO
ALTER TABLE [dbo].[Cheval]
    ADD CONSTRAINT [FK_Cheval_Proprietaire] FOREIGN KEY ([Id_Proprietaire]) REFERENCES [dbo].[Proprietaire] ([Id_Proprietaire]);


GO
PRINT N'Création de [dbo].[FK_Historique_ToCheval]...';


GO
ALTER TABLE [dbo].[Historique]
    ADD CONSTRAINT [FK_Historique_ToCheval] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval] ([Id_Cheval]);


GO
PRINT N'Création de [dbo].[FK_mym_Cheval_Entrainement_ToCheval]...';


GO
ALTER TABLE [dbo].[mym_Cheval_Entrainement]
    ADD CONSTRAINT [FK_mym_Cheval_Entrainement_ToCheval] FOREIGN KEY ([MYM_ChevaliId_Cheval]) REFERENCES [dbo].[Cheval] ([Id_Cheval]);


GO
PRINT N'Création de [dbo].[FK_mym_Cheval_Entrainement_ToEntrainement]...';


GO
ALTER TABLE [dbo].[mym_Cheval_Entrainement]
    ADD CONSTRAINT [FK_mym_Cheval_Entrainement_ToEntrainement] FOREIGN KEY ([MYM_Entrainementid_Entrainement]) REFERENCES [dbo].[Entrainement] ([Id_Entainement]);


GO
PRINT N'Création de [dbo].[FK_mym_Course_cheval_ToCourses]...';


GO
ALTER TABLE [dbo].[mym_Course_cheval]
    ADD CONSTRAINT [FK_mym_Course_cheval_ToCourses] FOREIGN KEY ([CoursesId_Course]) REFERENCES [dbo].[Course] ([Id_Courses]);


GO
PRINT N'Création de [dbo].[FK_mym_Course_cheval_ToCheval]...';


GO
ALTER TABLE [dbo].[mym_Course_cheval]
    ADD CONSTRAINT [FK_mym_Course_cheval_ToCheval] FOREIGN KEY ([ChevalId_Cheval]) REFERENCES [dbo].[Cheval] ([Id_Cheval]);


GO
PRINT N'Création de [dbo].[FK_mym_Employé_Entrainement_ToEntrainement]...';


GO
ALTER TABLE [dbo].[mym_Employé_Entrainement]
    ADD CONSTRAINT [FK_mym_Employé_Entrainement_ToEntrainement] FOREIGN KEY ([EntrainementID_Entrainement]) REFERENCES [dbo].[Entrainement] ([Id_Entainement]);


GO
PRINT N'Création de [dbo].[FK_mym_Employé_Entrainement_ToEmployé]...';


GO
ALTER TABLE [dbo].[mym_Employé_Entrainement]
    ADD CONSTRAINT [FK_mym_Employé_Entrainement_ToEmployé] FOREIGN KEY ([EmployéID_Employé]) REFERENCES [dbo].[Employé] ([Id_Employé]);


GO
PRINT N'Création de [dbo].[FK_mym_Vaccination_Cheval_ToVaccination]...';


GO
ALTER TABLE [dbo].[mym_Vaccination_Cheval]
    ADD CONSTRAINT [FK_mym_Vaccination_Cheval_ToVaccination] FOREIGN KEY ([VaccinationId_Vaccination]) REFERENCES [dbo].[Vaccination] ([Id_vaccination]);


GO
PRINT N'Création de [dbo].[FK_mym_Vaccination_Cheval_ToCheval]...';


GO
ALTER TABLE [dbo].[mym_Vaccination_Cheval]
    ADD CONSTRAINT [FK_mym_Vaccination_Cheval_ToCheval] FOREIGN KEY ([ChevalId_Cheval]) REFERENCES [dbo].[Cheval] ([Id_Cheval]);


GO
PRINT N'Création de [dbo].[FK_Soins_ToCheval]...';


GO
ALTER TABLE [dbo].[Soins]
    ADD CONSTRAINT [FK_Soins_ToCheval] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval] ([Id_Cheval]);


GO
PRINT N'Création de [dbo].[FK_Soins_ToEmploye]...';


GO
ALTER TABLE [dbo].[Soins]
    ADD CONSTRAINT [FK_Soins_ToEmploye] FOREIGN KEY ([Id_Employe]) REFERENCES [dbo].[Employé] ([Id_Employé]);


GO
-- Étape de refactorisation pour mettre à jour le serveur cible avec des journaux de transactions déployés

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '731fbd6f-701e-4fb1-a208-776809adaf2d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('731fbd6f-701e-4fb1-a208-776809adaf2d')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '56f5d357-d6bf-472e-9f28-a992e7cc2d3b')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('56f5d357-d6bf-472e-9f28-a992e7cc2d3b')

GO

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
[dbo].[Cheval].[Sortie_provisoire],[dbo].[Cheval].[Raison_Sortie],[dbo].[Cheval].[Id_Proprietaire],[dbo].[Cheval].[Id_Soins],
[dbo].[Cheval].[Poids],[dbo].[Cheval].[Race],[dbo].[Cheval].[Alimentation],[dbo].[Cheval].[complement_Alimentation],[dbo].[Cheval].[Age])
VALUES  
('1','dala','dalakhani','zarkava','2020-07-02','repos','10','10','450','PS','3litres','none','4'),
('2','khani','dalakhani','zarkava','2020-07-12','repos','20','20','450','PS','1litres','warning','5'),
('3','zarkandar','dalakhani','zarkava','2020-11-02','repos','30','30','450','PS','2litres','none','3'),
('4','dubawi','dalakhani','zarkava','2020-05-02','repos','10','40','450','PS','1litres','none','6'),
('5','alpha spirit','zarak','zarkava','2020-09-24','repos','30','50','450','PS','2litres','none','4');

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


insert mym_Cheval_Entrainement (MYM_ChevaliId_Cheval, MYM_Entrainementid_Entrainement)

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

insert mym_Cheval_Entrainement (MYM_ChevaliId_Cheval, MYM_Entrainementid_Entrainement)

values 

('5','1'),
('4','2'),
('3','4'),
('1','5'),
('2','3')
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
