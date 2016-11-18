Use MyLearnDB ;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_insert_estudiante   ')
DROP PROCEDURE sp_insert_estudiante   
GO

CREATE PROCEDURE SP_Select_Cursos @UserId INT
	AS
		SELECT Curso, SUM(PuntajeBadge) AS Nota, EstadoCurso
		FROM VIEW_CALIFICACIONES
		WHERE IdEstudiante=@UserId AND EstadoBadge='O'
		GROUP BY Curso, EstadoCurso
	GO

CREATE PROCEDURE SP_Nota_Poyecto @UserID INT, @ProjectId INT
	AS
		SELECT SUM(PuntajeBadge) AS Nota
		FROM VIEW_CALIFICACIONES
		WHERE IdEstudiante=@UserID AND EstadoBadge='O' AND IdProyecto=@ProjectId
	GO


CREATE PROCEDURE SP_Insertar_Estudiante   
	@Id CHAR(100), @Contrasena CHAR(8), @Sal CHAR(20), @RepositorioArchivos CHAR(100), @CredencialDrive CHAR(100),

	@Nombre CHAR(30), @Apellido CHAR(30), @Carne CHAR(15), @Email CHAR(50), @Telefono CHAR(15), @Pais CHAR(30),
	@Region CHAR(30), @FechaInscripcion DATE, @RepositorioCodigo CHAR(100), @LinkHojaDeVida CHAR(100)  
	AS
		INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado) 
		VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A')

		INSERT INTO ESTUDIANTE (Id,NombreContacto, ApellidoContacto, Carne, Email, Telefono, Pais, Region,
		FechaInscripcion, RepositorioCodigo, LinkHojaDeVida) 
		VALUES (@Id, @Nombre, @Apellido, @Carne, @Email, @Telefono,@Pais,@Region, @FechaInscripcion, @RepositorioCodigo,
		 @LinkHojaDeVida)
	GO


CREATE PROCEDURE SP_Insertar_Profesor
	@Id CHAR(100), @Contrasena CHAR(8), @Sal CHAR(20), @RepositorioArchivos CHAR(100), @CredencialDrive CHAR(100),

	@NombreContacto CHAR(30), @ApellidoContacto CHAR(30), @Email CHAR(50), @Telefono CHAR(15), 
	@FechaInscripcion DATE, @HorarioAtencion CHAR(15), @Pais CHAR(30), @Region CHAR(30), @IdUniversidad INT
		AS
			INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado) 
			VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A')

			INSERT INTO PROFESOR (Id, NombreContacto, ApellidoContacto, Email, Telefono, FechaInscripcion, HorarioAtencion, Pais,
			Region)
			VALUES (@Id, @NombreContacto, @ApellidoContacto, @Email, @Telefono, @FechaInscripcion, @HorarioAtencion, @Pais,
			@Region)

			INSERT INTO PROFESOR_POR_UNIVERSIDAD (IdProfesor, IdUniversidad, Estado)
			VALUES (@Id, @IdUniversidad, 'A')
		GO

CREATE PROCEDURE SP_Insertar_Empresa
@Id CHAR(100), @Contrasena CHAR(8), @Sal CHAR(20), @RepositorioArchivos CHAR(100), @CredencialDrive CHAR(100),

@NombreContacto CHAR(30), @ApellidoContacto CHAR(30), @NombreEmpresarial CHAR(30), @Email CHAR(50), @Telefono CHAR(15),
@FechaInscripcion DATE, @PaginaWebEmpresa CHAR(30), @Pais CHAR(30), @Region CHAR(30), @RepositorioCodigo CHAR(100)
	AS
		INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado) 
		VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A')

		INSERT INTO EMPRESA (Id, NombreContacto, ApellidoContacto, NombreEmpresarial, Email, Telefono, FechaInscripcion, 
		PaginaWebEmpresa, Pais, Region)
		VALUES (@Id, @NombreContacto, @ApellidoContacto, @NombreEmpresarial, @Email, @Telefono, @FechaInscripcion, 
		@PaginaWebEmpresa, @Pais, @Region) 
	GO

CREATE PROCEDURE SP_Insertar_Admin
@Id CHAR(100), @Contrasena CHAR(8), @Sal CHAR(20), @RepositorioArchivos CHAR(100), @CredencialDrive CHAR(100),
@Nombre CHAR(30), @ApellidoContacto CHAR(30)
	AS
		INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado) 
		VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A')

		INSERT INTO USUARIO_XMP (Id, NombreContacto, ApellidoContacto)
		VALUES (@Id, @Nombre, @ApellidoContacto) 
	GO



CREATE PROCEDURE SP_Insertar_Tecnologia @Nombre CHAR(30)
	AS
		INSERT INTO TECNOLOGIA (Nombre, Estado)
		VALUES (@Nombre, 'A')
	GO

CREATE PROCEDURE SP_Insertar_Universidad @Nombre CHAR(30)
	AS
		INSERT INTO UNIVERSIDAD (Nombre, Estado)
		VALUES (@Nombre, 'A')
	GO


CREATE PROCEDURE SP_Insertar_Curso @IdProfesor CHAR(100), @Nombre CHAR(30), @Codigo CHAR(10), @IdUniversidad INT
	AS
		DECLARE @IdCurso INT
		INSERT INTO CURSO (Nombre, Codigo, Estado)
		VALUES (@Nombre, @Codigo, 'A')

		SELECT @IdCurso = @@IDENTITY
		INSERT INTO CURSO_POR_PROFESOR (IdCurso, IdProfesor, Estado)
		VALUES (@IdCurso, @IdProfesor, 'A')

		INSERT INTO CURSO_POR_UNIVERSIDAD (IdCurso, IdUniversidad, Estado)
		VALUES (@IdCurso, @IdUniversidad, 'A')
	GO

CREATE PROCEDURE SP_Insertar_Badge (@Nombre CHAR (30), @Puntaje TINYINT, @IdCurso INT) 
	AS
		INSERT INTO BADGE (Nombre, Puntaje, IdCurso)
		VALUES (@Nombre, @Puntaje, @IdCurso)

	GO

CREATE PROCEDURE SP_Otorgar_Badge (@IdBadge INT, @IdProyecto INT)
	AS
		INSERT INTO BADGE_POR_PROYECTO (IdBadge, IdProyecto, Estado)
		VALUES (@IdBadge, @IdProyecto, 'A')
	GO

CREATE PROCEDURE SP_Insertar_Proyecto @IdEstudiante CHAR(100), @Nombre CHAR(30), @Problematica CHAR(100), @Descripcion CHAR(500), @IdCurso INT, @FechaInicio DATE, @FechaFinal DATE, @DocumentoAdicional CHAR(100), @NotaMinima INT 
	AS
		DECLARE @IdProyecto INT
		INSERT INTO PROYECTO (Nombre, Problematica, Descripcion, IdCurso, FechaInicio, FechaFinal, DocumentoAdicional, NotaMinima, Estado)
		VALUES (@Nombre,@Problematica, @Descripcion, @IdCurso, @FechaInicio, @FechaFinal, @DocumentoAdicional, @NotaMinima, 'P')

		SELECT @IdProyecto = @@IDENTITY
		INSERT INTO PROYECTO_POR_ESTUDIANTE (IdProyecto, IdEstudiante, Estado)
		VALUES (@IdProyecto, @IdEstudiante, 'P')
	GO

CREATE PROCEDURE SP_Aceptar_Propuesta @IdProfesor CHAR(100), @IdPropuesta CHAR(1)
	AS
		UPDATE PROYECTO
		SET Estado='A'
		WHERE Id=@IdPropuesta

		UPDATE PROYECTO_POR_ESTUDIANTE
		SET Estado='A'
		WHERE IdEstudiante=@IdPropuesta

		INSERT INTO PROYECTO_POR_PROFESOR (IdProyecto, IdProfesor, Estado)
		VALUES (@IdPropuesta, @IdProfesor, 'A')
	GO

CREATE PROCEDURE SP_Insertar_Trabajo @Nombre CHAR(30), @Descripcion CHAR(500), @IdEmpresa CHAR(100), @FechaInicio DATE, @FechaCierre DATE, @DocumentoAdicional CHAR(100)
	AS
		INSERT INTO TRABAJO (Nombre, Descripcion, IdEmpresa, FechaInicio, FechaCierre, DocumentoAdicional, Estado)
		VALUES (@Nombre, @Descripcion, @IdEmpresa, @FechaInicio, @FechaCierre, @DocumentoAdicional, 'P')
	GO

CREATE PROCEDURE SP_Crear_Propuesta_Subasta @IdTrabajo INT, @IdEstudiante CHAR(100), @Monto INT, @Comentario CHAR(300)
	AS
		INSERT INTO TRABAJO_POR_ESTUDIANTE (IdTrabajo, IdEstudiante, Monto, Comentario, Estado)
		VALUES (@IdTrabajo, @IdEstudiante, @Monto, @Comentario, 'P')
	GO

CREATE PROCEDURE SP_Aceptar_Subasta @IdSubasta CHAR(1), @IdEstudiante CHAR(100)
	AS
		UPDATE TRABAJO_POR_ESTUDIANTE
		SET Estado='X'
		WHERE IdTrabajo=@IdSubasta

		UPDATE TRABAJO_POR_ESTUDIANTE
		SET Estado='A'
		WHERE IdEstudiante=@IdEstudiante AND IdTrabajo=@IdSubasta
		
		UPDATE TRABAJO
		SET Estado='A'
		WHERE Id=@IdSubasta
	GO

CREATE PROCEDURE SP_Insertar_Mensaje_Proyecto @Contenido CHAR(500), @Adjunto CHAR(500), @Fecha DATETIME, @IdProyecto INT
	AS
		DECLARE @IdMensaje BIGINT
		INSERT INTO MENSAJE (Contenido, Adjunto, Fecha)
		VALUES (@Contenido, @Adjunto, @Fecha)
		
		SELECT @IdMensaje = @@IDENTITY
		INSERT INTO MENSAJE_POR_PROYECTO (IdMensaje, IdProyecto, Estado)
		VALUES (@IdMensaje,  @IdProyecto, 'A')
	GO

CREATE PROCEDURE SP_Insertar_Mensaje_Trabajo @Contenido CHAR(500), @Adjunto CHAR(500), @Fecha DATETIME, @IdTrabajo INT
	AS
		DECLARE @IdMensaje BIGINT
		INSERT INTO MENSAJE (Contenido, Adjunto, Fecha)
		VALUES (@Contenido, @Adjunto, @Fecha)
		
		SELECT @IdMensaje = @@IDENTITY
		INSERT INTO MENSAJE_POR_TRABAJO (IdMensaje, IdTrabajo, Estado)
		VALUES (@IdMensaje,  @IdTrabajo, 'A')
	GO

CREATE PROCEDURE SP_Insertar_Respuesta @MensajeRaiz BIGINT, @Contenido CHAR(500), @Adjunto CHAR(500), @Fecha DATETIME
	AS
		INSERT INTO RESPUESTA (MensajeRaiz, Contenido, Adjunto, Fecha)
		VALUES (@MensajeRaiz, @Contenido, @Adjunto, @Fecha)
	GO

/*Automatizar?*/
CREATE PROCEDURE SP_Insertar_Notificacion @Contenido CHAR(500), @Fecha DATETIME, @UserId CHAR(100)
	AS
		INSERT INTO NOTIFICACION (Contenido, Fecha, UserId, Estado)
		VALUES (@Contenido, @Fecha, @UserId, 'A')
	GO

CREATE PROCEDURE SP_Asignar_Tecnologia @IdProyecto INT, @IdTecnologia INT
	AS
		INSERT INTO TECNOLOGIA_POR_PROYECTO (IdProyecto, IdTecnologia, Estado)
		VALUES (@IdProyecto, @IdTecnologia, 'A')
	GO


CREATE PROCEDURE SP_Agregar_Al_Curso @IdEstudiante CHAR(100), @IdCurso INT
	AS
		INSERT INTO ESTUDIANTE_POR_CURSO (IdEstudiante, IdCurso, Estado)
		VALUES (@IdEstudiante, @IdCurso, 'A')
	GO















