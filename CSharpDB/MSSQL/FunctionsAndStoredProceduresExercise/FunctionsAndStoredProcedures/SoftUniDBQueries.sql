USE SoftUni

--1.Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
	SELECT 
			FirstName,
			LastName
		FROM Employees
		WHERE Salary > 35000
GO

EXEC usp_GetEmployeesSalaryAbove35000

--2.Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4)
AS
	SELECT 
			FirstName,
			LastName
		FROM Employees
		WHERE Salary >= @Number
GO

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--3.Town Names Starting With
CREATE OR ALTER PROC usp_GetTownsStartingWith @Symbol VARCHAR(5)
AS
	SELECT [Name]
		FROM Towns
		WHERE [Name] LIKE @Symbol + '%'
GO

EXEC usp_GetTownsStartingWith 'c'