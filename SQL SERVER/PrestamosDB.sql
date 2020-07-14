

-- CREATE DATABASE
Create database NoteDB
GO

--USING DATABASE
USE NoteDB 
GO

-- DROP TABLE IF EXIST
 if object_id('Students') is not null drop table Students
 GO

 -- CREATE TABLE
 Create table Students
 (
	ID bigint identity(1,1) primary key
	,Nombre nvarchar(200) not null
 )
 GO



 --TRUNCATE OR EMPTY TABLE
 -- truncate table Studensts