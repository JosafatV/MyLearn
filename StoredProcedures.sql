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
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Agregar_Al_Curso')
	DROP PROCEDURE SP_Agregar_Al_Curso
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Otorgar_Badge')
	DROP PROCEDURE SP_Otorgar_Badge
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Select_Badge_Por_Proyecto')
	DROP PROCEDURE SP_Select_Badge_Por_Proyecto
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Insertar_Propuesta_Proyecto')
	DROP PROCEDURE SP_Insertar_Propuesta_Proyecto
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Insertar_Empresa')
	DROP PROCEDURE  SP_Insertar_Empresa
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Select_Cursos_Estudiante')
	DROP PROCEDURE SP_Select_Cursos_Estudiante
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Buscar_Subastas_Por_Tecnologia_Nombre')
	DROP PROCEDURE SP_Buscar_Subastas_Por_Tecnologia_Nombre
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Select_Cursos_De_Universidad')
	DROP PROCEDURE SP_Select_Cursos_De_Universidad
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Select_Badge_Por_Proyecto_No_Otorgado')
	DROP PROCEDURE SP_Select_Badge_Por_Proyecto_No_Otorgado
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_CursosAprobados')
DROP PROCEDURE SP_CursosAprobados
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_CursosReprobados')
DROP PROCEDURE SP_CursosReprobados
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_TrabajosExitosos')
DROP PROCEDURE SP_TrabajosExitosos
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_TrabajosNoExitosos')
DROP PROCEDURE SP_TrabajosNoExitosos
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Promedio_Notas')
DROP PROCEDURE SP_Promedio_Notas
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'dbo.SP_Get_Last_User_Id')
	DROP PROCEDURE dbo.SP_Get_Last_User_Id

IF OBJECT_ID (N'dbo.FN_Get_Last_User_Id', N'FN') IS NOT NULL  
    DROP FUNCTION dbo.FN_Get_Last_User_Id;  
GO  


	/*FUNCTIONS*/
CREATE FUNCTION dbo.FN_Get_Last_User_Id()  
	RETURNS CHAR(100)   
	AS    
		BEGIN  
			DECLARE @generated CHAR(100);
			SELECT TOP 1 @generated = USUARIO.Id  
			FROM USUARIO ORDER BY CAST ( USUARIO.Id AS INT )DESC
			IF (@generated IS NULL)   
				SET @generated = '0';
		RETURN @generated;
	END;  
GO

CREATE FUNCTION dbo.FN_Promedio(@IdEstudiante CHAR(100))  
	RETURNS FLOAT   
	AS    
		BEGIN  
			DECLARE @generated FLOAT;
			SELECT TOP (1)  @generated = (SUM(ESTUDIANTE_POR_CURSO.Nota) / COUNT(Distinct ESTUDIANTE_POR_CURSO.IdCurso ) ) 
			FROM ESTUDIANTE_POR_CURSO
			WHERE ESTUDIANTE_POR_CURSO.IdEstudiante = @IdEstudiante AND (ESTUDIANTE_POR_CURSO.Estado = 'T')

			IF (@generated IS NULL)   
				SET @generated = 0;
		RETURN @generated;
	END;  
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

	CREATE PROCEDURE dbo.SP_Get_Last_User_Id
AS         
    SELECT dbo.FN_Get_Last_User_Id()   
	
GO

/*****************SIMPLE INSERTS*****************/

	/*Creates a new student*/
CREATE PROCEDURE SP_Insertar_Estudiante   
	@Id CHAR(100), @Contrasena VARCHAR(50), @Sal VARCHAR(100), @RepositorioArchivos CHAR(100), @CredencialDrive CHAR(100),

	@Nombre CHAR(30), @Apellido CHAR(30), @Carne CHAR(15), @Email CHAR(50), @Telefono CHAR(15), @Pais CHAR(30),
	@Region CHAR(30), @IdUniversidad INT , @RepositorioCodigo CHAR(100), @LinkHojaDeVida CHAR(100) , @UserName CHAR(40) 
	AS
		INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado, NombreDeUsuario) 
		VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A',@UserName)

		INSERT INTO ESTUDIANTE (Id,NombreContacto, ApellidoContacto, Carne, Email, Telefono, Pais, Region,
		IdUniversidad ,FechaInscripcion, RepositorioCodigo, LinkHojaDeVida) 
		VALUES (@Id, @Nombre, @Apellido, @Carne, @Email, @Telefono,@Pais,@Region,@IdUniversidad, GETDATE(), @RepositorioCodigo,
		 @LinkHojaDeVida)
	GO

	/*Creates a new teacher*/
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Insertar_Profesor')
DROP PROCEDURE  SP_Insertar_Profesor  
GO
CREATE PROCEDURE SP_Insertar_Profesor
	@Id CHAR(100), @Contrasena VARCHAR(50), @Sal VARCHAR(100), @RepositorioArchivos CHAR(100), @CredencialDrive CHAR(100),

	@NombreContacto CHAR(30), @ApellidoContacto CHAR(30), @Email CHAR(50), @Telefono CHAR(15), 
	 @HorarioAtencion CHAR(15), @Pais CHAR(30), @Region CHAR(30), @IdUniversidad INT, @UserName CHAR(40) 
		AS
			INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado, NombreDeUsuario) 
			VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A', @UserName)

			INSERT INTO PROFESOR (Id, NombreContacto, ApellidoContacto, Email, Telefono, FechaInscripcion, HorarioAtencion, Pais,
			Region)
			VALUES (@Id, @NombreContacto, @ApellidoContacto, @Email, @Telefono, getDate(), @HorarioAtencion, @Pais,
			@Region)

			INSERT INTO PROFESOR_POR_UNIVERSIDAD (IdProfesor, IdUniversidad, Estado)
			VALUES (@Id, @IdUniversidad, 'A')
		GO

	/*Creates a new company*/
CREATE PROCEDURE SP_Insertar_Empresa
@Id CHAR(100), @Contrasena VARCHAR(50), @Sal VARCHAR(100), @RepositorioArchivos CHAR(100), @CredencialDrive CHAR(100),

@NombreContacto CHAR(30), @ApellidoContacto CHAR(30), @NombreEmpresarial CHAR(30), @Email CHAR(50), @Telefono CHAR(15),
 @PaginaWebEmpresa CHAR(30), @Pais CHAR(30), @Region CHAR(30), @RepositorioCodigo CHAR(100), @UserName CHAR(40) 
	AS
		INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado, NombreDeUsuario) 
		VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A', @UserName)

		INSERT INTO EMPRESA (Id, NombreContacto, ApellidoContacto, NombreEmpresarial, Email, Telefono, FechaInscripcion , 
		PaginaWebEmpresa, Pais, Region)
		VALUES (@Id, @NombreContacto, @ApellidoContacto, @NombreEmpresarial, @Email, @Telefono, getDate(),
		@PaginaWebEmpresa, @Pais, @Region) 
	GO

	/*Creates a new administrator - EXTRA POINTS*/
CREATE PROCEDURE SP_Insertar_Admin
@Id CHAR(100), @Contrasena VARCHAR(50), @Sal VARCHAR(100), @RepositorioArchivos CHAR(100), @CredencialDrive CHAR(100),
@Nombre CHAR(30), @ApellidoContacto CHAR(30), @NombreUsuario CHAR(40)
	AS
		INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado, NombreDeUsuario) 
		VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A', @NombreUsuario)

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

CREATE PROCEDURE SP_Select_Cursos_Estudiante @IdEstudiante CHAR(100) 
	AS
		SELECT CURSO.Id, CURSO.Nombre, CURSO.Codigo, CURSO.NotaMinima, CURSO.FechaInicio, CURSO.NumeroGrupo, ESTUDIANTE_POR_CURSO.Estado
		FROM CURSO INNER JOIN ESTUDIANTE_POR_CURSO ON CURSO.Id = ESTUDIANTE_POR_CURSO.IdCurso
		WHERE ESTUDIANTE_POR_CURSO.IdEstudiante = @IdEstudiante AND ( ESTUDIANTE_POR_CURSO.Estado = 'A' OR ESTUDIANTE_POR_CURSO.Estado = 'T')		
	GO

CREATE PROCEDURE SP_Select_Cursos_De_Universidad ( @IdUniversidad INT , @EstadoCurso CHAR(1), @IdEstudiante CHAR(100) )
	AS
		SELECT DISTINCT (CURSO.Id) , CURSO.Nombre, CURSO.Codigo, CURSO.NotaMinima, CURSO.FechaInicio, CURSO.NumeroGrupo, CURSO.Estado
		FROM CURSO INNER JOIN CURSO_POR_UNIVERSIDAD ON CURSO.Id = CURSO_POR_UNIVERSIDAD.IdCurso,
				   ESTUDIANTE_POR_CURSO 	

			WHERE 
		/*ESTUDIANTE_POR_CURSO.IdEstudiante = @IdEstudiante AND  */
		CURSO_POR_UNIVERSIDAD.IdUniversidad = @IdUniversidad AND
		CURSO.Estado = @EstadoCurso AND
		not exists ( select * FROM ESTUDIANTE_POR_CURSO  where ESTUDIANTE_POR_CURSO.IdEstudiante = @IdEstudiante AND ESTUDIANTE_POR_CURSO.IdCurso = CURSO.Id )  
	GO

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
CREATE PROCEDURE SP_TerminarCurso (@IdCurso INT)
	AS
		UPDATE CURSO 
		SET CURSO.ESTADO = 'T'
		WHERE CURSO.Id = @IdCurso;

		UPDATE ESTUDIANTE_POR_CURSO 
		SET ESTUDIANTE_POR_CURSO.ESTADO = 'T'
		WHERE ESTUDIANTE_POR_CURSO.IdCurso = @IdCurso ;

		/*Calcular nota*/

	GO

/*  termina todos los proyectos de un curso */
CREATE PROCEDURE SP_Terminar_Proyectos_De_Un_Curso (@IdCurso INT)
	AS
	
		UPDATE PROYECTO
		SET ESTADO = 'T'
		WHERE IdCurso = @IdCurso;

	GO

CREATE PROCEDURE SP_Terminar_Proyecto_De_Un_Estudiante (@IdProyecto INT , @IdEstudiante CHAR(100), @Estado CHAR(1))
	AS
	
		UPDATE PROYECTO_POR_ESTUDIANTE
		SET ESTADO = @Estado
		WHERE IdProyecto = @IdProyecto  AND IdEstudiante = @IdEstudiante;

		UPDATE PROYECTO
		SET ESTADO = @Estado
		WHERE @IdProyecto = @IdProyecto;

	GO

	/*Creates a badge for a course*/
CREATE PROCEDURE SP_Insertar_Badge (@Nombre CHAR (30), @Puntaje TINYINT, @IdCurso INT) 
	AS
		INSERT INTO BADGE (Nombre, Puntaje, IdCurso)
		VALUES (@Nombre, @Puntaje, @IdCurso)
	GO

	/*Grants a student a badge*/
CREATE PROCEDURE SP_Otorgar_Badge (@IdBadge INT, @IdProyecto INT , @Estado CHAR(1))
	AS
		UPDATE BADGE_POR_PROYECTO 
		SET Estado=@Estado
		WHERE IdProyecto=@IdProyecto AND IdBadge=@IdBadge
	GO

CREATE PROCEDURE SP_Incrementar_Puntaje_Proyecto (@IdBadge INT, @IdProyecto INT)
	AS
		DECLARE @Puntaje TINYINT
		DECLARE @PuntajeActual TINYINT

		SELECT @Puntaje = BADGE.Puntaje
		FROM BADGE WHERE BADGE.Id = @IdBadge

		SELECT @PuntajeActual = PROYECTO.NotaObtenida 
		FROM PROYECTO WHERE PROYECTO.Id = @IdProyecto
		  
		UPDATE PROYECTO 
		SET NotaObtenida = (@PuntajeActual + @Puntaje)
		WHERE PROYECTO.Id = @IdProyecto

	GO

	/*badges obtenidosen un p*/
CREATE PROCEDURE SP_Select_Badge_Por_Proyecto (@IdProyecto INT,@Estado CHAR(1))
	AS
		SELECT BADGE.Id, BADGE.Nombre, BADGE.Puntaje, BADGE.IdCurso
		FROM BADGE JOIN BADGE_POR_PROYECTO ON BADGE.Id = BADGE_POR_PROYECTO.IdBadge
		WHERE BADGE_POR_PROYECTO.IdProyecto = @IdProyecto AND BADGE_POR_PROYECTO.Estado = @Estado
	GO

	/*badges obtenidosen un p*/
CREATE PROCEDURE SP_Select_Badge_Por_Proyecto_No_Otorgado (@IdCurso INT,@IdProyecto INT)
	AS
		SELECT DISTINCT (BADGE.Id), BADGE.Nombre, BADGE.Puntaje, BADGE.IdCurso
		FROM BADGE INNER JOIN CURSO ON BADGE.IdCurso= CURSO.Id , BADGE_POR_PROYECTO 

		WHERE CURSO.Id = @IdCurso  
				AND NOT EXISTS (SELECT * FROM BADGE_POR_PROYECTO WHERE BADGE_POR_PROYECTO.IdProyecto = @IdProyecto) 
	GO

	/*Marks a student as attending a course*/
CREATE PROCEDURE SP_Agregar_Al_Curso @IdEstudiante CHAR(100), @IdCurso INT
	AS
		INSERT INTO ESTUDIANTE_POR_CURSO (IdEstudiante, IdCurso, Estado)
		VALUES (@IdEstudiante, @IdCurso, 'A')
	GO

	/*Creates a proyect in the proposition stage*/
CREATE PROCEDURE SP_Insertar_Propuesta_Proyecto @IdEstudiante CHAR(100), @Nombre CHAR(30),
				 @Problematica CHAR(100), @Descripcion CHAR(500), @IdCurso INT, @FechaInicio DATE,
				  @FechaFinal DATE, @DocumentoAdicional CHAR(100), @Estado CHAR(1), @Nota TINYINT
	AS
		DECLARE @IdProyecto INT
		INSERT INTO 
		PROYECTO (Nombre, Problematica, Descripcion, IdCurso, FechaInicio, FechaFinal, DocumentoAdicional, Estado, NotaObtenida)
		VALUES (@Nombre,@Problematica, @Descripcion, @IdCurso, @FechaInicio, @FechaFinal, @DocumentoAdicional, @Estado,@Nota)

		SELECT @IdProyecto = @@IDENTITY
		INSERT INTO PROYECTO_POR_ESTUDIANTE (IdProyecto, IdEstudiante, Estado)
		VALUES (@IdProyecto, @IdEstudiante, @Estado)

		INSERT INTO PROYECTO_POR_PROFESOR (IdProyecto, IdProfesor, Estado)
			SELECT @IdProyecto, Cpp.IdProfesor, @Estado
			FROM CURSO_POR_PROFESOR AS Cpp 
			WHERE Cpp.IdCurso=@IdCurso

		SELECT @IdProyecto
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


CREATE PROCEDURE SP_Select_tecnologias_De_Proyecto( @IdProyecto INT) 
	AS
		SELECT TECNOLOGIA.*
		FROM TECNOLOGIA JOIN TECNOLOGIA_POR_PROYECTO ON TECNOLOGIA.Id = TECNOLOGIA_POR_PROYECTO.IdTecnologia
		
	GO


/********** COMPAÑIAS **********/

CREATE PROCEDURE SP_Buscar_Subastas_Por_Tecnologia_Nombre (@Tecnologia CHAR(30), @Nombre CHAR(30), @NumResultados INT)
	AS
	SELECT DISTINCT TOP(@NumResultados) TRABAJO.ID , TRABAJO.NOMBRE, TRABAJO.Descripcion, TRABAJO.IdEmpresa, TRABAJO.FechaInicio, TRABAJO.FechaCierre,
	TRABAJO.DocumentoAdicional, TRABAJO.EstrellasObtenidas, TRABAJO.PresupuestoBase, TRABAJO.Estado, TRABAJO.Exitoso

	FROM TRABAJO INNER JOIN TECNOLOGIA_POR_TRABAJO ON TRABAJO.Id = TECNOLOGIA_POR_TRABAJO.IdTrabajo
		INNER JOIN TECNOLOGIA ON TECNOLOGIA.Id = TECNOLOGIA_POR_TRABAJO.IdTecnologia
	WHERE TECNOLOGIA.Nombre LIKE  '%'+@Nombre+'%' or TRABAJO.Nombre = @Nombre 

GO


	/*Creates a new job in the action state*/
CREATE PROCEDURE SP_Insertar_Trabajo @Nombre CHAR(30), @Descripcion CHAR(500), @IdEmpresa CHAR(100), @FechaInicio DATE, @FechaCierre DATE, @DocumentoAdicional CHAR(100), @presupuesto float
	AS
		INSERT INTO TRABAJO (Nombre, Descripcion, IdEmpresa, FechaInicio, FechaCierre, DocumentoAdicional,PresupuestoBase, Estado)
		VALUES (@Nombre, @Descripcion, @IdEmpresa, @FechaInicio, @FechaCierre, @DocumentoAdicional,@presupuesto , 'P')
	GO
	
CREATE PROCEDURE SP_Select_Tecnologias_Por_Trabajo @IdTrabajo INT
	AS
		SELECT TECNOLOGIA.Id , TECNOLOGIA.Nombre,TECNOLOGIA.Estado
		FROM TECNOLOGIA INNER JOIN TECNOLOGIA_POR_TRABAJO ON TECNOLOGIA.Id = TECNOLOGIA_POR_TRABAJO.IdTecnologia 
		WHERE TECNOLOGIA_POR_TRABAJO.IdTrabajo = @IdTrabajo
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

CREATE PROCEDURE SP_CursosAprobados @IdEstudiante CHAR(100)
	AS
		SELECT COUNT(Distinct ESTUDIANTE_POR_CURSO.IdCurso)
		FROM ESTUDIANTE_POR_CURSO INNER JOIN CURSO ON ESTUDIANTE_POR_CURSO.IdCurso = CURSO.Id
		WHERE ESTUDIANTE_POR_CURSO.IdEstudiante = @IdEstudiante AND (ESTUDIANTE_POR_CURSO.Nota >= CURSO.NotaMinima )
					AND ESTUDIANTE_POR_CURSO.Estado = 'T'

	GO

CREATE PROCEDURE SP_CursosReprobados @IdEstudiante CHAR(100)
	AS
		SELECT COUNT(Distinct ESTUDIANTE_POR_CURSO.IdCurso)
		FROM ESTUDIANTE_POR_CURSO INNER JOIN CURSO ON ESTUDIANTE_POR_CURSO.IdCurso = CURSO.Id
		WHERE ESTUDIANTE_POR_CURSO.IdEstudiante = @IdEstudiante AND (ESTUDIANTE_POR_CURSO.Nota < CURSO.NotaMinima )
					AND ESTUDIANTE_POR_CURSO.Estado = 'T'

GO

CREATE PROCEDURE SP_TrabajosExitosos @IdEstudiante CHAR(100)
	AS
		SELECT COUNT(Distinct VIEW_TRABAJO.IdTrabajo)
		FROM VIEW_TRABAJO
		WHERE VIEW_TRABAJO.IdEstudiante = @IdEstudiante AND VIEW_TRABAJO.Exitoso = 1
					AND VIEW_TRABAJO.EstadoTrabajo = 'T'

GO

CREATE PROCEDURE SP_TrabajosNoExitosos @IdEstudiante CHAR(100)
	AS
		SELECT COUNT(Distinct VIEW_TRABAJO.IdTrabajo)
		FROM VIEW_TRABAJO
		WHERE VIEW_TRABAJO.IdEstudiante = @IdEstudiante AND VIEW_TRABAJO.Exitoso = 0
					AND VIEW_TRABAJO.EstadoTrabajo = 'T'

GO
/********** MY LEARN **********/



CREATE PROCEDURE SP_Promedio_Notas @IdEstudiante CHAR(100)
	AS
		SELECT dbo.FN_Promedio( @IdEstudiante) 


	GO
/*
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
*/

CREATE PROCEDURE SP_MyEmployee @Top INT, @Pais Char(30)
	AS
		SELECT TOP (20) A.IdEstudiante, NombreContacto, Telefono, Email, CAST(NotaPromedio*0.3+PromedioEstrellas*0.3+(ProyectosExitosos*100/ProyectosTerminados)*0.3+(CursosExitosos*100/CursosTerminados)*0.1 AS FLOAT) AS Performance
		FROM 
			(SELECT IdEstudiante, (SUM(Epc.Nota) / COUNT(Epc.IdCurso)) AS NotaPromedio
			FROM ESTUDIANTE_POR_CURSO AS Epc
			WHERE Epc.Estado = 'E' OR Epc.Estado = 'F' 
			GROUP BY IdEstudiante) AS A
		JOIN
			(SELECT IdEstudiante, CAST((SUM(EstrellasObtenidas) / COUNT(IdTrabajo))*20 AS FLOAT) AS PromedioEstrellas
			FROM VIEW_TRABAJO
			WHERE (EstadoTrabajo = 'E' OR EstadoTrabajo = 'F')
			GROUP BY IdEstudiante) AS B
		ON A.IdEstudiante=B.IdEstudiante
		JOIN
			(SELECT IdEstudiante, COUNT(IdProyecto) AS ProyectosExitosos
			FROM VIEW_PROYECTOS
			WHERE EstadoProyecto='E'
			GROUP BY IdEstudiante) AS C
		ON A.IdEstudiante=C.IdEstudiante
		JOIN
			(SELECT IdEstudiante, COUNT(IdProyecto) AS ProyectosTerminados
			FROM VIEW_PROYECTOS
			WHERE (EstadoProyecto='E' OR EstadoProyecto='F')
			GROUP BY IdEstudiante) AS D
		On A.IdEstudiante=D.IdEstudiante
		JOIN
			(SELECT IdEstudiante, COUNT(IdCurso) AS CursosExitosos
			FROM VIEW_CURSOS_MYEMPLOYEE
			WHERE EstadoEpc='E'
			GROUP BY IdEstudiante) AS E
		ON A.IdEstudiante=E.IdEstudiante
		JOIN
			(SELECT IdEstudiante, COUNT(IdCurso) AS CursosTerminados
			FROM VIEW_CURSOS_MYEMPLOYEE
			WHERE (EstadoEpc='E' OR EstadoEpc='F')
			GROUP BY IdEstudiante) AS F
		 ON A.IdEstudiante=F.IdEstudiante
		 JOIN 
			(SELECT Id, NombreContacto, Telefono, Email, Pais
			FROM ESTUDIANTE) AS G
		ON A.IdEstudiante=G.Id
		WHERE Pais=@Pais
		ORDER BY Performance DESC
	GO



	
CREATE PROCEDURE SP_MyEmployee_Custom @Top INT, @PorcentajeNotas INT, @PorcentajeEstrellas INT, @Proyectos INt, @Trabajos INT
	AS
		SELECT TOP (20) A.IdEstudiante, NombreContacto, Telefono, Email, CAST(NotaPromedio*@PorcentajeNotas+PromedioEstrellas*@PorcentajeEstrellas+(ProyectosExitosos*100/ProyectosTerminados)*@Proyectos+(CursosExitosos*100/CursosTerminados)*@Trabajos AS FLOAT) AS Performance
		FROM 
			(SELECT IdEstudiante, (SUM(Epc.Nota) / COUNT(Epc.IdCurso)) AS NotaPromedio
			FROM ESTUDIANTE_POR_CURSO AS Epc
			WHERE Epc.Estado = 'E' OR Epc.Estado = 'F' 
			GROUP BY IdEstudiante) AS A
		JOIN
			(SELECT IdEstudiante, CAST((SUM(EstrellasObtenidas) / COUNT(IdTrabajo))*20 AS FLOAT) AS PromedioEstrellas
			FROM VIEW_TRABAJO
			WHERE (EstadoTrabajo = 'E' OR EstadoTrabajo = 'F')
			GROUP BY IdEstudiante) AS B
		ON A.IdEstudiante=B.IdEstudiante
		JOIN
			(SELECT IdEstudiante, COUNT(IdProyecto) AS ProyectosExitosos
			FROM VIEW_PROYECTOS
			WHERE EstadoProyecto='E'
			GROUP BY IdEstudiante) AS C
		ON A.IdEstudiante=C.IdEstudiante
		JOIN
			(SELECT IdEstudiante, COUNT(IdProyecto) AS ProyectosTerminados
			FROM VIEW_PROYECTOS
			WHERE (EstadoProyecto='E' OR EstadoProyecto='F')
			GROUP BY IdEstudiante) AS D
		On A.IdEstudiante=D.IdEstudiante
		JOIN
			(SELECT IdEstudiante, COUNT(IdCurso) AS CursosExitosos
			FROM VIEW_CURSOS_MYEMPLOYEE
			WHERE EstadoEpc='E'
			GROUP BY IdEstudiante) AS E
		ON A.IdEstudiante=E.IdEstudiante
		JOIN
			(SELECT IdEstudiante, COUNT(IdCurso) AS CursosTerminados
			FROM VIEW_CURSOS_MYEMPLOYEE
			WHERE (EstadoEpc='E' OR EstadoEpc='F')
			GROUP BY IdEstudiante) AS F
		 ON A.IdEstudiante=F.IdEstudiante
		 JOIN 
			(SELECT Id, NombreContacto, Telefono, Email
			FROM ESTUDIANTE) AS G
		ON A.IdEstudiante=G.Id
		ORDER BY Performance DESC
	GO
