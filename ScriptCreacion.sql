
USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='MyLearnDB')
DROP DATABASE MyLearnDB
GO

CREATE DATABASE MyLearnDB;
GO


USE MyLearnDB;

CREATE TABLE USUARIO (
    Id INT IDENTITY(1,1),
    Contrasena CHAR(8),
    CONSTRAINT PK_USUARIO
		PRIMARY KEY (Id),
);

CREATE TABLE ESTUDIANTE (
    Id INT,
    NombreContacto CHAR(30) NOT NULL,
    ApellidoContacto CHAR(30) NOT NULL ,
    Carne CHAR(15),
    Email CHAR(50)  NOT NULL,
    Telefono CHAR(15) NOT NULL,
    Foto CHAR(30),
	Pais CHAR(30) NOT NULL ,
    Region CHAR(30),
    FechaInscripcion DATE  NOT NULL ,
    RepositorioCodigo CHAR(100),
    HojaDeVida CHAR(100),
    Idioma CHAR(50),
    
    CONSTRAINT PK_ESTUDIANTE
		PRIMARY KEY (Id),
    CONSTRAINT FK_ESTUDIANTE_ID
		FOREIGN KEY (Id) REFERENCES USUARIO(Id)
);

CREATE TABLE PROFESOR (
    Id INT,
    NombreContacto CHAR(30) NOT NULL ,
    ApellidoContacto CHAR(30) NOT NULL ,
    Email CHAR(50),
    Telefono CHAR(15) NOT NULL ,
    Foto CHAR(30),
    FechaInscripcion  DATE NOT NULL ,
    HorarioAtencion CHAR(15),
    Pais CHAR(30) NOT NULL ,
    Region CHAR(30),
    CONSTRAINT PK_PROFESOR
		PRIMARY KEY (Id),
    CONSTRAINT FK_PROFESOR_ID
		FOREIGN KEY (Id) REFERENCES USUARIO(Id)
);
    
CREATE TABLE EMPRESA (
    Id INT,
    NombreEmpresarial CHAR(30), /** If NULL => NombreEmpresarial=NombreContacto+NombreEmpresarial**/
    Email CHAR(50) NOT NULL ,
    Telefono CHAR(15) NOT NULL ,
    Foto CHAR(100),
    FechaInscripcion DATE NOT NULL ,
    PaginaWebEmpresa CHAR(30),
    Pais CHAR(30) NOT NULL ,
    Region CHAR(30),
    CONSTRAINT PK_EMPRESA
		PRIMARY KEY (Id),
    CONSTRAINT FK_EMPRESA_ID
		FOREIGN KEY (Id) REFERENCES USUARIO(Id)
);

/**/


CREATE TABLE TECNOLOGIA (
    Id INT IDENTITY(1,1),
    Nombre CHAR(30) NOT NULL ,
    
    CONSTRAINT PK_TECNOLOGIA
		PRIMARY KEY (Id)
);

CREATE TABLE REPOSITORIO (
    Id INT IDENTITY(1,1),
    Nombre CHAR(30) NOT NULL ,
    
    CONSTRAINT PK_REPOSITORIO_REPOSITORIO
		PRIMARY KEY (Id)
);

CREATE TABLE IDIOMA (
    Id INT IDENTITY(1,1),
    Nombre CHAR(30) NOT NULL ,
    
    CONSTRAINT PK_REPOSITORIO
		PRIMARY KEY (Id)
);

/**/

CREATE TABLE UNIVERSIDAD (
    Id INT IDENTITY(1,1),
    Nombre CHAR(30) NOT NULL ,
    
    CONSTRAINT PK_UNIVERSIDAD
		PRIMARY KEY (Id)
);

CREATE TABLE CURSO (
    Id INT IDENTITY(1,1),
    Nombre CHAR(30),
    Codigo CHAR(10),
    Estado CHAR(1),

	CONSTRAINT PK_CURSO
		PRIMARY KEY (Id)
);

CREATE TABLE BADGE (
	Id INT IDENTITY(1,1),
    Nombre CHAR (30),
    Puntaje TINYINT,
    Curso_Id INT,
	CONSTRAINT PK_BADGE
		PRIMARY KEY (Id),
    CONSTRAINT FK_CURSO_ID_BADGE
		FOREIGN KEY (Curso_Id) REFERENCES CURSO(Id)

);

/**/

CREATE TABLE PROYECTO (
    Id INT IDENTITY(1,1),
    Nombre CHAR(30) NOT NULL ,
    Problematica CHAR(100) NOT NULL ,
    Descripcion CHAR(500) NOT NULL ,
    Id_Curso INT,
    FechaInicio DATE NOT NULL ,
    FechaFinal DATE,
    DocumentoAdicional CHAR(100),
    NotaMinima INT NOT NULL ,
    Estado CHAR(1),

	CONSTRAINT PK_PROYECTO
		PRIMARY KEY (Id),
	FOREIGN KEY (Id_Curso) REFERENCES CURSO(Id)
);

CREATE TABLE TRABAJO (
    Id INT IDENTITY(1,1),
    Nombre CHAR(30) NOT NULL,
    Descripcion CHAR(500) NOT NULL,
    Empresa INT NOT NULL,
    FechaInicio  DATE,
    FechaCierre DATE NOT NULL,
    FechaFinal DATE,
    DocumentoAdicional CHAR(100),
    Estado CHAR(1),

	CONSTRAINT PK_TRABAJO
		PRIMARY KEY (Id),
	FOREIGN KEY (Empresa) REFERENCES EMPRESA(Id)
	
);

/**/

CREATE TABLE MENSAJE
(
    Id BIGINT IDENTITY(1,1),
    Contenido CHAR(500),
    Adjunto CHAR(500),
    Fecha DATETIME,
    
    CONSTRAINT PK_MENSAJE
		PRIMARY KEY (Id)
);

CREATE TABLE RESPUESTA
(
    Id BIGINT IDENTITY(1,1),
    MensajeRaiz BIGINT NOT NULL,
    Contenido CHAR(500),
    Adjunto CHAR(500),
    Fecha DATETIME,
    
    CONSTRAINT PK_RESPUESTA
		PRIMARY KEY (Id),
    CONSTRAINT FK_RESPUESTA_RAIZ
		FOREIGN KEY (MensajeRaiz) REFERENCES MENSAJE(Id)
);
/*------------------------------------------Relaciones entre tablas--------------------------------------*/
/*Manejo de cuentas*/


CREATE TABLE CURSO_POR_UNIVERSIDAD
(
    Curso_Id INT,
    Universidad_Id INT,
    CONSTRAINT PK_CURSO_POR_UNIVERSIDAD
		PRIMARY KEY (Curso_Id,Universidad_Id),
    CONSTRAINT FK_CURSO_ID_CURSO_POR_UNIVERSIDAD
		FOREIGN KEY (Curso_Id) REFERENCES BADGE(Id),
    CONSTRAINT FK_UNIVERSIDAD_ID_CURSO_POR_UNIVERSIDAD
		FOREIGN KEY (Universidad_Id) REFERENCES UNIVERSIDAD(Id)
)

CREATE TABLE CURSO_POR_PROFESOR
(
    Curso_Id INT,
    Profesor_Id INT,
    CONSTRAINT PK_CURSO_POR_PROFESOR
		PRIMARY KEY (Curso_Id,Profesor_Id),
    CONSTRAINT FK_CURSO_ID_CURSO_POR_PROFESOR
		FOREIGN KEY (Curso_Id) REFERENCES BADGE(Id),
    CONSTRAINT FK_UNIVERSIDA_ID_CURSO_POR_PROFESOR
		FOREIGN KEY (Profesor_Id) REFERENCES UNIVERSIDAD(Id)
)

CREATE TABLE PROFESOR_POR_UNIVERSIDAD
(
    Profesor_Id INT,
    Universidad_Id INT,
    CONSTRAINT PK_PROFESOR_POR_UNIVERSIDAD
		PRIMARY KEY (Profesor_Id,Universidad_Id),
    CONSTRAINT FK_CURSO_ID_PROFESOR_POR_UNIVERSIDAD
		FOREIGN KEY (Profesor_Id) REFERENCES PROFESOR(Id),
    CONSTRAINT FK_UNIVERSIDAD_ID_PROFESOR_POR_UNIVERSIDAD
		FOREIGN KEY (Universidad_Id) REFERENCES UNIVERSIDAD(Id)
)

CREATE TABLE ESTUDIANTE_POR_CURSO
(
    Estudiante_Id INT,
    Curso_Id INT,
    CONSTRAINT PK_ESTUDIANTE_POR_CURSO
		PRIMARY KEY ( Estudiante_Id,Curso_Id),
    CONSTRAINT FK_ESTUDIANTE_ID_ESTUDIANTE_POR_CURSO
		FOREIGN KEY (Estudiante_Id) REFERENCES ESTUDIANTE(Id),
    CONSTRAINT FK_CURSO_ID_ESTUDIANTE_POR_CURSO
		FOREIGN KEY ( Curso_Id) REFERENCES CURSO(Id)
)


/*Area de trabajo- curso*/
CREATE TABLE BADGE_POR_PROYECTO
(
    Id_Badge INT,
    Id_Proyecto INT,
    PRIMARY KEY (Id_Badge,Id_Proyecto),
    FOREIGN KEY (Id_Badge) REFERENCES BADGE (Id),
    FOREIGN KEY (Id_Proyecto) REFERENCES PROYECTO (Id)
)

CREATE TABLE PROYECTO_POR_PROFESOR
(
     Id_Proyecto INT,
     Id_Profesor INT,
    PRIMARY KEY (Id_Proyecto,Id_Profesor),
    FOREIGN KEY (Id_Proyecto) REFERENCES PROYECTO (Id),
    FOREIGN KEY (Id_Profesor) REFERENCES PROFESOR(Id)
)

CREATE TABLE PROYECTO_POR_ESTUDIANTE
(
     Id_Proyecto INT,
     Id_Estudiante INT,
    PRIMARY KEY (Id_Proyecto,Id_Estudiante),
    FOREIGN KEY (Id_Proyecto) REFERENCES PROYECTO (Id),
    FOREIGN KEY (Id_Estudiante) REFERENCES ESTUDIANTE(Id)
)
CREATE TABLE MENSAJE_POR_PROYECTO
(
    Id_Mensaje BIGINT,
    Id_Proyecto INT,
    PRIMARY KEY (Id_Mensaje,Id_Proyecto),
    FOREIGN KEY (Id_Mensaje) REFERENCES MENSAJE(Id),
    FOREIGN KEY (Id_Proyecto) REFERENCES PROYECTO(Id)
)

CREATE TABLE TECNOLOGIA_POR_PROYECTO
(
    Id_Tecnologia INT,
    Id_Proyecto INT,
    PRIMARY KEY (Id_Tecnologia,Id_Proyecto),
    FOREIGN KEY (Id_Tecnologia) REFERENCES TECNOLOGIA(Id),
    FOREIGN KEY (Id_Proyecto) REFERENCES PROYECTO(Id)
)


/*Mensajeria*/

CREATE TABLE RESPUESTA_POR_MENSAJE
(
    Id_Respuesta BIGINT,
    Id_Mensaje BIGINT,
    PRIMARY KEY (Id_Respuesta,Id_Mensaje),
    FOREIGN KEY (Id_Respuesta) REFERENCES RESPUESTA(Id),
    FOREIGN KEY (Id_Mensaje) REFERENCES MENSAJE(Id)
)
/*Area de trabajo- empresa*/

CREATE TABLE TRABAJO_POR_ESTUDIANTE
(
    Id_Trabajo INT,
    Id_Estudiante INT,
    PRIMARY KEY (Id_Trabajo,Id_Estudiante),
    FOREIGN KEY (Id_Trabajo) REFERENCES TRABAJO(Id),
    FOREIGN KEY (Id_Estudiante) REFERENCES ESTUDIANTE(Id)
)

CREATE TABLE TECNOLOGIA_POR_TRABAJO
(
    Id_Tecnologia INT,
    Id_Trabajo INT,
    PRIMARY KEY (Id_Tecnologia,Id_Trabajo),
    FOREIGN KEY (Id_Tecnologia) REFERENCES TECNOLOGIA(Id),
    FOREIGN KEY (Id_Trabajo) REFERENCES TRABAJO(Id)
)

CREATE TABLE MENSAJE_POR_TRABAJO
(
    Id_Mensaje BIGINT,
    Id_Trabajo INT,
    PRIMARY KEY (Id_Mensaje,Id_Trabajo),
    FOREIGN KEY (Id_Mensaje) REFERENCES MENSAJE(Id),
    FOREIGN KEY (Id_Trabajo) REFERENCES TRABAJO(Id)
)
