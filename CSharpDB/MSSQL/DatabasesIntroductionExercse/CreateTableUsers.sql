USE Minions

CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

INSERT INTO Users (Username, [Password], ProfilePicture,LastLoginTime, IsDeleted) VALUES
('One-Two', 'GerrardButler', 'https://m.media-amazon.com/images/M/MV5BMTQ0NTk5Mzk2OV5BMl5BanBnXkFtZTcwMDE3NTE4MQ@@._V1_.jpg','2021-01-13 15:40:33', 0),
('Mumbles', 'IdrisElba', NULL,NULL, 0),
('Handsome Bob', 'TomHardy', NULL,NULL, 0),
('Johhny Quid', 'TobyKebbel', NULL,NULL, 0),
('Lenny Cole', 'TomWilkinson', NULL,NULL, 1)

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07CFC9AFC6

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols Check (LEN(Password) > 5)