CREATE DATABASE ACTIVIDADES4;
GO

USE ACTIVIDADES4
GO

CREATE TABLE Materias (
    Codigo INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Creditos INT NOT NULL CHECK (Creditos BETWEEN 1 AND 10),
    Carrera NVARCHAR(100) NOT NULL
);

GO

CREATE TABLE Calificaciones (
    Id INT PRIMARY KEY IDENTITY(1,1),
    MatriculaEstudiante NVARCHAR(50) NOT NULL,
    CodigoMateria INT NOT NULL,
    Nota FLOAT NOT NULL CHECK (Nota BETWEEN 0 AND 100),
    Periodo NVARCHAR(20) NOT NULL,
    FOREIGN KEY (CodigoMateria) REFERENCES Materias(Codigo)
);
GO

