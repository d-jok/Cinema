CREATE TABLE [dbo].[Session]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MovieName] VARCHAR(50) NOT NULL, 
    [Date] DATE NOT NULL, 
    [Time] TIME NOT NULL, 
    [HallName] VARCHAR(50) NOT NULL, 
    [TicketPrice] INT NOT NULL DEFAULT 0 
)
