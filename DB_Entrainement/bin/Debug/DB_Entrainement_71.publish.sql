/*
Script de déploiement pour DB_entrainement

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DB_entrainement"
:setvar DefaultFilePrefix "DB_entrainement"
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
    [Id_Cheval]         INT            IDENTITY (1, 1) NOT NULL,
    [Nom_cheval]        NVARCHAR (50)  NOT NULL,
    [Pere_cheval]       NVARCHAR (50)  NOT NULL,
    [Mere_cheval]       NVARCHAR (50)  NOT NULL,
    [Sortie_provisoire] NVARCHAR (50)  NULL,
    [Raison_Sortie]     NVARCHAR (MAX) NULL,
    [Id_Proprietaire]   INT            NOT NULL,
    [Id_Soins]          INT            NULL,
    [Poids]             INT            NULL,
    [Race]              NVARCHAR (50)  NOT NULL,
    [Age]               INT            NOT NULL,
    [Sexe]              NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Cheval] PRIMARY KEY CLUSTERED ([Id_Cheval] ASC)
);


GO
PRINT N'Création de [dbo].[Course]...';


GO
CREATE TABLE [dbo].[Course] (
    [Id_Courses]      INT            IDENTITY (1, 1) NOT NULL,
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
    [Id_Employe]      INT           IDENTITY (1, 1) NOT NULL,
    [Nom_Employe]     NVARCHAR (50) NOT NULL,
    [Date_Embauche]   DATE          NULL,
    [Statuts_Employe] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Employé] PRIMARY KEY CLUSTERED ([Id_Employe] ASC)
);


GO
PRINT N'Création de [dbo].[Entrainement]...';


GO
CREATE TABLE [dbo].[Entrainement] (
    [Id_Entainement] INT           IDENTITY (1, 1) NOT NULL,
    [Id_Employe]     INT           NOT NULL,
    [Cheval]         NVARCHAR (50) NOT NULL,
    [Plat]           NVARCHAR (50) NULL,
    [Obstacle]       NVARCHAR (50) NULL,
    [Marcheur]       NVARCHAR (50) NULL,
    [Duree]          NVARCHAR (50) NULL,
    [Pre]            NVARCHAR (50) NULL,
    CONSTRAINT [PK_Entrainement] PRIMARY KEY CLUSTERED ([Id_Entainement] ASC)
);


GO
PRINT N'Création de [dbo].[Historique]...';


GO
CREATE TABLE [dbo].[Historique] (
    [Id_historique]          INT           IDENTITY (1, 1) NOT NULL,
    [Id_Cheval]              INT           NOT NULL,
    [Debourage]              NVARCHAR (50) NULL,
    [Pre-entrainement]       NVARCHAR (50) NULL,
    [Entraineur_precedent]   NVARCHAR (50) NULL,
    [Proprietaire_precedent] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Historique] PRIMARY KEY CLUSTERED ([Id_historique] ASC)
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
    [Nom_Proprietaire] NVARCHAR (MAX) NOT NULL,
    [Date_Arrivee]     DATE           NOT NULL,
    [Dernier_Resultat] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Proprietaire] PRIMARY KEY CLUSTERED ([Id_Proprietaire] ASC)
);


GO
PRINT N'Création de [dbo].[Soins]...';


GO
CREATE TABLE [dbo].[Soins] (
    [Id_Soins]                 INT            IDENTITY (1, 1) NOT NULL,
    [Id_Cheval]                INT            NOT NULL,
    [Id_Employe]               INT            NULL,
    [Vermifuge]                DATE           NULL,
    [Marechal_derniere_visite] DATE           NULL,
    [Note_Libre]               NVARCHAR (MAX) NULL,
    [Type_de_soin]             NVARCHAR (50)  NULL,
    [durree_indisponibilite]   NVARCHAR (50)  NULL,
    [date_de_soin]             DATE           NULL,
    [Alimentation]             NVARCHAR (50)  NOT NULL,
    [Complement_Alimentation]  NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Soins] PRIMARY KEY CLUSTERED ([Id_Soins] ASC)
);


GO
PRINT N'Création de [dbo].[Vaccination]...';


GO
CREATE TABLE [dbo].[Vaccination] (
    [Id_vaccination]        INT           IDENTITY (1, 1) NOT NULL,
    [Nom_vaccin]            NVARCHAR (50) NULL,
    [Delai_Indisponibilite] DATE          NULL,
    CONSTRAINT [PK_Vaccination] PRIMARY KEY CLUSTERED ([Id_vaccination] ASC)
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
    ADD CONSTRAINT [FK_mym_Employé_Entrainement_ToEmployé] FOREIGN KEY ([EmployéID_Employé]) REFERENCES [dbo].[Employé] ([Id_Employe]);


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
    ADD CONSTRAINT [FK_Soins_ToEmploye] FOREIGN KEY ([Id_Employe]) REFERENCES [dbo].[Employé] ([Id_Employe]);


GO
PRINT N'Création de [dbo].[CreateCheval]...';


GO
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
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4f25d3fb-83e9-4b15-a49e-5a3a049f7e3a')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4f25d3fb-83e9-4b15-a49e-5a3a049f7e3a')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '20a385f0-5585-45a1-a5b8-9679e2194d09')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('20a385f0-5585-45a1-a5b8-9679e2194d09')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7618ee6b-7e8c-43a3-8ce0-b21a596fe781')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7618ee6b-7e8c-43a3-8ce0-b21a596fe781')

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

insert into [dbo].[Entrainement] ([dbo].[Entrainement].[Cheval],
                                  [dbo].[Entrainement].[Plat],
                                  [dbo].[Entrainement].[Obstacle],
                                  [dbo].[Entrainement].[Marcheur],
                                  [dbo].[Entrainement].[Duree],
                                  [dbo].[Entrainement].[Pre],
                                  [dbo].[Entrainement].Id_Employe)
values 
('dala','1000m','2tours','none','2h','none','1'),
('khani','1500m','3tours','none','2h','none','2'),
('zarkandar','2000m','6tours','none','2h30','none','3'),
('dubawi','3500m','2tours','none','2h','none','4'),
('alpha spirit','3000m','none','2h','1h','none','5')

insert into [dbo].[Course] ([dbo].[Couse].[Hippodrome],
                            [dbo].[Couse].[Date_Courses],
                            [dbo].[Couse].[Distance],
                            [dbo].[Couse].[Corde],
                            [dbo].[Couse].[Discipline],
                            [dbo].[Couse].[Terrain],
                            [dbo].[Couse].[Avis],
                            [dbo].[Couse].[Jockey],
                            [dbo].[Couse].[Poids_De_Course])
Values 
('Auteuil','2020-09-01','4600','8','steeple','lourd','pas degueux','gueguen','68'),
('Auteuil','2020-09-02','3600','gauche','haie','tres lourd','bien','obrian','68'),
('Dieppe','2020-10-03','3800','droite','steeple','bon','bof','zuliani','68'),
('Longchamps','2020-09-04','1600','droite','plat','léger','passable','lestrade','68'),
('Compiegne','2020-09-05','3900','gauche','steeple','lourd','degueux','masure','68')

insert into [dbo].[Employé] ([dbo].[Employé].[Nom_Employe],
                             [dbo].[Employé].[Date_Embauche],
                             [dbo].[Employé].[Statuts_Employe])
values
('zuliani','2020-10-01','jockey'),
('Lemagnen','2020-10-02','apprenti'),
('Nabet','2020-10-03','garcon_decurie'),
('Lestrade','2020-10-04','garcon_de_voyage'),
('Gallon','2020-10-05','jockey')


insert [dbo].[Vaccination]([dbo].[Vaccination].[Nom_vaccin],
                           [dbo].[Vaccination].[Delai_Indisponibilite])
values
('polyo','2020-10-10'),
('polyo','2020-10-12'),
('polyo','2020-10-13'),
('polyo','2020-10-14'),
('polyo','2020-10-15')




--SET IDENTITY_INSERT [Proprietaire] ON
insert [dbo].[Proprietaire]([dbo].[Proprietaire].[Nom_Proprietaire],
                            [dbo].[Proprietaire].[Date_Arrivee],
                            [dbo].[Proprietaire].[Dernier_Resultat])
values
('nicole','2020-12-05','1er'),
('papot','2020-06-03','1er'),
('schule','2020-08-04','2eme'),
('Delay','2020-07-05','np'),
('deWaele','2020-10-15','np')



INSERT INTO [dbo].[Cheval] ([dbo].[Cheval].[Nom_cheval],
                            [dbo].[Cheval].[Pere_cheval],
                            [dbo].[Cheval].[Mere_cheval],
                            [dbo].[Cheval].[Sortie_provisoire],
                            [dbo].[Cheval].[Raison_Sortie],
                            [dbo].[Cheval].[Id_Proprietaire],
                            [dbo].[Cheval].[Id_Soins],
                            [dbo].[Cheval].[Poids],
                            [dbo].[Cheval].[Race],
                            [dbo].[Cheval].[Age],
                            Sexe)
                            
                            
VALUES  
('dala','dalakhani','zarkava','2020-07-02','repos','1','1','450','PS','4','M'),
('khani','dalakhani','zarkava','2020-07-12','repos','2','2','450','PS','5','F'),
('zarkandar','dalakhani','zarkava','2020-11-02','repos','3','3','450','PS','3','H'),
('dubawi','dalakhani','zarkava','2020-05-02','repos','1','4','450','PS','6','E'),
('alpha spirit','zarak','zarkava','2020-09-24','repos','3','5','450','PS','4','F');

insert [dbo].[Soins]([dbo].[Soins].[Id_Cheval],
                     [dbo].[Soins].[Id_Employe],
                     [dbo].[Soins].[Vermifuge],
                     [dbo].[Soins].[Marechal_derniere_visite],
                     [dbo].[Soins].[Note_Libre],
                     date_de_soin,
                     Type_de_soin,
                     durree_indisponibilite,
                     Alimentation,
                     Complement_Alimentation)
values
('1','4','2020-01-25','2020-09-10','complet','2020-09-10','infiltration_ant_d','7j','2litres','rien'),
('1','2','2020-04-07','2020-08-11','complet','2020-08-11','fracture_ant_g','15mois','2litres','foin'),
('2','2','2020-03-25','2020-07-15','complet','2020-07-15','tendinite_pos_d','1mois','2litres','granullé'),
('4','4','2020-01-15','2020-06-04','complet','2020-06-04','infiltration_ant_d','12j','2litres','orge'),
('3','5','2020-06-25','2020-09-10','complet','2020-09-10','fracture_pos_g','1an','2litres','sucre_paille'),
('1','5','2020-05-23','2020-05-23','complet','2020-05-23','tendinite_pos_d','12j','2litres','poudre'),
('1','2','2020-05-23','2020-06-12','complet','2020-06-12','fracture_pos_g','','2litres','avoine'),
('1','1','2020-05-23','2020-07-11','complet','2020-07-11','tendinite_Ant_g','1mois','2litres','maïs'),
('1','3','2020-05-23','2020-08-12','complet','2020-08-12','infiltration_Pos_d','15j','2litres','poivre'),
('1','3','2020-05-23','2020-05-13','complet','2020-05-13','fracture_Anterieur_g','6mois','2litres','sel')




insert [dbo].[Historique] ([dbo].[Historique].[Id_Cheval],
                           [dbo].[Historique].[Debourage],
                           [dbo].[Historique].[Pre-entrainement],
                           [dbo].[Historique].[Entraineur_precedent],
                           [dbo].[Historique].[Proprietaire_precedent])
values
('2','malenfant','malenfant','dubois','dubuisson'),
('4','perceval','perceval','nami','dubuisson'),
('3','caradoc','perceval','dubois','leona'),
('5','dugarry','marion','leblanc','dubuisson'),
('2','malenfant','malenfant','dubois','kartus');

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
