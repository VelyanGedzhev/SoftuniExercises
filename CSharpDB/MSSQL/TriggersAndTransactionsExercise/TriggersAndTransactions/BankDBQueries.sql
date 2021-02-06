USE Bank

--1.Create Table Logs

CREATE TABLE Logs 
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

CREATE TRIGGER tr_Insert ON Accounts FOR UPDATE
AS
	DECLARE @OldSum MONEY = (SELECT Balance FROM deleted)
	DECLARE @NewSum MONEY = (SELECT Balance FROM inserted)
	DECLARE @AccountId INT = (SELECT Id FROM inserted)

	INSERT INTO Logs (AccountId, OldSum, NewSum) VALUES
	(@AccountId, @OldSum, @NewSum)

