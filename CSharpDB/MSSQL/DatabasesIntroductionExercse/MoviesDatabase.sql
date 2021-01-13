--CREATE DATABASE Movies

--USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY,
	DirectorName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Directors VALUES
(1, 'Scorsese', NULL),
(2, 'Spielberg', NULL),
(3, 'Tarantino', NULL),
(4, 'Hitchcock', NULL),
(5, 'Coppola', NULL)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY,
	GenreName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Genres VALUES
(1, 'Comedy', NULL),
(2, 'Horror', NULL),
(3, 'Action', NULL),
(4, 'Thriller', NULL),
(5, 'Drama', 'The worst')

CREATE TABLE Categories
(
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(30) NOT NULL,
	Notes VARCHAR(30)
)

INSERT INTO Categories VALUES
(1, 'BestComedy', NULL),
(2, 'BestHorror', NULL),
(3, 'BestAction', NULL),
(4, 'BestThriller', NULL),
(5, 'BestDrama', 'The worst')

CREATE TABLE Movies
(
	Id INT PRIMARY KEY,
	Title VARCHAR(30) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME NOT NULL,
	Lenght DECIMAL(15,2) NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT NOT NULL,
	Notes VARCHAR(MAX)
)
ALTER TABLE Movies
ADD FOREIGN KEY (DirectorId) REFERENCES Directors(Id)

ALTER TABLE Movies
ADD FOREIGN KEY (GenreId) REFERENCES Genres(Id)

ALTER TABLE Movies
ADD FOREIGN KEY (CategoryId) REFERENCES Categories(Id)


INSERT INTO Movies VALUES
(1, 'Movie1',1,GETDATE(),1.20,1,1,7.2,NULL),
(2, 'Movie2',2,GETDATE(),1.30,2,2,8.7,NULL),
(3, 'Movie3',3,GETDATE(),1.40,3,3,9.2,NULL),
(4, 'Movie4',4,GETDATE(),1.43,3,3,5.2,NULL),
(5, 'Movie5',5,GETDATE(),1.47,5,4,6.2,NULL)