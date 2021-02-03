USE Bank
--09. Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
SELECT CONCAT(FirstName, ' ', LastName) AS FullName
	FROM AccountHolders

EXEC usp_GetHoldersFullName
--10. People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@Value DECIMAL(18,4))
AS
	SELECT FirstName, LastName
		FROM AccountHolders AS ah
		JOIN Accounts AS a ON a.AccountHolderId = ah.Id
		GROUP BY FirstName, LastName
		HAVING SUM(Balance) > @Value
		ORDER BY FirstName, LastName

EXEC usp_GetHoldersWithBalanceHigherThan 50000

--11. Future Value Function


--12. Calculating Interest


--13. *Cash in User Games Odd Rows
