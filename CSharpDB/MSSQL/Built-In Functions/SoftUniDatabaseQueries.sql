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
