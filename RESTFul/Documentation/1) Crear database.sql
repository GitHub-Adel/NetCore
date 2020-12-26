
--SQL DOCUMENT https://www.w3schools.com/sql/sql_foreignkey.asp

--esto es para registrar las ventas que se le hace a los clientes incluyendo los productos

--las 2 sig. lineas se deben correr primero
-- USE [master]; DROP DATABASE [VentaDB];
--CREATE DATABASE [VentaDB];

USE [VentaDB];

--DROP CONSTRAINTS 'F'=FORREIGN KEY
IF OBJECT_ID('FK_VentaCliente','F') IS NOT NULL ALTER TABLE [Venta] DROP CONSTRAINT [FK_VentaCliente];
IF OBJECT_ID('FK_VentaDetalleVenta','F') IS NOT NULL ALTER TABLE [VentaDetalle] DROP CONSTRAINT [FK_VentaDetalleVenta];
IF OBJECT_ID('FK_VentaDetalleProducto','F') IS NOT NULL ALTER TABLE [VentaDetalle] DROP CONSTRAINT [FK_VentaDetalleProducto];
IF OBJECT_ID('FK_SeguridadUsuario','F') IS NOT NULL ALTER TABLE [Seguridad] DROP CONSTRAINT [FK_SeguridadUsuario];
IF OBJECT_ID('FK_SeguridadRol','F') IS NOT NULL ALTER TABLE [Seguridad] DROP CONSTRAINT [FK_SeguridadRol];

--DROP TABLE  'U'= TABLE
IF OBJECT_ID('Cliente','U') IS NOT NULL DROP TABLE [Cliente];
IF OBJECT_ID('Producto','U') IS NOT NULL DROP TABLE [Producto];
IF OBJECT_ID('Venta','U') IS NOT NULL DROP TABLE [Venta];
IF OBJECT_ID('VentaDetalle','U') IS NOT NULL DROP TABLE [VentaDetalle];
IF OBJECT_ID('Usuario','U') IS NOT NULL DROP TABLE [Usuario];
IF OBJECT_ID('Rol','U') IS NOT NULL DROP TABLE [Rol];
IF OBJECT_ID('Seguridad','U') IS NOT NULL DROP TABLE [Seguridad];

--para crear el cliente que va a realizar la compra
CREATE TABLE [Cliente]
(
	 [ClienteID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[Nombre] VARCHAR(100) NOT NULL
);

--para crear el producto que se le va a vender al cliente
CREATE TABLE [Producto]
(
	 [ProductoID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[Descripcion] VARCHAR(100) NOT NULL
	,[Precio] float not null
);

--para crear las ventas de los clientes
CREATE TABLE [Venta]
(
	 [VentaID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[ClienteID] INT NOT NULL
	,[Fecha] DATETIME NOT NULL
	,[Monto] float not null
);

--para crear el detalle de las ventas
CREATE TABLE [VentaDetalle]
(
	 [VentaDetalleID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[VentaID] INT NOT NULL
	,[ProductoID] INT NOT NULL
	,[Precio] float not null
	,[Cantidad] float not null
	,[Total] float not null
);


--para la seguridad de nuestra API

--para los usuarios que consumiran el api
CREATE TABLE [Usuario]
(
	 [UsuarioID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[Nombre] varchar(40) NOT NULL
	,[Usuario] varchar(40) NOT NULL
	,[Clave] varchar(40) NOT NULL
);

--para agrupar los acceso a los usuarios (Administrador,Supervisor,Cajero)
CREATE TABLE [Rol]
(
	 [RolID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[Descripcion] varchar(40) NOT NULL
);

--para asignar rol a los usuarios
CREATE TABLE [Seguridad]
(
	 [SeguridadID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[UsuarioID] INT NOT NULL
	,[RolID] INT NOT NULL
);



--CONSTRAINTS agregamos relaciones
ALTER TABLE [Venta]  ADD CONSTRAINT [FK_VentaCliente] FOREIGN KEY (ClienteID) REFERENCES [Cliente](ClienteID);
ALTER TABLE [VentaDetalle] ADD CONSTRAINT [FK_VentaDetalleVenta] FOREIGN KEY (VentaID) REFERENCES [Venta](VentaID)
ALTER TABLE [VentaDetalle] ADD CONSTRAINT [FK_VentaDetalleProducto] FOREIGN KEY (ProductoID) REFERENCES [Producto](ProductoID);
ALTER TABLE [Seguridad] ADD CONSTRAINT [FK_SeguridadUsuario] FOREIGN KEY (UsuarioID) REFERENCES [Usuario](UsuarioID);
ALTER TABLE [Seguridad] ADD CONSTRAINT [FK_SeguridadRol] FOREIGN KEY (RolID) REFERENCES [Rol](RolID);



