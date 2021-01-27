USE Geography

--12. Highest Peaks in Bulgaria
SELECT 
		c.CountryCode,
		m.MountainRange,
		p.PeakName,
		p.Elevation
	FROM Peaks AS p
	JOIN Mountains AS m ON p.MountainId = m.Id
	JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
	JOIN Countries AS c ON c.CountryCode = mc.CountryCode
	WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
	ORDER BY p.Elevation DESC

--13. Count Mountain Ranges
SELECT
		c.CountryCode,
		COUNT(m.Id) AS MountainRanges
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains AS m ON m.Id = mc.MountainId
	WHERE c.CountryCode IN ('BG', 'RU', 'US')
	GROUP BY c.CountryCode

--14. Countries with Rivers
SELECT TOP(5) 
		c.CountryName,
		r.RiverName
	FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
	LEFT JOIN Continents AS co ON co.ContinentCode = c.ContinentCode
	WHERE c.ContinentCode = 'AF' 
	ORDER BY c.CountryName

--15. *Continents and Currencies
SELECT ContinentCode, CurrencyCode, CurrenyUsage FROM (
 SELECT 
 		c.ContinentCode,
 		c.CurrencyCode,
 		COUNT(c.CurrencyCode) AS CurrenyUsage,
		DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS Ranked
 	FROM Countries c
 	GROUP BY c.ContinentCode, c.CurrencyCode) AS k
	WHERE Ranked = 1 AND CurrenyUsage > 1
	ORDER BY ContinentCode

--16. Countries Without any Mountains
SELECT COUNT(c.CountryCode) AS [Count]
	FROM Countries as c
	LEFT JOIN MountainsCountries AS mr ON c.CountryCode = mr.CountryCode
	WHERE mr.CountryCode IS NULL
