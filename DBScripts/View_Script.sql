USE [RapidoERP_KMB]
GO

/****** Object:  View [dbo].[EMPPayRollReport]    Script Date: 06/24/2018 09:56:26 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[EMPPayRollReport]'))
DROP VIEW [dbo].[EMPPayRollReport]
GO

USE [RapidoERP_KMB]
GO

/****** Object:  View [dbo].[EMPPayRollReport]    Script Date: 06/24/2018 09:56:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[EMPPayRollReport]
AS
SELECT     ed.FirstName, ed.MiddleName, ed.LastName, ed.Designation, p.basic, p.DA, p.HRA, p.conveyance, p.Adhoc_allow, p.basic + p.DA + p.HRA + p.conveyance + p.Adhoc_allow AS Total, 
                      p.PF_bank_by_banj, p.PF_by_emp, p.Professional_tax, p.Festival_advance, p.HG_Insurance, p.LIC, dbo.GetNetPay(p.basic, p.DA, p.HRA, p.conveyance, p.Adhoc_allow, p.PF_bank_by_banj, 
                      p.PF_by_emp, p.Professional_tax, p.Festival_advance) AS NetPay
FROM         dbo.EmployeeDetail AS ed INNER JOIN
                      dbo.EmpPayroll AS p ON ed.EmpID = p.EmpID

GO


