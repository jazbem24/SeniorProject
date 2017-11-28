--capitalize attribute names 
--create Artist Table
CREATE TABLE dbo.Artists(
ID int IDENTITY(1,1) NOT NULL,
ArtistName varchar(128) NOT NULL,
BirthDate DateTime NOT NULL,
BirthPlace varchar(128) NOT NULL
CONSTRAINT[PK.dbo.Artists] PRIMARY KEY CLUSTERED(ID ASC)
);

--create ArtWork table 
CREATE TABLE dbo.ArtWork(
ID int IDENTITY(1,1) NOT NULL,
Title varchar(86) NOT NULL,
ArtistID int NOT NULL, 
CONSTRAINT[PK.dbo.ArtWork] PRIMARY KEY CLUSTERED(ID ASC),
CONSTRAINT[FK_dbo.Artwork_dbo.ArtistID] FOREIGN KEY ([ArtistID])REFERENCES [dbo].[Artists]([ID])
);

--create Genre Table
CREATE TABLE dbo.Genre(
ID int IDENTITY(1,1) NOT NULL,
Name varchar (64) NOT NULL
CONSTRAINT[PK.dbo.Genre] PRIMARY KEY CLUSTERED(ID ASC)
); 

--create classifications Table 
CREATE TABLE dbo.Classifications(
ID int IDENTITY(1,1) NOT NULL,
ArtworkID int NOT NULL,
GenreID int NOT NULL, 
CONSTRAINT[PK.dbo.Classifications] PRIMARY KEY CLUSTERED(ID ASC),
CONSTRAINT[FK_dbo.Classifications_dbo.ArtWorkID] FOREIGN KEY ([ArtworkID])REFERENCES [dbo].[ArtWork]([ID]),
CONSTRAINT[FK_dbo.GenreID_dbo.GenreID] FOREIGN KEY ([GenreID])REFERENCES [dbo].[Genre]([ID])
);
GO

--Now to plant seed data for the database 
--Artists Table 
INSERT INTO dbo.Artists(ArtistName,BirthDate,BirthPlace)
VALUES
('M.C. Escher', '06/17/1898', 'Leeuwarden,Netherlands'),
('Leonardo Da Vinci', '05/02/1519', 'Vinci,Italy'),
('Hatip Mehmed Efendi', '11/18/1680', 'Unknown'),
('Salvador Dali', '05/11/1904', 'Figueres,Spain'); 

--ArtWork Table
INSERT INTO dbo.ArtWork(Title, ArtistID)
VALUES 
('Circle Limit III', 1),
('Twon Tree', 1),
('Mona Lisa', 2),
('The Vitruvian Man', 2),
('Ebru', 3),
('Honey Is Sweeter Than Blood', 4); 

--Genre Table 
INSERT INTO dbo.Genre(Name) 
VALUES
('Tesselation'),
('Surrealism'),
('Portrait'),
('Renaissance'); 

--Classifications Table
INSERT INTO dbo.Classifications(ArtworkID, GenreID) 
VALUES
(1,1),
(2,1),
(2,2),
(3,3),
(3,4),
(4,4),
(5,1),
(6,2);