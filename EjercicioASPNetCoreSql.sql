CREATE DATABASE EjercicioAspNetCore;

GO

USE EjercicioAspNetCore;

GO



CREATE TABLE Tiendas(
	
	idTienda UNIQUEIDENTIFIER PRIMARY KEY,
	sucursal varchar(40),
	codigoPostal VARCHAR(5),
	estado varchar(50),	
	idUsuario uniqueidentifier,
	delegacionMunicipio varchar(60),
	calleNum varchar(50)

);

CREATE TABLE Articulos(
	
	codigo UNIQUEIDENTIFIER PRIMARY KEY,
	descripcion varchar(max),
	precio money,
	imagen varchar(max),
	stock int,
	fechaAlta datetime,
	idUsuario uniqueidentifier

);

CREATE TABLE DetalleArticulosCompra(
    idDetalleCompra UNIQUEIDENTIFIER PRIMARY KEY,
	codigo UNIQUEIDENTIFIER ,
	idCompra UNIQUEIDENTIFIER,
	precio money,
	cantidad int,
	fechaCompra datetime

);


CREATE TABLE ArticulosTiendas(

	idArticuloTienda uniqueidentifier PRIMARY KEY,
	codigo uniqueidentifier,
	idTienda uniqueidentifier,
	fecha datetime

);

CREATE TABLE ClientesArticulosCompra(

	idCompra uniqueidentifier PRIMARY KEY,
	idUsuario uniqueidentifier,
	fecha datetime,
	total decimal

);

--Tabla muy sencilla por mótivos práscticos
CREATE TABLE Usuarios(idUsuario uniqueidentifier PRIMARY KEY, correo varchar(70), contrasenia varchar(50),
	nombre varchar(30),
	codigoPostal VARCHAR(5),
	estado varchar(50),
	delegacionMunicipio varchar(60),
	calleNum varchar(50), estaActivo bit);

CREATE TABLE UsuarioRol(idRolUsuario uniqueidentifier PRIMARY KEY,idRol uniqueidentifier, idUsuario uniqueidentifier);

CREATE TABLE Rol(IdRol UNIQUEIDENTIFIER PRIMARY KEY, nombre varchar(70), descripcion varchar(300) );

--Creación de llaves foraneas

ALTER TABLE ArticulosTiendas
ADD FOREIGN KEY (codigo) REFERENCES Articulos(codigo);

ALTER TABLE ArticulosTiendas
ADD FOREIGN KEY (idTienda) REFERENCES Tiendas(idTienda);


ALTER TABLE UsuarioRol
ADD FOREIGN KEY (idRol) REFERENCES Rol(idRol);

ALTER TABLE UsuarioRol
ADD FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario);

ALTER TABLE DetalleArticulosCompra
ADD FOREIGN KEY (idCompra) REFERENCES ClientesArticulosCompra(idCompra);

ALTER TABLE ClientesArticulosCompra
ADD FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario);

ALTER TABLE Tiendas
ADD FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario);

ALTER TABLE Articulos
ADD FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario);



------------------------------------------------------------------



DECLARE @primerRol uniqueidentifier
DECLARE @segundoRol uniqueidentifier


SET @primerRol = NEWID()
SET @segundoRol = NEWID()


INSERT INTO Rol VALUES(@primerRol,'Vendedor','');
INSERT INTO Rol VALUES(@segundoRol,'Cliente','');



