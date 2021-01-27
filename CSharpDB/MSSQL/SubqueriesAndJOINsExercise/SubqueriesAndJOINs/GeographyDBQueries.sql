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