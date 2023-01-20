CREATE TABLE [dbo].[Buildings] (
    [BuildingId]   INT           NOT NULL,
    [BuildingName] NVARCHAR (50) NOT NULL,
    [AddressId]    INT           NOT NULL,
    CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED ([BuildingId] ASC),
    CONSTRAINT [FK_Buildings_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId])
);

