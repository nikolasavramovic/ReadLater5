
IF NOT EXISTS(SELECT 1 FROM sys.columns  WHERE Name = N'FirstName' AND Object_ID = Object_ID(N'dbo.AspNetUsers'))
BEGIN
    alter table [dbo].[AspNetUsers]
    add FirstName nvarchar(100)
END
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns  WHERE Name = N'LastName' AND Object_ID = Object_ID(N'dbo.AspNetUsers'))
BEGIN
    alter table [dbo].[AspNetUsers]
    add  LastName nvarchar(100)
END
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns  WHERE Name = N'Discriminator' AND Object_ID = Object_ID(N'dbo.AspNetUsers'))
BEGIN
    alter table [dbo].[AspNetUsers]
    add FDiscriminator nvarchar(100)
END
GO
         
