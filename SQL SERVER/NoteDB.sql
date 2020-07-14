

-- CREATE DATABASE
--Create database PrestamosDB
--GO

--USING DATABASE
USE PrestamosDB 
GO

-- DROP TABLE IF EXIST
 if object_id('Students') is not null drop table Students
 GO

 create table Students(
 precio decimal(12,2)
 ,cantidad decimal(12,2)
 ,total as precio * cantidad
 );

 insert into students(cantidad,precio)values(5,10)

 select * from students