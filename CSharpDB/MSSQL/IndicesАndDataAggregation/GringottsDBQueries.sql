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