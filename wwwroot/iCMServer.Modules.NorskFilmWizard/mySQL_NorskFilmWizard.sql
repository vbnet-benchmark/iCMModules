INSERT INTO mde_moduledefinitions (sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) VALUES (1,'NorskFilmWizard','','Desktop/Modules/NorskFilmWizard/NorskFilmWizard.ascx','','2004-09-15','autoscript','2005-01-01','autoscript',0,0);

INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.NorskFilmWizard','NorskFilmWizard_edit','Edit',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.NorskFilmWizard','NorskFilmWizard_edit','Editera',0,0);

CREATE TABLE nor_norskfilmwizard
(nor_id INT NOT NULL AUTO_INCREMENT, 
sit_id INT NOT NULL,
pag_id INT NOT NULL,  
mod_id INT NOT NULL, 
nor_name VARCHAR(100) NOT NULL, 
nor_createddate DATETIME NULL, 
nor_createdby VARCHAR(255) NULL, 
nor_updateddate DATETIME NULL, 
nor_updatedby VARCHAR(255) NULL, 
nor_hidden INT(1) NOT NULL, 
nor_deleted INT(1) NOT NULL, 
nor_ts TIMESTAMP NULL, 
PRIMARY KEY(nor_id));