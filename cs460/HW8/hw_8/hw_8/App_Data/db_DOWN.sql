--Alter to get rid of FK constraints, then drop them tables 

ALTER TABLE[dbo].[ArtWork]
DROP CONSTRAINT[FK_dbo.ArtWork_dbo.ArtistID];

ALTER TABLE[dbo].[Classifications]
DROP CONSTRAINT[FK_dbo.Classifications_dbo.ArtWorkID];
	
ALTER TABLE[dbo].[Classifications]
DROP CONSTRAINT[FK_dbo.Classifications_dbo.GenreID];

DROP TABLE Artists;
DROP TABLE ArtWork;
DROP TABLE Genre;
DROP TABLE Classifications; 
GO