USE [RapidoERP_KMB]
GO

/****** Object:  Table [dbo].[EmpPayroll]    Script Date: 06/18/2018 07:13:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmpPayroll]') AND type in (N'U'))
DROP TABLE [dbo].[EmpPayroll]
GO


/****** Object:  Table [dbo].[EmployeeDetail]    Script Date: 06/18/2018 07:13:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeDetail]') AND type in (N'U'))
DROP TABLE [dbo].[EmployeeDetail]
GO


/****** Object:  Table [dbo].[EmployeeDetail]    Script Date: 06/18/2018 07:13:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeDetail](
	[EmpID] [uniqueidentifier] NOT NULL,
	[EmpCode] [nvarchar](15) NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [nvarchar](6) NULL,
	[Nationality] [nvarchar](20) NULL,
	[Designation] [nvarchar](15) NULL,
	[Address] [nvarchar](150) NULL,
	[EmailId] [nvarchar](30) NULL,
	[ContactNo] [nvarchar](15) NULL,
	[IsContract] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
	[Createdby] [nvarchar](30) NULL,
 CONSTRAINT [PK_EmployeeDetails] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EmpPayroll_EmployeeDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[EmpPayroll]'))
ALTER TABLE [dbo].[EmpPayroll] DROP CONSTRAINT [FK_EmpPayroll_EmployeeDetail]
GO

ALTER TABLE [dbo].[EmployeeDetail] ADD  DEFAULT ((0)) FOR [IsContract]
GO


/****** Object:  Table [dbo].[EmpPayroll]    Script Date: 06/18/2018 07:13:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmpPayroll](
	[EmpPRID] [uniqueidentifier] NOT NULL,
	[EmpID] [uniqueidentifier] NOT NULL,
	[basic] [numeric](10, 5) NULL,
	[DA] [numeric](10, 5) NULL,
	[HRA] [numeric](10, 5) NULL,
	[conveyance] [numeric](10, 5) NULL,
	[Adhoc_allow] [numeric](10, 5) NULL,
	[PF_by_bank] [numeric](10, 5) NULL,
	[PF_by_emp] [numeric](10, 5) NULL,
	[Professional_tax] [numeric](10, 5) NULL,
	[Festival_advance] [numeric](10, 5) NULL,
	[HG_Insurance] [bit] NOT NULL,
	[LIC] [bit] NOT NULL,
	[Net_Pay] [numeric](10, 5) NULL,
	[Date_created] [datetime] NULL,
	[Createdby] [nvarchar](30) NULL,
 CONSTRAINT [PK_EMP_Payroll] PRIMARY KEY CLUSTERED 
(
	[EmpPRID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmpPayroll]  WITH CHECK ADD  CONSTRAINT [FK_EmpPayroll_EmployeeDetail] FOREIGN KEY([EmpID])
REFERENCES [dbo].[EmployeeDetail] ([EmpID])
GO

ALTER TABLE [dbo].[EmpPayroll] CHECK CONSTRAINT [FK_EmpPayroll_EmployeeDetail]
GO

ALTER TABLE [dbo].[EmpPayroll] ADD  DEFAULT ((0)) FOR [HG_Insurance]
GO
ALTER TABLE [dbo].[EmpPayroll] ADD  DEFAULT ((0)) FOR [LIC]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmpDesignation]') AND type in (N'U'))
DROP TABLE [dbo].[EmpDesignation]
GO


/****** Object:  Table [dbo].[EmpDesignation]    Script Date: 06/18/2018 07:13:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmpDesignation](
	[EMPDesgID] [uniqueidentifier] NOT NULL,
	[DesignationName] [nvarchar](20) NULL,
	[Date_created] [datetime] NULL,
	[Createdby] [nvarchar](30) NULL,
 CONSTRAINT [PK_EMP_Designation] PRIMARY KEY CLUSTERED 
(
	[EMPDesgID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO