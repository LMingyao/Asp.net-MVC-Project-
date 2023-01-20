CREATE TABLE [dbo].[Tenants] (
    [TenantUserId] INT NOT NULL,
    [UserId]       INT NOT NULL,
    CONSTRAINT [PK_Tenants] PRIMARY KEY CLUSTERED ([TenantUserId] ASC),
    CONSTRAINT [FK_Tenants_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

