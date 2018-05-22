USE dbConnect
GO

/* Catálogo de sexo */
INSERT INTO AdmClsMaster
(
	catalogId,
	value,
	subValue,
	detail,
	child,
	userRegister,
	dateRegister,
	userUpdate,
	dateUpdate
)
VALUES('SEXO','',NULL,'CATALOGO DE SEXO',0,'rmiranda',GETDATE(),'rmiranda',GETDATE()),
('SEXO','M',NULL,'Masculino',1,'rmiranda',GETDATE(),'rmiranda',GETDATE()),
('SEXO','F',NULL,'Femenino',1,'rmiranda',GETDATE(),'rmiranda',GETDATE())
GO

INSERT INTO AdmClsMaster
(
	catalogId,
	value,
	subValue,
	detail,
	child,
	userRegister,
	dateRegister,
	userUpdate,
	dateUpdate
)
VALUES('TIPOSDOCUMENTO','',NULL,'CATALOGO DE TIPOS DOCUMENTOS',0,'rmiranda',GETDATE(),'rmiranda',GETDATE()),
('TIPOSDOCUMENTO','D',NULL,'DUI',1,'rmiranda',GETDATE(),'rmiranda',GETDATE()),
('TIPOSDOCUMENTO','N',NULL,'NIT',1,'rmiranda',GETDATE(),'rmiranda',GETDATE()),
('TIPOSDOCUMENTO','P',NULL,'Pasaporte',1,'rmiranda',GETDATE(),'rmiranda',GETDATE())
GO

INSERT INTO AdmClsMaster
(
	catalogId,
	value,
	subValue,
	detail,
	child,
	userRegister,
	dateRegister,
	userUpdate,
	dateUpdate
)
VALUES('PROFESIONES','',NULL,'CATALOGO DE PROFESIONES U OFICIOS',0,'rmiranda',GETDATE(),'rmiranda',GETDATE()),
('PROFESIONES','01',NULL,'Ingeniero',1,'rmiranda',GETDATE(),'rmiranda',GETDATE())
GO

INSERT INTO AdmClsMaster
(
	catalogId,
	value,
	subValue,
	detail,
	child,
	userRegister,
	dateRegister,
	userUpdate,
	dateUpdate
)
VALUES('ROLES','',NULL,'ROLES DE USUARIO',0,'rmiranda',GETDATE(),'rmiranda',GETDATE()),
('ROLES','ADM',NULL,'Administrador',1,'rmiranda',GETDATE(),'rmiranda',GETDATE())
GO

SELECT * FROM AdmRole

INSERT INTO AdmRole(
	name,
	detail,
	stateRecord,
	userRegister,
	dateRegister,
	userUpdate,
	dateUpdate	
)
VALUES(
	'ADMIN',
	'ADMINISTRADOR',
	1,
	'rmiranda',
	GETDATE(),
	'rmiranda',
	GETDATE()
)
GO

SELECT * FROM AdmClsMaster
select * from AdmRole
