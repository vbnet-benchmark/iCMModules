INSERT INTO mde_moduledefinitions (sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) VALUES (1,'BB','','Desktop/Modules/BB/BB.ascx','','2004-09-15','autoscript','2005-01-01','autoscript',0,0);

INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BB','BB_edit','Edit',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BB','BB_edit','Editera',0,0);

CREATE TABLE bab_baby
(bab_id INT NOT NULL AUTO_INCREMENT, 
sit_id INT NOT NULL,
pag_id INT NOT NULL,  
mod_id INT NOT NULL, 
bab_name VARCHAR(100) NOT NULL, 
bab_header1 LONGTEXT NOT NULL, 
bab_text1 LONGTEXT NOT NULL, 
bab_week INT NOT NULL, 
bab_createddate DATETIME NULL, 
bab_createdby VARCHAR(255) NULL, 
bab_updateddate DATETIME NULL, 
bab_updatedby VARCHAR(255) NULL, 
bab_hidden INT(1) NOT NULL, 
bab_deleted INT(1) NOT NULL, 
bab_ts TIMESTAMP NULL, 
PRIMARY KEY(bab_id));