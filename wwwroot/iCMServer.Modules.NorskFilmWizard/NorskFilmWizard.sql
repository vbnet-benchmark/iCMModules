
INSERT INTO mde_moduledefinitions (sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) VALUES (1,'Template006','','Desktop/Modules/Template006/Template006.ascx','','2005-01-01','autoscript','2005-01-01','autoscript',0,0)
GO

INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template006','template006_edit','Edit',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template006','template006_edit','Editera',0,0)
GO

CREATE TABLE [dbo].[tem_template006] (
	[tem_id] [int] IDENTITY (1, 1) NOT NULL ,
	[sit_id] [int] NOT NULL ,
	[pag_id] [int] NOT NULL ,
	[mod_id] [int] NOT NULL ,
	[tem_name] [nvarchar] (100) COLLATE Finnish_Swedish_CI_AS NOT NULL ,
	[tem_header1] [ntext] COLLATE Finnish_Swedish_CI_AS NOT NULL ,
	[tem_text1] [ntext] COLLATE Finnish_Swedish_CI_AS NOT NULL ,
	[tem_createddate] [datetime] NULL ,
	[tem_createdby] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_updateddate] [datetime] NULL ,
	[tem_updatedby] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_hidden] [bit] NOT NULL ,
	[tem_deleted] [bit] NOT NULL ,
	[tem_ts] [timestamp] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tem_template006] WITH NOCHECK ADD 
	CONSTRAINT [PK_tem_template006] PRIMARY KEY  CLUSTERED 
	(
		[tem_id]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tem_template006] ADD 
	CONSTRAINT [DF_tem_template006_tem_hidden] DEFAULT (0) FOR [tem_hidden],
	CONSTRAINT [DF_tem_template006_tem_deleted] DEFAULT (0) FOR [tem_deleted]
GO
