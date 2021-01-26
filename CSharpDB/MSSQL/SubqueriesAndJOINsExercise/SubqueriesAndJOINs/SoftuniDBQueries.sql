USE SoftUni

--1.Employee Address

SELECT TOP(5)
	e.EmployeeID, 
	e.JobTitle, 
	e.AddressID,
	a.AddressText
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--2.Addresses with Towns

SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON t.TownID = a.TownID
	ORDER BY 
			e.FirstName,
			e.LastName

--3.Sales Employee

SELECT 
		e.EmployeeID, 
		e.FirstName, 
		e.LastName, 
		d.Name AS DepartmentName	
	FROM Employees e
	INNER JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name = 'Sales'
	ORDER BY e.EmployeeID

--4.Employee Departments

SELECT TOP(5)
		e.EmployeeID,
		e.FirstName,
		e.Salary,
		d.Name
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE Salary > 15000
	ORDER BY e.DepartmentID

--5.Employees Without Project

SELECT TOP(3)
		e.EmployeeID,
		e.FirstName
	FROM Employees e
	LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
	WHERE ep.EmployeeID IS NULL
	ORDER BY e.EmployeeID

--6.Employees Hired After

SELECT	
		e.FirstName,
		e.LastName,
		e.HireDate,
		d.Name AS DeptName
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE 
		d.Name IN ('Sales', 'Finance') 
		AND e.HireDate > '1999-1-1'
	ORDER BY e.HireDate

--7.Employees with Project

--SELECT 
--		e.EmployeeID,
--		e.FirstName,
--		p.Name as ProjectName
--	FROM Employees e
--	JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
--	JOIN Projects p ON ep.ProjectID = p.ProjectID