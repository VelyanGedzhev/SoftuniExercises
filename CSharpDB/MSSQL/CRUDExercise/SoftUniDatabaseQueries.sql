USE SoftUni

SELECT *
	FROM Departments

SELECT [Name]
	FROM Departments

SELECT FirstName, LastName, Salary
	FROM Employees

SELECT FirstName, MiddleName, LastName
	FROM Employees

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS FullName
	FROM Employees 

SELECT FirstName + '.' + LastName + '@softuni.bg' AS FullEmailAddress
	FROM Employees 

SELECT DISTINCT Salary
	FROM Employees

SELECT *
	FROM Employees
	WHERE JobTitle LIKE '%Sales Representative%'