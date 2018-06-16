USE [RapidoERP_KMB]
GO

/****** Object:  Table [dbo].[EmployeeDetail]    Script Date: 06/15/2018 17:42:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeDetail]') AND type in (N'U'))
DROP TABLE [dbo].[EmployeeDetail]
GO

USE [RapidoERP_KMB]
GO

/****** Object:  Table [dbo].[EmployeeDetail]    Script Date: 06/15/2018 17:42:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeDetail](
	[EmpId] [uniqueidentifier] NOT NULL,
	[EmpCode] [nvarchar](15) NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [nvarchar](6) NULL,
	[Nationality] [nvarchar](20) NULL,
	[Designation] [nvarchar](15) NULL,
	[Address] [nvarchar](150) NULL,
	[EmailId] [nvarchar](20) NULL,
	[ContactNo] [int] NULL,
	[DateCreated] [datetime] NULL,
	[Createdby] [nvarchar](30) NULL,
 CONSTRAINT [PK_EmployeeDetails] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[EMP_Designation]    Script Date: 06/16/2018 02:42:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EMP_Designation]') AND type in (N'U'))
DROP TABLE [dbo].[EMP_Designation]
GO

USE [RapidoERP_KMB]
GO

/****** Object:  Table [dbo].[EMP_Designation]    Script Date: 06/16/2018 02:42:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EMP_Designation](
	[EMP_DesId] [uniqueidentifier] NOT NULL,
	[DesignationName] [nvarchar](20) NULL,
	[Date_created] [datetime] NULL,
	[Createdby] [nvarchar](30) NULL,
 CONSTRAINT [PK_EMP_Designation] PRIMARY KEY CLUSTERED 
(
	[EMP_DesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[EMP_Payroll]    Script Date: 06/16/2018 02:43:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EMP_Payroll]') AND type in (N'U'))
DROP TABLE [dbo].[EMP_Payroll]
GO

USE [RapidoERP_KMB]
GO

/****** Object:  Table [dbo].[EMP_Payroll]    Script Date: 06/16/2018 02:43:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EMP_Payroll](
	[empId] [nchar](10) NOT NULL,
	[basic] [numeric](10, 5) NULL,
	[DA] [numeric](10, 5) NULL,
	[HRA] [numeric](10, 5) NULL,
	[conveyance] [numeric](10, 5) NULL,
	[Adhoc_allow] [numeric](10, 5) NULL,
	[PF_bank_by_banj] [numeric](10, 5) NULL,
	[PF_by_emp] [numeric](10, 5) NULL,
	[Professional_tax] [numeric](10, 5) NULL,
	[Festival_advance] [numeric](10, 5) NULL,
	[HG_Insurance] [bit] NULL,
	[LIC] [bit] NULL,
	[Net_Pay] [numeric](10, 0) NULL,
	[Date_created] [datetime] NULL,
	[Createdby] [nvarchar](30) NULL,
 CONSTRAINT [PK_EMP_Payroll] PRIMARY KEY CLUSTERED 
(
	[empId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



