USE [ISApteka]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 02.06.2022 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[StockID] [int] NOT NULL,
	[CountBill] [int] NOT NULL,
	[DoctorID] [int] NOT NULL,
	[ClientName] [nvarchar](max) NOT NULL,
	[ShortClientName] [nvarchar](80) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 02.06.2022 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[DoctorID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorName] [nvarchar](60) NOT NULL,
	[DoctorSecondName] [nvarchar](60) NOT NULL,
	[DoctorSurname] [nvarchar](60) NULL,
	[DoctorDegreeID] [int] NOT NULL,
	[DoctorImg] [nvarchar](max) NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorDegree]    Script Date: 02.06.2022 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorDegree](
	[DoctorDegreeID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorDegreeName] [nvarchar](90) NOT NULL,
 CONSTRAINT [PK_DoctorDegree] PRIMARY KEY CLUSTERED 
(
	[DoctorDegreeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DrugType]    Script Date: 02.06.2022 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrugType](
	[DrugTypeID] [int] IDENTITY(1,1) NOT NULL,
	[DrugTypeName] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_DrugType] PRIMARY KEY CLUSTERED 
(
	[DrugTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 02.06.2022 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[CountInStock] [int] NOT NULL,
	[DrugName] [nvarchar](50) NOT NULL,
	[DrugTypeID] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[StockShelf] [int] NOT NULL,
	[DrugImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 02.06.2022 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](50) NOT NULL,
	[SupplierAddress] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02.06.2022 22:46:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserLogin] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserSecondName] [nvarchar](50) NOT NULL,
	[UserSurname] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([BillID], [StockID], [CountBill], [DoctorID], [ClientName], [ShortClientName], [Description], [Price]) VALUES (1, 1, 1, 1, N'Тест Тест', N'Тест', N'Это тестовая квитанция', CAST(1500.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctor] ON 

INSERT [dbo].[Doctor] ([DoctorID], [DoctorName], [DoctorSecondName], [DoctorSurname], [DoctorDegreeID], [DoctorImg]) VALUES (1, N'Тест', N'Тест', N'Тест', 1, NULL)
SET IDENTITY_INSERT [dbo].[Doctor] OFF
GO
SET IDENTITY_INSERT [dbo].[DoctorDegree] ON 

INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (1, N'ЛОР')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (2, N'Терапевт')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (3, N'Окулист')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (4, N'Стоматолог')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (5, N'Акушер')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (6, N'Гастроэнтеролог')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (7, N'Гинеколог')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (8, N'Инфекционист')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (9, N'Кардиолог')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (10, N'Ортопед')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (11, N'Педиатр')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (12, N'Фармацевт')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (13, N'Фельдшер')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (14, N'Хирург')
INSERT [dbo].[DoctorDegree] ([DoctorDegreeID], [DoctorDegreeName]) VALUES (15, N'Эндокринолог')
SET IDENTITY_INSERT [dbo].[DoctorDegree] OFF
GO
SET IDENTITY_INSERT [dbo].[DrugType] ON 

INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (1, N'Антибатериальные препараты')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (2, N'Противоопухолевые препараты')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (3, N'Противогрибковые препараты')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (4, N'Противовирусные препараты')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (5, N'Препараты, влияющие на функцию почек')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (6, N'Препараты, влияющие на функции миокарда')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (7, N'Препараты, влияющие на функции желудочно-кишечного тракта')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (8, N'Препараты, влияющие на функцию бронхов')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (9, N'Препараты, влияющие на тонус сосудов')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (10, N'Препараты, влияющие на свертываемость крови')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (11, N'Препараты влияющие на психику')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (12, N'Препараты влияющие на метаболизм')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (13, N'Препараты, влияющие на иммунитет')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (14, N'Противовоспалительные и обезболивающие препараты')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (15, N'Противопаразитарные и противоглистные препараты')
INSERT [dbo].[DrugType] ([DrugTypeID], [DrugTypeName]) VALUES (16, N'Гормоны')
SET IDENTITY_INSERT [dbo].[DrugType] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([StockID], [SupplierID], [CountInStock], [DrugName], [DrugTypeID], [Description], [StockShelf], [DrugImage]) VALUES (1, 1, 120, N'Тест', 1, N'Тест', 3, NULL)
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (1, N'Alliance Healthcare', N'Москва')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (2, N'Главфарм', N'Москва')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (3, N'АСОКА', N'Московская область')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (4, N'Надежда+', N'Санкт-Петербург')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (5, N'Русская тройка', N'Краснодар')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (6, N'Евросервис Термоиндикатор', N'Санкт-Петербург')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (7, N'Bracco', N'Санкт-Петербург')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (8, N'Абрис+', N'Санкт-Петербург')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (9, N'Фармасинтез', N'Санкт-Петербург')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (10, N'Умка-Фамкэр', N'Санкт-Петербург')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (11, N'ТД Мультитрейд', N'Санкт-Петербург')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (12, N'ТД Гекса-Северо-Запад', N'Санкт-Петербург')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (13, N'Регион', N'Москва')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (14, N'Медком-МП', N'Москва')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [SupplierAddress]) VALUES (15, N'Мидэя', N'Москва')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserLogin], [UserName], [UserSecondName], [UserSurname]) VALUES (1, N'1', N'Тест', N'Тест', N'Тест')
INSERT [dbo].[Users] ([UserID], [UserLogin], [UserName], [UserSecondName], [UserSurname]) VALUES (2, N'9609566', N'Сотрудник', N'Разработчик', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Doctor] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctor] ([DoctorID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Doctor]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Stock] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([StockID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Stock]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_DoctorDegree] FOREIGN KEY([DoctorDegreeID])
REFERENCES [dbo].[DoctorDegree] ([DoctorDegreeID])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_DoctorDegree]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_DrugType] FOREIGN KEY([DrugTypeID])
REFERENCES [dbo].[DrugType] ([DrugTypeID])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_DrugType]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([SupplierID])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Supplier]
GO
