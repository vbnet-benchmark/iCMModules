ALTER TABLE bme_bnimembers ADD 
	bme_street nvarchar (255) NULL,
	bme_pcode nvarchar (25) NULL,
	bme_city nvarchar (255) NULL
GO

UPDATE bme_bnimembers SET 
	bme_street = '',
	bme_pcode = '',
	bme_city = ''
GO


INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_street','Street:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_street','Gata:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_pcode','Postal:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_pcode','PostNr:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (1,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_city','City:',0,0)
INSERT INTO lgt_languagetext (lng_id, lgt_location, lgt_phrase, lgt_text, lgt_hidden, lgt_deleted) VALUES (2,'iConsulting.iCMServer.Modules.BNIMembers','bnimember_city','Ort:',0,0)
GO