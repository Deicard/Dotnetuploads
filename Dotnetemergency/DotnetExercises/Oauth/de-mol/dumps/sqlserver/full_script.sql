/****** Object:  Table [dbo].[players]    Script Date: 19/04/2020 12:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[players](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[age] [int] NOT NULL,
	[gender] [nvarchar](1) NOT NULL,
	[profession] [nvarchar](250) NOT NULL,
	[photo] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_players] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[votes]    Script Date: 19/04/2020 12:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[votes](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[player_id] [bigint] NOT NULL,
	[user_id] [text] NOT NULL,
	[episode] [int] NOT NULL,
 CONSTRAINT [PK_votes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[players] ON 
GO
INSERT [dbo].[players] ([id], [name], [age], [gender], [profession], [photo]) VALUES (1, N'salim', 28, N'm', N'shopmanager bioscoop', N'salim.jpg')
GO
INSERT [dbo].[players] ([id], [name], [age], [gender], [profession], [photo]) VALUES (2, N'els', 51, N'v', N'lerares', N'els.jpg')
GO
INSERT [dbo].[players] ([id], [name], [age], [gender], [profession], [photo]) VALUES (3, N'bart', 43, N'm', N'advocaat', N'bart.jpg')
GO
INSERT [dbo].[players] ([id], [name], [age], [gender], [profession], [photo]) VALUES (4, N'laure', 46, N'v', N'management assistant', N'laure.jpg')
GO
INSERT [dbo].[players] ([id], [name], [age], [gender], [profession], [photo]) VALUES (5, N'dorien', 27, N'v', N'sauna uitbaatster', N'dorien.jpg')
GO
INSERT [dbo].[players] ([id], [name], [age], [gender], [profession], [photo]) VALUES (6, N'alina', 20, N'v', N'studente logopedie', N'alina.jpg')
GO
INSERT [dbo].[players] ([id], [name], [age], [gender], [profession], [photo]) VALUES (7, N'jolien', 26, N'v', N'bankbediende', N'jolien.jpg')
GO
INSERT [dbo].[players] ([id], [name], [age], [gender], [profession], [photo]) VALUES (8, N'christian', 26, N'm', N'consultant', N'christian.jpg')
GO
INSERT [dbo].[players] ([id], [name], [age], [gender], [profession], [photo]) VALUES (9, N'gilles', 29, N'm', N'horeca uitbater', N'gilles.jpg')
GO
INSERT [dbo].[players] ([id], [name], [age], [gender], [profession], [photo]) VALUES (10, N'bruno', 50, N'm', N'technisch directeur', N'bruno.jpg')
GO
SET IDENTITY_INSERT [dbo].[players] OFF
GO
/****** Object:  Index [IX_votes]    Script Date: 19/04/2020 12:26:18 ******/
ALTER TABLE [dbo].[votes] ADD  CONSTRAINT [IX_votes] UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
