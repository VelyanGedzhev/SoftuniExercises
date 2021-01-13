USE Minions

CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY,
	Username NVARCHAR(30) NOT NULL,
	[Password] NVARCHAR(26) NOT NULL,
	ProfilePicture IMAGE,
	IsDeleted BIT
)

INSERT INTO Users (Id, Username, [Password], ProfilePicture, IsDeleted) VALUES
(1, 'One-Two', 'GerrardButler', NULL, 0),
(2, 'Mumbles', 'IdrisElba', NULL, 0),
(3, 'Handsome Bob', 'TomHardy', NULL, 0),
(4, 'Johhny Quid', 'TobyKebbel', NULL, 0),
(5, 'Lenny Cole', 'TomWilkinson', NULL, 1)
