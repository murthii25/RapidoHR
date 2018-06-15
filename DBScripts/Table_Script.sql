USE [RapidoERP_KMB]
GO

/****** Object:  Table [dbo].[EmployeeDetail]    Script Date: 06/15/2018 14:18:50 ******/
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
 CONSTRAINT [PK_Employee_Details] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


