USE [master]
GO
/****** Object:  Database [PropertyRentalManagementDB]    Script Date: 2022-12-12 1:24:01 AM ******/
CREATE DATABASE [PropertyRentalManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PropertyRentalManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVEREXPRESS\MSSQL\DATA\PropertyRentalManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PropertyRentalManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVEREXPRESS\MSSQL\DATA\PropertyRentalManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PropertyRentalManagementDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PropertyRentalManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PropertyRentalManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PropertyRentalManagementDB] SET QUERY_STORE = OFF
GO
USE [PropertyRentalManagementDB]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 2022-12-12 1:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[StreetNumber] [int] NOT NULL,
	[StreetName] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Province] [nvarchar](50) NOT NULL,
	[PostalCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Apartments]    Script Date: 2022-12-12 1:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartments](
	[ApartmentNumber] [int] NOT NULL,
	[ApartmentType] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Floor] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[BuildingId] [int] NOT NULL,
 CONSTRAINT [PK_Apartments] PRIMARY KEY CLUSTERED 
(
	[ApartmentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 2022-12-12 1:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentId] [int] IDENTITY(1,1) NOT NULL,
	[AppointmentDate] [date] NOT NULL,
	[AppointmentTime] [datetime] NOT NULL,
	[TenantUserId] [int] NOT NULL,
	[EmployeeUserId] [int] NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuildingFinal]    Script Date: 2022-12-12 1:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuildingFinal](
	[BuildingId] [int] NOT NULL,
	[BuildingName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Apartment] [nvarchar](200) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[price] [int] NOT NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_BuildingFinal] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 2022-12-12 1:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buildings](
	[BuildingId] [int] IDENTITY(1,1) NOT NULL,
	[BuildingName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2022-12-12 1:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeUserId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 2022-12-12 1:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](1000) NOT NULL,
	[TenantUserId] [int] NOT NULL,
	[EmployeeUserId] [int] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 2022-12-12 1:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[RentalId] [int] IDENTITY(1,1) NOT NULL,
	[RentalPrice] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[ApartmentId] [int] NOT NULL,
	[TenantUserID] [int] NOT NULL,
	[EmployeeUserID] [int] NOT NULL,
 CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED 
(
	[RentalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 2022-12-12 1:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[ScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleDate] [date] NOT NULL,
	[ScheduleTime] [datetime] NOT NULL,
	[TenantUserId] [int] NOT NULL,
	[EmployeeUserId] [int] NOT NULL,
	[AppointmentId] [int] NOT NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenants]    Script Date: 2022-12-12 1:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenants](
	[TenantUserId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Tenants] PRIMARY KEY CLUSTERED 
(
	[TenantUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2022-12-12 1:24:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UFirstName] [nvarchar](50) NOT NULL,
	[ULastName] [nvarchar](50) NOT NULL,
	[UEmail] [nvarchar](50) NOT NULL,
	[UPhoneNumber] [nvarchar](50) NOT NULL,
	[UPassword] [nvarchar](50) NOT NULL,
	[UserType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressId], [StreetNumber], [StreetName], [City], [Province], [PostalCode]) VALUES (1391, 1200, N'Cresent', N'Montreal', N'QC', N'H3H2R7')
INSERT [dbo].[Addresses] ([AddressId], [StreetNumber], [StreetName], [City], [Province], [PostalCode]) VALUES (1392, 1100, N'De la gauchtiere', N'Montreal', N'QC', N'H3H2R7')
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
INSERT [dbo].[Apartments] ([ApartmentNumber], [ApartmentType], [Description], [Floor], [Status], [BuildingId]) VALUES (1001, N'Condo', N'Good, very Good, bon, tres bon!', 10, N'On Sale', 2)
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([AppointmentId], [AppointmentDate], [AppointmentTime], [TenantUserId], [EmployeeUserId]) VALUES (1, CAST(N'2022-12-01' AS Date), CAST(N'2022-12-01T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Appointments] ([AppointmentId], [AppointmentDate], [AppointmentTime], [TenantUserId], [EmployeeUserId]) VALUES (2, CAST(N'2022-12-01' AS Date), CAST(N'2022-10-08T00:00:00.000' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
INSERT [dbo].[BuildingFinal] ([BuildingId], [BuildingName], [Address], [Apartment], [Status], [price], [Description]) VALUES (2, N'Building Manifest', N'1200 Rue du Cresent, Montreal, Quebec, H3H 2R7', N'#1801', N'On Sale', 1600, N'Rare two-storey Penthouse condo with high ceiling, wall to wall glass, two unusually large balconies in both floors. Two compete bathrooms (one has shower and bidet), one garage, with spacious blissful master bedroom on top floor (10th floor)with good size closet. Wide entrance landing area, open concept kitchen, spacious dining room and living area. One indoor garage and locker.')
INSERT [dbo].[BuildingFinal] ([BuildingId], [BuildingName], [Address], [Apartment], [Status], [price], [Description]) VALUES (3, N'Luxury Gabriel', N'190 Rue du Rene Pierre, Quebec, Quebec, G1N 2E6', N'#565', N'On Sale', 1000, N'Ideal location! walking distance to Du Collège metro station, lower duplex apartment with a nice open concept kitchen on the 1st floor 2 bedrooms, and a bathroom, in the basement you will find a family room, another bedroom, and a bathroom, 2 outdoor parking spaces, access to the backyard. A must-see!')
GO
SET IDENTITY_INSERT [dbo].[Buildings] ON 

INSERT [dbo].[Buildings] ([BuildingId], [BuildingName], [AddressId]) VALUES (2, N'Huaguo Yuan', 1391)
SET IDENTITY_INSERT [dbo].[Buildings] OFF
GO
INSERT [dbo].[Employees] ([EmployeeUserId], [UserId]) VALUES (1, 1003)
INSERT [dbo].[Employees] ([EmployeeUserId], [UserId]) VALUES (2, 1005)
INSERT [dbo].[Employees] ([EmployeeUserId], [UserId]) VALUES (3, 1009)
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([MessageId], [Message], [TenantUserId], [EmployeeUserId]) VALUES (1, N'Hi, I am interested in...............', 1, 1)
INSERT [dbo].[Messages] ([MessageId], [Message], [TenantUserId], [EmployeeUserId]) VALUES (7, N'Hello, I am .... ', 1, 1)
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([RentalId], [RentalPrice], [StartDate], [EndDate], [ApartmentId], [TenantUserID], [EmployeeUserID]) VALUES (1, 1500, CAST(N'2022-12-01' AS Date), CAST(N'2023-12-01' AS Date), 1001, 1, 1)
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
INSERT [dbo].[Tenants] ([TenantUserId], [UserId]) VALUES (1, 1001)
INSERT [dbo].[Tenants] ([TenantUserId], [UserId]) VALUES (2, 1002)
INSERT [dbo].[Tenants] ([TenantUserId], [UserId]) VALUES (3, 1007)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UFirstName], [ULastName], [UEmail], [UPhoneNumber], [UPassword], [UserType]) VALUES (1001, N'Jimmy', N'Karts', N'jimmy@gmail.com', N'6669996699', N'jimmy', N'Tenant')
INSERT [dbo].[Users] ([UserId], [UFirstName], [ULastName], [UEmail], [UPhoneNumber], [UPassword], [UserType]) VALUES (1002, N'Kim', N'J', N'kim@gmail.com', N'4448888484', N'kim', N'Tenant')
INSERT [dbo].[Users] ([UserId], [UFirstName], [ULastName], [UEmail], [UPhoneNumber], [UPassword], [UserType]) VALUES (1003, N'Katherine', N'Ammy', N'katherine@gmail.com', N'6678888989', N'kartherine', N'Employee')
INSERT [dbo].[Users] ([UserId], [UFirstName], [ULastName], [UEmail], [UPhoneNumber], [UPassword], [UserType]) VALUES (1005, N'Array', N'Jay', N'array@gmail.com', N'4668788987', N'array', N'Employee')
INSERT [dbo].[Users] ([UserId], [UFirstName], [ULastName], [UEmail], [UPhoneNumber], [UPassword], [UserType]) VALUES (1007, N'Ming', N'Li', N'MingyaoLee520@gmail.com', N'4389413898', N's', N'Tenant')
INSERT [dbo].[Users] ([UserId], [UFirstName], [ULastName], [UEmail], [UPhoneNumber], [UPassword], [UserType]) VALUES (1009, N'Ming', N'Li', N'MingyaoLee520@gmail.com', N'4389413898', N'sa', N'Employee')
INSERT [dbo].[Users] ([UserId], [UFirstName], [ULastName], [UEmail], [UPhoneNumber], [UPassword], [UserType]) VALUES (1010, N'Xander', N'Alex', N'xander@yahoo.com', N'5483883575', N'xander', N'Tenant')
INSERT [dbo].[Users] ([UserId], [UFirstName], [ULastName], [UEmail], [UPhoneNumber], [UPassword], [UserType]) VALUES (1011, N'Mingyao', N'Li', N'MingyaoLee520@gmail.com', N'4389413898', N'ss', N'Tenant')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Apartments]  WITH CHECK ADD  CONSTRAINT [FK_Apartments_Buildings] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([BuildingId])
GO
ALTER TABLE [dbo].[Apartments] CHECK CONSTRAINT [FK_Apartments_Buildings]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Employees] FOREIGN KEY([EmployeeUserId])
REFERENCES [dbo].[Employees] ([EmployeeUserId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Employees]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Tenants] FOREIGN KEY([TenantUserId])
REFERENCES [dbo].[Tenants] ([TenantUserId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Tenants]
GO
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_Buildings_Addresses]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Users]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Employees] FOREIGN KEY([EmployeeUserId])
REFERENCES [dbo].[Employees] ([EmployeeUserId])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Employees]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Tenants] FOREIGN KEY([TenantUserId])
REFERENCES [dbo].[Tenants] ([TenantUserId])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Tenants]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Apartments] FOREIGN KEY([ApartmentId])
REFERENCES [dbo].[Apartments] ([ApartmentNumber])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Apartments]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Employees] FOREIGN KEY([EmployeeUserID])
REFERENCES [dbo].[Employees] ([EmployeeUserId])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Employees]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Tenants] FOREIGN KEY([TenantUserID])
REFERENCES [dbo].[Tenants] ([TenantUserId])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Tenants]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Appointments] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[Appointments] ([AppointmentId])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Appointments]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Employees] FOREIGN KEY([EmployeeUserId])
REFERENCES [dbo].[Employees] ([EmployeeUserId])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Employees]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Tenants] FOREIGN KEY([TenantUserId])
REFERENCES [dbo].[Tenants] ([TenantUserId])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Tenants]
GO
ALTER TABLE [dbo].[Tenants]  WITH CHECK ADD  CONSTRAINT [FK_Tenants_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Tenants] CHECK CONSTRAINT [FK_Tenants_Users]
GO
USE [master]
GO
ALTER DATABASE [PropertyRentalManagementDB] SET  READ_WRITE 
GO
