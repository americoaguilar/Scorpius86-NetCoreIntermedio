CREATE TABLE [dbo].[Tracking]
(
	TrackingId INT IDENTITY NOT NULL,
    OrderId INT NOT NULL,
    EstimatedDeliveryTime DATETIME NOT NULL,
    AddresseeClientId INT NOT NULL,
    TrackingStatusId INT NOT NULL,

    CONSTRAINT PK_Tracking PRIMARY KEY (TrackingId),
    CONSTRAINT FK_TrackingTrackingStatus FOREIGN KEY (TrackingStatusId) REFERENCES TrackingStatus(TrackingStatusId),
    CONSTRAINT FK_TrackingClient FOREIGN KEY (AddresseeClientId) REFERENCES Client(ClientId),
    CONSTRAINT FK_TrackingOrder FOREIGN KEY (OrderId) REFERENCES [Order](OrderId)
)   
