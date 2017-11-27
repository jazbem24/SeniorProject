--create Artist Table
CREATE TABLE dbo.Artists(
id int IDENTITY(1,1) NOT NULL,
artistName varchar(128) NOT NULL,
birthDate DateTime NOT NULL,
birthPlace varchar(128) NOT NULL
CONSTRAINT[PK.dbo.Artists] PRIMARY KEY CLUSTERED(ID ASC)
);

--create ArtWork table 
CREATE TABLE dbo.ArtWork(
id int IDENTITY(1,1) NOT NULL,
title varchar(86) NOT NULL,
ArtistID int NOT NULL, 
CONSTRAINT[PK.dbo.ArtWork] PRIMARY KEY CLUSTERED(ID ASC),
CONSTRAINT[FK_dbo.Artwork_dbo.ArtistID] FOREIGN KEY ([ArtistID])REFERENCES [dbo].[Artists]([ID])
);

--create Genre Table
CREATE TABLE dbo.Genre(
id int IDENTITY(1,1) NOT NULL,
name varchar (64) NOT NULL
CONSTRAINT[PK.dbo.Genre] PRIMARY KEY CLUSTERED(ID ASC)
); 

--create classifications Table 
CREATE TABLE dbo.Classifications(
id int IDENTITY(1,1) NOT NULL,
ArtworkID int NOT NULL,
GenreID int NOT NULL, 
CONSTRAINT[PK.dbo.Classifications] PRIMARY KEY CLUSTERED(ID ASC),
CONSTRAINT[FK_dbo.Classifications_dbo.ArtWorkID] FOREIGN KEY ([ArtworkID])REFERENCES [dbo].[ArtWork]([ID]),
CONSTRAINT[FK_dbo.GenreID_dbo.GenreID] FOREIGN KEY ([GenreID])REFERENCES [dbo].[Genre]([ID])
);
GO