CREATE DATABASE Bakery
USE Bakery

--Section 1. DDL 
--1. Database design
CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25) NOT NULL,
	LastName VARCHAR(25) NOT NULL,
	Gender CHAR(1) CHECK(Gender IN ('M', 'F')),
	Age INT,
	PhoneNumber VARCHAR(10) NOT NULL,
	CountryId INT REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(25) UNIQUE NOT NULL,
	Description VARCHAR(250),
	Recipe VARCHAR(MAX),
	Price DECIMAL(15,2) CHECK(Price >= 0)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	[Description] VARCHAR(255),
	Rate DECIMAL(15,2) CHECK(Rate BETWEEN 0 AND 10),
	ProductId INt REFERENCES Products(ID),
	CustomerId INT REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(25) UNIQUE NOT NULL,
	AddressText VARCHAR(30) NOT NULL,
	Summary VARCHAR(200),
	CountryId INT REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Description VARCHAR(200),
	OriginCountryId INT REFERENCES Countries(Id),
	DistributorId INT REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT REFERENCES Products(Id),
	IngredientId INT REFERENCES Ingredients(Id),
	CONSTRAINT PK_ProductsIngredients PRIMARY KEY (ProductId, IngredientId)
)

--Section 2. DML
--2. Insert

INSERT INTO Distributors (Name, CountryId, AddressText, Summary) VALUES
('Deloitte & Touche',	2,	'6 Arch St #9757',	'Customizable neutral traveling'),
('Congress Title',	13,	'58 Hancock St',	'Customer loyalty'),
('Kitchen People',	1,	'3 E 31st St #77',	'Triple-buffered stable delivery'),
('General Color Co Inc',	21,	'6185 Bohn St #72',	'Focus group'),
('Beck Corporation',	23,	'21 E 64th Ave',	'Quality-focused 4th generation hardware')

INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId) VALUES
('Francoise',	'Rautenstrauch',	15,	'M',	'0195698399',	5),
('Kendra',	'Loud',	22,	'F',	'0063631526',	11),
('Lourdes',	'Bauswell',	50,	'M',	'0139037043',	8),
('Hannah',	'Edmison',	18,	'F',	'0043343686',	1),
('Tom',	'Loeza',	31,	'M',	'0144876096',	23),
('Queenie',	'Kramarczyk',	30,	'F',	'0064215793',	29),
('Hiu',	'Portaro',	25,	'M',	'0068277755',	16),
('Josefa',	'Opitz',	43,	'F',	'0197887645',	17)

--3. Update
UPDATE Ingredients
	SET DistributorId = 35
		WHERE Name IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
	SET OriginCountryId = 14
		WHERE OriginCountryId = 8

--4. Delete
DELETE FROM Feedbacks
	WHERE CustomerId = 14 OR ProductId = 5

--Section 3. Querying 
--5.Products by Price
SELECT Name, Price, Description 
	FROM Products
	ORDER BY Price DESC, Name

--6. Negative Feedback
SELECT 
		f.ProductId,
		f.Rate,
		f.Description,
		f.CustomerId,
		c.Age,
		c.Gender
	FROM Feedbacks AS f
	JOIN Customers AS c ON f.CustomerId = c.Id
	WHERE f.Rate < 5
	ORDER BY f.ProductId DESC, f.Rate

--7. Customers without Feedback
SELECT 
		CONCAT(FirstName, ' ', LastName) AS CustomerName,
		c.PhoneNumber,
		c.Gender
	FROM Customers AS c
	LEFT JOIN Feedbacks AS f ON c.Id = f.CustomerId
	WHERE f.Id IS NULL
	ORDER BY c.Id

--8. Customers by Criteria
SELECT cu.FirstName, cu.Age, cu.PhoneNumber
	FROM Customers AS cu
	JOIN Countries AS co ON cu.CountryId = co.Id
	WHERE
		cu.Age >= 21 AND cu.FirstName LIKE ('%an%') OR
		cu.PhoneNumber LIKE ('%38') AND co.Name != 'Greece'
	ORDER BY cu.FirstName, cu.Age

--9. Middle Range Distributors
SELECT 
		d.Name,
		i.Name,
		p.Name,
		AVG(f.Rate)
	FROM Distributors AS d
	JOIN Ingredients AS i ON d.Id = i.DistributorId
	JOIN ProductsIngredients AS [pi] ON [pi].IngredientId = i.Id
	JOIN Products AS p ON [pi].ProductId = p.Id
	JOIN Feedbacks AS f ON f.ProductId = p.Id
	GROUP BY d.Name, d.Name, i.Name, p.Name
	HAVING AVG(f.Rate) BETWEEN 5 AND 8
	ORDER BY d.Name, i.Name, p.Name

--10. Country Representative
SELECT k.CountryName, k.DistributorName
	FROM (SELECT co.Name AS CountryName, d.Name AS DistributorName,
		DENSE_RANK() OVER (PARTITION BY co.Name ORDER BY COUNT(i.Id) DESC) AS [Rank]
	FROM Countries AS co
	JOIN Distributors AS d ON co.Id = d.CountryId
	LEFT JOIN Ingredients AS i ON d.Id = i.DistributorId
	GROUP BY d.Name, co.Name) AS k
	WHERE k.Rank = 1
	ORDER BY k.CountryName, k.DistributorName