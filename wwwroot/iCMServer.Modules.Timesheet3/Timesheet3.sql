if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tim_timesheet3]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
	drop table [dbo].[tim_timesheet3]
GO

CREATE TABLE [dbo].[tim_timesheet3] (
	[tim_id] [int] IDENTITY (1, 1) NOT NULL ,
	[sit_id] [int] NOT NULL ,
	[pag_id] [int] NULL ,
	[mod_id] [int] NULL ,
	[tim_subject] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[tim_text] [nvarchar] (2000) COLLATE Finnish_Swedish_CI_AS NULL ,
	[tim_starttime] [datetime] NULL ,
	[tim_endtime] [datetime] NULL ,
	[tim_allday] [int] NOT NULL ,
	[tim_reminder] [bit] NOT NULL ,
	[tim_reminderlimit] [datetime] NULL ,
	[tim_attendees] [nvarchar] (1000) COLLATE Finnish_Swedish_CI_AS NULL ,
	[tim_label] [nvarchar] (10) COLLATE Finnish_Swedish_CI_AS NULL ,
	[tim_createddate] [datetime] NULL ,
	[tim_createdby] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[tim_updateddate] [datetime] NULL ,
	[tim_updatedby] [nvarchar] (255) COLLATE Finnish_Swedish_CI_AS NULL ,
	[tim_hidden] [bit] NOT NULL ,
	[tim_deleted] [bit] NOT NULL ,
	[tim_ts] [timestamp] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tim_timesheet3] WITH NOCHECK ADD 
	CONSTRAINT [PK_tim_timesheet3] PRIMARY KEY  CLUSTERED 
	(
		[tim_id]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tim_timesheet3] ADD 
	CONSTRAINT [DF_tim_timesheet3_tim_allday] DEFAULT (0) FOR [tim_allday],
	CONSTRAINT [DF_tim_timesheet3_tim_reminder] DEFAULT (0) FOR [tim_reminder],
	CONSTRAINT [DF_tim_timesheet3_tim_hidden] DEFAULT (0) FOR [tim_hidden],
	CONSTRAINT [DF_tim_timesheet3_tim_deleted] DEFAULT (0) FOR [tim_deleted]
GO

INSERT INTO mde_moduledefinitions (sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) 
VALUES (1,'Timesheet3','','Desktop/Modules/Timesheet3/Timesheet3.ascx','',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
GO

INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_new','New',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_new','Nytt',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_newapp','New Appointment',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_newapp','Nytt Inlägg',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_newedit','Edit Appointment',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_newedit','Editera Inlägg',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_subject','Subject: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_subject','Rubrik: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_start','Start: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_start','Start: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_end','End: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_end','Slut: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_text','Text: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_text','Text: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_date','Date: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_date','Datum: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_lang','english',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_lang','swedish',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_update','Update',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_update','Uppdatera',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_cancel','Cancel',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_cancel','Ångra',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_delete','Delete',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_delete','Radera',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_errordate','Not a valid date!',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_errordate','Ej giltligt datum!',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_confirmdelete','Do you want to delete this appointment?',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_confirmdelete','Vill du radera detta inlägg?',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_datefrom','DateFrom: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_datefrom','DatumFrån: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_dateto','DateTo: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_dateto','DatumTill: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_confirmadd','This appointment span over 12 months, do you want to continue?',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_confirmadd','Detta inlägg sträcker sej över 12 månader, vill du fortsätta?',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label','Label: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label','Etikett: ',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_none','None',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_none','Ingen',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_important','Important',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_important','Viktigt',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_business','Business',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_business','Affärer',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_personal','Personal',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_personal','Personligt',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_vacation','Vacation',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_vacation','Semester',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_mustattend','Must Attend',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_mustattend','Närvaroplikt',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_travelrequired','Travel Required',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_travelrequired','Resor',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_needspreperation','Needs Preperation',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_needspreperation','Behöver Förberedelse',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_birthday','Birthday',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_birthday','Födelsedag',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_anniversary','Anniversary',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_anniversary','Jubileum',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_phonecall','Phone Call',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_label_phonecall','Telefon Samtal',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_simpleviewstate','Office view',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_simpleviewstate','Kontors vy',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_edit','Edit',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_edit','Editera',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_users','Users:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_users','Användare:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_header','Users:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_header','Användare:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_users','Users:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_users','Användare:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_addedusers','Members:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_addedusers','Medlemmar:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_delete','Delete',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_delete','Radera',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_add','Add',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_add','Lägg till',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_ok','Ok',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_ok','Ok',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_cancel','Cancel',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Timesheet3','timesheet3_cancel','Ångra',0,0)
