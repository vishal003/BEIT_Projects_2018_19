USE [url]
GO

/****** Object:  Table [dbo].[naive_prob]    Script Date: 18-04-2018 09:37:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[naive_prob](
	[ip_contains] [decimal](18, 5) NULL,
	[length_of_URL] [decimal](18, 5) NULL,
	[suspicious_char] [decimal](18, 5) NULL,
	[prefix_suffix] [decimal](18, 5) NULL,
	[dots] [decimal](18, 5) NULL,
	[sub_domain] [decimal](18, 5) NULL,
	[slash] [decimal](18, 5) NULL,
	[http_has] [decimal](18, 5) NULL,
	[phis_term] [decimal](18, 5) NULL,
	[results] [decimal](18, 5) NULL
) ON [PRIMARY]

GO

