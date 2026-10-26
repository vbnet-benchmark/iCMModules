
INSERT INTO mde_moduledefinitions (mde_id, sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) VALUES (15,1,'ProjectList','','Desktop/Modules/ProjectList/ProjectList.ascx','','2003-01-01','autoscript','2003-01-01','autoscript',0,0);

INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_search','Search',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_search','S&ouml;k',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_header1','Found',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_header1','Hittade',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_header2','',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_header2','stycken',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_header3','on the following pages',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_header3','p&aring; f&ouml;ljande sidor',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_modules','Module',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_modules','Modul',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_resultcount','Hits',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.ProjectList','ProjectList_resultcount','Antal tr&auml;ffar',0,0);

DROP TABLE prl_projectlistGAPRO;
	
CREATE TABLE prl_projectlistGAPRO
(prl_id INT NOT NULL AUTO_INCREMENT, 
sit_id INT NOT NULL,
pag_id INT NOT NULL,  
mod_id INT NOT NULL, 
prl_number INT NOT NULL, 
prl_start LONGTEXT NULL, 
prl_leader LONGTEXT NULL, 
prl_participant LONGTEXT NULL, 
prl_description LONGTEXT NULL, 
prl_aim LONGTEXT NULL, 
prl_month LONGTEXT NULL,  
prl_createddate DATETIME NULL, 
prl_createdby VARCHAR(255) NULL, 
prl_updateddate DATETIME NULL, 
prl_updatedby VARCHAR(255) NULL, 
prl_hidden INT(1) NOT NULL, 
prl_deleted INT(1) NOT NULL, 
prl_ts TIMESTAMP NULL, 
PRIMARY KEY(prl_id));

/*
DELETE FROM prl_projectlistGAPRO
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,01,'040329','Christer','Christer, Ingvar','Produktkalkyler','Fastställa lagervärde och självkostnad','Maj',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,02,'040329','Ingvar','Ingvar, Lasse','Buntscanning utlastning','Uppfylla kundkrav från Bauhaus samt säkerställa och underlätta utlastningsarbetet','Mars',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,03,'040329','Ingvar','Ingvar','Fakturaimport Sävsjöström','Underlätta fakturering och skapa försäljningsstatistik','April',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,04,'040329','Svante','Christer, Ingvar','Anläggningsregister i Navision','Flytta över bef register till Navision','September',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,05,'040329','Svante','Christer, Ingvar','Inventeringsrutiner','Skapa löpande inventeringsrutiner och säkerställa uppdatering av lager','April',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,06,'040329','Ingvar','Karin, Gerd','Tidredovisning via AgdaTid','Underlätta och säkerställa inrapportering för löneberäkning','Oktober',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,07,'040329','Ingvar','Cattis','Utveckla EDI för fakturering och ordermottagning','Underlätta och säkerställa','September',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
INSERT INTO prl_projectlistGAPRO (sit_id, mod_id, pag_id, prl_number, prl_start, prl_leader, prl_participant, prl_description, prl_aim, prl_month, prl_createddate, prl_createdby, prl_updateddate, prl_updatedby, prl_hidden, prl_deleted) VALUES (1,25,16,08,'040329','Ingvar','Christer','Utveckla försäljnings- och orderrapporter i Navision','','Maj',GETDATE(),'autoscript',GETDATE(),'autoscript',0,0)
*/