
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
    RepositorioArchivos CHAR(100),
	LinkHojaDeVida CHAR(100),
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
	RepositorioArchivos CHAR(100),
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
	RepositorioArchivos CHAR(100),
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
    Estado CHAR(1), /*Activo, Pasado*/

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
    Estado CHAR(1) /*Propuesta, Lectura, Activo*/,

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
    DocumentoAdicional CHAR(100),
    Estado CHAR(1), /*Propuesta, Terminado, Activo*/

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

CREATE TABLE NOTIFICACION
(
	Id BIGINT IDENTITY(1,1),
    Contenido CHAR(500),
    Fecha DATETIME,
	UserId INT,
	Estado CHAR(1), /*Leida, Nueva*/

	CONSTRAINT PK_NOTIFICACION
		PRIMARY KEY (Id),
	CONSTRAINT FK_USER_ID
		FOREIGN KEY UserId REFERENCES USUARIO(Id)
);
/*------------------------------------------Relaciones entre tablas--------------------------------------*/
/*Manejo de cuentas*/


CREATE TABLE CURSO_POR_UNIVERSIDAD
(
    Curso_Id INT,
    Universidad_Id INT,
	Estado CHAR(1),

    CONSTRAINT PK_CURSO_POR_UNIVERSIDAD
		PRIMARY KEY (Curso_Id,Universidad_Id),
    CONSTRAINT FK_CURSO_ID_CURSO_POR_UNIVERSIDAD
		FOREIGN KEY (Curso_Id) REFERENCES BADGE(Id),
    CONSTRAINT FK_UNIVERSIDAD_ID_CURSO_POR_UNIVERSIDAD
		FOREIGN KEY (Universidad_Id) REFERENCES UNIVERSIDAD(Id)
);

CREATE TABLE CURSO_POR_PROFESOR
(
    Curso_Id INT,
    Profesor_Id INT,
	Estado CHAR(1),

    CONSTRAINT PK_CURSO_POR_PROFESOR
		PRIMARY KEY (Curso_Id,Profesor_Id),
    CONSTRAINT FK_CURSO_ID_CURSO_POR_PROFESOR
		FOREIGN KEY (Curso_Id) REFERENCES BADGE(Id),
    CONSTRAINT FK_UNIVERSIDA_ID_CURSO_POR_PROFESOR
		FOREIGN KEY (Profesor_Id) REFERENCES UNIVERSIDAD(Id)
);

CREATE TABLE PROFESOR_POR_UNIVERSIDAD
(
    Profesor_Id INT,
    Universidad_Id INT,
	Estado CHAR(1),

    CONSTRAINT PK_PROFESOR_POR_UNIVERSIDAD
		PRIMARY KEY (Profesor_Id,Universidad_Id),
    CONSTRAINT FK_CURSO_ID_PROFESOR_POR_UNIVERSIDAD
		FOREIGN KEY (Profesor_Id) REFERENCES PROFESOR(Id),
    CONSTRAINT FK_UNIVERSIDAD_ID_PROFESOR_POR_UNIVERSIDAD
		FOREIGN KEY (Universidad_Id) REFERENCES UNIVERSIDAD(Id)
);

CREATE TABLE ESTUDIANTE_POR_CURSO
(
    Estudiante_Id INT,
    Curso_Id INT,
	Estado CHAR(1), /*Disponible, Inscrito*/

    CONSTRAINT PK_ESTUDIANTE_POR_CURSO
		PRIMARY KEY ( Estudiante_Id,Curso_Id),
    CONSTRAINT FK_ESTUDIANTE_ID_ESTUDIANTE_POR_CURSO
		FOREIGN KEY (Estudiante_Id) REFERENCES ESTUDIANTE(Id),
    CONSTRAINT FK_CURSO_ID_ESTUDIANTE_POR_CURSO
		FOREIGN KEY ( Curso_Id) REFERENCES CURSO(Id)
);


/*Area de trabajo- curso*/
CREATE TABLE BADGE_POR_PROYECTO
(
    Id_Badge INT,
    Id_Proyecto INT,
	Estado CHAR(1),

    PRIMARY KEY (Id_Badge,Id_Proyecto),
    FOREIGN KEY (Id_Badge) REFERENCES BADGE (Id),
    FOREIGN KEY (Id_Proyecto) REFERENCES PROYECTO (Id)
);

CREATE TABLE PROYECTO_POR_PROFESOR
(
     IdProyecto INT,
     IdProfesor INT,
	 Estado CHAR(1),

    PRIMARY KEY (IdProyecto, IdProfesor),
    FOREIGN KEY (IdProyecto) REFERENCES PROYECTO (Id),
    FOREIGN KEY (IdProfesor) REFERENCES PROFESOR(Id)
);

CREATE TABLE PROYECTO_POR_ESTUDIANTE
(
     IdProyecto INT,
     IdEstudiante INT,
	 Estado CHAR(1),

    PRIMARY KEY (IdProyecto,IdEstudiante),
    FOREIGN KEY (IdProyecto) REFERENCES PROYECTO (Id),
    FOREIGN KEY (IdEstudiante) REFERENCES ESTUDIANTE(Id)
);

CREATE TABLE IDIOMA_POR_ESTUDIANTE(
	IdEstudiante INT,
	IdIdioma INT,
	Estado CHAR(1),

	/*CONSTRAINT PK_IDIOMA_POR_ESTUDIANTE*/
	PRIMARY KEY (IdEstudiante, IdIdioma),
    FOREIGN KEY (IdIdioma) REFERENCES PROYECTO (Id),
    FOREIGN KEY (IdEstudiante) REFERENCES ESTUDIANTE(Id)
);

CREATE TABLE MENSAJE_POR_PROYECTO
(
    IdMensaje BIGINT,
    IdProyecto INT,
	Estado CHAR(1),

    PRIMARY KEY (IdMensaje, IdProyecto),
    FOREIGN KEY (IdMensaje) REFERENCES MENSAJE(Id),
    FOREIGN KEY (IdProyecto) REFERENCES PROYECTO(Id)
);

CREATE TABLE TECNOLOGIA_POR_PROYECTO
(
    IdTecnologia INT,
    IdProyecto INT,
	Estado CHAR(1),

    PRIMARY KEY (Id_Tecnologia, Id_Proyecto),
    FOREIGN KEY (Id_Tecnologia) REFERENCES TECNOLOGIA(Id),
    FOREIGN KEY (Id_Proyecto) REFERENCES PROYECTO(Id)
);

/*Area de trabajo- empresa*/

CREATE TABLE TRABAJO_POR_ESTUDIANTE
(
    IdTrabajo INT,
    IdEstudiante INT,
	Monto INT,
	Comentario CHAR(300),
	Estado CHAR(1), /*Aceptada, Negada, Enviada*/

    PRIMARY KEY (IdTrabajo, IdEstudiante),
    FOREIGN KEY (IdTrabajo) REFERENCES TRABAJO(Id),
    FOREIGN KEY (IdEstudiante) REFERENCES ESTUDIANTE(Id)
);

CREATE TABLE TECNOLOGIA_POR_TRABAJO
(
    Id_Tecnologia INT,
    Id_Trabajo INT,
	Fecha DATE,
	Estado CHAR(1),

    PRIMARY KEY (Id_Tecnologia,Id_Trabajo),
    FOREIGN KEY (Id_Tecnologia) REFERENCES TECNOLOGIA(Id),
    FOREIGN KEY (Id_Trabajo) REFERENCES TRABAJO(Id)
);

CREATE TABLE MENSAJE_POR_TRABAJO
(
    Id_Mensaje BIGINT,
    Id_Trabajo INT,
	Estado CHAR(1),

    PRIMARY KEY (Id_Mensaje,Id_Trabajo),
    FOREIGN KEY (Id_Mensaje) REFERENCES MENSAJE(Id),
    FOREIGN KEY (Id_Trabajo) REFERENCES TRABAJO(Id)
);
