USE [RapidoERP_KMB]
GO

/****** Object:  UserDefinedFunction [dbo].[GetNetPay]    Script Date: 06/24/2018 09:57:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetNetPay]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetNetPay]
GO

USE [RapidoERP_KMB]
GO

/****** Object:  UserDefinedFunction [dbo].[GetNetPay]    Script Date: 06/24/2018 09:57:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[GetNetPay] 
(
@Basic numeric(10,5),
@DA numeric(10,5),
@Hra numeric(10,5),
@Conveyance numeric(10,5),
@Adhocalloance numeric(10,5),
@PF_Bank numeric(10,5),
@PF_Employee numeric(10,5),
@PF_ProfessionalTax numeric(10,5),
@FestivalAdvance numeric(10,5)
)
RETURNS numeric(10,5)
AS
BEGIN
	DECLARE @Total numeric(10,5)
	
	RETURN ((@Basic+@DA+@Hra+@Conveyance+@Adhocalloance)-(@PF_Bank+@PF_Employee+@PF_ProfessionalTax+@FestivalAdvance)) 
	
END

GO


