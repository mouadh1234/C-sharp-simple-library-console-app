# C-sharp Console application "simple Library management" developped by visual studio 2022 and sql server 2019.
simple database named "Studying" with 2 tables named "Livres" and "Utilisateurs"
CREATE TABLE Livres (
    livreId int NOT NULL IDENTITY PRIMARY KEY,
    livretName nvarchar(50),
    livreAuteur nvarchar(50),
    livreGenre nvarchar(50),
);
CREATE TABLE Utilisateurs (
    userId int NOT NULL IDENTITY  PRIMARY KEY,
    loginUser nvarchar(50),
    passwordUser nvarchar(50),
    emailUser nvarchar(50),
);
-------------------------------------all made by Mouadh ARFAOUI-------------------------------------
