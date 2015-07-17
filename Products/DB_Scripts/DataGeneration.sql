USE [TestTaskProducts]
GO

Declare @counter int SET @counter = 0
Declare @DayOfMonth TinyInt SET @DayOfMonth = 1
Declare @Month TinyInt SET @Month = 1
Declare @Year Integer SET @Year = 2014

WHILE @counter < 200
BEGIN
 INSERT INTO [dbo].[Product]
             ([Name]
             ,[ArrivalDate]
             ,[Count]
             ,[Price]
             ,[IsPromo])
        VALUES
             ('product'+cast(@counter as varchar(255)),
              DateAdd(day, @DayOfMonth + 1, 
              DateAdd(month, @Month, 
              DateAdd(Year, @Year-1900, 0))),
              @counter,
              275.68 + @counter,
              0)
        SET @counter = @counter + 1
		SET @DayOfMonth = @DayOfMonth + 1
END
 