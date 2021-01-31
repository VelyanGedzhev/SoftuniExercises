USE SoftUni

--13. Departments Total Salaries
SELECT DepartmentID, SUM(Salary)
	FROM Employees 
	GROUP BY DepartmentID

--14. Employees Minimum Salaries
SELECT 
		DepartmentID,
		MIN(Salary)
	FROM Employees
	WHERE DepartmentID IN (2, 5, 7) AND HireDate > '2000/01/01'
	GROUP BY DepartmentID

--15. Employees Average Salaries
SELECT *
	INTO MyNewTable
	FROM Employees
	WHERE Salary > 30000

DELETE FROM MyNewTable
WHERE ManagerID = 42

UPDATE MyNewTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT 
		DepartmentID,
		AVG(Salary)
	FROM MyNewTable
	GROUP BY DepartmentID
	