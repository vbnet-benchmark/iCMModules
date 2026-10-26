use iCMServer
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cal_calendar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
	drop table [dbo].[cal_calendar]
GO

CREATE TABLE [dbo].[cal_calendar] (
	[cal_id] [int] IDENTITY (1, 1) NOT NULL ,
	[sit_id] [int] NOT NULL ,
	[pag_id] [int] NULL ,
	[mod_id] [int] NULL ,
	[cal_subject] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[cal_text] [nvarchar] (2000) COLLATE Finnish_Swedish_CI_AS NULL ,
	[cal_starttime] [datetime] NULL ,
	[cal_endtime] [datetime] NULL ,
	[cal_allday] [bit] NOT NULL ,
	[cal_reminder] [bit] NOT NULL ,
	[cal_reminderlimit] [datetime] NULL ,
	[cal_attendees] [nvarchar] (1000) COLLATE Finnish_Swedish_CI_AS NULL ,
	[cal_createddate] [datetime] NULL ,
	[cal_createdby] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[cal_updateddate] [datetime] NULL ,
	[cal_updatedby] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[cal_hidden] [bit] NOT NULL ,
	[cal_deleted] [bit] NOT NULL ,
	[cal_ts] [timestamp] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[cal_calendar] WITH NOCHECK ADD 
	CONSTRAINT [PK_cal_calendar] PRIMARY KEY  CLUSTERED 
	(
		[cal_id]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cal_calendar] ADD 
	CONSTRAINT [DF_cal_calendar_cal_allday] DEFAULT (0) FOR [cal_allday],
	CONSTRAINT [DF_cal_calendar_cal_reminder] DEFAULT (0) FOR [cal_reminder],
	CONSTRAINT [DF_cal_calendar_cal_hidden] DEFAULT (0) FOR [cal_hidden],
	CONSTRAINT [DF_cal_calendar_cal_deleted] DEFAULT (0) FOR [cal_deleted]
GO

INSERT INTO mde_moduledefinitions (sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) 
VALUES (1,'Calendar','','Desktop/Modules/Calendar/Calendar.ascx','',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
GO

INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_new','New',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_new','Nytt',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_newapp','New Appointment',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_newapp','Nytt Inl&auml;gg',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_newedit','Edit Appointment',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_newedit','Editera Inl&auml;gg',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_subject','Subject: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_subject','Rubrik: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_start','Start: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_start','Start: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_end','End: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_end','Slut: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_text','Text: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_text','Text: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_date','Date: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_date','Datum: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_lang','english',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_lang','swedish',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_update','Update',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_update','Uppdatera',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_cancel','Cancel',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_cancel','&Aring;ngra',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_delete','Delete',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_delete','Radera',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_errordate','Not a valid date!',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_errordate','Ej giltligt datum!',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Calendar','calendar_confirmdelete','Do you want to delete this appointment?',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Calendar','calendar_confirmdelete','Vill du radera detta inl&auml;gg?',0,0)
GO