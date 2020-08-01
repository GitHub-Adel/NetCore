
--SQL DOCUMENT https://www.w3schools.com/sql/sql_foreignkey.asp

-- USE [master]; DROP DATABASE [SocialmediaDB];
-- CREATE DATABASE [SocialmediaDB];

USE [SocialmediaDB];

--DROP CONSTRAINTS 'F'=FORREIGN KEY
IF OBJECT_ID('FK_PostUser','F') IS NOT NULL ALTER TABLE [Post] DROP CONSTRAINT FK_PostUser;
IF OBJECT_ID('FK_CommentPost','F') IS NOT NULL ALTER TABLE [Comment] DROP CONSTRAINT FK_CommentPost;
IF OBJECT_ID('FK_CommentUser','F') IS NOT NULL ALTER TABLE [Comment] DROP CONSTRAINT FK_CommentUser;

--DROP TABLE  'U'= TABLE
IF OBJECT_ID('User','U') IS NOT NULL DROP TABLE [User];
IF OBJECT_ID('Post','U') IS NOT NULL DROP TABLE [Post];
IF OBJECT_ID('Comment','U') IS NOT NULL DROP TABLE [Comment];


CREATE TABLE [User]
(
	[UserID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[Firstname] VARCHAR(50) NOT NULL
	,[Lastname] VARCHAR(50) NOT NULL
	,[Email] VARCHAR(30) NOT NULL
	,[Datebirth] DATETIME NOT NULL
	,[Phone] VARCHAR(10)
	,[Active] BIT NOT NULL
);

CREATE TABLE [Post]
(
	[PostID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[UserID] INT NOT NULL
	,[Date] DATETIME NOT NULL
	,[Description] VARCHAR(1000) NOT NULL
	,[Image] VARCHAR(500)  
);


CREATE TABLE [Comment]
(
	[CommentId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY
	,[PostID] INT NOT NULL
	,[UserID] INT NOT NULL
	,[Description] VARCHAR(500) NOT NULL
	,[Date] DATETIME NOT NULL
	,[Active] BIT NOT NULL
);

--CONSTRAINTS
ALTER TABLE [Post]  ADD CONSTRAINT FK_PostUser FOREIGN KEY (UserID) REFERENCES [User](UserID);
ALTER TABLE [Comment] ADD CONSTRAINT FK_CommentPost FOREIGN KEY (PostID) REFERENCES [Post](PostID)
ALTER TABLE [Comment] ADD CONSTRAINT FK_CommentUser FOREIGN KEY (UserID) REFERENCES [User](UserID);