USE [url]
GO

/****** Object:  Table [dbo].[features_dataset_naive]    Script Date: 18-04-2018 09:37:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[features_dataset_naive](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ip_contains] [int] NULL,
	[length_of_URL] [int] NULL,
	[suspicious_char] [int] NULL,
	[prefix_suffix] [int] NULL,
	[dots] [int] NULL,
	[sub_domain] [int] NULL,
	[slash] [int] NULL,
	[http_has] [int] NULL,
	[phis_term] [int] NULL,
	[results] [int] NULL,
 CONSTRAINT [PK_features_dataset_naive] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

