USE [master]
GO
/****** Object:  Database [TravelDb]    Script Date: 1.01.2024 14:15:37 ******/
CREATE DATABASE [TravelDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TravelDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TravelDb.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TravelDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TravelDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TravelDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TravelDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TravelDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TravelDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TravelDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TravelDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TravelDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TravelDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TravelDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TravelDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TravelDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TravelDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TravelDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TravelDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TravelDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TravelDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TravelDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TravelDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TravelDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TravelDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TravelDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TravelDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TravelDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TravelDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TravelDb] SET RECOVERY FULL 
GO
ALTER DATABASE [TravelDb] SET  MULTI_USER 
GO
ALTER DATABASE [TravelDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TravelDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TravelDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TravelDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TravelDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TravelDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TravelDb', N'ON'
GO
ALTER DATABASE [TravelDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [TravelDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TravelDb]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 1.01.2024 14:15:37 ******/
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
/****** Object:  Table [dbo].[BlogCityRelations]    Script Date: 1.01.2024 14:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogCityRelations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[IsStatus] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[City_Id] [int] NULL,
 CONSTRAINT [PK_dbo.BlogCityRelations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogComments]    Script Date: 1.01.2024 14:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[comment] [nvarchar](max) NULL,
	[BlogId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[commentDate] [datetime] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[IsStatus] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.BlogComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogLikeRelations]    Script Date: 1.01.2024 14:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogLikeRelations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[BlogId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[IsStatus] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[User_Id] [int] NULL,
	[Blog_Id] [int] NULL,
 CONSTRAINT [PK_dbo.BlogLikeRelations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 1.01.2024 14:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](max) NULL,
	[content] [nvarchar](max) NULL,
	[likeNumbers] [int] NOT NULL,
	[postDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[IsStatus] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[IsSpam] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 1.01.2024 14:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[IsStatus] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 1.01.2024 14:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[IsStatus] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1.01.2024 14:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](max) NULL,
	[userName] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[RoleId] [int] NOT NULL,
	[createTime] [datetime] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[IsStatus] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogId]    Script Date: 1.01.2024 14:15:37 ******/
CREATE NONCLUSTERED INDEX [IX_BlogId] ON [dbo].[BlogCityRelations]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_City_Id]    Script Date: 1.01.2024 14:15:37 ******/
CREATE NONCLUSTERED INDEX [IX_City_Id] ON [dbo].[BlogCityRelations]
(
	[City_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CityId]    Script Date: 1.01.2024 14:15:37 ******/
CREATE NONCLUSTERED INDEX [IX_CityId] ON [dbo].[BlogCityRelations]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogId]    Script Date: 1.01.2024 14:15:37 ******/
CREATE NONCLUSTERED INDEX [IX_BlogId] ON [dbo].[BlogComments]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 1.01.2024 14:15:37 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[BlogComments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Blog_Id]    Script Date: 1.01.2024 14:15:37 ******/
CREATE NONCLUSTERED INDEX [IX_Blog_Id] ON [dbo].[BlogLikeRelations]
(
	[Blog_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogId]    Script Date: 1.01.2024 14:15:37 ******/
CREATE NONCLUSTERED INDEX [IX_BlogId] ON [dbo].[BlogLikeRelations]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_Id]    Script Date: 1.01.2024 14:15:37 ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[BlogLikeRelations]
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 1.01.2024 14:15:37 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[BlogLikeRelations]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 1.01.2024 14:15:37 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Blogs]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleId]    Script Date: 1.01.2024 14:15:37 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Blogs] ADD  DEFAULT ((0)) FOR [IsSpam]
GO
ALTER TABLE [dbo].[BlogCityRelations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlogCityRelations_dbo.Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[BlogCityRelations] CHECK CONSTRAINT [FK_dbo.BlogCityRelations_dbo.Blogs_BlogId]
GO
ALTER TABLE [dbo].[BlogCityRelations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlogCityRelations_dbo.Cities_City_Id] FOREIGN KEY([City_Id])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[BlogCityRelations] CHECK CONSTRAINT [FK_dbo.BlogCityRelations_dbo.Cities_City_Id]
GO
ALTER TABLE [dbo].[BlogCityRelations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlogCityRelations_dbo.Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[BlogCityRelations] CHECK CONSTRAINT [FK_dbo.BlogCityRelations_dbo.Cities_CityId]
GO
ALTER TABLE [dbo].[BlogComments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlogComments_dbo.Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[BlogComments] CHECK CONSTRAINT [FK_dbo.BlogComments_dbo.Blogs_BlogId]
GO
ALTER TABLE [dbo].[BlogComments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlogComments_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogComments] CHECK CONSTRAINT [FK_dbo.BlogComments_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[BlogLikeRelations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlogLikeRelations_dbo.Blogs_Blog_Id] FOREIGN KEY([Blog_Id])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[BlogLikeRelations] CHECK CONSTRAINT [FK_dbo.BlogLikeRelations_dbo.Blogs_Blog_Id]
GO
ALTER TABLE [dbo].[BlogLikeRelations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlogLikeRelations_dbo.Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[BlogLikeRelations] CHECK CONSTRAINT [FK_dbo.BlogLikeRelations_dbo.Blogs_BlogId]
GO
ALTER TABLE [dbo].[BlogLikeRelations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlogLikeRelations_dbo.Users_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[BlogLikeRelations] CHECK CONSTRAINT [FK_dbo.BlogLikeRelations_dbo.Users_User_Id]
GO
ALTER TABLE [dbo].[BlogLikeRelations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlogLikeRelations_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[BlogLikeRelations] CHECK CONSTRAINT [FK_dbo.BlogLikeRelations_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Blogs_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_dbo.Blogs_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [TravelDb] SET  READ_WRITE 
GO
