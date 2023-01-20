CREATE TABLE [dbo].[Addresses] (
    [AddressId]    INT           NOT NULL,
    [StreetNumber] INT           NOT NULL,
    [StreetName]   NVARCHAR (50) NOT NULL,
    [City]         NVARCHAR (50) NOT NULL,
    [Province]     NVARCHAR (50) NOT NULL,
    [PostalCode]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([AddressId] ASC)
);

