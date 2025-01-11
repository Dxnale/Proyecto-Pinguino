﻿IF OBJECT_ID('dbo.danielTorrealba_PERFILES', 'U') IS NULL BEGIN CREATE TABLE danielTorrealba_PERFILES ( Rut NVARCHAR(10) NOT NULL PRIMARY KEY, Nombre NVARCHAR(30) NOT NULL, ApPat NVARCHAR(30) NOT NULL, ApMat NVARCHAR(30) NOT NULL, Edad INT NOT NULL, Clave NVARCHAR(250) NOT NULL, Nivel INT NOT NULL CHECK (Nivel IN (1, 2))); INSERT INTO danielTorrealba_PERFILES (Rut, Nombre, ApPat, ApMat, Edad, Clave, Nivel) VALUES ('11111111-1','LUIS','YAÑEZ','CARREÑO',49,CONCAT(LEFT('LUIS', 1), LEFT('YAÑEZ', 1), LEFT('CARREÑO', 1), '11111111-1'),1); END ELSE BEGIN PRINT 'La tabla danielTorrealba_PERFILES ya existe.'; END IF OBJECT_ID('dbo.danielTorrealba_FRASES', 'U') IS NULL BEGIN CREATE TABLE danielTorrealba_FRASES (id INT IDENTITY(1,1) PRIMARY KEY,frase NVARCHAR(MAX) NOT NULL); INSERT INTO danielTorrealba_FRASES (frase) VALUES ('Primero resuelve el problema, despues escribve el codigo.'),('Siempre hay más de una forma de resolver un problema.'),('Algoritmo: Palabra que usan los programadores cuando no quieren explicar lo que hicieron.'),('Un código limpio es un código mantenible.'), ('Hablar no es suficiente, muestrame el codigo.'); END ELSE BEGIN PRINT 'La tabla danielTorrealba_FRASES ya existe.';END