INSERT INTO mde_moduledefinitions (sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) VALUES (1,'Tasklist','','Desktop/Modules/Tasklist/Tasklist.ascx','','2005-01-01','autoscript','2005-01-01','autoscript',0,0);

CREATE TABLE tas_tasklist
	(tas_id INT NOT NULL AUTO_INCREMENT, 
	sit_id INT NOT NULL,
	pag_id INT NOT NULL,  
	mod_id INT NOT NULL, 
	tas_title VARCHAR(255) NULL, 
	tas_description LONGTEXT NULL, 
	tas_assignedto VARCHAR(255) NULL,
	tas_status VARCHAR(20) NULL,
	tas_priority VARCHAR(20) NULL,
	tas_percentcomplete INT NOT NULL, 
	tas_startdate DATETIME NULL, 
	tas_duedate DATETIME NULL, 
	tas_createddate DATETIME NULL, 
	tas_createdby VARCHAR(255) NULL, 
	tas_updateddate DATETIME NULL, 
	tas_updatedby VARCHAR(255) NULL, 
	tas_hidden INT(1) NOT NULL, 
	tas_deleted INT(1) NOT NULL, 
	tas_ts TIMESTAMP NULL, 
PRIMARY KEY(tas_id));

INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Tasklist','tasklist_new','Create new error report',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Tasklist','tasklist_new','Skapa ny felanmälan',0,0);

