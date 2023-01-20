CREATE TABLE [dbo].[Appointments] (
    [AppointmentId]   INT      NOT NULL,
    [AppointmentDate] DATE     NOT NULL,
    [AppointmentTime] DATETIME NOT NULL,
    [TenantUserId]    INT      NOT NULL,
    [EmployeeUserId]  INT      NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([AppointmentId] ASC),
    CONSTRAINT [FK_Appointments_Employees] FOREIGN KEY ([EmployeeUserId]) REFERENCES [dbo].[Employees] ([EmployeeUserId]),
    CONSTRAINT [FK_Appointments_Tenants] FOREIGN KEY ([TenantUserId]) REFERENCES [dbo].[Tenants] ([TenantUserId])
);

