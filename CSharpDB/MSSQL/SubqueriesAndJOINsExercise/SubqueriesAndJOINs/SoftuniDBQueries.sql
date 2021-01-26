USE SoftUni

--1.Employee Address

SELECT TOP(5)
	EmployeeID, 
	JobTitle, 
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
