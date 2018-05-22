USE dbConnect
GO

/* Módulo de errores */

/* Log de errores */
CREATE TABLE LogError
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	module VARCHAR(150) NOT NULL,
	method VARCHAR(200) NOT NULL,
	errorMessage VARCHAR(MAX) NOT NULL,
	moreInfo VARCHAR(MAX),
	dateError DATETIME NOT NULL,
)
GO



