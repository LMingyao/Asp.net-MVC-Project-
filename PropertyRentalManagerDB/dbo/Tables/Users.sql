CREATE TABLE [dbo].[Users] (
    [UserId]       INT           IDENTITY (1, 1) NOT NULL,
    [UFirstName]   NVARCHAR (50) NOT NULL,
    [ULastName]    NVARCHAR (50) NOT NULL,
    [UEmail]       NVARCHAR (50) NOT NULL,
    [UPhoneNumber] NVARCHAR (50) NOT NULL,
    [UPassword]    NVARCHAR (50) NOT NULL,
    [UserType]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

