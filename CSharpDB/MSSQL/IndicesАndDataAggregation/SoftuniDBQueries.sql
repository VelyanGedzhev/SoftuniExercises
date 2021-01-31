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
