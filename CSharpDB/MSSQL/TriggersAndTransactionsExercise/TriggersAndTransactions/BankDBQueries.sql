USE Bank

--1.Create Table Logs

CREATE TABLE Logs 
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)
GO

CREATE TRIGGER tr_Insert ON Accounts FOR UPDATE
AS
	DECLARE @OldSum MONEY = (SELECT Balance FROM deleted)
	DECLARE @NewSum MONEY = (SELECT Balance FROM inserted)
	DECLARE @AccountId INT = (SELECT Id FROM inserted)

	INSERT INTO Logs (AccountId, OldSum, NewSum) VALUES
	(@AccountId, @OldSum, @NewSum)

GO
--2.Create Table Emails
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	Subject NVARCHAR(100) NOT NULL,
	Body NVARCHAR(300) NOT NULL
)

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS
	DECLARE @AccountId INT = (SELECT TOP(1) AccountId FROM inserted)
	DECLARE @OldSum MONEY = (SELECT TOP(1) OldSum FROM inserted)
	DECLARE @NewSum MONEY = (SELECT TOP(1) NewSum FROM inserted)
	DECLARE @EventDate DATETIME = GETDATE()

	INSERT INTO NotificationEmails (Recipient, Subject, Body) VALUES
	(@AccountId, CONCAT('Balance change for account:', ' ', @AccountId),
	CONCAT('On', ' ', @EventDate, ' ', 'your balance was changed from', ' ', @OldSum,
	' ', 'to', ' ', @NewSum))
GO

--3.Deposit Money
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN TRANSACTION

	DECLARE @Account INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)

	IF(@Account IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid account ID!', 16, 1)
			RETURN
		END

	IF(@MoneyAmount < 0)
	BEGIN 
		ROLLBACK
		RAISERROR('Money amount cannot be negative!', 16 , 1)
		RETURN
	END

UPDATE Accounts
SET Balance += @MoneyAmount
WHERE Id = @AccountId
COMMIT

--4.Withdraw Money
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN TRANSACTION

	DECLARE @Account INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)
	DECLARE @Balance MONEY = (SELECT Balance FROM Accounts WHERE Id = @AccountId)

	IF(@Account IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid account ID!', 16, 1)
			RETURN
		END

	IF(@MoneyAmount < 0)
	BEGIN 
		ROLLBACK
		RAISERROR('Money amount cannot be negative!', 16 , 1)
		RETURN
	END

	IF(@Balance - @MoneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Insufficient funds!', 16 , 1)
		RETURN
	END

UPDATE Accounts
SET Balance -= @MoneyAmount
WHERE Id = @AccountId
COMMIT