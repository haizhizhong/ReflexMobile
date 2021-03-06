/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.1742)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [ReflexMobile]
GO
/****** Object:  Table [dbo].[CFS_FileLink]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFS_FileLink](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FileRepository_ID] [int] NULL,
	[CompanyID] [int] NULL,
	[DBFlavour] [varchar](5) NULL,
	[ContextItem_ID] [int] NULL,
	[IsOrigin] [bit] NULL,
	[TableDotField] [varchar](60) NULL,
	[IDValue] [int] NULL,
	[TargetPrint] [varchar](3) NULL,
	[Comment] [varchar](max) NULL,
	[ElectronicSaveSetup_ID] [int] NULL,
	[LinkOrigin] [varchar](30) NULL,
	[DraftingFileTypeID] [int] NULL,
	[OriginalSrcID] [int] NULL,
	[MatchId] [int] NULL,
	[SyncStatus] [varchar](20) NULL,
 CONSTRAINT [PK__CFS_File__3214EC27060DEAE8] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CFS_FileRepository]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFS_FileRepository](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](255) NULL,
	[FileData] [varbinary](max) NULL,
	[FileTypeDescription] [varchar](max) NULL,
	[AddedBy] [varchar](10) NULL,
	[DateAdded] [datetime] NULL,
	[FileType] [varchar](2) NULL,
	[TempID] [int] NULL,
	[TempLink] [varchar](50) NULL,
	[Mime_type] [varchar](200) NULL,
	[InternalOnly] [bit] NOT NULL,
	[FileStatus] [char](1) NOT NULL,
	[FileOrigin] [varchar](10) NULL,
	[OriginLink] [int] NULL,
	[OriginLink2] [int] NULL,
	[Ext]  AS (reverse(left(reverse([FileName]),charindex('.',reverse([FileName]))))) PERSISTED,
	[permanent_tf] [varchar](1) NULL,
	[CurrentTCSE_ID] [int] NOT NULL,
	[ContactID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CFS_LinkKey]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFS_LinkKey](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TableDotField] [varchar](60) NULL,
	[Description] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CFS_MimeType]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFS_MimeType](
	[Extension] [varchar](25) NOT NULL,
	[MimeType] [varchar](250) NULL,
 CONSTRAINT [PK_CFS_MimeType] PRIMARY KEY CLUSTERED 
(
	[Extension] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChangeOrder]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[EstimateId] [int] NOT NULL,
	[ChangeOrderNum] [int] NULL,
	[ChangeOrderName] [varchar](100) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_ChangeOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[ShortName] [varchar](10) NULL,
	[WeekStart] [tinyint] NOT NULL,
	[EquipRateGroupType] [char](1) NOT NULL,
	[MaxLevelCode] [int] NOT NULL,
	[Level1CodeDesc] [varchar](40) NOT NULL,
	[Level2CodeDesc] [varchar](40) NOT NULL,
	[Level3CodeDesc] [varchar](40) NOT NULL,
	[Level4CodeDesc] [varchar](40) NOT NULL,
	[Active] [bit] NOT NULL,
	[InSync] [bit] NOT NULL,
	[CompanyAddress1] [varchar](40) NULL,
	[CompanyAddress2] [varchar](40) NULL,
	[CompanyAddress3] [varchar](40) NULL,
	[CompanyCity] [varchar](20) NULL,
	[CompanyState] [varchar](15) NULL,
	[CompanyZip] [varchar](9) NULL,
	[CompanyPhone] [varchar](20) NULL,
	[CompanyFax] [varchar](20) NULL,
	[CompanyEmail] [varchar](50) NULL,
	[CompanyWeb] [varchar](500) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanySyncProcess]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanySyncProcess](
	[CompanyId] [int] NOT NULL,
	[SyncProcess] [varchar](30) NOT NULL,
	[SyncId] [int] NOT NULL,
	[SyncType] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContextGroup]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContextGroup](
	[ID] [int] NOT NULL,
	[Name] [varchar](100) NULL,
	[IsSystem] [bit] NULL,
	[InSync] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContextItem]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContextItem](
	[ID] [int] NOT NULL,
	[ContextGroupID] [int] NULL,
	[Name] [varchar](100) NULL,
	[WordMergeDSN] [varchar](100) NULL,
	[IsSystem] [bit] NULL,
	[InSync] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContextUsage]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContextUsage](
	[id] [int] NOT NULL,
	[ContextItemID] [int] NULL,
	[ContextGroupID] [int] NULL,
	[InSync] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostCodeMapping]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostCodeMapping](
	[CompanyId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[MappingId] [int] NOT NULL,
	[MappingCode] [varchar](15) NOT NULL,
	[InSync] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DATABASE_SETUP]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DATABASE_SETUP](
	[LOGON_DB] [varchar](50) NULL,
	[RES_DB] [varchar](50) NULL,
	[COMM_DB] [varchar](50) NULL,
	[LAND_DB] [varchar](50) NULL,
	[HUMAN_DB] [varchar](50) NULL,
	[tac_db] [varchar](50) NULL,
	[WEB_DB] [varchar](50) NULL,
	[WEB_SERVER] [varchar](500) NULL,
	[tr_db] [varchar](50) NULL,
	[ResConverted] [bit] NOT NULL,
	[CommConverted] [bit] NOT NULL,
	[REPORT_LOGGING] [varchar](1) NULL,
	[MEMB_DB] [varchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DM_DB] [varchar](50) NULL,
	[CSW_DB] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DefaultEarning]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefaultEarning](
	[CompanyId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Level1Id] [int] NULL,
	[Level2Id] [int] NULL,
	[Level3Id] [int] NULL,
	[Level4Id] [int] NULL,
	[EarningType] [char](1) NOT NULL,
	[InSync] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeleteHistory]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeleteHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [varchar](50) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[SyncStatus] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpNum] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[WorkClassCode] [varchar](5) NOT NULL,
	[OvertimeCode] [varchar](5) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[EqpNum] [varchar](10) NOT NULL,
	[AssetCode] [varchar](15) NOT NULL,
	[Desc] [varchar](100) NULL,
	[ClassCode] [varchar](5) NULL,
	[CategoryCode] [varchar](5) NULL,
	[OwnerType] [char](1) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentAssignment]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentAssignment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[EqpNum] [varchar](10) NOT NULL,
	[EmpNum] [int] NOT NULL,
	[AssignedDate] [datetime] NULL,
	[ReleasedDate] [datetime] NULL,
	[EarnGroup] [varchar](5) NOT NULL,
	[EarnCode] [varchar](5) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_EquipmentAssignment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentBillRate]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentBillRate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[EqpNum] [varchar](10) NOT NULL,
	[BillCycle] [char](1) NOT NULL,
	[BillRate] [money] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_EquipmentBillRate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentCategory]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Code] [varchar](5) NOT NULL,
	[Desc] [varchar](50) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_EquipmentEquipmentCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentClass]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Code] [varchar](5) NOT NULL,
	[Desc] [varchar](50) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_EquipmentClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentDefaultBillRate]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentDefaultBillRate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[GroupType] [char](1) NOT NULL,
	[BillCycle] [char](1) NOT NULL,
	[BillRate] [money] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_EquipmentDefaultBillRate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentGroupBillRate]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentGroupBillRate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ProjectId] [int] NULL,
	[GroupCode] [varchar](5) NOT NULL,
	[GroupType] [char](1) NOT NULL,
	[BillCycle] [char](1) NOT NULL,
	[BillRate] [money] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_EquipmentClassBillRate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentTemplate]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[EquipClassCode] [varchar](5) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[EqpNum] [varchar](10) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_EquipmentTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipTimeEntry]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipTimeEntry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[LogHeaderId] [int] NOT NULL,
	[EqpNum] [varchar](50) NOT NULL,
	[EmpNum] [int] NULL,
	[Level1Id] [int] NULL,
	[Level2Id] [int] NULL,
	[Level3Id] [int] NULL,
	[Level4Id] [int] NULL,
	[Billable] [bit] NOT NULL,
	[Quantity] [decimal](14, 4) NOT NULL,
	[BillCycle] [char](1) NOT NULL,
	[BillAmount] [money] NULL,
	[ChangeOrderId] [int] NULL,
	[SyncStatus] [varchar](20) NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_EquipTimeEntry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldPO]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldPO](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[PODate] [datetime] NOT NULL,
	[PONum] [varchar](20) NOT NULL,
	[SupplierCode] [varchar](40) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Billable] [bit] NOT NULL,
	[POAmount] [money] NOT NULL,
	[FieldPOStatus] [char](1) NOT NULL,
	[CreatorId] [int] NOT NULL,
	[SyncStatus] [varchar](20) NULL,
 CONSTRAINT [PK_FieldPO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldPODetail]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldPODetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[POId] [int] NOT NULL,
	[LineNum] [smallint] NOT NULL,
	[Description] [varchar](150) NOT NULL,
	[Level1Code] [int] NULL,
	[Level2Code] [int] NULL,
	[Level3Code] [int] NULL,
	[Level4Code] [int] NULL,
	[Billable] [bit] NOT NULL,
	[Amount] [money] NOT NULL,
	[Component] [char](1) NOT NULL,
 CONSTRAINT [PK_FieldPODetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LabourTemplate]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabourTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[EmpNum] [int] NOT NULL,
	[WorkClassCode] [varchar](5) NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_LabourTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LabourTimeDetail]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabourTimeDetail](
	[DetailId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[EntryId] [int] NOT NULL,
	[TimeCodeId] [int] NOT NULL,
	[BillRate] [money] NULL,
	[WorkHours] [decimal](10, 4) NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_LabourTimeDetail] PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LabourTimeEntry]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabourTimeEntry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[LogHeaderId] [int] NOT NULL,
	[EmpNum] [int] NOT NULL,
	[Level1Id] [int] NULL,
	[Level2Id] [int] NULL,
	[Level3Id] [int] NULL,
	[Level4Id] [int] NULL,
	[Billable] [bit] NOT NULL,
	[WorkClassCode] [varchar](5) NOT NULL,
	[TotalHours] [money] NULL,
	[BillAmount] [money] NULL,
	[ChangeOrderId] [int] NULL,
	[SyncStatus] [varchar](20) NULL,
	[Deleted] [bit] NOT NULL,
	[Manual] [bit] NOT NULL,
	[IncludedHours] [decimal](10, 4) NULL,
 CONSTRAINT [PK_LabourTimeEntry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LemAP]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LemAP](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NULL,
	[CompanyId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[LogHeaderId] [int] NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[InvoiceNum] [varchar](15) NOT NULL,
	[SupplierCode] [varchar](10) NOT NULL,
	[PONum] [varchar](20) NOT NULL,
	[InvoiceAmount] [money] NOT NULL,
	[MarkupAmount] [money] NOT NULL,
	[BillAmount] [money] NOT NULL,
	[SyncStatus] [varchar](20) NULL,
 CONSTRAINT [PK_LemAP] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LemAPDetail]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LemAPDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[LemAPId] [int] NOT NULL,
	[LineNum] [int] NOT NULL,
	[Description] [varchar](150) NOT NULL,
	[Reference] [varchar](150) NOT NULL,
	[Amount] [money] NOT NULL,
	[MarkupPercent] [decimal](19, 4) NOT NULL,
	[MarkupAmount] [money] NOT NULL,
	[BillAmount] [money] NOT NULL,
	[Level1Id] [int] NULL,
	[Level2Id] [int] NULL,
	[Level3Id] [int] NULL,
	[Level4Id] [int] NULL,
 CONSTRAINT [PK_LemAPDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LemHeader]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LemHeader](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogStatus] [char](1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[LemNum] [varchar](20) NOT NULL,
	[CreatorId] [int] NOT NULL,
	[ApprovalComments] [varchar](max) NULL,
	[SyncStatus] [varchar](20) NULL,
	[Deleted] [bit] NOT NULL,
	[SubmitStatus] [char](1) NOT NULL,
	[LEM_Desc] [varchar](max) NULL,
	[EmailData] [varbinary](max) NULL,
 CONSTRAINT [PK_LemLogHeader] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level1Code]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level1Code](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Code] [varchar](6) NOT NULL,
	[Desc] [varchar](30) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_Level1Code] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level2Code]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level2Code](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Level1Id] [int] NOT NULL,
	[Code] [varchar](6) NOT NULL,
	[Desc] [varchar](30) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_Level2Code] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level3Code]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level3Code](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Level2Id] [int] NOT NULL,
	[Code] [varchar](6) NOT NULL,
	[Desc] [varchar](30) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_Level3Code] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level4Code]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level4Code](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Level3Id] [int] NOT NULL,
	[Code] [varchar](6) NOT NULL,
	[Desc] [varchar](30) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_Level4Code] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginUser]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[LoginName] [varchar](30) NOT NULL,
	[CodeVersion] [varchar](100) NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OvertimeLimit]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OvertimeLimit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[MatchId] [int] NOT NULL,
	[ProjectId] [int] NULL,
	[Code] [varchar](5) NOT NULL,
	[Desc] [varchar](30) NOT NULL,
	[DailyLimit] [decimal](10, 2) NULL,
	[DailyDoubleLimit] [decimal](10, 2) NULL,
	[WeeklyLimit] [decimal](10, 2) NULL,
	[WeeklyDoubleLimit] [decimal](10, 2) NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_OvertimeLimit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Code] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CustomerCode] [varchar](10) NOT NULL,
	[CustomerName] [varchar](40) NOT NULL,
	[CustomerAddress] [varchar](40) NULL,
	[SiteLocation] [varchar](40) NULL,
	[StartDate] [datetime] NULL,
	[EstCompletionDate] [datetime] NULL,
	[Billable] [bit] NOT NULL,
	[InSync] [bit] NOT NULL,
	[POReference] [varchar](30) NULL,
	[SiteAddress] [varchar](200) NULL,
	[SiteCity] [varchar](20) NULL,
	[SiteState] [varchar](2) NULL,
	[SiteZip] [varchar](10) NULL,
	[CustomerAddress2] [varchar](40) NULL,
	[CustomerAddress3] [varchar](40) NULL,
	[CustomerCity] [varchar](20) NULL,
	[CustomerState] [varchar](2) NULL,
	[CustomerZip] [varchar](10) NULL,
	[ProjectExtendedDescription] [varchar](max) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectAccess]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectAccess](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[InSync] [bit] NOT NULL,
	[CompanyId] [int] NULL,
 CONSTRAINT [PK_ProjectAccess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectEquipmentClass]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectEquipmentClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[MatchId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ClassCode] [varchar](10) NOT NULL,
	[Schedulable] [bit] NOT NULL,
	[UseOverride] [bit] NOT NULL,
	[BillRate] [money] NULL,
	[BillCycle] [char](1) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_ProjectEquipmentClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectWorkClass]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectWorkClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[MatchId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[WorkClassCode] [varchar](5) NOT NULL,
	[RegularBillRate] [money] NULL,
	[OvertimeBillRate] [money] NULL,
	[DoubletimeBillRate] [money] NULL,
	[TravelBillRate] [money] NULL,
	[Schedulable] [bit] NOT NULL,
	[CeilingCost] [money] NULL,
	[RegularHours] [decimal](10, 2) NULL,
	[TravelHours] [decimal](10, 2) NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_ProjectWorkClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportLEMApprovalAP]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportLEMApprovalAP](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LogHeaderId] [int] NULL,
	[InvoiceDate] [datetime] NULL,
	[InvoiceNum] [varchar](15) NULL,
	[PONum] [varchar](20) NULL,
	[LineNum] [int] NULL,
	[Description] [varchar](150) NULL,
	[Amount] [money] NULL,
	[InvoiceAmount] [money] NULL,
	[HeaderMarkupAmount] [money] NULL,
	[MarkupAmount] [money] NULL,
	[MarkupPercent] [decimal](19, 4) NULL,
	[BillAmount] [money] NULL,
	[Username] [varchar](10) NULL,
	[SupplierName] [varchar](40) NULL,
	[SupplierCode] [varchar](10) NULL,
	[Level1Code] [varchar](6) NULL,
	[Level1] [varchar](30) NULL,
	[Level2Code] [varchar](6) NULL,
	[Level2] [varchar](30) NULL,
	[Level3Code] [varchar](6) NULL,
	[Level3] [varchar](30) NULL,
	[Level4Code] [varchar](6) NULL,
	[Level4] [varchar](30) NULL,
	[CostCode] [varchar](15) NULL,
	[Lv1Id] [int] NULL,
	[Lv2Id] [int] NULL,
	[Lv3Id] [int] NULL,
	[Lv4Id] [int] NULL,
	[COCode] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportLEMApprovalEquipment]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportLEMApprovalEquipment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LogHeaderId] [int] NULL,
	[Level1Code] [varchar](6) NULL,
	[Level1] [varchar](30) NULL,
	[Level2Code] [varchar](6) NULL,
	[Level2] [varchar](30) NULL,
	[Level3Code] [varchar](6) NULL,
	[Level3] [varchar](30) NULL,
	[Level4Code] [varchar](6) NULL,
	[Level4] [varchar](30) NULL,
	[AssetCode] [varchar](15) NULL,
	[Asset] [varchar](100) NULL,
	[ClassCode] [varchar](5) NULL,
	[Class] [varchar](50) NULL,
	[CategoryCode] [varchar](5) NULL,
	[Category] [varchar](50) NULL,
	[Billable] [bit] NULL,
	[Quantity] [decimal](14, 4) NULL,
	[BillAmount] [money] NULL,
	[UnitBillRate] [money] NULL,
	[BillCycle] [char](1) NULL,
	[Component] [varchar](1) NULL,
	[Username] [varchar](10) NULL,
	[OwnerType] [char](1) NULL,
	[CostCode] [varchar](15) NULL,
	[Lv1Id] [int] NULL,
	[Lv2Id] [int] NULL,
	[Lv3Id] [int] NULL,
	[Lv4Id] [int] NULL,
	[COCode] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportLEMApprovalHeader]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportLEMApprovalHeader](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LogHeaderId] [int] NULL,
	[LogDate] [datetime] NULL,
	[LEM#] [varchar](20) NULL,
	[Project] [int] NULL,
	[ProjectName] [varchar](50) NULL,
	[CustomerCode] [varchar](10) NULL,
	[CustomerName] [varchar](40) NULL,
	[SiteLocation] [varchar](40) NULL,
	[POReference] [varchar](30) NULL,
	[CompanyName] [varchar](50) NULL,
	[Billable] [bit] NULL,
	[Username] [varchar](10) NULL,
	[CompanyAddress1] [varchar](40) NULL,
	[CompanyAddress2] [varchar](40) NULL,
	[CompanyAddress3] [varchar](40) NULL,
	[CompanyCity] [varchar](20) NULL,
	[CompanyState] [varchar](15) NULL,
	[CompanyZip] [varchar](9) NULL,
	[CompanyPhone] [varchar](20) NULL,
	[CompanyFax] [varchar](20) NULL,
	[CompanyEmail] [varchar](50) NULL,
	[CompanyWeb] [varchar](500) NULL,
	[SiteAddress] [varchar](200) NULL,
	[SiteCity] [varchar](20) NULL,
	[SiteState] [varchar](2) NULL,
	[SiteZip] [varchar](10) NULL,
	[CustomerAddress2] [varchar](40) NULL,
	[CustomerAddress3] [varchar](40) NULL,
	[CustomerCity] [varchar](20) NULL,
	[CustomerState] [varchar](2) NULL,
	[CustomerZip] [varchar](10) NULL,
	[ProjectExtendedDescription] [varchar](max) NULL,
	[LEM_Desc] [varchar](max) NULL,
	[CustomerAddress1] [varchar](40) NULL,
	[TotalAPAmt] [money] NULL,
	[TotalEqAmt] [money] NULL,
	[TotalLabHrs] [decimal](10, 2) NULL,
	[TotalLabAmt] [money] NULL,
	[TotalLabTravelAmt] [money] NULL,
	[TotalLabLOAAmt] [money] NULL,
	[TotalLabEqAmt] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportLEMApprovalLabour]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportLEMApprovalLabour](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LogHeaderId] [int] NULL,
	[EntryID] [int] NULL,
	[EmpNum] [int] NULL,
	[Name] [varchar](62) NULL,
	[WorkClassCode] [varchar](5) NULL,
	[WorkClass] [varchar](30) NULL,
	[Level1Code] [varchar](6) NULL,
	[Level1] [varchar](30) NULL,
	[Level2Code] [varchar](6) NULL,
	[Level2] [varchar](30) NULL,
	[Level3Code] [varchar](6) NULL,
	[Level3] [varchar](30) NULL,
	[Level4Code] [varchar](6) NULL,
	[Level4] [varchar](30) NULL,
	[Billable] [bit] NULL,
	[BillAmount] [money] NULL,
	[TotalHours] [money] NULL,
	[Component] [varchar](1) NULL,
	[Username] [varchar](10) NULL,
	[RegularHours] [decimal](10, 2) NULL,
	[RegularRate] [money] NULL,
	[OTHours] [decimal](10, 2) NULL,
	[OTRate] [money] NULL,
	[TravelHours] [decimal](10, 2) NULL,
	[TravelRate] [money] NULL,
	[LOAHours] [decimal](10, 2) NULL,
	[LOARate] [money] NULL,
	[EquipmentHours] [decimal](10, 2) NULL,
	[EquipmentRate] [money] NULL,
	[OtherHours] [decimal](10, 2) NULL,
	[OtherRate] [money] NULL,
	[DTHours] [decimal](10, 2) NULL,
	[DTRate] [money] NULL,
	[CostCode] [varchar](15) NULL,
	[Lv1Id] [int] NULL,
	[Lv2Id] [int] NULL,
	[Lv3Id] [int] NULL,
	[Lv4Id] [int] NULL,
	[COCode] [varchar](25) NULL,
	[type] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportLEMApprovalLabourDetail]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportLEMApprovalLabourDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EntryId] [int] NULL,
	[BillRate] [money] NULL,
	[WorkHours] [decimal](10, 4) NULL,
	[Amount] [money] NULL,
	[Description] [varchar](50) NULL,
	[ValueType] [varchar](10) NULL,
	[BillingRateType] [varchar](10) NULL,
	[Component] [varchar](1) NULL,
	[Username] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScanAttachments]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScanAttachments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ScanData] [varbinary](max) NULL,
	[ScanStatus] [varchar](10) NOT NULL,
 CONSTRAINT [PK_id_ScanAttachments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SECURITY]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SECURITY](
	[DEPARTMENT] [varchar](10) NULL,
	[FUNCTION_ID] [int] NULL,
	[CompanyId] [int] NULL,
	[InSync] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityFunction]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityFunction](
	[ID] [int] NOT NULL,
	[ParentID] [int] NULL,
	[Description] [varchar](100) NULL,
	[AltDescription] [varchar](100) NULL,
	[Level] [int] NULL,
	[Image] [int] NULL,
	[CompanyType] [varchar](5) NULL,
	[ApplicationFlavour] [varchar](10) NULL,
	[Discontinued] [bit] NULL,
	[UserControlType] [varchar](50) NULL,
	[KickinIt] [varchar](30) NULL,
	[cascades] [bit] NOT NULL,
	[IsModule] [bit] NULL,
	[HelpBookmarkDocument] [varchar](200) NULL,
	[DestinationName] [varchar](200) NULL,
	[FieldServices] [bit] NULL,
	[InSync] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[SupplierCode] [varchar](10) NOT NULL,
	[SupplierName] [varchar](40) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SyncCoreMatch]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SyncCoreMatch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SyncTable] [varchar](20) NOT NULL,
	[SourceId] [int] NOT NULL,
	[MatchId] [int] NOT NULL,
	[SyncMatch] [varchar](50) NULL,
 CONSTRAINT [PK_SyncCoreMatch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SyncStatus]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SyncStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[SyncTable] [varchar](50) NOT NULL,
	[SyncType] [varchar](20) NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[DoSync] [bit] NOT NULL,
	[SyncName] [varchar](50) NOT NULL,
	[DisplayName] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYSTEM_EXCEPTION]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYSTEM_EXCEPTION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [varchar](50) NULL,
	[COMPANYID] [int] NULL,
	[ERROR_DATE] [datetime] NULL,
	[COMMAND_TEXT] [varchar](8000) NULL,
	[CONNECTION_STRING] [varchar](8000) NULL,
	[EX_LINE_NUMBER] [int] NULL,
	[EX_MESSAGE] [varchar](8000) NULL,
	[EX_NUMBER] [int] NULL,
	[EX_PROCEDURE] [varchar](8000) NULL,
	[EX_STACKTRACE] [text] NULL,
	[INNER_LINE_NUMBER] [int] NULL,
	[INNER_MESSAGE] [varchar](8000) NULL,
	[INNER_NUMBER] [int] NULL,
	[INNER_PROCEDURE] [varchar](8000) NULL,
	[INNER_STACKTRACE] [text] NULL,
	[Friendly_Message] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemInfo]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemInfo](
	[DataBaseVersion] [varchar](100) NOT NULL,
	[KeepDays] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeCode]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Desc] [varchar](50) NOT NULL,
	[ValueType] [varchar](10) NOT NULL,
	[BillingRateType] [varchar](10) NOT NULL,
	[IncludedInWeekCalc] [bit] NOT NULL,
	[OvertimeId] [int] NULL,
	[DoubleTimeId] [int] NULL,
	[InSync] [bit] NOT NULL,
	[Component] [char](1) NOT NULL,
	[ReportTypeColumn] [varchar](20) NULL,
 CONSTRAINT [PK_TimeCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccess]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccess](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[Department] [varchar](10) NOT NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_UserAccess] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectLevelCode]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLevelCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Level1Id] [int] NULL,
	[Level2Id] [int] NULL,
	[Level3Id] [int] NULL,
	[Level4Id] [int] NULL,
	[InSync] [bit] NOT NULL,
	CONSTRAINT [PK_ProjectLevelCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkClass]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Code] [varchar](5) NOT NULL,
	[Desc] [varchar](30) NOT NULL,
	[RegularBillRate] [money] NULL,
	[OvertimeBillRate] [money] NULL,
	[DoubleTimeBillRate] [money] NULL,
	[TravelBillRate] [money] NULL,
	[InSync] [bit] NOT NULL,
 CONSTRAINT [PK_WorkClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[working_TableOfContents]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[working_TableOfContents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](max) NULL,
	[username] [varchar](10) NULL,
	[HeaderNumber] [varchar](30) NULL,
	[LineNumber] [varchar](20) NULL,
	[Seq] [int] NULL,
	[Origin] [varchar](50) NULL,
	[TopicaLArea] [varchar](50) NULL,
	[FileType] [varchar](250) NULL,
	[Company] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CFS_FileLink] ADD  CONSTRAINT [DF__CFS_FileL__IsOri__07F6335A]  DEFAULT ((0)) FOR [IsOrigin]
GO
ALTER TABLE [dbo].[CFS_FileRepository] ADD  DEFAULT ((0)) FOR [InternalOnly]
GO
ALTER TABLE [dbo].[CFS_FileRepository] ADD  DEFAULT ('D') FOR [FileStatus]
GO
ALTER TABLE [dbo].[CFS_FileRepository] ADD  DEFAULT ((-1)) FOR [CurrentTCSE_ID]
GO
ALTER TABLE [dbo].[DATABASE_SETUP] ADD  DEFAULT ((0)) FOR [ResConverted]
GO
ALTER TABLE [dbo].[DATABASE_SETUP] ADD  DEFAULT ((0)) FOR [CommConverted]
GO
ALTER TABLE [dbo].[ScanAttachments] ADD  DEFAULT ('InProcess') FOR [ScanStatus]
GO
ALTER TABLE [dbo].[SecurityFunction] ADD  DEFAULT ((0)) FOR [cascades]
GO
ALTER TABLE [dbo].[SecurityFunction] ADD  DEFAULT ((0)) FOR [IsModule]
GO
ALTER TABLE [dbo].[CFS_FileLink]  WITH CHECK ADD  CONSTRAINT [FK_CFS_FileLink_CFS_FileRepository] FOREIGN KEY([FileRepository_ID])
REFERENCES [dbo].[CFS_FileRepository] ([ID])
GO
ALTER TABLE [dbo].[CFS_FileLink] CHECK CONSTRAINT [FK_CFS_FileLink_CFS_FileRepository]
GO
/****** Object:  StoredProcedure [dbo].[CFS_AttachFile]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[CFS_AttachFile] @FileName varchar(255), @FileData varbinary(max), @ContactID int,
	@FileType varchar(2), @TempID int, @TempLink varchar(50), @InternalOnly bit, @FileStatus char(1), @FileOrigin varchar(10),
	@OriginLink int, @OriginLink2 int, @permanent_tf varchar(1), @CurrentTCSE_ID int
as
begin
	declare @FileRepository_ID int
			
	insert into CFS_FileRepository (FileName, FileData, ContactID, DateAdded, FileType, TempID, TempLink, Mime_type, 
		InternalOnly, FileStatus, FileOrigin, OriginLink, OriginLink2, permanent_tf, CurrentTCSE_ID)
	select @FileName, @FileData, @ContactID, getdate(), @FileType, @TempID, @TempLink, null,
		isnull(@InternalOnly, 0), @FileStatus, @FileOrigin, @OriginLink, @OriginLink2, isnull(@permanent_tf,'F'), @CurrentTCSE_ID
		
	select @FileRepository_ID=SCOPE_IDENTITY()
	
	--mime_type list from: http://stackoverflow.com/questions/1029740/get-mime-type-from-filename-extension
	update r
	set r.Mime_Type=m.MimeType
	from CFS_FileRepository r 
	join CFS_MimeType m on m.Extension=r.Ext
	where r.ID=@FileRepository_ID
	
	select @FileRepository_ID [FileRepository_ID]
end


GO
/****** Object:  StoredProcedure [dbo].[CFS_CreateFileLink]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[CFS_CreateFileLink] @FileRepository_ID int, @CompanyID int, @DBFlavour varchar(5), @TableDotField varchar(60), @IDValue int, 
	@ContextItem_ID int, @IsOrigin bit,
	--NEED TO DISCUSS BELOW PARAMS
	@TargetPrint varchar(3),
	@Comment varchar(max),
	@ElectronicSaveSetup_ID int,
	@LinkOrigin varchar(30),
	@DraftingFileTypeID int,
	@OriginalSrcID int
as
begin
	insert into CFS_FileLink (FileRepository_ID,CompanyID, DBFlavour, ContextItem_ID, IsOrigin, TableDotField, IDValue, TargetPrint, Comment, LinkOrigin )
	select @FileRepository_ID,@CompanyID, @DBFlavour, @ContextItem_ID, isnull(@IsOrigin,0), @TableDotField, @IDValue, @TargetPrint, @Comment, @LinkOrigin
end



GO
/****** Object:  StoredProcedure [dbo].[ReportLEMApproval]    Script Date: 2017-11-03 9:38:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[ReportLEMApproval] @id int, @username varchar(10) 
as
begin
                delete ReportLEMApprovalAP where username = @username
                delete ReportLEMApprovalEquipment where username = @username
                delete ReportLEMApprovalLabourDetail where username = @username
                delete ReportLEMApprovalLabour where username = @username
                delete ReportLEMApprovalHeader where username = @username

                declare @LowLevel int, @SepLOA bit, @SepTravel bit, @SepEquip bit, @pri_id int

                select @SepLOA=0, @SepTravel=0, @SepEquip=0

                select @LowLevel=c.MaxLevelCode, @pri_id=h.ProjectId 
                from LemHeader h
                join Company c on c.MatchId=h.CompanyId
                where h.id = @id 

                if exists(select *
                                from LemHeader lh
                                join DefaultEarning de on de.ProjectId=lh.ProjectId and de.CompanyId=lh.CompanyId and de.EarningType='L'
                                where lh.id = @id and de.level1id is not null )
                begin
                                select @SepLOA = 1
                end

                if exists(select *
                                from LemHeader lh
                                join DefaultEarning de on de.ProjectId=lh.ProjectId and de.CompanyId=lh.CompanyId and de.EarningType='T'
                                where lh.id = @id and de.level1id is not null )
                begin
                                select @SepTravel = 1
                end

                if exists(select *
                                from LemHeader lh
                                join DefaultEarning de on de.ProjectId=lh.ProjectId and de.CompanyId=lh.CompanyId and de.EarningType='E'
                                where lh.id = @id and de.level1id is not null )
                begin
                                select @SepEquip = 1
                end

                insert ReportLEMApprovalHeader(LogHeaderId, LogDate, LEM#, Project, ProjectName, CustomerCode, CustomerName, SiteLocation,
                                POReference, CompanyName, Billable, Username, 
                                CompanyAddress1, CompanyAddress2, CompanyAddress3, CompanyCity, CompanyState, CompanyZip, CompanyPhone, CompanyFax, CompanyEmail, CompanyWeb,
                                SiteAddress, SiteCity, SiteState, SiteZip, CustomerAddress1, CustomerAddress2, CustomerAddress3, CustomerCity, CustomerState,  CustomerZip, 
                                ProjectExtendedDescription, LEM_Desc)
                select h.Id [LogHeaderId], LogDate [Date], LemNum [LEM#], p.Code [Project], p.Name [ProjectName], p.CustomerCode, p.CustomerName, p.SiteLocation, p.POReference,
                                c.CompanyName, p.Billable, @username Username,
                                c.CompanyAddress1, c.CompanyAddress2, c.CompanyAddress3, c.CompanyCity, c.CompanyState, c.CompanyZip, c.CompanyPhone, c.CompanyFax, c.CompanyEmail, c.CompanyWeb,
                                p.SiteAddress, p.SiteCity, p.SiteState, p.SiteZip, p.CustomerAddress, p.CustomerAddress2, p.CustomerAddress3, p.CustomerCity, p.CustomerState,  p.CustomerZip, 
                                p.ProjectExtendedDescription, isnull(h.LEM_Desc,'')
                from LemHeader h
                join Project p on p.MatchId = h.ProjectId 
                join Company c on c.MatchId = p.CompanyId
                where h.id = @id
                

                -- Labor
                insert ReportLEMApprovalLabour(LogHeaderId, EntryID, EmpNum, Name, WorkClassCode, WorkClass, 
                                Level1Code, Level1, Level2Code, Level2, Level3Code, Level3, Level4Code, Level4, 
                                Billable, BillAmount, Component, Username, TotalHours, 
                                RegularHours, RegularRate, OTHours, OTRate, TravelHours, TravelRate, LOAHours, LOARate, EquipmentHours, 
                                EquipmentRate, OtherHours, OtherRate, DTHours, DTRate, Lv1Id, Lv2Id, Lv3Id, Lv4Id, COCode)
                select h.LogHeaderId, h.id EntryID,
                                h.EmpNum, case when isnull(e.FirstName,'') != '' then isnull(e.FirstName,'') + ' ' else '' end + isnull(e.LastName,'') [Name],
                                wc.Code [WorkClassCode], wc.[Desc] [WorkClass], 
                                isnull(lc1.Code,'') [Level1Code], isnull(lc1.[Desc],'') [Level1], isnull(lc2.Code,'') [Level2Code], isnull(lc2.[Desc],'') [Level2],
                                isnull(lc3.Code,'') [Level3Code], isnull(lc3.[Desc],'') [Level3], isnull(lc4.Code,'') [Level4Code], isnull(lc4.[Desc],'') [Level4],
                                h.Billable, isnull(h.BillAmount,0), 'L' Component, @username Username,
                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else 0 end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Regular' and d.EntryId = h.Id),0) +
                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else 0 end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Overtime' and d.EntryId = h.Id),0) +
                                case when @SepTravel = 1 then 0 else isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else 0 end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Travel' and d.EntryId = h.Id),0) end +                          
                                case when @SepLOA = 1 then 0 else isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else 0 end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'LOA' and d.EntryId = h.Id),0) end +
                                case when @SepEquip = 1 then 0 else isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else 0 end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Equipment' and d.EntryId = h.Id),0) end +
                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else 0 end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Other' and d.EntryId = h.Id),0) +
                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else 0 end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Double Time' and d.EntryId = h.Id),0),

                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else case when isnull(d.amount,0) != 0 then 1 else 0 end end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Regular' and d.EntryId = h.Id),0),
                                isnull((select max(case when tc.ValueType = 'Hours' then d.BillRate else d.Amount end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Regular' and d.EntryId = h.Id),0),

                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else case when isnull(d.amount,0) != 0 then 1 else 0 end end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Overtime' and d.EntryId = h.Id),0),
                                isnull((select max(case when tc.ValueType = 'Hours' then d.BillRate else d.Amount end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Overtime' and d.EntryId = h.Id),0),

                                case when @SepTravel = 1 then 0 else isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else case when isnull(d.amount,0) != 0 then 1 else 0 end end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Travel' and d.EntryId = h.Id),0) end,
                                case when @SepTravel = 1 then 0 else isnull((select max(case when tc.ValueType = 'Hours' then d.BillRate else d.Amount end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Travel' and d.EntryId = h.Id),0) end,

                                case when @SepLOA = 1 then 0 else isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else case when isnull(d.amount,0) != 0 then 1 else 0 end end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'LOA' and d.EntryId = h.Id),0) end,
                                case when @SepLOA = 1 then 0 else isnull((select max(case when tc.ValueType = 'Hours' then d.BillRate else d.Amount end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'LOA' and d.EntryId = h.Id),0) end,

                                case when @SepEquip = 1 then 0 else isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else case when isnull(d.amount,0) != 0 then 1 else 0 end end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Equipment' and d.EntryId = h.Id),0) end,
                                case when @SepEquip = 1 then 0 else isnull((select max(case when tc.ValueType = 'Hours' then d.BillRate else d.Amount end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Equipment' and d.EntryId = h.Id),0) end,

                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else case when isnull(d.amount,0) != 0 then 1 else 0 end end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Other' and d.EntryId = h.Id),0),
                                isnull((select max(case when tc.ValueType = 'Hours' then d.BillRate else d.Amount end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Other' and d.EntryId = h.Id),0),

                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else case when isnull(d.amount,0) != 0 then 1 else 0 end end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Double Time' and d.EntryId = h.Id),0),
                                isnull((select max(case when tc.ValueType = 'Hours' then d.BillRate else d.Amount end) from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId where ReportTypeColumn = 'Double Time' and d.EntryId = h.Id),0),
                                h.Level1Id, h.Level2Id, h.Level3Id, h.Level4Id, cast(p.Code as varchar(15))+'-'+cast(co.ChangeOrderNum as varchar(10))
                from LabourTimeEntry h
                join LemHeader lh on lh.id=h.LogHeaderId and lh.CompanyId=h.CompanyId
                join Project p on p.MatchId = lh.ProjectId and p.CompanyId=lh.CompanyId
                join Employee e on e.EmpNum = h.EmpNum and e.CompanyId = h.CompanyId
                join WorkClass wc on wc.Code = h.WorkClassCode and wc.CompanyId = h.CompanyId
                left join Level1Code lc1 on lc1.MatchId = h.Level1Id and lc1.CompanyId = h.CompanyId
                left join Level2Code lc2 on lc2.MatchId = h.Level2Id and lc2.CompanyId = h.CompanyId
                left join Level3Code lc3 on lc3.MatchId = h.Level3Id and lc3.CompanyId = h.CompanyId
                left join Level4Code lc4 on lc4.MatchId = h.Level4Id and lc4.CompanyId = h.CompanyId
                left outer join changeorder co on co.EstimateId=h.ChangeOrderId and co.CompanyId=h.CompanyId
                where h.LogHeaderId = @id
                

                if( @SepLOA = 1 )
                begin
                                -- Labor - LOA
                                insert ReportLEMApprovalLabour(LogHeaderId, EntryID, EmpNum, Name, WorkClassCode, WorkClass, 
                                                Level1Code, Level1, Level2Code, Level2, Level3Code, Level3, Level4Code, Level4, 
                                                Billable, BillAmount, Component, Username, TotalHours,
                                                LOAHours, LOARate, Lv1Id, Lv2Id, Lv3Id, Lv4Id, COCode, type)
                                select h.LogHeaderId, h.id EntryID,
                                                h.EmpNum, case when isnull(e.FirstName,'') != '' then isnull(e.FirstName,'') + ' ' else '' end + isnull(e.LastName,'') [Name],
                                                wc.Code [WorkClassCode], wc.[Desc] [WorkClass], 
                                                isnull(lc1.Code,'') [Level1Code], isnull(lc1.[Desc],'') [Level1], isnull(lc2.Code,'') [Level2Code], isnull(lc2.[Desc],'') [Level2],
                                                isnull(lc3.Code,'') [Level3Code], isnull(lc3.[Desc],'') [Level3], isnull(lc4.Code,'') [Level4Code], isnull(lc4.[Desc],'') [Level4],
                                                h.Billable, isnull(h.BillAmount,0), 'L' Component, @username Username,                             
                                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else 0 end) 
                                                                                from LabourTimeDetail d 
                                                                                join TimeCode tc on tc.MatchId = d.TimeCodeId 
                                                                                where ReportTypeColumn = 'LOA' and d.EntryId = h.Id),0),
                                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else case when isnull(d.amount,0) != 0 then 1 else 0 end end) 
                                                                                from LabourTimeDetail d 
                                                                                join TimeCode tc on tc.MatchId = d.TimeCodeId 
                                                                                where ReportTypeColumn = 'LOA' and d.EntryId = h.Id),0),
                                                isnull((select max(case when tc.ValueType = 'Hours' then d.BillRate else d.Amount end) 
                                                                                from LabourTimeDetail d 
                                                                                join TimeCode tc on tc.MatchId = d.TimeCodeId 
                                                                                where ReportTypeColumn = 'LOA' and d.EntryId = h.Id),0),
                                                de.Level1Id, de.Level2Id, de.Level3Id, de.Level4Id, cast(p.Code as varchar(15))+'-'+cast(co.ChangeOrderNum as varchar(10)), 'L'
                                from LabourTimeEntry h
                                join LemHeader lh on lh.id=h.LogHeaderId and lh.CompanyId=h.CompanyId
                                join Project p on p.MatchId = lh.ProjectId and p.CompanyId=lh.CompanyId
                                join DefaultEarning de on de.ProjectId=lh.ProjectId and de.CompanyId=lh.CompanyId and de.EarningType = 'L'
                                join Employee e on e.EmpNum = h.EmpNum and e.CompanyId = h.CompanyId
                                join WorkClass wc on wc.Code = h.WorkClassCode and wc.CompanyId = h.CompanyId
                                left join Level1Code lc1 on lc1.MatchId = de.Level1Id and lc1.CompanyId = de.CompanyId
                                left join Level2Code lc2 on lc2.MatchId = de.Level2Id and lc2.CompanyId = de.CompanyId
                                left join Level3Code lc3 on lc3.MatchId = de.Level3Id and lc3.CompanyId = de.CompanyId
                                left join Level4Code lc4 on lc4.MatchId = de.Level4Id and lc4.CompanyId = de.CompanyId
                                left outer join changeorder co on co.EstimateId=h.ChangeOrderId and co.CompanyId=h.CompanyId
                                where h.LogHeaderId = @id

                                delete from ReportLEMApprovalLabour where username=@username and type='L' and LOAHours = 0
                end

                if( @SepTravel = 1 )
                begin
                                -- Labor - Travel
                                insert ReportLEMApprovalLabour(LogHeaderId, EntryID, EmpNum, Name, WorkClassCode, WorkClass, 
                                                Level1Code, Level1, Level2Code, Level2, Level3Code, Level3, Level4Code, Level4, 
                                                Billable, BillAmount, Component, Username, TotalHours,
                                                TravelHours, TravelRate, Lv1Id, Lv2Id, Lv3Id, Lv4Id, COCode, type)
                                select h.LogHeaderId, h.id EntryID,
                                                h.EmpNum, case when isnull(e.FirstName,'') != '' then isnull(e.FirstName,'') + ' ' else '' end + isnull(e.LastName,'') [Name],
                                                wc.Code [WorkClassCode], wc.[Desc] [WorkClass], 
                                                isnull(lc1.Code,'') [Level1Code], isnull(lc1.[Desc],'') [Level1], isnull(lc2.Code,'') [Level2Code], isnull(lc2.[Desc],'') [Level2],
                                                isnull(lc3.Code,'') [Level3Code], isnull(lc3.[Desc],'') [Level3], isnull(lc4.Code,'') [Level4Code], isnull(lc4.[Desc],'') [Level4],
                                                h.Billable, isnull(h.BillAmount,0), 'L' Component, @username Username,
                                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else 0 end) 
                                                                                from LabourTimeDetail d 
                                                                                join TimeCode tc on tc.MatchId = d.TimeCodeId 
                                                                                where ReportTypeColumn = 'Travel' and d.EntryId = h.Id),0),
                                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else case when isnull(d.amount,0) != 0 then 1 else 0 end end) 
                                                                                from LabourTimeDetail d 
                                                                                join TimeCode tc on tc.MatchId = d.TimeCodeId 
                                                                                where ReportTypeColumn = 'Travel' and d.EntryId = h.Id),0),
                                                isnull((select max(case when tc.ValueType = 'Hours' then d.BillRate else d.Amount end) 
                                                                                from LabourTimeDetail d 
                                                                                join TimeCode tc on tc.MatchId = d.TimeCodeId 
                                                                                where ReportTypeColumn = 'Travel' and d.EntryId = h.Id),0),
                                                de.Level1Id, de.Level2Id, de.Level3Id, de.Level4Id, cast(p.Code as varchar(15))+'-'+cast(co.ChangeOrderNum as varchar(10)), 'T'
                                from LabourTimeEntry h
                                join LemHeader lh on lh.id=h.LogHeaderId and lh.CompanyId=h.CompanyId
                                join Project p on p.MatchId = lh.ProjectId and p.CompanyId=lh.CompanyId
                                join DefaultEarning de on de.ProjectId=lh.ProjectId and de.CompanyId=lh.CompanyId and de.EarningType = 'T'
                                join Employee e on e.EmpNum = h.EmpNum and e.CompanyId = h.CompanyId
                                join WorkClass wc on wc.Code = h.WorkClassCode and wc.CompanyId = h.CompanyId
                                left join Level1Code lc1 on lc1.MatchId = de.Level1Id and lc1.CompanyId = de.CompanyId
                                left join Level2Code lc2 on lc2.MatchId = de.Level2Id and lc2.CompanyId = de.CompanyId
                                left join Level3Code lc3 on lc3.MatchId = de.Level3Id and lc3.CompanyId = de.CompanyId
                                left join Level4Code lc4 on lc4.MatchId = de.Level4Id and lc4.CompanyId = de.CompanyId
                                left outer join changeorder co on co.EstimateId=h.ChangeOrderId and co.CompanyId=h.CompanyId
                                where h.LogHeaderId = @id
                
                                delete from ReportLEMApprovalLabour where username=@username and type='T' and TravelHours = 0
                end
                                

                if( @SepEquip = 1 )
                begin
                                -- Labor - Equip
                                insert ReportLEMApprovalLabour(LogHeaderId, EntryID, EmpNum, Name, WorkClassCode, WorkClass, 
                                                Level1Code, Level1, Level2Code, Level2, Level3Code, Level3, Level4Code, Level4, 
                                                Billable, BillAmount, Component, Username, TotalHours,
                                                EquipmentHours, EquipmentRate, Lv1Id, Lv2Id, Lv3Id, Lv4Id, COCode, type)
                                select h.LogHeaderId, h.id EntryID,
                                                h.EmpNum, case when isnull(e.FirstName,'') != '' then isnull(e.FirstName,'') + ' ' else '' end + isnull(e.LastName,'') [Name],
                                                wc.Code [WorkClassCode], wc.[Desc] [WorkClass], 
                                                isnull(lc1.Code,'') [Level1Code], isnull(lc1.[Desc],'') [Level1], isnull(lc2.Code,'') [Level2Code], isnull(lc2.[Desc],'') [Level2],
                                                isnull(lc3.Code,'') [Level3Code], isnull(lc3.[Desc],'') [Level3], isnull(lc4.Code,'') [Level4Code], isnull(lc4.[Desc],'') [Level4],
                                                h.Billable, isnull(h.BillAmount,0), 'L' Component, @username Username,
                                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else 0 end) 
                                                                                from LabourTimeDetail d 
                                                                                join TimeCode tc on tc.MatchId = d.TimeCodeId 
                                                                                where ReportTypeColumn = 'Equipment' and d.EntryId = h.Id),0),
                                                isnull((select sum(case when tc.ValueType = 'Hours' then d.WorkHours else case when isnull(d.amount,0) != 0 then 1 else 0 end end) 
                                                                                from LabourTimeDetail d 
                                                                                join TimeCode tc on tc.MatchId = d.TimeCodeId 
                                                                                where ReportTypeColumn = 'Equipment' and d.EntryId = h.Id),0),
                                                isnull((select max(case when tc.ValueType = 'Hours' then d.BillRate else d.Amount end) 
                                                                                from LabourTimeDetail d 
                                                                                join TimeCode tc on tc.MatchId = d.TimeCodeId 
                                                                                where ReportTypeColumn = 'Equipment' and d.EntryId = h.Id),0),
                                                de.Level1Id, de.Level2Id, de.Level3Id, de.Level4Id, cast(p.Code as varchar(15))+'-'+cast(co.ChangeOrderNum as varchar(10)), 'E'
                                from LabourTimeEntry h
                                join LemHeader lh on lh.id=h.LogHeaderId and lh.CompanyId=h.CompanyId
                                join Project p on p.MatchId = lh.ProjectId and p.CompanyId=lh.CompanyId
                                join DefaultEarning de on de.ProjectId=lh.ProjectId and de.CompanyId=lh.CompanyId and de.EarningType = 'E'
                                join Employee e on e.EmpNum = h.EmpNum and e.CompanyId = h.CompanyId
                                join WorkClass wc on wc.Code = h.WorkClassCode and wc.CompanyId = h.CompanyId
                                left join Level1Code lc1 on lc1.MatchId = de.Level1Id and lc1.CompanyId = de.CompanyId
                                left join Level2Code lc2 on lc2.MatchId = de.Level2Id and lc2.CompanyId = de.CompanyId
                                left join Level3Code lc3 on lc3.MatchId = de.Level3Id and lc3.CompanyId = de.CompanyId
                                left join Level4Code lc4 on lc4.MatchId = de.Level4Id and lc4.CompanyId = de.CompanyId
                                left outer join changeorder co on co.EstimateId=h.ChangeOrderId and co.CompanyId=h.CompanyId
                                where h.LogHeaderId = @id

                                delete from ReportLEMApprovalLabour where username=@username and type='E' and EquipmentHours = 0
                end
                
                
                update ReportLEMApprovalLabour
                set BillAmount = 
                                round(isnull(RegularHours,0)*isnull(RegularRate,0),2) + 
                                round(isnull(OTHours,0)*isnull(OTRate,0),2) + 
                                round(isnull(TravelHours,0)*isnull(TravelRate,0),2) + 
                                round(isnull(LOAHours,0)*isnull(LOARate,0),2) + 
                                round(isnull(EquipmentHours,0)*isnull(EquipmentRate,0),2) + 
                                round(isnull(OtherHours,0)*isnull(OtherRate,0),2) + 
                                round(isnull(DTHours,0)*isnull(DTRate,0),2) 
                where username=@username
                


                -- clear up blank LOA - Travel - Equip
                if(@LowLevel = 1)
                begin
                                update r
                                set r.CostCode=c.MappingCode
                                from ReportLEMApprovalLabour r
                                join CostCodeMapping c on c.MappingId=r.Lv1Id and c.ProjectId=@pri_id
                                where r.username=@username
                end

                if(@LowLevel = 2)
                begin
                                update r
                                set r.CostCode=c.MappingCode
                                from ReportLEMApprovalLabour r
                                join CostCodeMapping c on c.MappingId=r.Lv2Id and c.ProjectId=@pri_id
                                where r.username=@username
                end

                if(@LowLevel = 3)
                begin
                                update r
                                set r.CostCode=c.MappingCode
                                from ReportLEMApprovalLabour r
                                join CostCodeMapping c on c.MappingId=r.Lv3Id and c.ProjectId=@pri_id
                                where r.username=@username
                end

                if(@LowLevel = 4)
                begin
                                update r
                                set r.CostCode=c.MappingCode
                                from ReportLEMApprovalLabour r
                                join CostCodeMapping c on c.MappingId=r.Lv4Id and c.ProjectId=@pri_id
                                where r.username=@username
                end

                insert ReportLEMApprovalLabourDetail(EntryId, BillRate, WorkHours, Amount, Description, ValueType, BillingRateType, Component, Username)
                select d.EntryId, isnull(BillRate,0), isnull(WorkHours,0), isnull(Amount,0), tc.[Desc], tc.ValueType, tc.BillingRateType, tc.Component Component, @username Username
                from LabourTimeDetail d join TimeCode tc on tc.MatchId = d.TimeCodeId 
                where d.EntryID in (select id from LabourTimeEntry h where h.LogHeaderId = @id)
                order by EntryId, tc.MatchId


                -- Equipment
                insert ReportLEMApprovalEquipment(LogHeaderId, Level1Code, Level1, Level2Code, Level2, Level3Code, Level3, Level4Code, Level4,
                                AssetCode, Asset, ClassCode, Class, CategoryCode, Category, Billable, Quantity, BillAmount, UnitBillRate, BillCycle, Component, 
                                Username, OwnerType, Lv1Id, Lv2Id, Lv3Id, Lv4Id, COCode)
                select h.LogHeaderId,
                                isnull(lc1.Code,'') [Level1Code], isnull(lc1.[Desc],'') [Level1], isnull(lc2.Code,'') [Level2Code], isnull(lc2.[Desc],'') [Level2],
                                isnull(lc3.Code,'') [Level3Code], isnull(lc3.[Desc],'') [Level3], isnull(lc4.Code,'') [Level4Code], isnull(lc4.[Desc],'') [Level4],
                                e.AssetCode, e.[Desc] [Asset], e.ClassCode, ec.[Desc] [Class], e.CategoryCode, cat.[Desc] [Category],
                                h.Billable, isnull(h.Quantity,0), isnull(h.BillAmount,0), 
                                isnull(cast(case when isnull(h.Quantity,0) = 0 then 0 else BillAmount / h.Quantity end as money),0) UnitBillRate, 
                                h.BillCycle, 'E' Component, @username Username, e.OwnerType, h.Level1Id, h.Level2Id, h.Level3Id, h.Level4Id, cast(p.Code as varchar(15))+'-'+cast(co.ChangeOrderNum as varchar(10))
                from EquipTimeEntry h
                join LemHeader lh on lh.id=h.LogHeaderId and lh.CompanyId=h.CompanyId
                join Project p on p.MatchId = lh.ProjectId and p.CompanyId=lh.CompanyId
                join Equipment e on e.EqpNum = h.EqpNum and e.CompanyId = h.CompanyId
                join EquipmentClass ec on ec.Code = e.ClassCode and ec.CompanyId = h.CompanyId
                join EquipmentCategory cat on cat.Code = e.CategoryCode and cat.CompanyId = h.CompanyId
                left join Level1Code lc1 on lc1.MatchId = h.Level1Id and lc1.CompanyId = h.CompanyId
                left join Level2Code lc2 on lc2.MatchId = h.Level2Id and lc2.CompanyId = h.CompanyId
                left join Level3Code lc3 on lc3.MatchId = h.Level3Id and lc3.CompanyId = h.CompanyId
                left join Level4Code lc4 on lc4.MatchId = h.Level4Id and lc4.CompanyId = h.CompanyId
                left outer join changeorder co on co.EstimateId=h.ChangeOrderId and co.CompanyId=h.CompanyId
                where h.LogHeaderId = @id

                if(@LowLevel = 1)
                begin
                                update r
                                set r.CostCode=c.MappingCode
                                from ReportLEMApprovalEquipment r
                                join CostCodeMapping c on c.MappingId=r.Lv1Id and c.ProjectId=@pri_id
                                where r.username=@username
                end

                if(@LowLevel = 2)
                begin
                                update r
                                set r.CostCode=c.MappingCode
                                from ReportLEMApprovalEquipment r
                                join CostCodeMapping c on c.MappingId=r.Lv2Id and c.ProjectId=@pri_id
                                where r.username=@username
                end

                if(@LowLevel = 3)
                begin
                                update r
                                set r.CostCode=c.MappingCode
                                from ReportLEMApprovalEquipment r
                                join CostCodeMapping c on c.MappingId=r.Lv3Id and c.ProjectId=@pri_id
                                where r.username=@username
                end

                if(@LowLevel = 4)
                begin
                                update r
                                set r.CostCode=c.MappingCode
                                from ReportLEMApprovalEquipment r
                                join CostCodeMapping c on c.MappingId=r.Lv4Id and c.ProjectId=@pri_id
                                where r.username=@username
                end

                
                -- AP
                insert ReportLEMApprovalAP(LogHeaderId, InvoiceDate, InvoiceNum, PONum, LineNum, Description, Amount, InvoiceAmount, 
                                HeaderMarkupAmount, MarkupAmount, MarkupPercent, BillAmount, Username, 
                                SupplierName, SupplierCode,    Level1Code, Level1, Level2Code, Level2, Level3Code, Level3, Level4Code, Level4, Lv1Id, Lv2Id, Lv3Id, Lv4Id)
                select h.LogHeaderId, InvoiceDate, h.InvoiceNum, h.PONum, 
                                d.LineNum, d.[Description], isnull(d.Amount,0), isnull(h.InvoiceAmount,0), isnull(h.MarkupAmount,0) [HeaderMarkupAmount], isnull(d.MarkupAmount,0) [MarkupAmount], isnull(d.MarkupPercent,0), 
                                isnull(d.BillAmount,0), @username Username,
                                s.SupplierName, s.SupplierCode, 
                                isnull(lc1.Code,'') [Level1Code], isnull(lc1.[Desc],'') [Level1], isnull(lc2.Code,'') [Level2Code], isnull(lc2.[Desc],'') [Level2],
                                isnull(lc3.Code,'') [Level3Code], isnull(lc3.[Desc],'') [Level3], isnull(lc4.Code,'') [Level4Code], isnull(lc4.[Desc],'') [Level4],
                                d.Level1Id, d.Level2Id, d.Level3Id, d.Level4Id
                from LemAP h
                join LemAPDetail d on h.Id = d.LemAPId and h.CompanyID = d.CompanyID
                left join Level1Code lc1 on lc1.MatchId = d.Level1Id and lc1.CompanyId = h.CompanyId
                left join Level2Code lc2 on lc2.MatchId = d.Level2Id and lc2.CompanyId = h.CompanyId
                left join Level3Code lc3 on lc3.MatchId = d.Level3Id and lc3.CompanyId = h.CompanyId
                left join Level4Code lc4 on lc4.MatchId = d.Level4Id and lc4.CompanyId = h.CompanyId
                join Supplier s on h.SupplierCode = s.SupplierCode and h.CompanyId = s.CompanyId
                where h.LogHeaderId = @id

                if(@LowLevel = 1)
                begin
                                update r
                                set r.CostCode=c.MappingCode
                                from ReportLEMApprovalAP r
                                join CostCodeMapping c on c.MappingId=r.Lv1Id and c.ProjectId=@pri_id
                                where r.username=@username
                end

                if(@LowLevel = 2)
                begin
                                update r
                                set r.CostCode=c.MappingCode
                                from ReportLEMApprovalAP r
                                join CostCodeMapping c on c.MappingId=r.Lv2Id and c.ProjectId=@pri_id
                                where r.username=@username
                end

                if(@LowLevel = 3)
                begin
                                update r
                                set r.CostCode=c.MappingCode
                                from ReportLEMApprovalAP r
                                join CostCodeMapping c on c.MappingId=r.Lv3Id and c.ProjectId=@pri_id
                                where r.username=@username
                end

                if(@LowLevel = 4)
                begin
                                update r
                                set r.CostCode=c.MappingCode
                                from ReportLEMApprovalAP r
                                join CostCodeMapping c on c.MappingId=r.Lv4Id and c.ProjectId=@pri_id
                                where r.username=@username
                end                        


                update ReportLEMApprovalHeader set
                TotalAPAmt = (select SUM(isnull(a.BillAmount,0)) from ReportLEMApprovalAP a where a.Username = ReportLEMApprovalHeader.Username and a.LogHeaderId = ReportLEMApprovalHeader.LogHeaderId),
                TotalEqAmt = (select SUM(isnull(e.BillAmount,0)) from ReportLEMApprovalEquipment e where e.Username = ReportLEMApprovalHeader.Username and e.LogHeaderId = ReportLEMApprovalHeader.LogHeaderId),
                TotalLabHrs = (select SUM(isnull(l.TotalHours,0)) from ReportLEMApprovalLabour l where l.Username = ReportLEMApprovalHeader.Username and l.LogHeaderId = ReportLEMApprovalHeader.LogHeaderId),
                TotalLabAmt = (select SUM(isnull(l.BillAmount,0)) from ReportLEMApprovalLabour l where l.Username = ReportLEMApprovalHeader.Username and l.LogHeaderId = ReportLEMApprovalHeader.LogHeaderId),
                TotalLabTravelAmt = (select SUM(isnull(l.TravelHours,0) * isnull(l.TravelRate,0)) from ReportLEMApprovalLabour l where l.Username = ReportLEMApprovalHeader.Username and l.LogHeaderId = ReportLEMApprovalHeader.LogHeaderId),
                TotalLabLOAAmt = (select SUM(isnull(l.LOAHours,0) * isnull(l.LOARate,0)) from ReportLEMApprovalLabour l where l.Username = ReportLEMApprovalHeader.Username and l.LogHeaderId = ReportLEMApprovalHeader.LogHeaderId),
                TotalLabEqAmt = (select SUM(isnull(l.EquipmentHours,0) * isnull(l.EquipmentRate,0)) from ReportLEMApprovalLabour l where l.Username = ReportLEMApprovalHeader.Username and l.LogHeaderId = ReportLEMApprovalHeader.LogHeaderId)
                where username = @username
end


GO
