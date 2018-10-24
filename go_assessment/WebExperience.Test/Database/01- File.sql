USE[Grafik_Master]
GO

/****** Object:  Table [dbo].[Files]    Script Date: 23.10.2018 11:53:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE[dbo].[Files](
    [Id][uniqueidentifier] NOT NULL,
    [FileName][nvarchar](max) NOT NULL,
    [MimeType][nvarchar](100) NOT NULL,
    [CreatedBy][nvarchar](100) NOT NULL,
    [Email][nvarchar](100) NULL,
    [Country][nvarchar](70) NOT NULL,
    [Description][nvarchar](max) NOT NULL,
    CONSTRAINT[PK_Files] PRIMARY KEY CLUSTERED
        (
        [Id] ASC
        )WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]

GO

