USE [NvtLesson11Dbs]
GO
/****** Object:  Table [dbo].[NvtTaiKhoan]    Script Date: 7/1/2024 3:20:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NvtTaiKhoan](
	[NvtId] [int] NOT NULL,
	[NvtUserName] [nvarchar](50) NULL,
	[NvtPassword] [nvarchar](50) NULL,
	[NvtFullName] [nvarchar](50) NULL,
	[NvtAge] [int] NULL,
	[NvtEmail] [nvarchar](50) NULL,
	[NvtPhone] [nvarchar](50) NULL,
	[NvtStatus] [bit] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[NvtTaiKhoan] ([NvtId], [NvtUserName], [NvtPassword], [NvtFullName], [NvtAge], [NvtEmail], [NvtPhone], [NvtStatus]) VALUES (1, N'NguyenVanThao', N'123456a@', N'Nguyễn Văn Thạo', 20, N'vanthao1705@gmail.com', N'0382658414', 1)
GO
