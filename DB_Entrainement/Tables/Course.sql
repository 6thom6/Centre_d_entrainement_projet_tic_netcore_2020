﻿CREATE TABLE [dbo].[Course]
(
	[Id_Courses] INT NOT NULL identity, 
    [Hippodrome] NVARCHAR(50) NOT NULL, 
    [Date_Courses] DATE NOT NULL, 
    [Distance] INT NOT NULL, 
    [Corde] NVARCHAR(50) NOT NULL, 
    [Discipline] NVARCHAR(50) NOT NULL, 
    [Terrain] NVARCHAR(50) NOT NULL, 
    [Avis] NVARCHAR(MAX) NULL, 
    [Jockey] NVARCHAR(50) NOT NULL, 
    [Poids_De_Course] FLOAT NOT NULL, 
    CONSTRAINT [PK_Course] PRIMARY KEY ([Id_Courses]), 

  
   
)
