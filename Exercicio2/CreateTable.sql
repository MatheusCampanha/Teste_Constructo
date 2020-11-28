CREATE TABLE Condominio(
	Id int not null primary key,
	Nome nvarchar(100) not null,
	Bairro nvarchar(100) not null
)

CREATE TABLE Familia(
	Id int not null primary key,
	Nome nvarchar(100) not null,
	Id_Condominio int FOREIGN KEY REFERENCES Condominio(Id),
	Apto nvarchar(50) not null
)

CREATE TABLE Morador(
	Id int not null primary key,
	Id_Familia int FOREIGN KEY REFERENCES Familia(Id),
	Nome nvarchar(100) not null,
	QuantidadeBichosEstimacao int not null
)