INSERT INTO mde_moduledefinitions (sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) VALUES (1,'Template006','','Desktop/Modules/Template006/Template006.ascx','','2005-01-01','autoscript','2005-01-01','autoscript',0,0);

INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template006','template006_edit','Edit',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template006','template006_edit','Editera',0,0);

CREATE TABLE tem_template006
(tem_id INT NOT NULL AUTO_INCREMENT, 
sit_id INT NOT NULL,
pag_id INT NOT NULL,  
mod_id INT NOT NULL, 
tem_name VARCHAR(100) NOT NULL, 
tem_header1 LONGTEXT NOT NULL, 
tem_text1 LONGTEXT NOT NULL, 
tem_createddate DATETIME NULL, 
tem_createdby VARCHAR(255) NULL, 
tem_updateddate DATETIME NULL, 
tem_updatedby VARCHAR(255) NULL, 
tem_hidden INT(1) NOT NULL, 
tem_deleted INT(1) NOT NULL, 
tem_ts TIMESTAMP NULL, 
PRIMARY KEY(tem_id));