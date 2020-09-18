CREATE PROCEDURE [dbo].[CreateCourse]
	@Hippodrome Nvarchar (50),
	@Date_Courses Date,
	@Distance int,
	@Corde Nvarchar (50),
	@Discipline Nvarchar (50),
	@Terrain Nvarchar (50),
	@Avis nvarchar (max),
	@Jockey Nvarchar (50),
	@Poids_De_Course float
AS
BEGIN
		INSERT INTO Course (Hippodrome, Date_Courses, Distance, Corde, Discipline, Terrain, Avis, Jockey, Poids_De_Course)
		VALUES (@Hippodrome, @Date_Courses, @Distance, @Corde, @Discipline, @Terrain, @Avis, @Jockey, @Poids_De_Course);
END
