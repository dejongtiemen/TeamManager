
CREATE TABLE Competitie(
	Naam varchar(50) NOT NULL PRIMARY KEY,
	Team1 varchar(50) FOREIGN KEY REFERENCES Team(Naam),

	);