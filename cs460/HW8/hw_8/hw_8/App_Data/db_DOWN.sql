--Alter to get rid of FK constraints, then drop them tables 

ALTER TABLE[dbo].[ArtWorks]
DROP CONSTRAINT[FK_dbo.ArtWorks_dbo.ArtistID];

ALTER TABLE[dbo].[Classifications]
DROP CONSTRAINT[FK_dbo.Classifications_dbo.ArtWorkID];
	
ALTER TABLE[dbo].[Classifications]
DROP CONSTRAINT[FK_dbo.Classifications_dbo.GenreID];

DROP TABLE Artists;
DROP TABLE ArtWorks;
DROP TABLE Genres;
DROP TABLE Classifications; 
GO