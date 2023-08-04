USE MASTER
GO

if exists(select * from sys.databases where name = 'TudoHorroroso')
	drop database TudoHorroroso
go

CREATE DATABASE TudoHorroroso
GO

USE TudoHorroroso
GO

CREATE TABLE [User]
(
    UserName VARCHAR(100),
    HashCode VARCHAR(MAX),
    Salt VARCHAR(MAX),
    Email VARCHAR(100)
)
