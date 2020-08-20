-- Problem 13 *

CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(50))
RETURNS TABLE
AS
RETURN 
(
SELECT 
  SUM(t.Cash) AS [SumCash]
FROM(
     SELECT
       *, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber 
     FROM UsersGames
     WHERE GameId = (
	                 SELECT 
	                   Id 
					 FROM Games 
					 WHERE [Name] = @gameName
					 )
	 ) AS t
WHERE t.RowNumber % 2 != 0
)
GO

SELECT * FROM dbo.ufn_CashInUsersGames ('Love in a mist')
GO
