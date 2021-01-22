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