USE [master]
GO
/****** Object:  Database [HospitalAppoimentDB]    Script Date: 6/17/2020 12:31:57 AM ******/
CREATE DATABASE [HospitalAppoimentDB]
GO

USE [HospitalAppoimentDB]
GO

/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Appoinments]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appoinments](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](16) NULL,
	[Patient] [int] NOT NULL,
	[Doctor] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Time] [nvarchar](20) NULL,
	[Status] [int] NOT NULL,
	[IsPayment] [bit] NOT NULL,
	[Price] [float] NOT NULL,
	[Reduce] [float] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Appoinments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssignPositions]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignPositions](
	[StaffID] [int] NOT NULL,
	[PositionID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[Desc] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AssignPositions] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC,
	[PositionID] ASC,
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Desc] [nvarchar](550) NULL,
	[Phone] [nvarchar](50) NULL,
	[Mail] [nvarchar](150) NULL,
	[IsMedicalExam] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Avatar] [nvarchar](500) NULL,
	[BirthDay] [nvarchar](250) NULL,
	[Address] [nvarchar](850) NULL,
	[Phone] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Department] [int] NOT NULL,
	[DateCreate] [datetime] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Doctors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DoctorSchedules]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorSchedules](
	[ID] [int] NOT NULL,
	[Day] [int] NOT NULL,
	[Shift] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.DoctorSchedules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[Day] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](550) NULL,
	[Member] [int] NOT NULL,
	[Rate] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Feedbacks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[News]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Avatar] [nvarchar](max) NULL,
	[Desc] [nvarchar](350) NULL,
	[Content] [nvarchar](max) NULL,
	[ViewNumber] [int] NOT NULL,
	[MetaTitle] [nvarchar](60) NULL,
	[MetaDesc] [nvarchar](160) NULL,
	[MetaKeyword] [nvarchar](260) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.News] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patients]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[BirthDay] [nvarchar](250) NULL,
	[Address] [nvarchar](850) NULL,
	[Phone] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Account] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[DateCreate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Patients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Positions]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Desc] [nvarchar](550) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Positions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Promotions]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotions](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](12) NULL,
	[Title] [nvarchar](250) NULL,
	[Avatar] [nvarchar](max) NULL,
	[Desc] [nvarchar](350) NULL,
	[Content] [nvarchar](max) NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[DoctorApply] [nvarchar](max) NULL,
	[AmountReduced] [int] NOT NULL,
	[PercentReduced] [float] NOT NULL,
	[Type] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Promotions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShiftTimes]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShiftTimes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [nvarchar](50) NULL,
	[EndTime] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.ShiftTimes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 6/17/2020 12:31:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Address] [nvarchar](350) NULL,
	[BirthDay] [datetime] NULL,
	[Phone] [nvarchar](50) NULL,
	[Gender] [int] NOT NULL,
	[Mail] [nvarchar](150) NULL,
	[Account] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Staffs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202006140911507_start', N'HospitalAppoimentSolution.Services.Migrations.Configuration', 0x1F8B0800000000000400ED5D5B6FDCBA117E2FD0FFB0D8A716C8B17C698234589F035F5BA3C78EE175F2CE95B8B67074D94A94E3FD6D7DE84FEA5F28258A122951A248516B79230408BC94F8F122CE70663833FCDF7FFEBBF8EDD5F7662F308ADD30389D1F1D1CCE6730B043C70D9E4EE7095AFFF279FEDBAF7FFED3E2CAF15F67DFE97B27E97BB866109FCE9F11DA7CB1ACD87E863E880F7CD78EC2385CA3033BF42DE084D6F1E1E1DFADA3230B628839C69ACD160F49805C1F663FF0CF8B30B0E10625C0BB0D1DE8C579397EB2CC506777C087F106D8F074FECF30DEB80878679B4D882102B40CBD04E15E1D2C61F4E2DA309ECFCE3C17E09E2DA1B79ECF40108408A46F7CF916C3258AC2E069B9C105C07BDC6E207E6F0DBC18E6E3F952BEDE756887C7E9D0ACB22285B2931885BE22E0D1493E5756B5BAD68CCF8BB9C4B37985671D6DD35167337A3ACF26314867713EAB36F7E5C28BD257DBA6FC12207040BED94189F561D65EE343B190F07A4BFF7D985D241E4A22781AC00445C0FB30BB4F569E6BFF0B6E1FC33F60701A249EC70E050F063FE30A70D17D146E6084B60F709D0FF0E6723EB3F87A56B562518DA943067E13A04F7F9BCFEE70E360E5C162A53093B4446104FF01031801049D7B80108CF087BE716036D7B5D62B6D5DE0B9A3ADE1A589A96E3EBB05AFBFC3E0093D637AFC349F5DBBAFD0A1057907BE052EA6515C07450994B5813BE5665FB818D4C9B16050ED2097A18D47DA13034F114548FF7EC44B431984546A9CB1E3430333B6C41F3789FB0DF626BE075B9F99F7F330F420089481EE23CCD48A690B315DA84FDA037492DE20677E9894C3E904B2B04A96D3CE88E2D87D0AEEC3D8259CAE3733E2F046C490F0D25AAFEB5C49F82EED7EC7D72FE10644281D9C0ED72B3AD667D1B33DEEC529B8A1F4438AED167681FF34C02F2E2288D99998BD75A979BE1DBC8B982EDCF556A78BA4E60EBAC873DD6EECB233832957547FE652628D88B1F4967484C4654ED2797491D7BA717F34B1734BC8FDA39146EE9FC3A06D28461AB905AED726191A69E426BE858E6B03EFEA15F87D0595890B8E9F0BE6527C6F0E98E14CDCAF33F74BFF1F9CF99DBDE0498F5A19938966CEDD083D5F82365230341EC789601CB7B4F37927FCDCCC68AEFC768E6E6A032CE59CBEBA3A61CBBD3576750556919FA54642274951CDF0358A376AFE265601419D1319E083B2A5B2ED07B07C76D7C8F0C6DA79095D43E8AC80FD47FFC5439146BD6CC666FEF459563598C47E0BFD15EC69BD7C6078E15BDA3F7175956E7426843BF823EE4F0429CA440023D38AA582A119D545A27C9F1819CB4518A07696616630DF5DF8E32EE9CF366E2102B2AFFCC90C8F4340F2058E8C358469E84718396D2BD7485B934D61F43685E278B1EFD69103EDD3EEB10F568549DD1FB1BA7F66DBECA1EC50C6E87B10C7127E6FC67AA16B75E8CEAD8C1D318FF07079ECFC6A8FCE8026C164FC824914FAA1215AA750FB44EC6FECDA766C60FD4CEAF358D5674CD9113262F0BA0A1C2338C4B68FC9D61B9EAF115739E275E7C8F65789E805231BD6B0345DF8548D873BE6D8D94100F9B87D397601B54F1C7B60F12CA359897FAD19DD287076D18C443DD668A3FB4A4EBD290DACE214665AC1A60C22669CA6E4760A335B75D5F0D2557ADF897B1AFE464E6FD3F82E5CDCF6CC4232E99DE3D43B53B91AB8986F155B1C2E75617CB9CA24EE57917DFC5B0CF3FD20CEBBCD779A202F21A24BB988B0C25D2F3B4302DD0ED8582E4B02C4454708C12AF11812C0D2EB4804C6FA24C98032215D0892BB2E7602A01E3CCD40A5CF9004907A7588A04ADF110908395BAFD527C592BAF9B188A87E71F4228368F9D29DBF71610311A294B616094C21988B6018054006934A46420822798928B7A0D1E2D9C22201A679C1C26A88445DDC82CD06B3222632352F992D4958EAC52F4BF5F84C9F6058762C08D32C7A5BB484972D788295A7C4D072ED4671AA6E831548F9D685E3D75EAB73A48619A6EDD5994E55402C279FD649FF26F5E471BA2CC7AA2097F37B8D879CBE918D1E167DE442576B956769E030F0402410452F7037FCA0D9ABAEB9363168B1F549497784825E599006226EC3A1BC908511F3C756946C87E630B292EE088452590411EDB621D08D98C5A065DD5198584BEEF396C50ADF8878AB725F881475C7A0E1962C082DEB8E42E32D59145A56475958158AA912AB55A3D68A22576500DDD843459430CD22783944834D48005A16260987ACAC4C71F066CB72622222B935D512DBD98CC6C74572A4DB12FCD98E981A9D79A4B444812D321A09C71C997255B45405A8639DD7F4FF3624560D61B1D87255B46ABFCAD2A158DE1B91352BD01B2669461B5027E7B6CAC3ECFAF91113BFC9A1BAE2D086D19FC8729B0EC7414891C212CECC2DDCF2CD4A54F6592E5C90DF6BB94713FBF8B9D947AEC69B661D44C6D5601B0D15876119C40ACDD627250AA25F7EE2CC897E79597794D280CCE294A50AFDA1266FAE43B470B76C2C77AC6331F2221D39AA498A5255A4A8D75A559DA2E5C328206F4ADEA5916D10322F2C74BAE4DE0C300CD9D7284D91C8F230388EB193A2D17CF8D2186AF893179654F58FDD5C752833905F671C45A1824890C7A47102415EA6606AA8719D07457E63C00C94799570127256329A659BD9D90DAF58116687D52AAE365ED5C58C2462C0CA40FDD678AACB0BBBE3B0615D2C145BAE42C34570174FC645B11A567D9ECA5235A42240AB0A563C9854B49F5A452B8E150DF3457A9CA1CE1A1B6B8E554B9BF4ABC6F150A71B6E3CB450E5C08C7AD5F02766B474681DEDAD6873A8E3941E0729EA47286F2FBC4C871B2A683FCFD6577AB298A6AFC20D4683C09AEB0EA5C8F6F56798140C2105D0C0970A11D06285AD9886BE709B312D54F517C9435FEA4E23F90355CF842224A5EEA0503C52D8EA2B712EDC865F79368469E25D7334C6A9CE30472B3DF2D4395A4BDD61381A13C052A33D55CFA42246A5427BAA38DDD58CB75A3BC493D2F4BAC9DC3035D68CB8DE585540538A9B3955D2840A48833B58105AB64B7F83F1A991933EF06EF5819A1778F595A2F5BCA4F85D7881E71ED8F24B8A6A2ED9E495F90C4FCF8BEBA4EED8CB6D8CA04FA2FD96FFF62E3CE2044C5FB80581BB863122F17AF3E3C3345E9EBBD7683C770C5971EC70E184AD170DF15F6C0761872BF7C94DA7561A5BA89AEF9C497010BC80C87E4E7596CAED3D25A6C6553D59B77B5DD4A385C0446E39F86FD4F79A1EE1E4A417F5A84D0E1FB4A533B2DA9D3C2B571D844B67BCF642A00EC15FC7A387C1DFC6D30543F7321E0D827D2FB7DCE82CA2FA1D375A4426B8E1460FA74C1A42E9EC2F3E78FDAB2A75D5034B45B4DF1DA98CE2ECD5AD7A30A96EB7AAC1A5BDBAC5F322391BD1B9A766E71BE520BB2497A247BC137C54DE0A44ABBE9EE44B71EF65C3E6C5A0CA986C84BB584450C714DED9A2B3914D143F0E8A17F826BF5B6A27F613B3C4CEA7DF6AA04C65D46A760D63BDE5B38308613F0FC19D34FACAE52835C79BAB3790E82A217C26506D55445960D7BD7EC408098B85DE7EF77AE87D806D9FEADC9D1E0A8C57FDDE8E3DB22770976198926BF8BB2F74BE257BF3C5DB1914B61B854EA8DD7AB1374B6810615BBCFF6A095152B9FD44BD7B958C96BDFA57BFF44167BDD7AE7C100EF5930625F3373C34181DB5702B173A88D78E3AF4A4638C42C710BAD64E4AC6A40E0CAF0E54F2EF1932AC54D3ED1982D5D63AD4EF1FD80F527C37D6BD69231AC7462476727DCF32B7FC18F85875FA2731BEF7F2E593CF6B6B9D95E4F3DA3882E4F3BD46284C30AF759A294C2FAF7724ADA6A2EF90EB3438A2BEDB5DB796A8DD90F853C9CB6E08552AAECB2015B3AEEFC73796CE9AC6D16117654483755775275D11668813583E4FB99635678033DC77A5144DA2F3DB89CED5B4E2F55CBF7C670AFF57BAD098A4E0653B828CE1C44115CFE12AC47D27BDE5F28D5B92862A09C3EB8D555E103658CD4B2E69943D6AAC35C83E1435C6E52C9735943B55D61BC91F081BA0B9CC3B819709C91B1A295F686E8CC97B2E69B44C5D5E6BAE7C246A88C9872E69A235E9B9085A251D7A5B3674117699455D86DFBC84DB176FF7655B2AC1AD89D4858D3049D825AD30B9D46BAD30CF44ADB039DA65AD9074EBF51648B9103D4FDD2EE2821D52B4D79DF017D603DE4C7177C92FAC9D622E52402C306600ED74D24A50FACE4DB00E2903C783627B445F111C96E08D069C45C85D031BE1C73696A9B27B2ABE032F49C5687F059D9BE06B823609C23C0DFA2B3EBE7261B5B79FE5A1E7FBBCF8BAC93EBB8921E06EBAE95EF935384F5CCF29FA7D2DD89D1A20D27D28177671AF9628157A9FB605D25D2DE0A809289F3ECC8C53412D408FD0DF78182CFE1A2CC10BD4E9DBB718FE0E9F80BDBDCF63299A41E41F829FF6C5A50B9E22E0C73946591FFFC46BD8F15F7FFD3FA4383047569B0000, N'6.4.0')
SET IDENTITY_INSERT [dbo].[Appoinments] ON 

INSERT [dbo].[Appoinments] ([ID], [Code], [Patient], [Doctor], [Date], [Time], [Status], [IsPayment], [Price], [Reduce], [Amount]) VALUES (2, N'160620b6b5rub', 18, 3, CAST(N'2020-06-17 00:00:00.000' AS DateTime), N'16:00', 2, 1, 100000, 0, 100000)
INSERT [dbo].[Appoinments] ([ID], [Code], [Patient], [Doctor], [Date], [Time], [Status], [IsPayment], [Price], [Reduce], [Amount]) VALUES (3, N'170620pwgndbu', 18, 3, CAST(N'2020-06-19 00:00:00.000' AS DateTime), N'16:00', 0, 1, 100000, 10000, 90000)
SET IDENTITY_INSERT [dbo].[Appoinments] OFF
INSERT [dbo].[AssignPositions] ([StaffID], [PositionID], [DepartmentID], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (2, 2, 1, NULL, CAST(N'2020-06-14 17:30:11.857' AS DateTime), N'admin', CAST(N'2020-06-14 17:30:11.857' AS DateTime), N'admin', 1)
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [IsMedicalExam], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (1, N'Phòng R&D', N'demo@gmail.com', N'0123456789', N'demo@gmail.com', 0, CAST(N'2020-06-14 17:28:04.337' AS DateTime), N'admin', CAST(N'2020-06-14 17:28:04.337' AS DateTime), N'admin', 1)
INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [IsMedicalExam], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (2, N'Phòng nhân sự', N'Phòng nhân sự', N'0334888777', N'demo@gmail.com', 0, CAST(N'2020-06-14 17:28:18.090' AS DateTime), N'admin', CAST(N'2020-06-14 17:28:18.090' AS DateTime), N'admin', 1)
INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [IsMedicalExam], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (3, N'Phòng điều hành', N'Phòng điều hành', N'0123456789', N'demo@gmail.com', 0, CAST(N'2020-06-14 17:28:50.427' AS DateTime), N'admin', CAST(N'2020-06-14 17:28:50.427' AS DateTime), N'admin', 1)
INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [IsMedicalExam], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (4, N'Khoa Nội', N'Khoa Nội', N'0123456789', N'demo@gmail.com', 1, CAST(N'2020-06-14 22:51:42.563' AS DateTime), N'admin', CAST(N'2020-06-14 22:51:42.563' AS DateTime), N'admin', 1)
INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [IsMedicalExam], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (5, N'Khoa Ngoại', N'Khoa Ngoại', N'0123456789', N'demo@gmail.com', 1, CAST(N'2020-06-14 22:51:52.867' AS DateTime), N'admin', CAST(N'2020-06-14 22:51:52.867' AS DateTime), N'admin', 1)
INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [IsMedicalExam], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (6, N'Khoa Thần Kinh', N'Khoa Thần Kinh', N'0123456789', N'demo@gmail.com', 1, CAST(N'2020-06-14 22:52:02.543' AS DateTime), N'admin', CAST(N'2020-06-14 22:52:02.543' AS DateTime), N'admin', 1)
INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [IsMedicalExam], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (7, N'Khoa Da Liễu', N'Khoa Da Liễu', N'0123456789', N'demo@gmail.com', 1, CAST(N'2020-06-14 22:52:11.667' AS DateTime), N'admin', CAST(N'2020-06-14 22:52:11.667' AS DateTime), N'admin', 1)
INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [IsMedicalExam], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (8, N'Khoa Xương Khớp', N'Khoa Sương Khớp', N'0123456789', N'demo@gmail.com', 1, CAST(N'2020-06-14 22:52:27.713' AS DateTime), N'admin', CAST(N'2020-06-14 22:53:21.663' AS DateTime), N'admin', 1)
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[Doctors] ON 

INSERT [dbo].[Doctors] ([ID], [Name], [Avatar], [BirthDay], [Address], [Phone], [Email], [Department], [DateCreate], [Price]) VALUES (3, N'Trần Thái Tuấn', N'http://localhost:44351/Content/FileUploads/images/doctor-thumb-05.jpg', N'07/02/1979', N'179 Nguyễn Văn Linh, P.5, Q.7, TP.Hồ Chí Minh', N'1231231231', N'123@123.com', 4, CAST(N'2020-06-14 22:57:39.050' AS DateTime), 100000)
INSERT [dbo].[Doctors] ([ID], [Name], [Avatar], [BirthDay], [Address], [Phone], [Email], [Department], [DateCreate], [Price]) VALUES (4, N'Kim Xa Lý', N'http://localhost:44351/Content/FileUploads/images/doctor-thumb-01.jpg', N'20/10/1987', N'485 Nguyễn Xí, P.4, Bình Thạnh, Hồ Chí Minh', N'0123456789', N'demo@gmail.com', 5, CAST(N'2020-06-14 23:01:22.847' AS DateTime), 85000)
INSERT [dbo].[Doctors] ([ID], [Name], [Avatar], [BirthDay], [Address], [Phone], [Email], [Department], [DateCreate], [Price]) VALUES (5, N'Thái Đình Tâm', N'http://localhost:44351/Content/FileUploads/images/doctor-thumb-08.jpg', N'21/11/1985', N'Bình thuận 2, Thuận giao, Thuận an, Bình dương', N'0123456789', N'dinhtam0@gmail.com', 6, CAST(N'2020-06-14 23:02:17.197' AS DateTime), 90000)
INSERT [dbo].[Doctors] ([ID], [Name], [Avatar], [BirthDay], [Address], [Phone], [Email], [Department], [DateCreate], [Price]) VALUES (6, N'Dương Thị Thu Hương', N'http://localhost:44351/Content/FileUploads/images/doctor-thumb-03.jpg', N'11/07/1981', N'78/2 Võ Văn Việt, Phường 7, Quận 9, Tp.Hồ Chí Minh', N'0189898989', N'thuhuong@gmail.com', 7, CAST(N'2020-06-14 23:03:42.867' AS DateTime), 75000)
SET IDENTITY_INSERT [dbo].[Doctors] OFF
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (3, 1, N'1|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (3, 2, N'1|2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (3, 3, N'2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (3, 4, N'1|2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (3, 5, N'2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (3, 6, N'1|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (4, 1, N'1|2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (4, 2, N'1|2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (4, 3, N'2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (4, 4, N'1|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (4, 5, N'1|2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (4, 6, N'2|1|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (5, 1, N'1|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (5, 2, N'1|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (5, 3, N'1|2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (5, 4, N'1|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (5, 5, N'1|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (5, 6, N'1|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (6, 1, N'1|2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (6, 2, N'1|2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (6, 3, N'2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (6, 4, N'2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (6, 5, N'1|2|')
INSERT [dbo].[DoctorSchedules] ([ID], [Day], [Shift]) VALUES (6, 6, N'1|2|')
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([ID], [Title], [Avatar], [Desc], [Content], [ViewNumber], [MetaTitle], [MetaDesc], [MetaKeyword], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (1, N'6 bí kíp giúp bảo vệ sức khoẻ cho “dân” văn phòng', N'http://localhost:44351//Content/FileUploads/images/2018020507.jpg', N'Nhịp sống nhanh làm cho dân văn phòng thở không ra hơi, luôn bận rộn và bận rộn. Lại có người khó thoát ra khỏi áp lực công việc. Một số chiêu thức sau đây sẽ bảo vệ sức khoẻ cho dân văn phòng.', N'<ul>
	<li><em>Thời gian l&agrave;m việc d&agrave;i:</em>&nbsp;Đ&acirc;y l&agrave; đặc điểm điển h&igrave;nh nhất của d&acirc;n văn ph&ograve;ng, 1 ng&agrave;y l&agrave;m việc 8 tiếng hầu như l&agrave; kh&ocirc;ng đủ đối với họ, v&igrave; l&agrave;m th&ecirc;m, đi sớm về muộn hầu như đ&atilde; trở th&agrave;nh &ldquo;m&ocirc;n học bắt buộc&rdquo; của họ.</li>
</ul>

<ul>
	<li><em>&Aacute;p lực c&ocirc;ng việc lớn:</em>&nbsp;C&aacute;c ng&agrave;nh nghề đều kh&ocirc;ng thiếu nh&acirc;n t&agrave;i. Trong c&ocirc;ng cuộc cạnh tranh khốc liệt n&agrave;y, muốn đứng vững th&igrave; &aacute;p lực của d&acirc;n văn ph&ograve;ng &ldquo;kh&ocirc;ng n&oacute;i m&agrave; hiểu&rdquo;. Khẩu hiệu của văn ho&aacute; doanh nghiệp &ldquo; th&aacute;ch thức ch&iacute;nh m&igrave;nh, khơi dậy tiềm năng&rdquo; c&agrave;ng l&agrave;m cho họ thở kh&ocirc;ng ra hơi.</li>
</ul>

<ul>
	<li><em>Thời gian nghỉ ngơi &iacute;t:</em>&nbsp;Do l&agrave;m việc qu&aacute; giờ một c&aacute;ch thường xuy&ecirc;n, ngủ đ&atilde; trở th&agrave;nh một thứ đồ &ldquo;xa xỉ phẩm&rdquo; của d&acirc;n văn ph&ograve;ng. kh&ocirc;ng &iacute;t người lợi dụng thời gian nghỉ cuối tuần để ngủ b&ugrave;.Nhưng như thế cũng l&agrave;m họ mất đi cơ hội tham gia c&aacute;c hoạt động vui chơi, cuộc sống ng&agrave;y c&agrave;ng thu hẹp lại v&agrave; bệnh nghề nghiệp ng&agrave;y c&agrave;ng nhiều.C&ocirc;ng việc qu&aacute; khắc khổ l&agrave;m cho d&acirc;n văn ph&ograve;ng bị rất nhiều bệnh nghề nghiệp như mỡ m&aacute;u cao, mỡ gan, c&aacute;c bệnh về dạ d&agrave;y ti&ecirc;u ho&aacute;. Lại th&ecirc;m c&aacute;c bệnh do m&aacute;y t&iacute;nh, điều ho&agrave;, bệnh về mắt cũng &ldquo;kh&ocirc;ng mời m&agrave; đến&rdquo;.</li>
</ul>

<ul>
	<li><em>C&oacute; khoảng c&aacute;ch với người th&acirc;n trong gia đ&igrave;nh:</em>&nbsp;Đối với những người chưa kết h&ocirc;n th&igrave; phải c&aacute;ch một qu&atilde;ng thời gian d&agrave;i mới được nghỉ ph&eacute;p về thăm bố mẹ, c&ograve;n đối với những người đ&atilde; c&oacute; gia đ&igrave;nh th&igrave; s&aacute;ng sớm đi ra khỏi nh&agrave; khi con c&ograve;n chưa thức dậy, tối khi về đến nh&agrave; th&igrave; con đ&atilde; ngủ từ l&acirc;u rồi.</li>
</ul>

<ul>
	<li><em>Cơ hội giao lưu &iacute;t:</em>&nbsp;Đặc biệt l&agrave; d&acirc;n l&agrave;m kỹ thuật, h&agrave;ng ng&agrave;y phải đối diện với giấy tờ, bản vẽ, kế hoạch, giao lưu với người kh&aacute;c chủ yếu l&agrave; qua internet. Thời gian l&acirc;u dần, họ quen với &ldquo;giao lưu&rdquo; với c&aacute;c m&aacute;y m&oacute;c &ldquo;kh&ocirc;ng c&oacute; t&igrave;nh cảm&rdquo;. Nếu gặp phải con người đang &ldquo;sống sờ sờ&rdquo; trước mặt th&igrave; rất kh&oacute; để ho&agrave; hợp như thế n&agrave;o.Thế l&agrave;, tr&ecirc;n mạng th&igrave; nhiệt t&igrave;nh như lửa, trong cuộc sống th&igrave; lạnh nhạt như băng. Những điều họ thể hiện trong hư v&ocirc; v&agrave; thế giới hiện thực đ&atilde; l&agrave;m cho họ trở th&agrave;nh &ldquo;người hai mặt&rdquo; ẩn chứa hai loại t&iacute;nh c&aacute;ch cực đoan.</li>
</ul>

<p><br />
<strong>C&aacute;c biện ph&aacute;p khắc phục</strong></p>

<p style="text-align:center"><strong><img alt="" src="http://localhost:44351/Content/FileUploads/images/2018020507.jpg" /></strong></p>

<p>&nbsp;</p>

<ol>
	<li><em>Vứt bỏ cố chấp:</em>&nbsp;Một số người chỉ muốn bất chấp tất cả để đạt được mục đ&iacute;ch, họ kh&ocirc;ng muốn thua k&eacute;m ai v&agrave; vứt bỏ bất cứ c&aacute;i g&igrave;. Họ lu&ocirc;n mang theo ho&agrave;i b&atilde;o lớn v&agrave; &aacute;p lực để sống qua mỗi ng&agrave;y. V&igrave; vậy, d&acirc;n văn ph&ograve;ng h&atilde;y n&ecirc;n biết vứt bỏ những ho&agrave;i b&atilde;o &ldquo;cố chấp&rdquo; kh&ocirc;ng c&oacute; &yacute; nghĩa, n&ecirc;n nắm bắt v&agrave; l&agrave;m tốt c&ocirc;ng việc ch&iacute;nh. Như thế t&acirc;m trạng sẽ thoải m&aacute;i v&agrave; đỡ &aacute;p lực hơn</li>
	<li><em>Ki&ecirc;n quyết kh&ocirc;ng l&agrave;m việc qu&aacute; thời gian:</em>&nbsp;Rất nhiều người theo đuổi mục đ&iacute;ch l&agrave;m việc l&agrave; phải c&oacute; kết quả ho&agrave;n mỹ. Nhưng tr&ecirc;n thực tế, kh&ocirc;ng phải c&ocirc;ng việc n&agrave;o cũng thuận lợi, bạn c&oacute; thể ho&agrave;n th&agrave;nh một c&aacute;ch tốt đẹp. Khi h&agrave;ng đống c&ocirc;ng việc dồn lại, thời gian lại cấp b&aacute;ch, buộc họ phải l&agrave;m việc qu&aacute; thời gian.C&aacute;c chuy&ecirc;n gia khuy&ecirc;n rằng một số c&ocirc;ng việc chỉ cần l&agrave;m đến 80 ph&uacute;t l&agrave; đủ, c&ugrave;ng lắm l&agrave; 100 ph&uacute;t. Kh&ocirc;ng n&ecirc;n k&eacute;o d&agrave;i thời gian l&agrave;m việc qu&aacute; sức khiến ảnh hưởng đến sức khoẻ. H&atilde;y cho cơ thể thời gian nghỉ ngơi. Bạn c&oacute; thể thư gi&atilde;n bằng c&aacute;ch đi bộ ở nơi c&oacute; kh&ocirc;ng kh&iacute; trong l&agrave;nh, tho&aacute;ng m&aacute;t.</li>
	<li><em>Mạnh dạn l&agrave;m một người &ldquo;th&aacute;ch thức ch&iacute;nh m&igrave;nh&rdquo;:</em>&nbsp;C&ocirc;ng việc qu&aacute; nhiều n&ecirc;n c&oacute; nhiều &aacute;p lực khiến bạn &ldquo;trốn tr&aacute;nh&rdquo; tr&aacute;ch nhiệm một số c&ocirc;ng việc n&agrave;o đ&oacute;. Nhưng khi bạn th&aacute;ch thức với giới hạn của ch&iacute;nh m&igrave;nh sẽ gi&uacute;p bạn tăng th&ecirc;m l&ograve;ng tự tin. V&igrave; thế mỗi ng&agrave;y bạn n&ecirc;n thử c&aacute;ch l&agrave;m việc mới, thử vận động hay chơi một m&ocirc;n thể thao n&agrave;o đ&oacute;, như thế sẽ l&agrave;m cho bạn giảm bớt &aacute;p lực.</li>
	<li><em>Học c&aacute;ch lập bảng kế hoạch:</em>&nbsp;Khi bạn c&oacute; một bản kế hoạch ho&agrave;n mỹ v&agrave; từng bước thực hiện từng việc trong đ&oacute; th&igrave; sẽ kh&ocirc;ng tạo ra c&aacute;i gọi l&agrave; &aacute;p lực nữa, bởi v&igrave; tất cả mọi việc đều nằm trong tầm tay v&agrave; trong sự khống chế của bạn.</li>
	<li><em>Th&ocirc;ng qua giao lưu &ldquo;giải ph&oacute;ng&rdquo; &aacute;p lực:</em>&nbsp;H&atilde;y mở rộng l&ograve;ng m&igrave;nh, n&ecirc;n giao lưu tiếp x&uacute;c,n&oacute;i chuyện nhiều với bạn b&egrave;, họ h&agrave;ng th&acirc;n th&iacute;ch. L&uacute;c cần thiết c&oacute; thể &ldquo;t&acirc;m sự&rdquo; với cấp tr&ecirc;n. Khi bạn n&oacute;i ra hết được mọi &aacute;p lực của c&ocirc;ng việc, bạn sẽ d&agrave;nh được sự quan t&acirc;m, lo lắng v&agrave; chăm s&oacute;c v&agrave; động vi&ecirc;n của đồng nghiệp. Thậm ch&iacute; c&oacute; người c&ograve;n đưa ra cho bạn những giải ph&aacute;p khắc phục. Như vậy, &aacute;p lực tự nhi&ecirc;n đ&atilde; giảm xuống một nửa rồi.</li>
	<li><em>Một ng&agrave;y kh&ocirc;ng thể thiếu &ldquo;3 bữa&rdquo;:</em>&nbsp;Sức khoẻ rất quan trọng. Rất nhiều người c&oacute; th&oacute;i quen kh&ocirc;ng ăn s&aacute;ng, chỉ uống mỗi cốc c&agrave; ph&ecirc; trước khi đi l&agrave;m. Như thế sẽ ảnh hưởng rất lớn đến sức khoẻ, cần phải &ldquo;cai&rdquo; được th&oacute;i quen xấu n&agrave;y.</li>
</ol>
', 0, NULL, NULL, NULL, CAST(N'2020-06-14 22:27:53.743' AS DateTime), NULL, CAST(N'2020-06-14 22:27:53.743' AS DateTime), NULL, 1)
INSERT [dbo].[News] ([ID], [Title], [Avatar], [Desc], [Content], [ViewNumber], [MetaTitle], [MetaDesc], [MetaKeyword], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (2, N'MẸO CHĂM SÓC SỨC KHỎE CỰC HAY CHO DÂN VĂN PHÒNG', N'http://localhost:44351//Content/FileUploads/images/1_c597412f9e4040119101cb52bf0d593f_1024x1024.jpg', N'Văn phòng là công việc buộc phải ngồi nhiều và ít có thời gian vận động. Dân văn phòng còn hay phải ngồi trong môi trường máy lạnh ít nhất 8 tiếng một ngày', N'<p>Văn ph&ograve;ng l&agrave; c&ocirc;ng việc buộc phải ngồi nhiều v&agrave; &iacute;t c&oacute; thời gian vận động. D&acirc;n văn ph&ograve;ng c&ograve;n hay phải ngồi trong m&ocirc;i trường m&aacute;y lạnh &iacute;t nhất 8 tiếng một ng&agrave;y. Điều n&agrave;y t&aacute;c động kh&ocirc;ng hề tốt đến sức khỏe, dẫn đến nhiều loại bệnh tật. B&agrave;i viết sau đ&acirc;y phần n&agrave;o đ&oacute; gi&uacute;p c&aacute;c bạn l&agrave;m việc văn ph&ograve;ng c&oacute; những mẹo chăm s&oacute;c sức khỏe đơn giản v&agrave; hữu &iacute;ch, đặc biệt hiệu quả m&agrave; vẫn tiết kiệm thời gian.</p>

<p><strong>Kh&ocirc;ng ngồi qu&aacute; l&acirc;u</strong></p>

<p><strong><img alt="" src="http://localhost:44351/Content/FileUploads/images/1_c597412f9e4040119101cb52bf0d593f_1024x1024.jpg" /></strong></p>

<p>&nbsp;</p>

<p>Ngồi qu&aacute; l&acirc;u dẫn đến việc lưu th&ocirc;ng m&aacute;u kh&oacute; khăn dẫn đến t&igrave;nh trạng hoa mắt, ch&oacute;ng mặt khi đột ngột l&agrave;m việc hay hoạt động. Một số nghi&ecirc;n cứu c&ograve;n chỉ ra rằng, ngồi l&acirc;u sẽ ảnh hưởng nặng nề đến xương khớp, tim mạch v&agrave; hệ ti&ecirc;u h&oacute;a. Ngồi qu&aacute; l&acirc;u một chổ cũng l&agrave;m giảm khả năng tập trung v&agrave; giảm năng suất l&agrave;m việc của bạn.</p>

<p>V&igrave; vậy đừng ngồi qu&aacute; l&acirc;u một chỗ, trung b&igrave;nh cứ 2 tiếng n&ecirc;n ra khỏi chỗ ngồi thư gi&atilde;n hoặc tập v&agrave;i động t&aacute;c thể dục nhẹ.</p>

<p><strong>Tạo kh&ocirc;ng kh&iacute; trong l&agrave;nh</strong></p>

<p><strong><img alt="" src="http://localhost:44351/Content/FileUploads/images/2_bcff6b1a32b145da8418c057a16ab0fc_1024x1024.jpg" /></strong></p>

<p>Một điều chắc chắn l&agrave; l&agrave;m việc trong m&ocirc;i trường kh&ocirc;ng kh&iacute; &ocirc; nhiễm v&agrave; kh&ocirc;ng được trong l&agrave;nh th&igrave; sức khỏe v&agrave; hiệu suất l&agrave;m việc sẽ ảnh hưởng rất nhiều. Một điều cần lưu &yacute; l&agrave; d&acirc;n văn ph&ograve;ng thường xuy&ecirc;n ngồi trong ph&ograve;ng m&aacute;y lạnh rất dễ xảy ra c&oacute; vấn đề h&ocirc; hấp.</p>

<p>Nếu c&oacute; thể h&atilde;y th&ecirc;m hệ thống th&ocirc;ng gi&oacute; hoặc mở cửa sổ để kh&ocirc;ng kh&iacute; lưu th&ocirc;ng. Ch&uacute; &yacute; th&ecirc;m c&acirc;y xanh tại văn ph&ograve;ng nơi l&agrave;m việc để trao đổi kh&ocirc;ng kh&iacute;. V&agrave; nếu c&oacute; c&aacute;ch n&agrave;o hay ho để g&oacute;p phần tạo bầu kh&ocirc;ng kh&iacute; trong l&agrave;nh h&atilde;y cố gắng thực hiện.</p>

<p><strong>Bảo vệ mắt tốt hơn</strong></p>

<p>Đ&ocirc;i mắt lu&ocirc;n cần được bảo vệ v&agrave; chăm s&oacute;c chu đ&aacute;o, bởi v&igrave; đ&ocirc;i mắt thường xuy&ecirc;n phải hoạt động v&agrave; đặc biệt l&agrave; suốt ng&agrave;y phải đối diện với m&agrave;y h&igrave;nh m&aacute;y t&iacute;nh. &nbsp;Bạn cần cho mắt m&igrave;nh c&oacute; thời gian nghỉ ngơi v&agrave; thư gi&atilde;n như việc bạn cho cơ thể m&igrave;nh nghỉ ngơi. Cụ thể mỗi 1 tiếng l&agrave;m việc trước m&aacute;y t&iacute;nh, bạn cần nhắm mắt lại từ 20-30s để mắt nghỉ ngơi, hoặc c&oacute; thể đảo mắt qua lại để mắt hoạt động lại b&igrave;nh thường.</p>

<p>Một số lưu &yacute; bảo vệ mắt kh&aacute;c đ&oacute; l&agrave; điều chỉnh &aacute;nh s&aacute;ng m&agrave;n h&igrave;nh, cỡ chữ ph&ugrave; hợp m&agrave; c&aacute;c m&aacute;u sắc tương phản kh&aacute;c tr&ecirc;n m&aacute;y t&iacute;nh, để mắt cảm thấy ph&ugrave; hợp v&agrave; dễ chịu nhất khi l&agrave;m việc.</p>

<p><strong>Ăn s&aacute;ng đầy đủ</strong></p>

<p><strong><img alt="" src="http://localhost:44351/Content/FileUploads/images/4_5cb47c8d103945ffa1445eecc86b8167_1024x1024.jpg" /></strong></p>

<p>Bữa s&aacute;ng l&agrave; bữa ăn quan trọng nhất trong một ng&agrave;y, ấy m&agrave; c&oacute; nhiều người nhất l&agrave; nh&acirc;n vi&ecirc;n văn ph&ograve;ng v&igrave; bận rộn m&agrave; bỏ đi bữa ăn s&aacute;ng. Việc đ&oacute; ảnh hưởng ti&ecirc;u cực đến sức một c&aacute;ch rất nghi&ecirc;m trọng. Hậu quả dẫn đến thiếu năng lượng, tập trung k&eacute;m v&agrave; hiệu quả l&agrave;m việc giảm s&uacute;t. Đừng bỏ qua bất kỳ bữa ăn s&aacute;ng n&agrave;o để đảm bảo một sức khỏe tốt nhất!</p>
', 0, NULL, NULL, NULL, CAST(N'2020-06-14 22:31:17.123' AS DateTime), NULL, CAST(N'2020-06-14 22:31:17.123' AS DateTime), NULL, 1)
INSERT [dbo].[News] ([ID], [Title], [Avatar], [Desc], [Content], [ViewNumber], [MetaTitle], [MetaDesc], [MetaKeyword], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (3, N'Cách chăm sóc trẻ em khi bị sốt tại nhà hiệu quả', N'http://localhost:44351//Content/FileUploads/images/cahm-soc-tre-em.jpg', N'Đứa con là tài sản vô giá của cha mẹ,chúng ta chăm sóc những đứa con của mình rất chu đáo mỗi ngày nhưng không thể tránh được việc các bé bị ốm. Vì ốm là hiện tượng thường gặp ở trẻ nhỏ vì hệ kháng sinh của trẻ nhỏ yếu hơn so với người trưởng thành. ', N'<p>Đứa con l&agrave; t&agrave;i sản v&ocirc; gi&aacute; của cha mẹ,ch&uacute;ng ta chăm s&oacute;c những đứa con của m&igrave;nh rất chu đ&aacute;o mỗi ng&agrave;y nhưng kh&ocirc;ng thể tr&aacute;nh được việc c&aacute;c b&eacute; bị ốm. V&igrave; ốm l&agrave; hiện tượng thường gặp ở trẻ nhỏ v&igrave; hệ kh&aacute;ng sinh của trẻ nhỏ yếu hơn so với người trưởng th&agrave;nh. Con ốm chắc hẳn l&agrave; điều m&agrave; c&aacute;c bậc phụ huynh rất &aacute;i ngại, lo lắng nhưng việc chăm con ốm đ&uacute;ng c&aacute;ch kh&ocirc;ng phải cha mẹ n&agrave;o cũng biết. L&agrave;m thế n&agrave;o để chăm con đ&uacute;ng c&aacute;ch khi con bạn bị ốm? dưới đ&acirc;y l&agrave; c&aacute;ch chăm s&oacute;c trẻ bị ốm đ&uacute;ng c&aacute;ch tại nh&agrave; m&agrave; tất cả c&aacute;c bậc cha mẹ n&ecirc;n biết.</p>

<p><strong>NHỮNG LƯU &Yacute; KHI CHĂM S&Oacute;C B&Eacute; BỊ BỆNH TỐT NHẤT</strong></p>

<p><strong>1. Kh&iacute;ch Lệ Tinh Thần B&eacute;.</strong></p>

<p>Bị ốm sẽ kh&oacute; chịu v&agrave; trẻ c&oacute; thể lo lắng hay buồn b&atilde; bởi những g&igrave; ch&uacute;ng cảm thấy. V&igrave; thế h&atilde;y quan t&acirc;m v&agrave; chăm s&oacute;c trẻ hơn b&igrave;nh thường. V&iacute; dụ như bạn c&oacute; thể:</p>

<p>+ Ngồi c&ugrave;ng trẻ</p>

<p>+ Đọc s&aacute;ch cho trẻ</p>

<p>+ H&aacute;t cho trẻ nghe</p>

<p>+ Cầm tay trẻ</p>

<p>+ &Ocirc;m trẻ v&agrave;o l&ograve;ng</p>

<p><strong>2. K&ecirc; Cao Người Hoặc Đầu Trẻ</strong></p>

<p>Việc để trẻ nằm thẳng người tr&ecirc;n một mặt phẳng c&oacute; thể khiến cơn ho trở n&ecirc;n tệ hơn. Để giữ cho đầu trẻ được k&ecirc; cao, bạn c&oacute; thể đặt một cuốn s&aacute;ch hoặc khăn tắm dưới đệm hay dưới ch&acirc;n của trẻ.</p>

<p>+ Bạn cũng c&oacute; thể đặt th&ecirc;m một c&aacute;i gối hoặc sử dụng một c&aacute;i nệm k&ecirc; lưng để giữ cho trẻ nằm cao.</p>

<p><strong>3. Bật M&aacute;y Tạo Ẩm.</strong></p>

<p><strong><img alt="" src="http://localhost:44351/Content/FileUploads/images/cham_soc_tre_khi_om.jpg" /></strong></p>

<p>Kh&ocirc;ng kh&iacute; kh&ocirc; c&oacute; thể khiến cơn ho v&agrave; vi&ecirc;m họng trở n&ecirc;n tệ hơn, v&igrave; vậy h&atilde;y thử d&ugrave;ng m&aacute;y tạo ẩm hoặc m&aacute;y phun sương m&aacute;t để giữ ẩm cho kh&ocirc;ng kh&iacute; trong ph&ograve;ng trẻ. Điều n&agrave;y c&oacute; thể gi&uacute;p giảm cơn ho, ngạt mũi v&agrave; cảm gi&aacute;c kh&oacute; chịu.</p>

<p>+ H&atilde;y chắc chắn l&agrave; bạn thay nước trong m&aacute;y tạo ẩm thường xuy&ecirc;n.</p>

<p>+ Vệ sinh m&aacute;y tạo ẩm theo hướng dẫn của nh&agrave; sản xuất để ngăn chặn nấm mốc ph&aacute;t triển trong đ&oacute;.</p>

<p><strong>4. Để Trẻ Ở Trong M&ocirc;i Trường Y&ecirc;n Tĩnh</strong></p>

<p>Giữ cho kh&ocirc;ng gian trong nh&agrave; y&ecirc;n tĩnh nhất c&oacute; thể để gi&uacute;p trẻ nghỉ ngơi tốt hơn. K&iacute;ch th&iacute;ch từ tivi v&agrave; m&aacute;y t&iacute;nh l&agrave;m hạn chế giấc ngủ của trẻ v&agrave; trẻ cần nghỉ ngơi nhiều c&agrave;ng nhiều c&agrave;ng tốt, vậy n&ecirc;n bạn c&oacute; thể c&acirc;n nhắc việc di chuyển c&aacute;c thiết bị n&agrave;y khỏi ph&ograve;ng trẻ hoặc hạn chế trẻ sử dụng ch&uacute;ng</p>

<p>&nbsp;</p>

<p><strong>5. Giữ Cho Nhiệt Độ Trong Nh&agrave; Bạn Dễ Chịu.</strong></p>

<p>Trẻ c&oacute; thể thấy n&oacute;ng hoặc lạnh do ốm, v&igrave; vậy, điều chỉnh nhiệt độ trong nh&agrave; c&oacute; thể gi&uacute;p trẻ thấy dễ chịu hơn. Sẽ tốt hơn nếu giữ nhiệt độ nh&agrave; bạn trong khoảng từ 18 đến 21 độ C (tương đương 65 đến 70 độ F), bạn cũng c&oacute; thể điều chỉnh nhiệt độ nếu trẻ qu&aacute; n&oacute;ng hoặc qu&aacute; lạnh.</p>

<p>+ V&iacute; dụ như nếu trẻ ph&agrave;n n&agrave;n l&agrave; ch&uacute;ng qu&aacute; lạnh, vậy n&ecirc;n tăng nhiệt độ một ch&uacute;t. C&ograve;n nếu trẻ n&oacute;i rằng ch&uacute;ng qu&aacute; n&oacute;ng th&igrave; h&atilde;y bật điều h&ograve;a hoặc quạt.</p>

<p><strong>6. Thường Xuy&ecirc;n Thay Đổi Nơi Nghỉ Ngơi Cho B&eacute;:</strong></p>

<p>Khi ốm bậc cha mẹ thường c&oacute; xu hướng cho b&eacute; nằm một chỗ đ&oacute; l&agrave; một việc l&agrave;m sai lầm điều n&agrave;y sẽ khiến b&eacute; trở n&ecirc;n mệt mỏi hơn. Thay v&agrave;o đ&oacute; bạn c&oacute; thể thay đổi nơi nghỉ cho b&eacute; bằng c&aacute;ch cho b&eacute; ra ngo&agrave;i ph&ograve;ng kh&aacute;ch hay cho b&eacute; tựa người tr&ecirc;n ghế mềm. Tr&aacute;nh cho b&eacute; nằm qu&aacute; l&acirc;u sẽ khiến b&eacute; c&oacute; cảm gi&aacute;c mệt mỏi.</p>

<p><strong>7. Cho Con Uống Nhiều Nước</strong></p>

<p><strong><img alt="" src="http://localhost:44351/Content/FileUploads/images/cc85d64a4f0ba655ff1a.jpg" /></strong></p>

<p>Khi trẻ ốm cần cho trẻ uống nhiều nước, nhất l&agrave; đối với trẻ bị ti&ecirc;u chảy. Ngo&agrave;i ra, s&uacute;p, nước ch&aacute;o muối, dung dịch Oresol chỉ l&agrave; c&aacute;c dịch để b&ugrave; nước, kh&ocirc;ng n&ecirc;n coi l&agrave; thức ăn v&igrave; kh&ocirc;ng cung cấp đủ chất dinh dưỡng.</p>

<p><strong>8. Kh&ocirc;ng &Eacute;p Ăn</strong></p>

<p>Khi trẻ bị ốm sẽ hay m&egrave; nheo v&agrave; biếng ăn. Do đ&oacute;, mẹ n&ecirc;n cho b&eacute; ăn những m&oacute;n ưa th&iacute;ch. Mẹ cũng n&ecirc;n nghiền thức ăn th&agrave;nh chất lỏng để b&eacute; dễ nuốt. L&uacute;c n&agrave;y những vật dụng phục vụ ăn uống thu h&uacute;t sự quan t&acirc;m v&agrave; hiếu kỳ của trẻ n&ecirc;n được tận dụng tối đa như ống h&uacute;t lạ mắt, ch&eacute;n bột h&igrave;nh ngộ nghĩnh,&hellip;.</p>

<p><strong>9. Chia Nhỏ Bữa Ăn</strong></p>

<p>với người lớn ch&uacute;ng ta khi bệnh cũng kh&ocirc;ng muốn ăn do vị gi&aacute;c bị ảnh hưởng. Trẻ nhỏ cũng vậy. Do đ&oacute;, mẹ n&ecirc;n chia nhỏ c&aacute;c bữa ăn để vẫn đảm bảo nguồn dinh dưỡng cần thiết v&agrave; đầy đủ cho con mau l&agrave;nh bệnh v&agrave; lại sức.</p>

<p>Chia nhỏ khẩu phần ăn trong thời gian con ốm cũng l&agrave; một c&aacute;ch gi&uacute;p con duy tr&igrave; đủ dưỡng chất để cơ thể chống lại bệnh tật</p>

<p><strong>10. Tăng Cường Đề Kh&aacute;ng</strong></p>

<p>Nếu mẹ để &yacute; ủ ấm hay chườm khăn th&igrave; đ&oacute; cũng chỉ l&agrave; giải ph&aacute;p b&ecirc;n ngo&agrave;i. Quan trọng hơn, mẹ n&ecirc;n cho con uống nhiều nước cam, chanh,&hellip; hoặc vitamin C nhằm tăng cường sức đề kh&aacute;ng cho b&eacute;.</p>

<p>Chuẩn bị đủ c&aacute;c loại thuốc sốt, ti&ecirc;u chảy, ho,&hellip;: Đ&acirc;y kh&ocirc;ng chỉ l&agrave; điều n&ecirc;n l&agrave;m trong l&uacute;c b&eacute; bệnh m&agrave; bố mẹ n&ecirc;n thực hiện từ khi b&eacute; c&ograve;n khoẻ mạnh v&igrave; nhiều khi b&eacute; trở bệnh trong đ&ecirc;m th&igrave; bố mẹ sẽ trở tay kh&ocirc;ng kịp. Trong nh&agrave; lu&ocirc;n trang bị nhiệt kế, c&aacute;c loại thuốc sốt, ho,&hellip; th&ocirc;ng thường để khi con c&oacute; dấu hiệu ốm l&agrave; mẹ &ldquo;xử l&yacute;&rdquo; ngay</p>

<p><strong>11. Lu&ocirc;n Cặp Nhiệt Độ Cho Trẻ</strong></p>

<p><strong><img alt="" src="http://localhost:44351/Content/FileUploads/images/tre_sot_cao_co_giat.jpg" /></strong></p>

<p>&nbsp;</p>

<p>Nếu bạn kh&ocirc;ng c&oacute; nhiệt kế, kiểm tra xem c&aacute;c dấu hiệu như r&eacute;t run, mặt đỏ bừng, đổ mồ h&ocirc;i, hoặc cảm thấy rất n&oacute;ng khi chạm v&agrave;o hay kh&ocirc;ng.</p>

<p><strong>13. Hỏi Trẻ Xem Ch&uacute;ng C&oacute; Bị Đau Kh&ocirc;ng</strong></p>

<p>Nếu c&oacute; h&atilde;y hỏi trẻ đau như thế n&agrave;o v&agrave; đau ở đ&acirc;u. Bạn cũng c&oacute; thể ấn nhẹ v&agrave;o nơi m&agrave; trẻ k&ecirc;u đau để kiểm tra độ nghi&ecirc;m trọng của n&oacute;.</p>

<p>Ngo&agrave;i ra bạn cần lu&ocirc;n Theo d&otilde;i c&aacute;c dấu hiệu của bệnh nặng. H&atilde;y ch&uacute; &yacute; cẩn thận với những dấu hiệu cho thấy rằng con của bạn cần phải gặp một chuy&ecirc;n gia y tế ngay lập tức.</p>

<p><strong>NHỮNG SAI LẦM TRONG VIỆC CHĂM S&Oacute;C CON ỐM</strong></p>

<p>C&oacute; một số cha mẹ do kh&ocirc;ng c&oacute; kinh nghiệm n&ecirc;n thường xuy&ecirc;n mắc phải những sai lầm khi chăm s&oacute;c con ốm khiến bệnh t&igrave;nh của con c&agrave;ng trở n&ecirc;n nặng hơn, như:</p>

<p>+ Ẵm bế b&eacute; qu&aacute; nhiều ,đắp chăn cho b&eacute; khi sốt.</p>

<p>+ chườm đ&aacute; cho con khi thấy con sốt hoặc cho uống lu&ocirc;n một việc thuốc khi đo xong nhiệt độ cho con thấy 37.5 độ.</p>

<p>+ Chuy&ecirc;n gia nhi khoa cho rằng đ&oacute; l&agrave; c&aacute;c c&aacute;ch hạ sốt sai lầm kinh điển m&agrave; rất nhiều bậc cha mẹ mắc phải do chưa c&oacute; kiến thức về việc chăm s&oacute;c b&eacute; sốt đ&uacute;ng c&aacute;ch.</p>

<p>+ Khi b&eacute; sốt cha mẹ n&ecirc;n cho b&eacute; mặc đồ tho&aacute;ng m&aacute;t, tr&aacute;nh gi&oacute;, ăn uống đủ chất v&agrave; trẻ nhỏ n&ecirc;n cho b&uacute; mẹ nhiều hơn. Kh&ocirc;ng n&ecirc;n &eacute;p b&eacute; ăn li&ecirc;n tục cho đ&uacute;ng bữa v&igrave; v&agrave;o những ng&agrave;y ốm nhu cầu ăn của b&eacute; sẽ bị ảnh hưởng. n&ecirc;n cho b&eacute; ăn theo nhu cầu của b&eacute;.</p>

<p>+ Tuyệt đối kh&ocirc;ng được tự &yacute; cho b&eacute; uống thuốc theo cảm t&iacute;nh.</p>

<p>Đặc Biệt Khi Chăm S&oacute;c Trẻ Bị Ốm C&aacute;c mẹ phải hết sức ki&ecirc;n nhẫn v&agrave; nhớ một số lưu &yacute; khi chăm s&oacute;c b&eacute; bị bệnh đ&uacute;ng c&aacute;ch tốt nhất tại nh&agrave; tr&ecirc;n đ&acirc;y để c&oacute; thể gi&uacute;p b&eacute; nhanh ch&oacute;ng vượt qua căn bệnh khỏe mạnh trở lại. Trong qu&aacute; tr&igrave;nh ph&aacute;t triển c&aacute;c b&eacute; kh&ocirc;ng thể tr&aacute;nh khỏi những lần bệnh v&igrave; vậy c&aacute;c mẹ đừng qu&aacute; lo lắng chỉ cần chăm s&oacute;c cho b&eacute; thật chu đ&aacute;o.</p>
', 0, NULL, NULL, NULL, CAST(N'2020-06-16 12:01:00.737' AS DateTime), NULL, CAST(N'2020-06-16 12:04:03.803' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[News] OFF
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([ID], [Name], [BirthDay], [Address], [Phone], [Email], [Account], [Password], [DateCreate]) VALUES (18, N'Lê Tùng', N'02/02/1992', N'456 DT742, Phú Chánh, Thủ Dầu Một, Bình Dương', N'0789789789', N'tungle789@gmail.com', N'tungle789', N'123456', CAST(N'2020-06-16 15:14:10.423' AS DateTime))
SET IDENTITY_INSERT [dbo].[Patients] OFF
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([ID], [Title], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (1, N'CEO', N'Giám đốc điều hành', CAST(N'2020-06-14 17:25:31.620' AS DateTime), N'admin', CAST(N'2020-06-14 17:25:31.620' AS DateTime), N'admin', 1)
INSERT [dbo].[Positions] ([ID], [Title], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (2, N'Trường phòng', N'Trường phòng', CAST(N'2020-06-14 17:25:40.007' AS DateTime), N'admin', CAST(N'2020-06-14 17:25:40.007' AS DateTime), N'admin', 1)
INSERT [dbo].[Positions] ([ID], [Title], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (3, N'Phó phòng', N'Phó phòng', CAST(N'2020-06-14 17:25:46.590' AS DateTime), N'admin', CAST(N'2020-06-14 17:25:46.590' AS DateTime), N'admin', 1)
INSERT [dbo].[Positions] ([ID], [Title], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (4, N'Nhân viên', N'Nhân viên', CAST(N'2020-06-14 17:25:51.853' AS DateTime), N'admin', CAST(N'2020-06-14 17:25:51.853' AS DateTime), N'admin', 1)
SET IDENTITY_INSERT [dbo].[Positions] OFF
SET IDENTITY_INSERT [dbo].[Promotions] ON 

INSERT [dbo].[Promotions] ([ID], [Code], [Title], [Avatar], [Desc], [Content], [StartDate], [EndDate], [DoctorApply], [AmountReduced], [PercentReduced], [Type], [Status]) VALUES (1, N'140620-aeht', N'Giảm ngay 5% khi đặt lịch khám trong tháng 7', N'http://localhost:44351/Content/FileUploads/images/1.jpg', N'Giảm ngay 5% khi đặt lịch khám trong tháng 7', N'<p>đang cập nhật</p>
', CAST(N'2020-07-01 00:00:00.000' AS DateTime), CAST(N'2020-07-31 00:00:00.000' AS DateTime), NULL, 0, 5, 2, 1)
INSERT [dbo].[Promotions] ([ID], [Code], [Title], [Avatar], [Desc], [Content], [StartDate], [EndDate], [DoctorApply], [AmountReduced], [PercentReduced], [Type], [Status]) VALUES (3, N'160620-1sgh', N'Giảm ngay 10% cho khách đặt lịch hẹn trước 15-07', N'http://localhost:44351/Content/FileUploads/images/2018020507.jpg', N'Giảm ngay 10% cho khách đặt lịch hẹn trước 15-07', N'<p>Giảm ngay 10% cho kh&aacute;ch đặt lịch hẹn trước 15-07</p>
', CAST(N'2020-06-16 00:00:00.000' AS DateTime), CAST(N'2020-07-15 00:00:00.000' AS DateTime), NULL, 0, 10, 2, 1)
SET IDENTITY_INSERT [dbo].[Promotions] OFF
SET IDENTITY_INSERT [dbo].[ShiftTimes] ON 

INSERT [dbo].[ShiftTimes] ([ID], [StartTime], [EndTime], [Name]) VALUES (1, N'7:00', N'11:00', N'Ca Sáng')
INSERT [dbo].[ShiftTimes] ([ID], [StartTime], [EndTime], [Name]) VALUES (2, N'13:00', N'16:00', N'Ca Chiều')
SET IDENTITY_INSERT [dbo].[ShiftTimes] OFF
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([ID], [Name], [Address], [BirthDay], [Phone], [Gender], [Mail], [Account], [Password], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (1, N'Quản trị viên', N'Main', NULL, N'Main', 1, N'Main', N'admin', N'admin', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Staffs] ([ID], [Name], [Address], [BirthDay], [Phone], [Gender], [Mail], [Account], [Password], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (2, N'Nguyễn Lê Thái Ngân', N'245 Lê Đức Thọ, Gò Vấp, HCM, Việt Nam', CAST(N'1994-04-04 00:00:00.000' AS DateTime), N'0123456789', 0, N'demo@gmail.com', N'thaingan9x', N'123456', CAST(N'2020-06-14 16:50:15.657' AS DateTime), N'admin', CAST(N'2020-06-14 17:04:33.560' AS DateTime), N'admin', 1)
SET IDENTITY_INSERT [dbo].[Staffs] OFF
USE [master]
GO
ALTER DATABASE [HospitalAppoimentDB] SET  READ_WRITE 
GO
