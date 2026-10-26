
INSERT INTO mde_moduledefinitions (sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) VALUES (1,'Template003','','Desktop/Modules/Template003/Template003.ascx','','2005-01-01','autoscript','2005-01-01','autoscript',0,0)
GO
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_edit','Edit',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_edit','Editera',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field1','Field 1',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field1','F&auml;lt 1',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field2','Field 2',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field2','F&auml;lt 2',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field3','Field 3',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field3','F&auml;lt 3',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field4','Field 4',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field4','F&auml;lt 4',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field5','Field 5',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field5','F&auml;lt 5',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field6','Field 6',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field6','F&auml;lt 6',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field7','Field 7',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field7','F&auml;lt 7',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field8','Field 8',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field8','F&auml;lt 8',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field9','Field 9',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field9','F&auml;lt 9',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_header','Edit Tooltip',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_header','Administrera Tooltip',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_save','Save',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_save','Spara',0,0)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tem_template003]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
	drop table [dbo].[tem_template003]
GO

CREATE TABLE [dbo].[tem_template003] (
	[tem_id] [int] IDENTITY (1, 1) NOT NULL ,
	[sit_id] [int] NOT NULL ,
	[pag_id] [int] NULL ,
	[mod_id] [int] NULL ,
	[tem_name] [nvarchar] (100) COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_tooltip1] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_tooltip2] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_tooltip3] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_tooltip4] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_tooltip5] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_tooltip6] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_tooltip7] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_tooltip8] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_tooltip9] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_createddate] [datetime] NULL ,
	[tem_createdby] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_updateddate] [datetime] NULL ,
	[tem_updatedby] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[tem_hidden] [bit] NOT NULL ,
	[tem_deleted] [bit] NOT NULL ,
	[tem_ts] [timestamp] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tem_template003] WITH NOCHECK ADD 
	CONSTRAINT [PK_tem_template003] PRIMARY KEY  CLUSTERED 
	(
		[tem_id]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tem_template003] ADD 
	CONSTRAINT [DF_tem_template003_tem_hidden] DEFAULT (0) FOR [tem_hidden],
	CONSTRAINT [DF_tem_template003_tem_deleted] DEFAULT (0) FOR [tem_deleted]
GO
