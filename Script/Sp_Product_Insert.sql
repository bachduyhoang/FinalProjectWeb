-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Sp_Product_Insert
	@Name nvarchar(50),
	@Image varchar(300),
	@Price	float,
	@Quantity	int,
	@DayCreate	datetime,
	@Description	nvarchar(100),
	@Status	bit,
	@BrandID varchar(10)
AS
BEGIN
	insert into Products(productName,imageLink,price,quantity,dayCreated,[description],[status],brandID)
	values(@Name,@Image,@Price,@Quantity,GETDATE(),@Description,@Status,@brandID)
END
GO
