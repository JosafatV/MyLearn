Use MyLearnDB ;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Insertar_Estudiante')
DROP PROCEDURE SP_Insertar_Estudiante   
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Insertar_Propuesta_Subasta')
DROP PROCEDURE SP_Insertar_Propuesta_Subasta   
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Rechazar_Demas_Subastas')
DROP PROCEDURE SP_Rechazar_Demas_Subastas  
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Insertar_Mensaje_Trabajo')
DROP PROCEDURE SP_Insertar_Mensaje_Trabajo  
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Insertar_Respuesta')
DROP PROCEDURE SP_Insertar_Respuesta  
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Insertar_Curso')
DROP PROCEDURE SP_Insertar_Curso  
GO



/*****************SELECTS*****************/
	/*Obtains the values needed to fill the Courses table in student's profile*/
CREATE PROCEDURE SP_Select_Cursos @UserId INT
	AS
		SELECT Curso, SUM(PuntajeBadge) AS Nota, EstadoCurso
		FROM VIEW_CALIFICACIONES
		WHERE IdEstudiante=@UserId AND EstadoBadge='A' OR EstadoBadge='B' 
		GROUP BY Curso, EstadoCurso
	GO

	/**Obtains the grade obtained in a project*/
CREATE PROCEDURE SP_Nota_Poyecto @UserID INT, @ProjectId INT
	AS
		SELECT SUM(PuntajeBadge) AS Nota
		FROM VIEW_CALIFICACIONES
		WHERE IdEstudiante=@UserID AND IdProyecto=@ProjectId AND (EstadoBadge='A' OR EstadoBadge='B')
	GO


/*****************SIMPLE INSERTS*****************/

	/*Creates a new student*/
CREATE PROCEDURE SP_Insertar_Estudiante   
	@Id CHAR(100), @Contrasena CHAR(8), @Sal CHAR(20), @RepositorioArchivos CHAR(100), @CredencialDrive CHAR(100),

	@Nombre CHAR(30), @Apellido CHAR(30), @Carne CHAR(15), @Email CHAR(50), @Telefono CHAR(15), @Pais CHAR(30),
	@Region CHAR(30), @IdUniversidad INT , @RepositorioCodigo CHAR(100), @LinkHojaDeVida CHAR(100)  
	AS
		INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado) 
		VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A')

		INSERT INTO ESTUDIANTE (Id,NombreContacto, ApellidoContacto, Carne, Email, Telefono, Pais, Region,
		IdUniversidad ,FechaInscripcion, RepositorioCodigo, LinkHojaDeVida) 
		VALUES (@Id, @Nombre, @Apellido, @Carne, @Email, @Telefono,@Pais,@Region,@IdUniversidad , GETDATE(), @RepositorioCodigo,
		 @LinkHojaDeVida)
	GO

	/*Creates a new teacher*/
CREATE PROCEDURE SP_Insertar_Profesor
	@Id CHAR(100), @Contrasena CHAR(8), @Sal CHAR(20), @RepositorioArchivos CHAR(100), @CredencialDrive CHAR(100),

	@NombreContacto CHAR(30), @ApellidoContacto CHAR(30), @Email CHAR(50), @Telefono CHAR(15), 
	 @HorarioAtencion CHAR(15), @Pais CHAR(30), @Region CHAR(30), @IdUniversidad INT
		AS
			INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado) 
			VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A')

			INSERT INTO PROFESOR (Id, NombreContacto, ApellidoContacto, Email, Telefono, FechaInscripcion, HorarioAtencion, Pais,
			Region)
			VALUES (@Id, @NombreContacto, @ApellidoContacto, @Email, @Telefono, getDate(), @HorarioAtencion, @Pais,
			@Region)

			INSERT INTO PROFESOR_POR_UNIVERSIDAD (IdProfesor, IdUniversidad, Estado)
			VALUES (@Id, @IdUniversidad, 'A')
		GO

	/*Creates a new company*/
CREATE PROCEDURE SP_Insertar_Empresa
@Id CHAR(100), @Contrasena CHAR(8), @Sal CHAR(20), @RepositorioArchivos CHAR(100), @CredencialDrive CHAR(100),

@NombreContacto CHAR(30), @ApellidoContacto CHAR(30), @NombreEmpresarial CHAR(30), @Email CHAR(50), @Telefono CHAR(15),
 @PaginaWebEmpresa CHAR(30), @Pais CHAR(30), @Region CHAR(30), @RepositorioCodigo CHAR(100)
	AS
		INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado) 
		VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A')

		INSERT INTO EMPRESA (Id, NombreContacto, ApellidoContacto, NombreEmpresarial, Email, Telefono, FechaInscripcion , 
		PaginaWebEmpresa, Pais, Region)
		VALUES (@Id, @NombreContacto, @ApellidoContacto, @NombreEmpresarial, @Email, @Telefono, getDate(),
		@PaginaWebEmpresa, @Pais, @Region) 
	GO

	/*Creates a new administrator - EXTRA POINTS*/
CREATE PROCEDURE SP_Insertar_Admin
@Id CHAR(100), @Contrasena CHAR(8), @Sal CHAR(20), @RepositorioArchivos CHAR(100), @CredencialDrive CHAR(100),
@Nombre CHAR(30), @ApellidoContacto CHAR(30)
	AS
		INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado) 
		VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A')

		INSERT INTO USUARIO_XMP (Id, NombreContacto, ApellidoContacto)
		VALUES (@Id, @Nombre, @ApellidoContacto) 
	GO

	/*Inserts a new technology*/
CREATE PROCEDURE SP_Insertar_Tecnologia @Nombre CHAR(30)
	AS
		INSERT INTO TECNOLOGIA (Nombre, Estado)
		VALUES (@Nombre, 'A')
	GO

	/*Inserts a new university*/
CREATE PROCEDURE SP_Insertar_Universidad @Nombre CHAR(30)
	AS
		INSERT INTO UNIVERSIDAD (Nombre, Estado)
		VALUES (@Nombre, 'A')
	GO

/*****************MULTI-PARTED INSERTS*****************/


/********** UNIVERSIDAD **********/
	/*Creates a new course*/
CREATE PROCEDURE SP_Insertar_Curso @IdProfesor CHAR(100), @Nombre CHAR(30), 
		@Codigo CHAR(10), @IdUniversidad INT, @NotaMinima tinyINT, @FechaInicio DATE , @NumeroGrupo INT
	AS
		DECLARE @IdCurso INT
		INSERT INTO CURSO (Nombre, Codigo, NotaMinima, Estado,FechaInicio, NumeroGrupo)
		VALUES (@Nombre, @Codigo, @NotaMinima, 'A', @FechaInicio , @NumeroGrupo)

		SELECT @IdCurso = scope_identity() 
		INSERT INTO CURSO_POR_PROFESOR (IdCurso, IdProfesor, Estado)
		VALUES (@IdCurso, @IdProfesor, 'A')

		INSERT INTO CURSO_POR_UNIVERSIDAD (IdCurso, IdUniversidad, Estado)
		VALUES (@IdCurso, @IdUniversidad, 'A')

		SELECT @IdCurso
	GO

	/*SP_Terminar_Curso*/

	/*Creates a badge for a course*/
CREATE PROCEDURE SP_Insertar_Badge (@Nombre CHAR (30), @Puntaje TINYINT, @IdCurso INT) 
	AS
		INSERT INTO BADGE (Nombre, Puntaje, IdCurso)
		VALUES (@Nombre, @Puntaje, @IdCurso)
	GO

	/*Grants a student a badge*/
CREATE PROCEDURE SP_Otorgar_Badge (@IdBadge INT, @IdProyecto INT)
	AS
		UPDATE BADGE_POR_PROYECTO 
		SET Estado='O'
		WHERE IdProyecto=@IdProyecto AND IdBadge=@IdBadge
	GO

	/*Marks a student as attending a course*/
CREATE PROCEDURE SP_Agregar_Al_Curso @IdEstudiante CHAR(100), @IdCurso INT
	AS
		INSERT INTO ESTUDIANTE_POR_CURSO (IdEstudiante, IdCurso, Estado)
		VALUES (@IdEstudiante, @IdCurso, 'A')
	GO

	/*Creates a proyect in the proposition stage*/
CREATE PROCEDURE SP_Insertar_Propuesta_Proyecto @IdEstudiante CHAR(100), @Nombre CHAR(30), @Problematica CHAR(100), @Descripcion CHAR(500), @IdCurso INT, @FechaInicio DATE, @FechaFinal DATE, @DocumentoAdicional CHAR(100)
	AS
		DECLARE @IdProyecto INT
		INSERT INTO PROYECTO (Nombre, Problematica, Descripcion, IdCurso, FechaInicio, FechaFinal, DocumentoAdicional, Estado)
		VALUES (@Nombre,@Problematica, @Descripcion, @IdCurso, @FechaInicio, @FechaFinal, @DocumentoAdicional, 'P')

		SELECT @IdProyecto = @@IDENTITY
		INSERT INTO PROYECTO_POR_ESTUDIANTE (IdProyecto, IdEstudiante, Estado)
		VALUES (@IdProyecto, @IdEstudiante, 'P')

		INSERT INTO PROYECTO_POR_PROFESOR (IdProyecto, IdProfesor, Estado)
			SELECT @IdProyecto, Cpp.IdProfesor, 'P' 
			FROM CURSO_POR_PROFESOR AS Cpp 
			WHERE Cpp.IdCurso=@IdCurso
	GO


	/*Marks a proyect proposition as an active project and asigns it badges*/
CREATE PROCEDURE SP_Aceptar_Proyecto @IdProfesor CHAR(100), @IdPropuesta INT, @IdCurso INT 
	AS
		UPDATE PROYECTO
		SET Estado='A', NotaObtenida=0
		WHERE Id=@IdPropuesta

		UPDATE PROYECTO_POR_ESTUDIANTE
		SET Estado='A'
		WHERE IdProyecto=@IdPropuesta

		UPDATE PROYECTO_POR_PROFESOR
		SET Estado='A'
		WHERE IdProyecto=@IdPropuesta

		INSERT INTO BADGE_POR_PROYECTO (IdBadge, IdProyecto, Estado)
			SELECT BADGE.Id, @IdPropuesta, 'P' 
			FROM BADGE 
			WHERE BADGE.IdCurso=@IdCurso
	GO



/********** COMPAÑIAS **********/

	/*Creates a new job in the action state*/
CREATE PROCEDURE SP_Insertar_Trabajo @Nombre CHAR(30), @Descripcion CHAR(500), @IdEmpresa CHAR(100), @FechaInicio DATE, @FechaCierre DATE, @DocumentoAdicional CHAR(100), @presupuesto float
	AS
		INSERT INTO TRABAJO (Nombre, Descripcion, IdEmpresa, FechaInicio, FechaCierre, DocumentoAdicional,PresupuestoBase, Estado)
		VALUES (@Nombre, @Descripcion, @IdEmpresa, @FechaInicio, @FechaCierre, @DocumentoAdicional,@presupuesto , 'P')
	GO

	/*Creates a new offer for the auctions*/
CREATE PROCEDURE SP_Insertar_Propuesta_Subasta @IdTrabajo INT, @IdEstudiante CHAR(100), @Monto INT, @Comentario CHAR(300), @FechaFinal Date
	AS
		INSERT INTO TRABAJO_POR_ESTUDIANTE (IdTrabajo, IdEstudiante, Monto, Comentario, Estado, FechaFinalizacion)
		VALUES (@IdTrabajo, @IdEstudiante, @Monto, @Comentario, 'P', @FechaFinal)
	GO

	/*canceling all others offers to an auction*/
CREATE PROCEDURE SP_Rechazar_Demas_Subastas @IdSubasta INT, @IdEstudiante CHAR(100)
	AS
		UPDATE TRABAJO_POR_ESTUDIANTE
		SET Estado='X'
		WHERE IdTrabajo = @IdSubasta AND IdEstudiante != @IdEstudiante
	GO

	/*accepts an offer to an auction*/
CREATE PROCEDURE SP_Aceptar_Subasta @IdSubasta INT, @IdEstudiante CHAR(100)
	AS
		UPDATE TRABAJO_POR_ESTUDIANTE
		SET Estado='X'
		WHERE IdTrabajo = @IdSubasta AND IdEstudiante != @IdEstudiante

		UPDATE TRABAJO_POR_ESTUDIANTE
		SET Estado='A'
		WHERE IdEstudiante=@IdEstudiante AND IdTrabajo=@IdSubasta
		
		UPDATE TRABAJO
		SET Estado='A'
		WHERE Id=@IdSubasta
	GO

/********** MENSAJERIA **********/
	/*Creates a new message for a project*/
CREATE PROCEDURE SP_Insertar_Mensaje_Proyecto @Contenido CHAR(500), @Adjunto CHAR(500), 
	@IdProyecto INT, @NombreEmisor CHAR(30)
	AS
		DECLARE @IdMensaje BIGINT
		INSERT INTO MENSAJE (Contenido, Adjunto, Fecha, NombreEmisor)
		VALUES (@Contenido, @Adjunto, GETDATE(), @NombreEmisor)
		
		SELECT @IdMensaje = @@IDENTITY
		INSERT INTO MENSAJE_POR_PROYECTO (IdMensaje, IdProyecto, Estado)
		VALUES (@IdMensaje,  @IdProyecto, 'A')
	GO

	/*Creates a new message for a job*/
CREATE PROCEDURE SP_Insertar_Mensaje_Trabajo @Contenido CHAR(500), @Adjunto CHAR(500), 
	@IdTrabajo INT, @NombreEmisor CHAR(30)
	AS
		DECLARE @IdMensaje BIGINT
		INSERT INTO MENSAJE (Contenido, Adjunto, Fecha,NombreEmisor)
		VALUES (@Contenido, @Adjunto, GETDATE(), @NombreEmisor)
		
		SELECT @IdMensaje = @@IDENTITY
		INSERT INTO MENSAJE_POR_TRABAJO (IdMensaje, IdTrabajo, Estado)
		VALUES (@IdMensaje,  @IdTrabajo, 'A')
	GO

	/*creates a new answer to a root message*/
CREATE PROCEDURE SP_Insertar_Respuesta @MensajeRaiz BIGINT, @Contenido CHAR(500), 
				@Adjunto CHAR(500), @NombreEmisor CHAR(30)
	AS
		INSERT INTO RESPUESTA (MensajeRaiz, Contenido, Adjunto, Fecha,NombreEmisor)
		VALUES (@MensajeRaiz, @Contenido, @Adjunto, GETDATE(), @NombreEmisor)
	GO

	/*Assigns a technology to a project*/
CREATE PROCEDURE SP_Asignar_Tecnologia_Proyecto @IdProyecto INT, @IdTecnologia INT
	AS
		INSERT INTO TECNOLOGIA_POR_PROYECTO (IdProyecto, IdTecnologia, Estado)
		VALUES (@IdProyecto, @IdTecnologia, 'A')
	GO

	/*Assigns a technology to a job*/
CREATE PROCEDURE SP_Asignar_Tecnologia_Trabajo @IdTrabajo INT, @IdTecnologia INT
	AS
		INSERT INTO TECNOLOGIA_POR_TRABAJO(IdTrabajo, IdTecnologia, Estado)
		VALUES (@IdTrabajo, @IdTecnologia, 'A')
	GO

/*Automatizar?*/
CREATE PROCEDURE SP_Insertar_Notificacion @Contenido CHAR(500), @Fecha DATETIME, @UserId CHAR(100)
	AS
		INSERT INTO NOTIFICACION (Contenido, Fecha, UserId, Estado)
		VALUES (@Contenido, @Fecha, @UserId, 'A')
	GO

/********** MY LEARN **********/

CREATE PROCEDURE SP_Promedio_Notas @IdEstudiante CHAR(100)
	AS
		SELECT (SUM(NotaEstudiante) / COUNT(IdCurso) * 0.3) AS PonderadoNotas
		FROM VIEW_CURSOS
		WHERE IdEstudiante = @IdEstudiante AND (EstadoCurso = 'E' OR EstadoCurso = 'F')
	GO

CREATE PROCEDURE SP_Promedio_de_Estrellas @IdEstudiante CHAR(100)
	AS
		SELECT (SUM(EstrellasObtenidas) / (COUNT(IdTrabajo) * 5)) * 0.3 AS PromedioEstrellas
		FROM VIEW_TRABAJO
		WHERE IdEstudiante = @IdEstudiante AND (EstadoTrabajo = 'E' OR EstadoTrabajo = 'F')
	GO

CREATE PROCEDURE SP_Promedio_Trabajos_Exitosos @IdEstudiante CHAR(100)
	AS
		SELECT COUNT(IdProyecto) AS ProyectosExitosos
		FROM VIEW_PROYECTOS
		WHERE IdEstudiante=@IdEstudiante AND EstadoProyecto='E'
		UNION
		SELECT COUNT(IdProyecto) AS ProyectosTerminados
		FROM VIEW_PROYECTOS
		WHERE IdEstudiante=@IdEstudiante AND (EstadoProyecto='E' OR EstadoProyecto='F')
	GO

CREATE PROCEDURE SP_Promedio_Cursos_Aprobados @IdEstudiante CHAR(100)
	AS
		SELECT COUNT(IdCurso) AS CursosExitosos
		FROM VIEW_CURSOS
		WHERE IdEstudiante=@IdEstudiante AND EstadoCurso='E'
		UNION
		SELECT COUNT(IdCurso) AS CursosTerminados
		FROM VIEW_CURSOS
		WHERE IdEstudiante=@IdEstudiante AND (EstadoCurso='E' OR EstadoCurso='F')
	GO