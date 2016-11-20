USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='MyLearnDB')
DROP DATABASE MyLearnDB
GO

CREATE DATABASE MyLearnDB;
GO

USE MyLearnDB;

CREATE TABLE USUARIO (
    Id CHAR(100),
    Contrasena CHAR(8),
	Sal CHAR(20),
	RepositorioArchivos CHAR(100),
	CredencialDrive CHAR(100),
	Estado CHAR(1),

    CONSTRAINT PK_USUARIO
		PRIMARY KEY (Id),
);

CREATE TABLE USUARIO_XMP (
    Id CHAR(100),
    NombreContacto CHAR(30) NOT NULL,
    ApellidoContacto CHAR(30) NOT NULL,
   
    CONSTRAINT PK_USUARIO_XMP
		PRIMARY KEY (Id),
    CONSTRAINT FK_USUARIO_XMP
		FOREIGN KEY (Id) REFERENCES USUARIO(Id)
);
CREATE TABLE ESTUDIANTE (
    Id CHAR(100),
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
	LinkHojaDeVida CHAR(100),
    
    CONSTRAINT PK_ESTUDIANTE
		PRIMARY KEY (Id),
    CONSTRAINT FK_ESTUDIANTE_ID
		FOREIGN KEY (Id) REFERENCES USUARIO(Id)
);

CREATE TABLE PROFESOR (
    Id CHAR(100),
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
    Id CHAR(100),
	NombreContacto CHAR(30),
	ApellidoContacto CHAR(30),
    NombreEmpresarial CHAR(30), /** If NULL => NombreEmpresarial=NombreContacto+ApellidoContacto**/
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
    Nombre CHAR(30) UNIQUE NOT NULL,
	Estado CHAR(1),
    
    CONSTRAINT PK_TECNOLOGIA
		PRIMARY KEY (Id)
);

CREATE TABLE IDIOMA (
    Id INT IDENTITY(1,1),
    Nombre CHAR(30) UNIQUE NOT NULL ,
    
    CONSTRAINT PK_IDIOMA
		PRIMARY KEY (Id)
);

/**/

CREATE TABLE UNIVERSIDAD (
    Id INT IDENTITY(1,1),
    Nombre CHAR(30) NOT NULL ,
	Estado CHAR(1),
    
    CONSTRAINT PK_UNIVERSIDAD
		PRIMARY KEY (Id)
);

CREATE TABLE CURSO (
    Id INT IDENTITY(1,1),
    Nombre CHAR(30),
    Codigo CHAR(10),
    NotaMinima tiny INT NOT NULL ,
    Estado CHAR(1), /*Activo, Cerrado*/

	CONSTRAINT PK_CURSO
		PRIMARY KEY (Id)
);

CREATE TABLE BADGE (
	Id INT IDENTITY(1,1),
    Nombre CHAR (30),
    Puntaje TINYINT,
    IdCurso INT,

	CONSTRAINT PK_BADGE
		PRIMARY KEY (Id),
    CONSTRAINT FK_CURSO_ID_BADGE
		FOREIGN KEY (IdCurso) REFERENCES CURSO(Id)
);
/**/

CREATE TABLE PROYECTO (
    Id INT IDENTITY(1,1),
    Nombre CHAR(30) NOT NULL ,
    Problematica CHAR(100) NOT NULL ,
    Descripcion CHAR(500) NOT NULL ,
    IdCurso INT,
    FechaInicio DATE NOT NULL ,
    FechaFinal DATE,
    DocumentoAdicional CHAR(100),
    NotaObtenida tinyINT,
    Estado CHAR(1) /*Propuesta, Lectura, Activo,*/,

	CONSTRAINT PK_PROYECTO
		PRIMARY KEY (Id),
	CONSTRAINT FK_ID_CURSO
		FOREIGN KEY (IdCurso) REFERENCES CURSO(Id)
);

CREATE TABLE TRABAJO (
    Id INT IDENTITY(1,1),
    Nombre CHAR(30) NOT NULL,
    Descripcion CHAR(500) NOT NULL,
    IdEmpresa CHAR(100) NOT NULL,
    FechaInicio  DATE,
    FechaCierre DATE NOT NULL,
    DocumentoAdicional CHAR(100),
    EstrellasObtenidas tinyINT,
    Estado CHAR(1), /*Propuesta, Exito(Terminado), Fracaso(Terminado), Activo*/

	CONSTRAINT PK_TRABAJO
		PRIMARY KEY (Id),
	CONSTRAINT FK_TRABAJO_POR_EMPRESA
		FOREIGN KEY (IdEmpresa) REFERENCES EMPRESA(Id)
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
	UserId CHAR(100),
	Estado CHAR(1), /*Leida, Nueva, Borrada*/

	CONSTRAINT PK_NOTIFICACION
		PRIMARY KEY (Id),
	CONSTRAINT FK_USER_ID
		FOREIGN KEY (UserId) REFERENCES USUARIO(Id)
);

/*------------------------------------------Relaciones entre tablas--------------------------------------*/
/*Manejo de cuentas*/


CREATE TABLE CURSO_POR_UNIVERSIDAD
(
    IdCurso INT,
    IdUniversidad INT,
	Estado CHAR(1), /*Activo, Inactivo*/

    CONSTRAINT PK_CURSO_POR_UNIVERSIDAD
		PRIMARY KEY (IdCurso, IdUniversidad),
    CONSTRAINT FK_IDCURSO_CURSO_POR_UNIVERSIDAD
		FOREIGN KEY (IdCurso) REFERENCES CURSO(Id),
    CONSTRAINT FK_IDUNIVERSIDAD_CURSO_POR_UNIVERSIDAD
		FOREIGN KEY (IdUniversidad) REFERENCES UNIVERSIDAD(Id)
);

CREATE TABLE CURSO_POR_PROFESOR
(
	IdCurso INT,
    IdProfesor CHAR(100),
	Estado CHAR(1), /*Activo, Inactivo*/

    CONSTRAINT PK_CURSO_POR_PROFESOR
		PRIMARY KEY (IdCurso, IdProfesor),
    CONSTRAINT FK_IDCURSO_CURSO_POR_PROFESOR
		FOREIGN KEY (IdCurso) REFERENCES CURSO(Id),
    CONSTRAINT FK_IDPOFESOR_CURSO_POR_PROFESOR
		FOREIGN KEY (IdProfesor) REFERENCES PROFESOR(Id)
);

CREATE TABLE PROFESOR_POR_UNIVERSIDAD
(
    IdProfesor CHAR(100),
    IdUniversidad INT,
    Estado CHAR(1), /*Activo, Inactivo*/

    CONSTRAINT PK_PROFESOR_POR_UNIVERSIDAD
		PRIMARY KEY (IdProfesor, IdUniversidad),
    CONSTRAINT FK_IDPROFESOR_PROFESOR_POR_UNIVERSIDAD
		FOREIGN KEY (IdProfesor) REFERENCES PROFESOR(Id),
    CONSTRAINT FK_IDUNIVERSIDAD_PROFESOR_POR_UNIVERSIDAD
		FOREIGN KEY (IdUniversidad) REFERENCES UNIVERSIDAD(Id)
);

CREATE TABLE ESTUDIANTE_POR_CURSO
(
    IdEstudiante CHAR(100),
    IdCurso INT,
    Nota INT,
    Estado CHAR(1), /*Disponible, Inscrito, Aprobado(Inactivo), Reprobado(Inactivo)*/

    CONSTRAINT PK_ESTUDIANTE_POR_CURSO
		PRIMARY KEY (IdEstudiante, IdCurso),
    CONSTRAINT FK_IDESTUDIANTE_ESTUDIANTE_POR_CURSO
		FOREIGN KEY (IdEstudiante) REFERENCES ESTUDIANTE(Id),
    CONSTRAINT FK_IDCURSO_ESTUDIANTE_POR_CURSO
		FOREIGN KEY (IdCurso) REFERENCES CURSO(Id)
);


/*Area de trabajo- curso*/
CREATE TABLE BADGE_POR_PROYECTO
(
    IdBadge INT,
    IdProyecto INT,
	Estado CHAR(1), /*Alardeado (Obtenido), Por Alardear (Obtenido), Pendiente*/

	CONSTRAINT PK_BADGE_POR_PROYECTO
		PRIMARY KEY (IdBadge, IdProyecto),
	CONSTRAINT FK_IDBADGE_BADGE_POR_PROYECTO
		FOREIGN KEY (IdBadge) REFERENCES BADGE (Id),
	CONSTRAINT FK_IDPROYECTO_BADGE_POR_PROYECTO
	    FOREIGN KEY (IdProyecto) REFERENCES PROYECTO (Id)
);

CREATE TABLE PROYECTO_POR_PROFESOR
(
     IdProyecto INT,
     IdProfesor CHAR(100),
	 Estado CHAR(1),

	CONSTRAINT PK_PROYECTO_POR_PROFESOR
		PRIMARY KEY (IdProyecto, IdProfesor),
	CONSTRAINT FK_IDPROYECTO_PROYECTO_POR_PROFESOR
		FOREIGN KEY (IdProyecto) REFERENCES PROYECTO (Id),
	CONSTRAINT FK_IDPROFESOR_PROYECTO_POR_PROFESOR
		FOREIGN KEY (IdProfesor) REFERENCES PROFESOR(Id)
);

CREATE TABLE PROYECTO_POR_ESTUDIANTE
(
    IdProyecto INT,
    IdEstudiante CHAR(100),
	Estado CHAR(1),

	CONSTRAINT PK_PROYECTO_POR_ESTUDIANTE
		PRIMARY KEY (IdProyecto,IdEstudiante),
	CONSTRAINT FK_IDPROYECTO_PROYECTO_POR_ESTUDIANTE
		FOREIGN KEY (IdProyecto) REFERENCES PROYECTO (Id),
	CONSTRAINT FK_IDESTUDIANTE_PROYECTO_POR_ESTUDIANTE
		FOREIGN KEY (IdEstudiante) REFERENCES ESTUDIANTE(Id)
);

CREATE TABLE IDIOMA_POR_ESTUDIANTE(
	IdEstudiante CHAR(100),
	IdIdioma INT,
	Estado CHAR(1),

	CONSTRAINT PK_IDIOMA_POR_ESTUDIANTE
		PRIMARY KEY (IdEstudiante, IdIdioma),
	CONSTRAINT FK_IDIDIOMA_IDIOMA_POR_ESTUDIANTE
		FOREIGN KEY (IdIdioma) REFERENCES IDIOMA (Id),
	CONSTRAINT FK_IDESTUDIANTE_IDIOMA_POR_ESTUDIANTE
		FOREIGN KEY (IdEstudiante) REFERENCES ESTUDIANTE(Id)
);

CREATE TABLE MENSAJE_POR_PROYECTO
(
    IdMensaje BIGINT,
    IdProyecto INT,
	Estado CHAR(1),

	CONSTRAINT PK_MENSAJE_POR_PROYECTO
		PRIMARY KEY (IdMensaje, IdProyecto),
	CONSTRAINT FK_IDMENSAJE_MENSAJE_POR_PROYECTO
		FOREIGN KEY (IdMensaje) REFERENCES MENSAJE(Id),
	CONSTRAINT FK_IDPROYECTO_MENSAJE_POR_PROYECTO
		FOREIGN KEY (IdProyecto) REFERENCES PROYECTO(Id)
);

CREATE TABLE TECNOLOGIA_POR_PROYECTO
(
    IdTecnologia INT,
    IdProyecto INT,
	Estado CHAR(1),

	CONSTRAINT PK_TECNOLOGIA_POR_PROYECTO
		PRIMARY KEY (IdTecnologia, IdProyecto),
	CONSTRAINT FK_IDTECNOLOGIA_TECNOLOGIA_POR_PROYECTO
		FOREIGN KEY (IdTecnologia) REFERENCES TECNOLOGIA(Id),
	CONSTRAINT FK_IDPROYECTO_TECNOLOGIA_POR_PROYECTO
		FOREIGN KEY (IdProyecto) REFERENCES PROYECTO(Id)
);

/*Area de trabajo- empresa*/

CREATE TABLE TRABAJO_POR_ESTUDIANTE
(
    IdTrabajo INT,
    IdEstudiante CHAR(100),
	Monto INT,
	Comentario CHAR(300),
	Estado CHAR(1), /*Aceptada, Negada, Enviada*/

	CONSTRAINT PK_TRABAJO_POR_ESTUDIANTE
		PRIMARY KEY (IdTrabajo, IdEstudiante),
	CONSTRAINT FK_IDTRABAJO_TRABAJO_POR_ESTUDIANTE
		FOREIGN KEY (IdTrabajo) REFERENCES TRABAJO(Id),
	CONSTRAINT FK_IDESTUDIANTE_TRABAJO_POR_ESTUDIANTE
		FOREIGN KEY (IdEstudiante) REFERENCES ESTUDIANTE(Id)
);

CREATE TABLE TECNOLOGIA_POR_TRABAJO
(
    IdTecnologia INT,
    IdTrabajo INT,
	Estado CHAR(1),

	CONSTRAINT PK_TECNOLOGIA_POR_TRABAJO
		PRIMARY KEY (IdTecnologia,IdTrabajo),
	CONSTRAINT FK_IDTECNOLOGIA_TECNOLOGIA_POR_TRABAJO
		FOREIGN KEY (IdTecnologia) REFERENCES TECNOLOGIA(Id),
	CONSTRAINT FK_IDTRABAJO_TECNOLOGIA_POR_TRABAJO
		FOREIGN KEY (IdTrabajo) REFERENCES TRABAJO(Id)
);

CREATE TABLE MENSAJE_POR_TRABAJO
(
    IdMensaje BIGINT,
    IdTrabajo INT,
	Estado CHAR(1),

	CONSTRAINT PK_MENSAJE_POR_TRABAJO
		PRIMARY KEY (IdMensaje,IdTrabajo),
	CONSTRAINT FK_IDMENSAJE_MENSAJE_POR_TRABAJO
		FOREIGN KEY (IdMensaje) REFERENCES MENSAJE(Id),
	CONSTRAINT FK_IDTRABAJO_MENSAJE_POR_TRABAJO
		FOREIGN KEY (IdTrabajo) REFERENCES TRABAJO(Id)
);
