USE dbConnect
GO

/* Persona */
CREATE TABLE Person
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	firstName VARCHAR(100) NOT NULL,
	secondName VARCHAR(100),
	firstLastName VARCHAR(100) NOT NULL,
	secondLastName VARCHAR(100),
	dateBorn DATE NOT NULL,
	typeDocument INT FOREIGN KEY REFERENCES AdmClsMaster(id) NOT NULL,
	document VARCHAR(50) NOT NULL,
	homeAddress VARCHAR(255) NOT NULL,
	homePhone VARCHAR(20),
	workPhone VARCHAR(20),
	movilPhone1 VARCHAr(20),
	movilPhone2 VARCHAr(20),
	profession INT FOREIGN KEY REFERENCES AdmClsMaster(id) NOT NULL,
	workplace VARCHAR(255),
	stateRecord BIT DEFAULT(1) NOT NULL,
	userRegister VARCHAR(100) NOT NULL,
	dateRegister DATETIME NOT NULL,
	userUpdate VARCHAR(100) NOT NULL,
	dateUpdate DATETIME NOT NULL
)
GO

CREATE TABLE PersonEntry
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	idPerson INT FOREIGN KEY REFERENCES Person(id) NOT NULL,
	dateEntry DATETIME NOT NULL,
	diagnostic VARCHAR(500),
	medicOnCharge INT FOREIGN KEY REFERENCES AdmUser(id) NOT NULL,
	paymentMethod INT FOREIGN KEY REFERENCES AdmClsMaster(id) NOT NULL,
	stateRecord BIT DEFAULT(1) NOT NULL,
	userRegister VARCHAR(100) NOT NULL,
	dateRegister DATETIME NOT NULL,
	userUpdate VARCHAR(100) NOT NULL,
	dateUpdate DATETIME NOT NULL
)
GO

CREATE TABLE PersonOutput
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	idPerson INT FOREIGN KEY REFERENCES Person(id) NOT NULL,
	dateEntry DATETIME NOT NULL,
	diagnostic VARCHAR(500),
	typeOutput INT FOREIGN KEY REFERENCES AdmClsMaster(id) NOT NULL,
	conditionOutput INT FOREIGN KEY REFERENCES AdmClsMaster(id) NOT NULL,
	stateRecord BIT DEFAULT(1) NOT NULL,
	userRegister VARCHAR(100) NOT NULL,
	dateRegister DATETIME NOT NULL,
	userUpdate VARCHAR(100) NOT NULL,
	dateUpdate DATETIME NOT NULL
)
GO

CREATE TABLE PersonEvent
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	referenceEvent INT NOT NULL,
	typeEvent INT FOREIGN KEY REFERENCES AdmClsMaster(id) NOT NULL,
	dateEvent DATETIME NOT NULL,
	stateRecord BIT DEFAULT(1) NOT NULL,
	userRegister VARCHAR(100) NOT NULL,
	dateRegister DATETIME NOT NULL,
	userUpdate VARCHAR(100) NOT NULL,
	dateUpdate DATETIME NOT NULL
)
GO

