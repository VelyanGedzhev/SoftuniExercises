USE Geography
--Problem 12. Countries Holding ‘A’ 3 or More Times

SELECT CountryName, IsoCode
	FROM Countries
	WHERE CountryName LIKE('%a%a%a%')
	ORDER BY IsoCode

