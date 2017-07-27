
CREATE TABLE Ruta
(
    IdRuta int IDENTITY(1,1) PRIMARY KEY,
	CantidadDePuntos int NOT NULL
);

CREATE TABLE TipoVehiculo (
    IdTipoVehiculo int IDENTITY(1,1) PRIMARY KEY,
    Etiqueta varchar(MAX) NOT NULL,
    IdRuta int NOT NULL FOREIGN KEY REFERENCES Ruta(IdRuta)
);

CREATE TABLE Vehiculo (
    IdVehiculo int IDENTITY(1,1) PRIMARY KEY,
    Placa varchar(MAX) NOT NULL,
    IdTipoVehiculo int NOT NULL FOREIGN KEY REFERENCES TipoVehiculo(IdTipoVehiculo)
);

CREATE TABLE Ubicacion
(
    IdUbicacion int IDENTITY(1,1) PRIMARY KEY,
	Longitud float NOT NULL,
	Latitud float NOT NULL,
	Referencia varchar(MAX)
);
CREATE TABLE PuntoControl (
    IdPuntoControl int IDENTITY(1,1) PRIMARY KEY,
	DescripcionDispositivo varchar(MAX),	
    IdUbicacion int NOT NULL FOREIGN KEY REFERENCES Ubicacion(IdUbicacion)
);
CREATE TABLE RegistroPunto
(
  IdVehiculo INT NOT NULL,
  IdPunto INT NOT NULL,
  DateTime int NOT NULL,
  CONSTRAINT PK_RegistroPunto PRIMARY KEY NONCLUSTERED (IdVehiculo, IdPunto)
);
CREATE TABLE RutaPunto
(
  IdRuta INT NOT NULL,
  IdPunto INT NOT NULL,
  Numero int NOT NULL,
  CONSTRAINT PK_RutaPunto PRIMARY KEY NONCLUSTERED (IdRuta, IdPunto)
);
