CREATE TABLE [dbo].[Messages] (
    [MessageId]      INT             NOT NULL,
    [Message]        NVARCHAR (1000) NOT NULL,
    [TenantUserId]   INT             NOT NULL,
    [EmployeeUserId] INT             NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([MessageId] ASC),
    CONSTRAINT [FK_Messages_Employees] FOREIGN KEY ([EmployeeUserId]) REFERENCES [dbo].[Employees] ([EmployeeUserId]),
    CONSTRAINT [FK_Messages_Tenants] FOREIGN KEY ([TenantUserId]) REFERENCES [dbo].[Tenants] ([TenantUserId])
);

