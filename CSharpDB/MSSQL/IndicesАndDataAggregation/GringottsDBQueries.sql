USE Gringotts

--1. Records’ Count
SELECT COUNT(Id)
	FROM WizzardDeposits

--2. Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits

--3. Longest Magic Wand Per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
	GROUP BY DepositGroup

--4. * Smallest Deposit Group Per Magic Wand Size(not included in final score)
SELECT TOP(2) DepositGroup
	FROM WizzardDeposits
	GROUP BY DepositGroup
	ORDER BY AVG(MagicWandSize)

--5. Deposits Sum
SELECT 
		DepositGroup,
		SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	GROUP BY DepositGroup

--6. Deposits Sum for Ollivander Family
SELECT 
		DepositGroup,
		SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup

--7. Deposits Filter
SELECT 
		DepositGroup,
		SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY TotalSum DESC

--8.  Deposit Charge
SELECT 
		DepositGroup,
		MagicWandCreator,
		MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
	GROUP BY DepositGroup, MagicWandCreator
	ORDER BY MagicWandCreator, DepositGroup

--9. Age Groups
SELECT a.AgeRanking AS AgeGroup, COUNT(*) AS WizardCount
FROM (
         SELECT CASE
                    WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
                    WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
                    WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
                    WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
                    WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
                    WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
                    ELSE '[61+]'
                    END AS AgeRanking
         FROM WizzardDeposits) AS a
GROUP BY a.AgeRanking

--10. First Letter
SELECT LEFT(FirstName, 1) 
	FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest'
	GROUP BY LEFT(FirstName, 1)
	
--11. Average Interest 
SELECT 
		DepositGroup,
		IsDepositExpired,
		AVG(DepositInterest) AS AverageInterest
	FROM WizzardDeposits
	WHERE DepositStartDate > '1985/01/01'
	GROUP BY 
		DepositGroup,
		IsDepositExpired
	ORDER BY 
		DepositGroup DESC,
		IsDepositExpired

--12. * Rich Wizard, Poor Wizard (not included in final score)
SELECT 
		SUM(c.DepositAmount - n.DepositAmount) AS [SumDifference]
	FROM WizzardDeposits AS c
	JOIN WizzardDeposits AS n ON   n.Id = c.Id + 1
