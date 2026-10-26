use iCMServer
GO

INSERT INTO mde_moduledefinitions (sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) 
VALUES (1,'ProjectList','','Desktop/Modules/ProjectList/ProjectList.ascx','',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
GO

--INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_search','Search',0,0)
--INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_search','S&ouml;k',0,0)
--INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_header1','Found',0,0)
--INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_header1','Hittade',0,0)
--INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_header2','',0,0)
--INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_header2','stycken',0,0)
--INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_header3','on the following pages',0,0)
--INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_header3','p&aring; f&ouml;ljande sidor',0,0)
--INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_modules','Module',0,0)
--INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_modules','Modul',0,0)
--INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_resultcount','Hits',0,0)
--INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_resultcount','Antal tr&auml;ffar',0,0)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[prl_projectlistGAPRO]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[prl_projectlistGAPRO]
GO

CREATE TABLE [dbo].[prl_projectlistGAPRO] (
	[prl_id] [int] IDENTITY (1, 1) NOT NULL ,
	[sit_id] [int] NOT NULL ,
	[mod_id] [int] NOT NULL ,
	[pag_id] [int] NOT NULL ,	
	[prl_number][int] NULL ,
	[prl_start] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[prl_leader] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[prl_participant] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[prl_description] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[prl_aim] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[prl_month] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[prl_createddate] [datetime] NULL ,
	[prl_createdby] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[prl_updateddate] [datetime] NULL ,
	[prl_updatedby] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[prl_hidden] [bit] NOT NULL ,
	[prl_deleted] [bit] NOT NULL ,
	[prl_ts] [timestamp] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[prl_projectlistGAPRO] WITH NOCHECK ADD 
	CONSTRAINT [PK_prl_projectlistGAPRO] PRIMARY KEY  CLUSTERED 
	(
		[prl_id]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[prl_projectlistGAPRO] ADD 
	CONSTRAINT [DF_prl_projectlistGAPRO_prl_hidden] DEFAULT (0) FOR [prl_hidden],
	CONSTRAINT [DF_prl_projectlistGAPRO_prl_deleted] DEFAULT (0) FOR [prl_deleted]
GO

-- Delete all rows from prl_projectlistGAPRO and insert new data
PRINT 'Delete all rows from prl_projectlistGAPRO and insert new data'
DELETE FROM prl_projectlistGAPRO
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,01,'040329','Christer','Christer, Ingvar','Produktkalkyler','Fastställa lagervärde och självkostnad','Maj',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,02,'040329','Ingvar','Ingvar, Lasse','Buntscanning utlastning','Uppfylla kundkrav från Bauhaus samt säkerställa och underlätta utlastningsarbetet','Mars',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,03,'040329','Ingvar','Ingvar','Fakturaimport Sävsjöström','Underlätta fakturering och skapa försäljningsstatistik','April',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,04,'040329','Svante','Christer, Ingvar','Anläggningsregister i Navision','Flytta över bef register till Navision','September',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,05,'040329','Svante','Christer, Ingvar','Inventeringsrutiner','Skapa löpande inventeringsrutiner och säkerställa uppdatering av lager','April',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,06,'040329','Ingvar','Karin, Gerd','Tidredovisning via AgdaTid','Underlätta och säkerställa inrapportering för löneberäkning','Oktober',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,07,'040329','Ingvar','Cattis','Utveckla EDI för fakturering och ordermottagning','Underlätta och säkerställa','September',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,08,'040329','Ingvar','Christer','Utveckla försäljnings- och orderrapporter i Navision','','Maj',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
GO