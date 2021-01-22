--Problem 1. Find Names of All Employees by First Name

USE SoftUni

SELECT FirstName, LastName
	FROM Employees
	WHERE CHARINDEX('SA', FirstName) = 1

--SELECT FirstName, LastName
--	FROM Employees
--	WHERE FirstName LIKE('SA%')

--Problem 2. Find Names of All employees by Last Name 

SELECT FirstName, LastName
	FROM Employees
	WHERE LastName LIKE('%ei%')

--Problem 3. Find First Names of All Employees

SELECT FirstName
	FROM Employees
	WHERE DepartmentID IN (3, 10) 
	AND (DATEPART(YEAR, HireDate) >= 1995 AND DATEPART(YEAR, HireDate) <= 2005)

--Problem 4. Find All Employees Except Engineers

SELECT FirstName, LastName
	FROM Employees
	WHERE JobTitle NOT LIKE('%engineer%')

--Problem 5. Find Towns with Name Length

SELECT [Name]
	FROM Towns
	WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
	ORDER BY [Name]

--Problem 6. Find Towns Starting With

SELECT TownID, [Name]
	FROM Towns
	WHERE 
		[Name] LIKE('M%') OR 
		[Name] LIKE('K%') OR
		[Name] LIKE('B%') OR
		[Name] LIKE('E%')
	ORDER BY [Name]

--SELECT TownID, [Name]
--	FROM Towns
--	WHERE 
--		CHARINDEX('M', [Name]) = 1 OR 
--		CHARINDEX('K', [Name]) = 1 OR
--		CHARINDEX('B', [Name]) = 1 OR
--		CHARINDEX('E', [Name]) = 1
--	ORDER BY [Name]

--Problem 7. Find Towns Not Starting With

SELECT TownID, [Name]
	FROM Towns
	WHERE NOT
		(CHARINDEX('R', [Name]) = 1 OR 
		CHARINDEX('D', [Name]) = 1 OR
		CHARINDEX('B', [Name]) = 1)
	ORDER BY [Name]

--Problem 8. Create View Employees Hired After 2000 Year

CREATE VIEW v_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
	FROM Employees
	WHERE DATEPART(YEAR, HireDate) > 2000

--Problem 9. Length of Last Name

SELECT FirstName, LastName
	FROM Employees
	WHERE LEN(LastName) = 5
