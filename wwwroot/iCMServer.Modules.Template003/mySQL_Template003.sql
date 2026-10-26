
INSERT INTO mde_moduledefinitions (sit_id, mde_name, mde_description, mde_desktopsrc, mde_mobilesrc, mde_createddate, mde_createdby, mde_updateddate, mde_updatedby, mde_hidden, mde_deleted) VALUES (1,'Template003','','Desktop/Modules/Template003/Template003.ascx','','2005-01-01','autoscript','2005-01-01','autoscript',0,0);


INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_edit','Edit',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_edit','Editera',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field1','Field 1',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field1','F&auml;lt 1',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field2','Field 2',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field2','F&auml;lt 2',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field3','Field 3',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field3','F&auml;lt 3',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field4','Field 4',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field4','F&auml;lt 4',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field5','Field 5',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field5','F&auml;lt 5',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field6','Field 6',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field6','F&auml;lt 6',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field7','Field 7',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field7','F&auml;lt 7',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field8','Field 8',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field8','F&auml;lt 8',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_field9','Field 9',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_field9','F&auml;lt 9',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_header','Edit Tooltip',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_header','Administrera Tooltip',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.Template003','template003_save','Save',0,0);
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.Template003','template003_save','Spara',0,0);

CREATE TABLE tem_template003(
	tem_id INT NOT NULL AUTO_INCREMENT,  
	sit_id INT NOT NULL, 
	pag_id INT NOT NULL, 
	mod_id INT NOT NULL, 
	tem_name VARCHAR(100) NULL, 
	tem_tooltip1 LONGTEXT NULL,
	tem_tooltip2 LONGTEXT NULL,
	tem_tooltip3 LONGTEXT NULL,
	tem_tooltip4 LONGTEXT NULL,
	tem_tooltip5 LONGTEXT NULL,
	tem_tooltip6 LONGTEXT NULL,
	tem_tooltip7 LONGTEXT NULL,
	tem_tooltip8 LONGTEXT NULL,
	tem_tooltip9 LONGTEXT NULL,
	tem_createddate DATETIME NULL, 
	tem_createdby VARCHAR(255) NULL, 
	tem_updateddate DATETIME NULL, 
	tem_updatedby VARCHAR(255) NULL, 
	tem_hidden INT(1) NOT NULL, 
	tem_deleted INT(1) NOT NULL, 
	tem_ts TIMESTAMP NULL, 
PRIMARY KEY(tem_id)
);