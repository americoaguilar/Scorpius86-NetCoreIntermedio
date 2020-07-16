CREATE TABLE [dbo].[TrackingStatus]
(
	TrackingStatusId INT IDENTITY NOT NULL,
	[Description] VARCHAR(250),
	IconCls VARCHAR(250),

	CONSTRAINT PK_TrackingStatus PRIMARY KEY (TrackingStatusId) 
)
