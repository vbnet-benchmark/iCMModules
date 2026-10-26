use iCMServer
GO

INSERT INTO mde_moduledefinitions (sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) 
VALUES (1,'TaskList','','Desktop/Modules/TaskList/TaskList.ascx','',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tas_tasklist]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tas_tasklist]
GO

CREATE TABLE [dbo].[tas_tasklist] (
	[tas_id] [int] IDENTITY (1, 1) NOT NULL ,
	[sit_id] [int] NOT NULL ,
	[mod_id] [int] NOT NULL ,
	[pag_id] [int] NOT NULL ,	
	[tas_title] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tas_description] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tas_assignedto] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
    [tas_status] [nvarchar] (20) NULL ,
    [tas_priority] [nvarchar] (20) NULL ,
    [tas_percentcomplete] [int] NULL ,
    [tas_startdate] [datetime] NULL ,
    [tas_duedate] [datetime] NULL ,
	[tas_createddate] [datetime] NULL ,
	[tas_createdby] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tas_updateddate] [datetime] NULL ,
	[tas_updatedby] [ntext] COLLATE Finnish_Swedish_CI_AS NULL ,
	[tas_hidden] [bit] NOT NULL ,
	[tas_deleted] [bit] NOT NULL ,
	[tas_ts] [timestamp] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tas_tasklist] WITH NOCHECK ADD 
	CONSTRAINT [PK_tas_tasklist] PRIMARY KEY  CLUSTERED 
	(
		[tas_id]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tas_tasklist] ADD 
	CONSTRAINT [DF_tas_tasklist_tas_hidden] DEFAULT (0) FOR [tas_hidden],
	CONSTRAINT [DF_tas_tasklist_tas_deleted] DEFAULT (0) FOR [tas_deleted]
GO

INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Tasklist','tasklist_new','Create new error report',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Tasklist','tasklist_new','Skapa ny felanmälan',0,0)
GO
