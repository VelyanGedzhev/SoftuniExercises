USE Gringotts

--1. Records’ Count
SELECT COUNT(Id)
	FROM WizzardDeposits

--2. Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
