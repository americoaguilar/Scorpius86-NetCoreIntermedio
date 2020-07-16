CREATE TABLE [dbo].[TrackingProduct]
(
	TrackingProductId INT NOT NULL IDENTITY,
	TrackingId INT NOT NULL,
	ProductId INT NOT NULL,

	CONSTRAINT PK_TrackingProduct PRIMARY KEY (TrackingProductId),
    CONSTRAINT FK_TrackingProductTracking FOREIGN KEY (TrackingId) REFERENCES Tracking(TrackingId),
	CONSTRAINT FK_TrackingProductProduct FOREIGN KEY (ProductId) REFERENCES Product(ProductId),
)
