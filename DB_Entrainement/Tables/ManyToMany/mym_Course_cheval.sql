﻿CREATE TABLE [dbo].[mym_Course_cheval]
(
    [ChevalId_Cheval] INT NULL, 
    [CoursesId_Course] INT NULL, 
    CONSTRAINT [FK_mym_Course_cheval_ToCourses] FOREIGN KEY ([CoursesId_Course]) REFERENCES [dbo].[Course](Id_Courses), 
    CONSTRAINT [FK_mym_Course_cheval_ToCheval] FOREIGN KEY ([ChevalId_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval]), 

)
