
-- Problem 01 (14)

CREATE TABLE Logs
(
LogId INT PRIMARY KEY IDENTITY,
AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
OldSum DECIMAL (15,4),
NewSum DECIMAL (15,4)
)

GO

CREATE TRIGGER tr_InsertAccountInfo ON Accounts 
FOR UPDATE
AS
  DECLARE @OldSum DECIMAL(15,4) = (SELECT Balance FROM deleted)
  DECLARE @NewSum DECIMAL(15,4) = (SELECT Balance FROM inserted)
  DECLARE @AccountId INT = (SELECT Id FROM inserted)

  INSERT INTO Logs(AccountId, OldSum, NewSum)
  VALUES(@AccountId, @OldSum, @NewSum)

  UPDATE Accounts
  SET Balance -= 10
  WHERE Id = 1

GO

SELECT * FROM Accounts WHERE Id = 1
SELECT * FROM Logs

-- Problem 02 (15)

CREATE TABLE NotificationEmails
(
Id INT PRIMARY KEY IDENTITY,
Recipient INT FOREIGN KEY REFERENCES Accounts(Id), 
[Subject] NVARCHAR(50),
Body NVARCHAR(50)
)

GO

CREATE TRIGGER tr_InsertEmailsInfo On Logs
FOR INSERT
AS
  DECLARE @AccountId INT = (SELECT TOP 1 AccountId FROM inserted)
  DECLARE @Subject NVARCHAR(50) = 'Balance change for account: ' + CAST(@AccountId AS NVARCHAR(50))
  DECLARE @OldSum DECIMAL(15,4) = (SELECT TOP 1 OldSum FROM inserted)
  DECLARE @NewSum DECIMAL(15,4) = (SELECT TOP 1 NewSum FROM inserted)
  DECLARE @Body NVARCHAR(50) = 'On ' + FORMAT(GETDATE(), 'mmm DD yyyy hh:mm tt') + ' your balance was changed from ' + CAST(@OldSum AS NVARCHAR(50)) + ' to ' + CAST(@NewSum AS NVARCHAR(50))+ '.'

  INSERT INTO NotificationEmails(Recipient, [Subject], Body)
  VALUES(@AccountId, @Subject, @Body)

SELECT * FROM NotificationEmails

GO

-- Problem 03 (16)

CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15,4)) 
AS
  DECLARE @money DECIMAL(15,4) = ABS(@MoneyAmount)
	IF(@MoneyAmount < 0)
	BEGIN
	  ROLLBACK
	  RAISERROR('Money amount cannot be zero or less!', 50001, 1)
	  RETURN
	END

	IF NOT EXISTS (SELECT Id FROM Accounts WHERE Id = @AccountId)
	BEGIN
	  ROLLBACK
	  RAISERROR('Invalid Account ID!', 50002, 1)
	  RETURN
	END

	UPDATE Accounts
	SET Balance += @money
	WHERE @AccountId = Id

GO

-- Problem 04 (17)

CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(15,4)) 
AS
BEGIN TRANSACTION
	IF(@MoneyAmount < 0)
	BEGIN
	  ROLLBACK
	  RAISERROR('Money amount cannot be zero or less!', 50001, 1)
	  RETURN
	END

	IF NOT EXISTS (SELECT Id FROM Accounts WHERE Id = @AccountId)
	BEGIN
	  ROLLBACK
	  RAISERROR('Invalid Account ID!', 50002, 1)
	  RETURN
	END

	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE @AccountId = Id

COMMIT
GO

-- Problem 05 (18)

CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15,4))
AS
BEGIN TRANSACTION
  EXEC usp_WithdrawMoney  @SenderId, @Amount
  EXEC usp_DepositMoney @ReceiverId, @Amount
COMMIT
GO