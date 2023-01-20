CREATE TABLE [dbo].[Schedules] (
    [ScheduleId]     INT      NOT NULL,
    [ScheduleDate]   DATE     NOT NULL,
    [ScheduleTime]   DATETIME NOT NULL,
    [TenantUserId]   INT      NOT NULL,
    [EmployeeUserId] INT      NOT NULL,
    [AppointmentId]  INT      NOT NULL,
    CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED ([ScheduleId] ASC),
    CONSTRAINT [FK_Schedules_Appointments] FOREIGN KEY ([AppointmentId]) REFERENCES [dbo].[Appointments] ([AppointmentId]),
    CONSTRAINT [FK_Schedules_Employees] FOREIGN KEY ([EmployeeUserId]) REFERENCES [dbo].[Employees] ([EmployeeUserId]),
    CONSTRAINT [FK_Schedules_Tenants] FOREIGN KEY ([TenantUserId]) REFERENCES [dbo].[Tenants] ([TenantUserId])
);

