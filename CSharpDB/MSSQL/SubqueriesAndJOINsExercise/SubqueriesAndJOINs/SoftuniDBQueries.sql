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

SELECT TOP(5)
		e.EmployeeID,
		e.FirstName,
		p.Name as ProjectName
	FROM Employees e
	JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

--8.Employee 24

SELECT 
		e.EmployeeID,
		e.FirstName,
		CASE
			WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
			ELSE p.Name
		END AS ProjectName
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

--9.Employee Manager

SELECT 
		e.EmployeeID,
		e.FirstName,
		e.ManagerID,
		m.FirstName AS ManagerName
	FROM Employees AS e
	JOIN Employees AS m ON m.EmployeeID = e.ManagerID
	WHERE e.ManagerID IN (3, 7)
	ORDER BY e.EmployeeID

--10.Employee Summary
SELECT TOP(50)
		e.EmployeeID,
		CONCAT(e.FirstName,' ', e.LastName) AS EmployeeName,
		CONCAT(em.FirstName,' ', em.LastName) AS ManagerName,
		d.Name AS DepartmentName
	FROM Employees AS e
	JOIN Employees AS em ON em.EmployeeID = e.ManagerID
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID