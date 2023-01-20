CREATE TABLE [dbo].[Apartments] (
    [ApartmentNumber] INT            NOT NULL,
    [ApartmentType]   NVARCHAR (50)  NOT NULL,
    [Description]     NVARCHAR (200) NOT NULL,
    [Floor]           INT            NOT NULL,
    [Status]          NVARCHAR (50)  NOT NULL,
    [BuildingId]      INT            NOT NULL,
    CONSTRAINT [PK_Apartments] PRIMARY KEY CLUSTERED ([ApartmentNumber] ASC),
    CONSTRAINT [FK_Apartments_Buildings] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Buildings] ([BuildingId])
);

