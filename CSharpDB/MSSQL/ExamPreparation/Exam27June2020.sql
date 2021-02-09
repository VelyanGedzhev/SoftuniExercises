--Section 1. DDL
CREATE DATABASE WMS
USE WMS

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) CHECK(LEN(Phone) = 12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) DEFAULT 'Pending' CHECK([Status] IN('Pending', 'In Progress', 'Finished')) NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId)  NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0  NOT NULL
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL(15,2) CHECK(Price BETWEEN 1 AND 9999.99) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId)  NOT NULL,
	StockQty INT DEFAULT 0 CHECK(StockQty >= 0),
)

CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderID)  NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId)  NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity > 0)  NOT NULL,
	CONSTRAINT PK_OrdersParts PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId)  NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId)  NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity > 0)  NOT NULL,
	CONSTRAINT PK_JobsParts PRIMARY KEY (JobId, PartId)
)

--2. Insert
INSERT INTO Clients (FirstName, LastName, Phone) VALUES
('Teri',	'Ennaco', '570-889-5187'),
('Merlyn',	'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie',	'Mconnell',	'908-802-3564'),
('Lemuel',	'Latzke', '631-748-6479'),
('Melodie',	'Knipp', '805-690-1682'),
('Candida',	'Corbley', '908-275-8357')

INSERT INTO Parts (SerialNumber, Description, Price, VendorId) VALUES
('WP8182119',	'Door Boot Seal', 117.86,	2),
('W10780048',	'Suspension Rod', 42.81,	1),
('W10841140',	'Silicone Adhesive',  6.77,	4),
('WPY055980',	'High Temperature Adhesive', 13.94,	3)

--3.Update
UPDATE Jobs
SET 
	MechanicId = 3,
	Status = 'In Progress'
WHERE Status = 'Pending'

--4.Delete
DELETE FROM OrderParts WHERE OrderId = 19
DELETE FROm Orders WHERE OrderId = 19

--5. Mechanic Assignments
SELECT 
	CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	j.Status,
	j.IssueDate
	FROM Mechanics AS m
	LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	ORDER BY m.MechanicId, j.IssueDate, j.JobId

--6.Current Clients
SELECT 
		CONCAT(c.FirstName, ' ', c.LastName) AS Client,
		DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
		j.Status
	FROM Clients AS c
	LEFT JOIN Jobs AS j ON j.ClientId = c.ClientId
	WHERE j.Status != 'Finished' -- OR [WHERE j.FinishDate IS NULL]
	ORDER BY [Days going] DESC

--7.Mechanic Performance
SELECT 
		CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
		AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
	FROM Mechanics AS m
	JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	GROUP BY j.MechanicId, CONCAT(m.FirstName, ' ', m.LastName)
	ORDER BY j.MechanicId 

--8.Available Mechanics
SELECT
		m.FirstName + ' ' +  m.LastName AS Mechanic
	FROM Mechanics AS m
	LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	WHERE j.JobId IS NULL OR (SELECT COUNT(JobId)
				FROM Jobs
				WHERE Status <> 'Finished' AND MechanicId = m.MechanicId
				GROUP BY MechanicId, Status) IS NULL
	GROUP BY m.MechanicId, m.FirstName + ' ' +  m.LastName

--9.Past Expenses
SELECT 
		j.JobId,
		ISNULL(SUM(p.Price * op.Quantity), 0) AS Total
	FROM Jobs AS j
	LEFT JOIN Orders AS o ON o.JobId = j.JobId
	LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
	LEFT JOIN Parts AS p ON p.PartId = op.PartId
	WHERE Status = 'Finished' 
	GROUP BY j.JobId
	ORDER BY Total DESC, j.JobId