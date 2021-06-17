USE [master]
GO
/****** Object:  Database [DataManager]    Script Date: 17/06/2021 0:30:33 ******/
CREATE DATABASE [DataManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DataManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DataManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DataManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DataManager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataManager] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DataManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataManager] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DataManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataManager] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DataManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataManager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DataManager] SET  MULTI_USER 
GO
ALTER DATABASE [DataManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DataManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DataManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DataManager] SET QUERY_STORE = OFF
GO
USE [DataManager]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 17/06/2021 0:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 17/06/2021 0:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[User_Username] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditCardDataBreaches]    Script Date: 17/06/2021 0:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCardDataBreaches](
	[CreditCard_Id] [int] NOT NULL,
	[DataBreach_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CreditCardDataBreaches] PRIMARY KEY CLUSTERED 
(
	[CreditCard_Id] ASC,
	[DataBreach_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditCards]    Script Date: 17/06/2021 0:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](max) NULL,
	[HideNumber] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[ExpirationDate] [datetime] NOT NULL,
	[Category_Id] [int] NULL,
 CONSTRAINT [PK_dbo.CreditCards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataBreaches]    Script Date: 17/06/2021 0:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataBreaches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[User_Username] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.DataBreaches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeakedCreditCards]    Script Date: 17/06/2021 0:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeakedCreditCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](max) NULL,
	[DataBreach_Id] [int] NULL,
 CONSTRAINT [PK_dbo.LeakedCreditCards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeakedPasswords]    Script Date: 17/06/2021 0:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeakedPasswords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[DataBreach_Id] [int] NULL,
 CONSTRAINT [PK_dbo.LeakedPasswords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SharedPasswords]    Script Date: 17/06/2021 0:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SharedPasswords](
	[User_Username] [nvarchar](128) NOT NULL,
	[UserPasswordPair_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SharedPasswords] PRIMARY KEY CLUSTERED 
(
	[User_Username] ASC,
	[UserPasswordPair_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPasswordPairDataBreaches]    Script Date: 17/06/2021 0:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPasswordPairDataBreaches](
	[UserPasswordPair_Id] [int] NOT NULL,
	[DataBreach_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserPasswordPairDataBreaches] PRIMARY KEY CLUSTERED 
(
	[UserPasswordPair_Id] ASC,
	[DataBreach_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPasswordPairs]    Script Date: 17/06/2021 0:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPasswordPairs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EncryptedPassword] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Site] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[PasswordStrength] [int] NOT NULL,
	[LastModifiedDate] [datetime2](7) NOT NULL,
	[Category_Id] [int] NULL,
 CONSTRAINT [PK_dbo.UserPasswordPairs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17/06/2021 0:30:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Username] [nvarchar](128) NOT NULL,
	[EncryptedMasterPassword] [nvarchar](max) NULL,
	[PublicKey] [nvarchar](max) NULL,
	[PrivateKey] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_User_Username]    Script Date: 17/06/2021 0:30:34 ******/
CREATE NONCLUSTERED INDEX [IX_User_Username] ON [dbo].[Categories]
(
	[User_Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CreditCard_Id]    Script Date: 17/06/2021 0:30:34 ******/
CREATE NONCLUSTERED INDEX [IX_CreditCard_Id] ON [dbo].[CreditCardDataBreaches]
(
	[CreditCard_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DataBreach_Id]    Script Date: 17/06/2021 0:30:34 ******/
CREATE NONCLUSTERED INDEX [IX_DataBreach_Id] ON [dbo].[CreditCardDataBreaches]
(
	[DataBreach_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Category_Id]    Script Date: 17/06/2021 0:30:34 ******/
CREATE NONCLUSTERED INDEX [IX_Category_Id] ON [dbo].[CreditCards]
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_User_Username]    Script Date: 17/06/2021 0:30:34 ******/
CREATE NONCLUSTERED INDEX [IX_User_Username] ON [dbo].[DataBreaches]
(
	[User_Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DataBreach_Id]    Script Date: 17/06/2021 0:30:34 ******/
CREATE NONCLUSTERED INDEX [IX_DataBreach_Id] ON [dbo].[LeakedCreditCards]
(
	[DataBreach_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DataBreach_Id]    Script Date: 17/06/2021 0:30:34 ******/
CREATE NONCLUSTERED INDEX [IX_DataBreach_Id] ON [dbo].[LeakedPasswords]
(
	[DataBreach_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_User_Username]    Script Date: 17/06/2021 0:30:34 ******/
CREATE NONCLUSTERED INDEX [IX_User_Username] ON [dbo].[SharedPasswords]
(
	[User_Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserPasswordPair_Id]    Script Date: 17/06/2021 0:30:34 ******/
CREATE NONCLUSTERED INDEX [IX_UserPasswordPair_Id] ON [dbo].[SharedPasswords]
(
	[UserPasswordPair_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DataBreach_Id]    Script Date: 17/06/2021 0:30:34 ******/
CREATE NONCLUSTERED INDEX [IX_DataBreach_Id] ON [dbo].[UserPasswordPairDataBreaches]
(
	[DataBreach_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserPasswordPair_Id]    Script Date: 17/06/2021 0:30:34 ******/
CREATE NONCLUSTERED INDEX [IX_UserPasswordPair_Id] ON [dbo].[UserPasswordPairDataBreaches]
(
	[UserPasswordPair_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Category_Id]    Script Date: 17/06/2021 0:30:34 ******/
CREATE NONCLUSTERED INDEX [IX_Category_Id] ON [dbo].[UserPasswordPairs]
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Categories_dbo.Users_User_Username] FOREIGN KEY([User_Username])
REFERENCES [dbo].[Users] ([Username])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_dbo.Categories_dbo.Users_User_Username]
GO
ALTER TABLE [dbo].[CreditCardDataBreaches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditCardDataBreaches_dbo.CreditCards_CreditCard_Id] FOREIGN KEY([CreditCard_Id])
REFERENCES [dbo].[CreditCards] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CreditCardDataBreaches] CHECK CONSTRAINT [FK_dbo.CreditCardDataBreaches_dbo.CreditCards_CreditCard_Id]
GO
ALTER TABLE [dbo].[CreditCardDataBreaches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditCardDataBreaches_dbo.DataBreaches_DataBreach_Id] FOREIGN KEY([DataBreach_Id])
REFERENCES [dbo].[DataBreaches] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CreditCardDataBreaches] CHECK CONSTRAINT [FK_dbo.CreditCardDataBreaches_dbo.DataBreaches_DataBreach_Id]
GO
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditCards_dbo.Categories_Category_Id] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_dbo.CreditCards_dbo.Categories_Category_Id]
GO
ALTER TABLE [dbo].[DataBreaches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DataBreaches_dbo.Users_User_Username] FOREIGN KEY([User_Username])
REFERENCES [dbo].[Users] ([Username])
GO
ALTER TABLE [dbo].[DataBreaches] CHECK CONSTRAINT [FK_dbo.DataBreaches_dbo.Users_User_Username]
GO
ALTER TABLE [dbo].[LeakedCreditCards]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LeakedCreditCards_dbo.DataBreaches_DataBreach_Id] FOREIGN KEY([DataBreach_Id])
REFERENCES [dbo].[DataBreaches] ([Id])
GO
ALTER TABLE [dbo].[LeakedCreditCards] CHECK CONSTRAINT [FK_dbo.LeakedCreditCards_dbo.DataBreaches_DataBreach_Id]
GO
ALTER TABLE [dbo].[LeakedPasswords]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LeakedPasswords_dbo.DataBreaches_DataBreach_Id] FOREIGN KEY([DataBreach_Id])
REFERENCES [dbo].[DataBreaches] ([Id])
GO
ALTER TABLE [dbo].[LeakedPasswords] CHECK CONSTRAINT [FK_dbo.LeakedPasswords_dbo.DataBreaches_DataBreach_Id]
GO
ALTER TABLE [dbo].[SharedPasswords]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SharedPasswords_dbo.UserPasswordPairs_UserPasswordPair_Id] FOREIGN KEY([UserPasswordPair_Id])
REFERENCES [dbo].[UserPasswordPairs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SharedPasswords] CHECK CONSTRAINT [FK_dbo.SharedPasswords_dbo.UserPasswordPairs_UserPasswordPair_Id]
GO
ALTER TABLE [dbo].[SharedPasswords]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SharedPasswords_dbo.Users_User_Username] FOREIGN KEY([User_Username])
REFERENCES [dbo].[Users] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SharedPasswords] CHECK CONSTRAINT [FK_dbo.SharedPasswords_dbo.Users_User_Username]
GO
ALTER TABLE [dbo].[UserPasswordPairDataBreaches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserPasswordPairDataBreaches_dbo.DataBreaches_DataBreach_Id] FOREIGN KEY([DataBreach_Id])
REFERENCES [dbo].[DataBreaches] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserPasswordPairDataBreaches] CHECK CONSTRAINT [FK_dbo.UserPasswordPairDataBreaches_dbo.DataBreaches_DataBreach_Id]
GO
ALTER TABLE [dbo].[UserPasswordPairDataBreaches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserPasswordPairDataBreaches_dbo.UserPasswordPairs_UserPasswordPair_Id] FOREIGN KEY([UserPasswordPair_Id])
REFERENCES [dbo].[UserPasswordPairs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserPasswordPairDataBreaches] CHECK CONSTRAINT [FK_dbo.UserPasswordPairDataBreaches_dbo.UserPasswordPairs_UserPasswordPair_Id]
GO
ALTER TABLE [dbo].[UserPasswordPairs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserPasswordPairs_dbo.Categories_Category_Id] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[UserPasswordPairs] CHECK CONSTRAINT [FK_dbo.UserPasswordPairs_dbo.Categories_Category_Id]
GO
USE [master]
GO
ALTER DATABASE [DataManager] SET  READ_WRITE 
GO
