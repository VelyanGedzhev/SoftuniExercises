USE Bank
--09. Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
SELECT CONCAT(FirstName, ' ', LastName) AS FullName
	FROM AccountHolders

EXEC usp_GetHoldersFullName
--10. People with Balance Higher Than

--11. Future Value Function

--12. Calculating Interest

--13. *Cash in User Games Odd Rows
