CREATE TABLE dbo.Addresses(
	id			 int		IDENTITY (1,1) NOT NULL,
	customerNumber	 int			NOT NULL,
	dob			 date			NOT NULL,
	fullName	 varchar(128)	NOT NULL,
	city		 varchar(64)	NOT NULL,
	st			 varchar(64)	NOT NULL,
	zip			 int			NOT NULL,	 
	street		 varchar(128)	NOT NULL,
	currentDate	 date			NOT NULL,
	CONSTRAINT [PK.dbo.Addresses] PRIMARY KEY CLUSTERED(ID ASC)
); 

INSERT INTO dbo.Addresses (customerNumber, dob,  fullName, city, st, zip, street, currentDate) VALUES
	(3251, '01/10/1958',  'North West', 'Portland', 'OR', 97364, 'Mount Tabor Drive','1/1/2012'),
	(2341, '02/23/1968',  'Bill Freeman', 'Hayward', 'CA', 93834, 'Edgewater Lane','1/1/2012'),
	(3847, '11/09/1943',  'Gertrude Wilmer', 'Tanjer', 'ID', 28304, 'Under Way','1/1/2012'),
	(4582, '08/10/1999',  'Philip Tablet', 'Newark', 'ND', 95842, 'Donut Circle','1/1/2012'),
	(3251, '01/17/1976',  'Johnson East', 'Atlanta', 'GA', 24345, 'Peach Drive','1/1/2012');

GO