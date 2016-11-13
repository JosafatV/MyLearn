USE [MyLearnDB]
GO


CREATE VIEW [dbo].[VIEW_ESTUDIANTE]
	AS
	SELECT        dbo.ESTUDIANTE.NombreContacto, dbo.ESTUDIANTE.ApellidoContacto, dbo.ESTUDIANTE.Carne, dbo.ESTUDIANTE.Email, dbo.ESTUDIANTE.Telefono, dbo.ESTUDIANTE.Pais, dbo.ESTUDIANTE.Region, 
                         dbo.ESTUDIANTE.FechaInscripcion, dbo.ESTUDIANTE.RepositorioCodigo, dbo.ESTUDIANTE.LinkHojaDeVida, dbo.ESTUDIANTE.Id, dbo.USUARIO.Contrasena, dbo.USUARIO.Sal, dbo.USUARIO.RepositorioArchivos, 
                         dbo.USUARIO.CredencialDrive, dbo.USUARIO.Estado
	FROM            dbo.ESTUDIANTE INNER JOIN
                         dbo.USUARIO ON dbo.ESTUDIANTE.Id = dbo.USUARIO.Id

	GO


	CREATE VIEW [dbo].[VIEW_PROFESOR]
	AS
		SELECT        dbo.USUARIO.*, dbo.PROFESOR.NombreContacto, dbo.PROFESOR.ApellidoContacto, dbo.PROFESOR.Email, dbo.PROFESOR.Telefono, dbo.PROFESOR.Foto, dbo.PROFESOR.FechaInscripcion, 
					      dbo.PROFESOR.Pais, dbo.PROFESOR.HorarioAtencion, dbo.PROFESOR.Region
		FROM          dbo.PROFESOR INNER JOIN
						  dbo.USUARIO ON dbo.PROFESOR.Id = dbo.USUARIO.Id
	GO


		CREATE VIEW [dbo].[VIEW_EMPRESA]
	AS
		SELECT        dbo.EMPRESA.*, dbo.USUARIO.Contrasena, dbo.USUARIO.Sal, dbo.USUARIO.RepositorioArchivos, dbo.USUARIO.CredencialDrive, dbo.USUARIO.Estado
		FROM          dbo.EMPRESA INNER JOIN
                         dbo.USUARIO ON dbo.EMPRESA.Id = dbo.USUARIO.Id
	GO


			CREATE VIEW [dbo].[VIEW_PROYECTOS]
	AS
		SELECT        dbo.PROYECTO.Nombre, dbo.PROYECTO_POR_ESTUDIANTE.Estado
		FROM            dbo.PROYECTO INNER JOIN
                         dbo.PROYECTO_POR_ESTUDIANTE ON dbo.PROYECTO.Id = dbo.PROYECTO_POR_ESTUDIANTE.IdProyecto
	GO


			CREATE VIEW [dbo].[VIEW_OFERTAS_EMPLEO]
	AS
		SELECT        dbo.TRABAJO.Nombre, dbo.TRABAJO_POR_ESTUDIANTE.Estado
		FROM            dbo.TRABAJO INNER JOIN
                         dbo.TRABAJO_POR_ESTUDIANTE ON dbo.TRABAJO.Id = dbo.TRABAJO_POR_ESTUDIANTE.IdTrabajo
	GO


			CREATE VIEW [dbo].[VIEW_CALIFICACIONES]
	AS
SELECT        dbo.ESTUDIANTE_POR_CURSO.IdEstudiante, dbo.CURSO.Nombre AS Curso, dbo.CURSO.Estado AS EstadoCurso, dbo.BADGE.Puntaje AS PuntajeBadge, dbo.BADGE_POR_PROYECTO.Estado AS EstadoBadge, 
                         dbo.PROYECTO.Nombre AS Proyecto, dbo.PROYECTO.Id AS IdProyecto, dbo.PROYECTO.FechaInicio AS InicioProyecto, dbo.PROYECTO.NotaMinima, dbo.PROYECTO.Estado AS EstadoProyecto, dbo.BADGE.Nombre AS Badge
FROM            dbo.BADGE INNER JOIN
                         dbo.BADGE_POR_PROYECTO ON dbo.BADGE.Id = dbo.BADGE_POR_PROYECTO.IdBadge INNER JOIN
                         dbo.CURSO ON dbo.BADGE.IdCurso = dbo.CURSO.Id INNER JOIN
                         dbo.ESTUDIANTE_POR_CURSO ON dbo.CURSO.Id = dbo.ESTUDIANTE_POR_CURSO.IdCurso INNER JOIN
                         dbo.PROYECTO ON dbo.BADGE_POR_PROYECTO.IdProyecto = dbo.PROYECTO.Id AND dbo.CURSO.Id = dbo.PROYECTO.IdCurso
	GO

