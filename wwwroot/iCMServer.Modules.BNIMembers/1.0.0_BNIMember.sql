
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bme_bnimembers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
	drop table [dbo].[bme_bnimembers]
GO

CREATE TABLE [dbo].[bme_bnimembers] (
	[bme_id] [int] IDENTITY (1, 1) NOT NULL ,
	[sit_id] [int] NOT NULL ,
	[pag_id] [int] NULL ,
	[mod_id] [int] NULL ,
	[bme_name] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[bme_phone] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[bme_mail] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[bme_web] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[bme_text] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[bme_hook] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[bme_logocontent] [image] NULL ,
	[bme_logocontenttype] [nvarchar] (200) COLLATE Finnish_Swedish_CI_AS NULL ,
	[bme_logocontentsize] [bigint] NULL ,
	[bme_mecontent] [image] NULL ,
	[bme_mecontenttype] [nvarchar] (200) COLLATE Finnish_Swedish_CI_AS NULL ,
	[bme_mecontentsize] [bigint] NULL ,
	[bme_createddate] [datetime] NULL ,
	[bme_createdby] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[bme_updateddate] [datetime] NULL ,
	[bme_updatedby] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[bme_hidden] [bit] NOT NULL ,
	[bme_deleted] [bit] NOT NULL ,
	[bme_ts] [timestamp] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[bme_bnimembers] WITH NOCHECK ADD 
	CONSTRAINT [PK_bme_bnimembers] PRIMARY KEY  CLUSTERED 
	(
		[bme_id]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[bme_bnimembers] ADD 
	CONSTRAINT [DF_bme_bnimembers_bme_hidden] DEFAULT (0) FOR [bme_hidden],
	CONSTRAINT [DF_bme_bnimembers_bme_deleted] DEFAULT (0) FOR [bme_deleted]
GO

INSERT INTO mde_moduledefinitions (sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) VALUES (1,'BNIMembers','','Desktop/Modules/BNIMembers/BNIMembers.ascx','',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
GO

INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_logo','New logo',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_logo','Ny logga',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_hook','Seek',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_hook','S&ouml;ker',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_me','New picture',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_me','Ny bild',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_name','Name:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_name','Namn:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_phone','Phone:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_phone','Telefon:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_mail','Mail:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_mail','Epost:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_web','Web:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_web','Web:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_save','Save',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_save','Spara',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_metitle','Upload new picture',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_metitle','Ladda upp ny bild',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_mesave','Save',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_mesave','Spara',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_mecancel','Cancel',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_mecancel','&Aring;ngra',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_medelete','Delete',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_medelete','Radera',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_logotitle','Upload new logo',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_logotitle','Ladda upp ny logga',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_logosave','Save',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_logosave','Spara',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_logocancel','Cancel',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_logocancel','&Aring;ngra',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_logodelete','Delete',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_logodelete','Radera',0,0)


GO