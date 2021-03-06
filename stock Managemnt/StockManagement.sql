USE [master]
GO
/****** Object:  Database [StockManagementNauticDb]    Script Date: 11/28/2018 5:41:50 PM ******/
CREATE DATABASE [StockManagementNauticDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StockManagementNauticDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\StockManagementNauticDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StockManagementNauticDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\StockManagementNauticDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StockManagementNauticDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StockManagementNauticDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StockManagementNauticDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StockManagementNauticDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StockManagementNauticDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StockManagementNauticDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StockManagementNauticDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StockManagementNauticDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StockManagementNauticDb] SET  MULTI_USER 
GO
ALTER DATABASE [StockManagementNauticDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StockManagementNauticDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StockManagementNauticDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StockManagementNauticDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StockManagementNauticDb]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/28/2018 5:41:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company]    Script Date: 11/28/2018 5:41:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item]    Script Date: 11/28/2018 5:41:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](100) NULL,
	[ReorderLevel] [int] NULL,
	[AvailableQuantity] [int] NULL,
	[CompanyId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockOut]    Script Date: 11/28/2018 5:41:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockOut](
	[StockOutId] [int] IDENTITY(1,1) NOT NULL,
	[Action] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Date] [varchar](50) NOT NULL,
	[ItemId] [int] NOT NULL,
 CONSTRAINT [PK_StockOut] PRIMARY KEY CLUSTERED 
(
	[StockOutId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ItemsView]    Script Date: 11/28/2018 5:41:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ItemsView]
AS
SELECT        dbo.Item.ItemId, dbo.Item.ItemName, dbo.Item.AvailableQuantity, dbo.Company.CompanyId, dbo.Company.CompanyName, dbo.Category.CategoryId, dbo.Category.CategoryName, dbo.Item.ReorderLevel
FROM            dbo.Item INNER JOIN
                         dbo.Company ON dbo.Item.CompanyId = dbo.Company.CompanyId INNER JOIN
                         dbo.Category ON dbo.Item.CategoryId = dbo.Category.CategoryId



GO
/****** Object:  View [dbo].[StockOutView]    Script Date: 11/28/2018 5:41:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StockOutView]
AS
SELECT ItemsView.ItemId, ItemsView.ItemName, ItemsView.AvailableQuantity, ItemsView.CompanyId, ItemsView.CompanyName, StockOut.StockOutId, StockOut.Action, StockOut.Quantity, StockOut.Date
FROM ItemsView INNER JOIN StockOut ON ItemsView.ItemId = StockOut.ItemId



GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Stationares')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Cosmetics')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Electronics')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Kitchen Items')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (1, N'Unilever')
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (2, N'Walton')
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (3, N'Samsung')
INSERT [dbo].[Company] ([CompanyId], [CompanyName]) VALUES (4, N'RFL')
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([ItemId], [ItemName], [ReorderLevel], [AvailableQuantity], [CompanyId], [CategoryId]) VALUES (1, N'Laptop', 10, 50, 3, 3)
INSERT [dbo].[Item] ([ItemId], [ItemName], [ReorderLevel], [AvailableQuantity], [CompanyId], [CategoryId]) VALUES (2, N'Laptop', 10, 344, 2, 3)
INSERT [dbo].[Item] ([ItemId], [ItemName], [ReorderLevel], [AvailableQuantity], [CompanyId], [CategoryId]) VALUES (3, N'Mobile', 10, 43, 2, 3)
INSERT [dbo].[Item] ([ItemId], [ItemName], [ReorderLevel], [AvailableQuantity], [CompanyId], [CategoryId]) VALUES (4, N'Soap', 7, 8, 1, 2)
INSERT [dbo].[Item] ([ItemId], [ItemName], [ReorderLevel], [AvailableQuantity], [CompanyId], [CategoryId]) VALUES (5, N'Chair', 0, 87, 4, 4)
INSERT [dbo].[Item] ([ItemId], [ItemName], [ReorderLevel], [AvailableQuantity], [CompanyId], [CategoryId]) VALUES (6, N'Table', 2, 155, 4, 4)
INSERT [dbo].[Item] ([ItemId], [ItemName], [ReorderLevel], [AvailableQuantity], [CompanyId], [CategoryId]) VALUES (7, N'Battery', 0, 431, 2, 1)
SET IDENTITY_INSERT [dbo].[Item] OFF
SET IDENTITY_INSERT [dbo].[StockOut] ON 

INSERT [dbo].[StockOut] ([StockOutId], [Action], [Quantity], [Date], [ItemId]) VALUES (1, N'sell', 2, N'2018-11-28', 4)
INSERT [dbo].[StockOut] ([StockOutId], [Action], [Quantity], [Date], [ItemId]) VALUES (2, N'damage', 2, N'2018-11-28', 1)
INSERT [dbo].[StockOut] ([StockOutId], [Action], [Quantity], [Date], [ItemId]) VALUES (3, N'sell', 10, N'2018-11-28', 2)
INSERT [dbo].[StockOut] ([StockOutId], [Action], [Quantity], [Date], [ItemId]) VALUES (4, N'damage', 10, N'2018-11-28', 7)
INSERT [dbo].[StockOut] ([StockOutId], [Action], [Quantity], [Date], [ItemId]) VALUES (5, N'damage', 3, N'2018-11-28', 7)
INSERT [dbo].[StockOut] ([StockOutId], [Action], [Quantity], [Date], [ItemId]) VALUES (6, N'sell', 10, N'2018-11-28', 7)
SET IDENTITY_INSERT [dbo].[StockOut] OFF
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Category]
GO
ALTER TABLE [dbo].[StockOut]  WITH CHECK ADD  CONSTRAINT [FK_StockOut_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[StockOut] CHECK CONSTRAINT [FK_StockOut_Item]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[42] 4[13] 2[29] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Company"
            Begin Extent = 
               Top = 6
               Left = 259
               Bottom = 102
               Right = 432
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Category"
            Begin Extent = 
               Top = 102
               Left = 259
               Bottom = 198
               Right = 429
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Item"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ItemsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ItemsView'
GO
USE [master]
GO
ALTER DATABASE [StockManagementNauticDb] SET  READ_WRITE 
GO
