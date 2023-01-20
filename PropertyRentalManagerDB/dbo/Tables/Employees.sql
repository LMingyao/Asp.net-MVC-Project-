CREATE TABLE [dbo].[Employees] (
    [EmployeeUserId] INT NOT NULL,
    [UserId]         INT NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeUserId] ASC),
    CONSTRAINT [FK_Employees_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

