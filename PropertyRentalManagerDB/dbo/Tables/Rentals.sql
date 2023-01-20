CREATE TABLE [dbo].[Rentals] (
    [RentalId]       INT  NOT NULL,
    [RentalPrice]    INT  NOT NULL,
    [StartDate]      DATE NOT NULL,
    [EndDate]        DATE NOT NULL,
    [ApartmentId]    INT  NOT NULL,
    [TenantUserID]   INT  NOT NULL,
    [EmployeeUserID] INT  NOT NULL,
    CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED ([RentalId] ASC),
    CONSTRAINT [FK_Rentals_Apartments] FOREIGN KEY ([ApartmentId]) REFERENCES [dbo].[Apartments] ([ApartmentNumber]),
    CONSTRAINT [FK_Rentals_Employees] FOREIGN KEY ([EmployeeUserID]) REFERENCES [dbo].[Employees] ([EmployeeUserId]),
    CONSTRAINT [FK_Rentals_Tenants] FOREIGN KEY ([TenantUserID]) REFERENCES [dbo].[Tenants] ([TenantUserId])
);

