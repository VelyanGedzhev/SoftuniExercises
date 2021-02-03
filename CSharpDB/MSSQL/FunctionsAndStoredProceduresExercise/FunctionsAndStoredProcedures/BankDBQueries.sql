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
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(15,2), @yearlyInterest FLOAT, @years INT)
RETURNS DECIMAL(15,4)
BEGIN
	DECLARE @Result DECIMAL(15,4)
	SET @Result = @sum * (POWER((1 + @yearlyInterest), @years))
	RETURN @Result
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)
--12. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount (@AccountID INT, @InterestRate FLOAT)
AS
	SELECT 
			a.Id,
			ah.FirstName,
			ah.LastName,
			a.Balance,
			dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years]
		FROM AccountHolders AS ah
		JOIN Accounts AS a ON a.AccountHolderId = ah.Id
		WHERE a.Id = @AccountID

EXEC usp_CalculateFutureValueForAccount 1, 0.1
