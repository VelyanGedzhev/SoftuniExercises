USE SoftUni

--1.Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
	SELECT 
			FirstName,
			LastName
		FROM Employees
		WHERE Salary > 35000


EXEC usp_GetEmployeesSalaryAbove35000

--2.Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4)
AS
	SELECT 
			FirstName,
			LastName
		FROM Employees
		WHERE Salary >= @Number


EXEC usp_GetEmployeesSalaryAboveNumber 48100

--3.Town Names Starting With
CREATE OR ALTER PROC usp_GetTownsStartingWith @Symbol VARCHAR(5)
AS
	SELECT [Name]
		FROM Towns
		WHERE [Name] LIKE @Symbol + '%'


EXEC usp_GetTownsStartingWith 'c'

--4.Employees from Town
CREATE PROC usp_GetEmployeesFromTown (@TownName NVARCHAR(60))
AS
	SELECT FirstName, LastName 
		FROM Employees AS e
		JOIN Addresses AS a ON e.AddressID = a.AddressID
		JOIN Towns as t ON a.TownID = t.TownID
		WHERE t.Name = @TownName

EXEC usp_GetEmployeesFromTown 'Berlin'