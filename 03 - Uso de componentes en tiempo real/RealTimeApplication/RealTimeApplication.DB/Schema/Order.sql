CREATE TABLE [dbo].[Order]
(
	OrderId INT IDENTITY NOT NULL,
	ClientId INT NOT NULL,
	[Description] VARCHAR(250) NOT NULL,

	CONSTRAINT PK_Order PRIMARY KEY (OrderId),
	    CONSTRAINT FK_OrderClient FOREIGN KEY (ClientId) REFERENCES Client(ClientId),
)
