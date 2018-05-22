USE dbConnect
GO

/* Módulo de administración */

/* Roles */
CREATE TABLE AdmRole
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(20) NOT NULL,
	detail VARCHAR(255),
	stateRecord BIT DEFAULT(1) NOT NULL,
	userRegister VARCHAR(100) NOT NULL,
	dateRegister DATETIME NOT NULL,
	userUpdate VARCHAR(100) NOT NULL,
	dateUpdate DATETIME NOT NULL
)
GO

/* Opciones */
CREATE TABLE AdmApplication
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	detail VARCHAR(100) NOT NULL,
	href VARCHAR(500) NOT NULL,
	icon VARCHAR(150),
	stateRecord BIT DEFAULT(1) NOT NULL,
	userRegister VARCHAR(100) NOT NULL,
	dateRegister DATETIME NOT NULL,
	userUpdate VARCHAR(100) NOT NULL,
	dateUpdate DATETIME NOT NULL
)
GO

/* Opciones por Rol */
CREATE TABLE AdmRoleApplication
(
	idRole INT FOREIGN KEY REFERENCES AdmRole(id) NOT NULL,
	idApplication INT FOREIGN KEY REFERENCES AdmApplication(id) NOT NULL,
	stateRecord BIT DEFAULT(1) NOT NULL,
	userRegister VARCHAR(100) NOT NULL,
	dateRegister DATETIME NOT NULL,
	userUpdate VARCHAR(100) NOT NULL,
	dateUpdate DATETIME NOT NULL
)
GO

/* Usuarios de aplicación */
CREATE TABLE AdmUser
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	idPerson INT REFERENCES Person(id) NOT NULL,
	loginName VARCHAR(100) NOT NULL,
	personalKey VARCHAR(255) NOT NULL,
	attemps INT NOT NULL,
	name VARCHAR(255),
	idRole INT FOREIGN KEY REFERENCES AdmRole(id) NOT NULL,
	stateRecord BIT DEFAULT(1) NOT NULL,
	userRegister VARCHAR(100) NOT NULL,
	dateRegister DATETIME NOT NULL,
	userUpdate VARCHAR(100) NOT NULL,
	dateUpdate DATETIME NOT NULL
)
GO

/* Usuarios para acceder a los métodos de la API */
CREATE TABLE AdmUserApi
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	loginName VARCHAR(100) NOT NULL,
	name VARCHAR(100) NOT NULL,
	personalKey VARCHAR(255) NOT NULL,
	stateRecord BIT DEFAULT(1) NOT NULL,
	userRegister VARCHAR(100) NOT NULL,
	dateRegister DATETIME NOT NULL,
	userUpdate VARCHAR(100) NOT NULL,
	dateUpdate DATETIME NOT NULL
)
GO

/* Catálogo */
CREATE TABLE AdmClsMaster
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	catalogId VARCHAR(30) NOT NULL,
	value VARCHAR(20) NOT NULL,
	subValue VARCHAR(20),
	detail VARCHAR(155) NOT NULL,
	child BIT DEFAULT(1) NOT NULL,
	stateRecord BIT DEFAULT(1) NOT NULL,
	userRegister VARCHAR(100) NOT NULL,
	dateRegister DATETIME NOT NULL,
	userUpdate VARCHAR(100) NOT NULL,
	dateUpdate DATETIME NOT NULL
)
GO

CREATE TABLE AdmGlobalParam
(
	id VARCHAR(20) PRIMARY KEY,
	value VARCHAR(200) NOT NULL,
	detail VARCHAR(255) NOT NULL,
	stateRecord BIT DEFAULT(1) NOT NULL,
	userRegister VARCHAR(100) NOT NULL,
	dateRegister DATETIME NOT NULL,
	userUpdate VARCHAR(100) NOT NULL,
	dateUpdate DATETIME NOT NULL
)
GO

INSERT INTO AdmGlobalParam
(
	id,
	value,
	detail,
	stateRecord,
	userRegister,
	dateRegister,
	userUpdate,
	dateUpdate
)
VALUES(
	'MAXINTENTOS',
	'10',
	'Número máximo de intentos antes de bloquear usuario de aplicación',
	1,
	'rmiranda',
	GETDATE(),
	'rmiranda',
	GETDATE()
)

