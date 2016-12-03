	
/*-----------------------	BUSQUEDA POR PROMEDIO-----------------------------------------------------------*/

CREATE PROCEDURE Sp_get_por_promedio @Top INT, @PromedioNotas FLOAT
	AS
		SELECT TOP (@Top) A.IdEstudiante, (NombreContacto+'-'+ G.ApellidoContacto) as NombreContacto, Telefono, Email, 
		(CAST(NotaPromedio*0.3 +PromedioEstrellas*0.3+ (ProyectosExitosos*100/ProyectosTerminados)*0.3 +(CursosExitosos*100/CursosTerminados)*0.1 AS FLOAT)) AS Performance

		FROM
		
		
		(SELECT Id, NombreContacto, Telefono, Email, Pais, ApellidoContacto
			FROM ESTUDIANTE) AS G
		
		JOIN        /*    promedio de notas      */
			(SELECT IdEstudiante, (SUM(Epc.Nota) / COUNT(Epc.IdCurso)) AS NotaPromedio
			FROM ESTUDIANTE_POR_CURSO AS Epc
			WHERE Epc.Estado = 'T'
			GROUP BY IdEstudiante) AS A
		ON G.Id = A.IdEstudiante
		
		JOIN        /*    promedio de estrellas       */
			(SELECT IdEstudiante, CAST((SUM(EstrellasObtenidas) / COUNT(IdTrabajo))*20 AS FLOAT) AS PromedioEstrellas
			FROM VIEW_TRABAJO
			WHERE (EstadoTrabajo = 'T')
			GROUP BY IdEstudiante) AS B
		ON G.Id=B.IdEstudiante
		
		JOIN        /*    tasa trabajos exitosos      */
			(SELECT IdEstudiante, COUNT(Distinct VIEW_TRABAJO.IdTrabajo) AS ProyectosExitosos
			FROM VIEW_TRABAJO
			WHERE VIEW_TRABAJO.Exitoso = 1 AND VIEW_TRABAJO.EstadoTrabajo = 'T'
			GROUP BY IdEstudiante) AS C
		ON G.Id=C.IdEstudiante
		
		JOIN              /*    tasa trabajos terminados      */
			(SELECT IdEstudiante, COUNT(Distinct VIEW_TRABAJO.IdTrabajo) AS ProyectosTerminados
			FROM VIEW_TRABAJO
			WHERE VIEW_TRABAJO.EstadoTrabajo = 'T'
			GROUP BY IdEstudiante) AS D
		On G.Id=D.IdEstudiante
		
		JOIN			/*    cursos exitosos (proyecto)      */
			(SELECT IdEstudiante, COUNT(Distinct ESTUDIANTE_POR_CURSO.IdCurso) AS CursosExitosos
			FROM ESTUDIANTE_POR_CURSO INNER JOIN CURSO ON ESTUDIANTE_POR_CURSO.IdCurso = CURSO.Id
			WHERE (ESTUDIANTE_POR_CURSO.Nota >= CURSO.NotaMinima ) AND ESTUDIANTE_POR_CURSO.Estado = 'T'
			GROUP BY IdEstudiante) AS E
		ON G.Id=E.IdEstudiante
		
		JOIN			/*    cursos terminados  (proyecto)    */
			(SELECT IdEstudiante, COUNT(Distinct ESTUDIANTE_POR_CURSO.IdCurso) AS CursosTerminados
			FROM ESTUDIANTE_POR_CURSO INNER JOIN CURSO ON ESTUDIANTE_POR_CURSO.IdCurso = CURSO.Id
			WHERE ESTUDIANTE_POR_CURSO.Estado = 'T'
			GROUP BY IdEstudiante) AS F
		 ON G.Id=F.IdEstudiante
		
		/*SQL does not compute this again since it큦 made in the select*/
		
		WHERE NotaPromedio >= @PromedioNotas 
		
		ORDER BY Performance DESC
	GO

		
/*-----------------------	BUSQUEDA POR calificacion trabajo (Prom estrellas)-----------------------------------------------------------*/

CREATE PROCEDURE Sp_get_por_calificacion_trabajos @Top INT, @CalificacionTrabajos FLOAT
	AS
		SELECT TOP (@Top) A.IdEstudiante, (NombreContacto+'-'+ G.ApellidoContacto) as NombreContacto, Telefono, Email, 
		(CAST(NotaPromedio*0.3 +PromedioEstrellas*0.3+ (ProyectosExitosos*100/ProyectosTerminados)*0.3 +(CursosExitosos*100/CursosTerminados)*0.1 AS FLOAT)) AS Performance

		FROM
		
		
		(SELECT Id, NombreContacto, Telefono, Email, Pais, ApellidoContacto
			FROM ESTUDIANTE) AS G
		
		JOIN        /*    promedio de notas      */
			(SELECT IdEstudiante, (SUM(Epc.Nota) / COUNT(Epc.IdCurso)) AS NotaPromedio
			FROM ESTUDIANTE_POR_CURSO AS Epc
			WHERE Epc.Estado = 'T'
			GROUP BY IdEstudiante) AS A
		ON G.Id = A.IdEstudiante
		
		JOIN        /*    promedio de estrellas       */
			(SELECT IdEstudiante, CAST((SUM(EstrellasObtenidas) / COUNT(IdTrabajo))*20 AS FLOAT) AS PromedioEstrellas
			FROM VIEW_TRABAJO
			WHERE (EstadoTrabajo = 'T')
			GROUP BY IdEstudiante) AS B
		ON G.Id=B.IdEstudiante
		
		JOIN        /*    tasa trabajos exitosos      */
			(SELECT IdEstudiante, COUNT(Distinct VIEW_TRABAJO.IdTrabajo) AS ProyectosExitosos
			FROM VIEW_TRABAJO
			WHERE VIEW_TRABAJO.Exitoso = 1 AND VIEW_TRABAJO.EstadoTrabajo = 'T'
			GROUP BY IdEstudiante) AS C
		ON G.Id=C.IdEstudiante
		
		JOIN              /*    tasa trabajos terminados      */
			(SELECT IdEstudiante, COUNT(Distinct VIEW_TRABAJO.IdTrabajo) AS ProyectosTerminados
			FROM VIEW_TRABAJO
			WHERE VIEW_TRABAJO.EstadoTrabajo = 'T'
			GROUP BY IdEstudiante) AS D
		On G.Id=D.IdEstudiante
		
		JOIN			/*    cursos exitosos (proyecto)      */
			(SELECT IdEstudiante, COUNT(Distinct ESTUDIANTE_POR_CURSO.IdCurso) AS CursosExitosos
			FROM ESTUDIANTE_POR_CURSO INNER JOIN CURSO ON ESTUDIANTE_POR_CURSO.IdCurso = CURSO.Id
			WHERE (ESTUDIANTE_POR_CURSO.Nota >= CURSO.NotaMinima ) AND ESTUDIANTE_POR_CURSO.Estado = 'T'
			GROUP BY IdEstudiante) AS E
		ON G.Id=E.IdEstudiante
		
		JOIN			/*    cursos terminados  (proyecto)    */
			(SELECT IdEstudiante, COUNT(Distinct ESTUDIANTE_POR_CURSO.IdCurso) AS CursosTerminados
			FROM ESTUDIANTE_POR_CURSO INNER JOIN CURSO ON ESTUDIANTE_POR_CURSO.IdCurso = CURSO.Id
			WHERE ESTUDIANTE_POR_CURSO.Estado = 'T'
			GROUP BY IdEstudiante) AS F
		 ON G.Id=F.IdEstudiante
		
		/*SQL does not compute this again since it큦 made in the select*/
		
		WHERE PromedioEstrellas >=  @CalificacionTrabajos
		
		ORDER BY Performance DESC
	GO

	/*-----------------------	BUSQUEDA POR tasa trabajos exitosos-----------------------------------------------------------*/

CREATE PROCEDURE Sp_get_por_tasa_trabajos_exitosos @Top INT, @tasa FLOAT
	AS
		SELECT TOP (@Top) A.IdEstudiante, (NombreContacto+'-'+ G.ApellidoContacto) as NombreContacto, Telefono, Email, 
		(CAST(NotaPromedio*0.3 +PromedioEstrellas*0.3+ (ProyectosExitosos*100/ProyectosTerminados)*0.3 +(CursosExitosos*100/CursosTerminados)*0.1 AS FLOAT)) AS Performance

		FROM
		
		
		(SELECT Id, NombreContacto, Telefono, Email, Pais, ApellidoContacto
			FROM ESTUDIANTE) AS G
		
		JOIN        /*    promedio de notas      */
			(SELECT IdEstudiante, (SUM(Epc.Nota) / COUNT(Epc.IdCurso)) AS NotaPromedio
			FROM ESTUDIANTE_POR_CURSO AS Epc
			WHERE Epc.Estado = 'T'
			GROUP BY IdEstudiante) AS A
		ON G.Id = A.IdEstudiante
		
		JOIN        /*    promedio de estrellas       */
			(SELECT IdEstudiante, CAST((SUM(EstrellasObtenidas) / COUNT(IdTrabajo))*20 AS FLOAT) AS PromedioEstrellas
			FROM VIEW_TRABAJO
			WHERE (EstadoTrabajo = 'T')
			GROUP BY IdEstudiante) AS B
		ON G.Id=B.IdEstudiante
		
		JOIN        /*    tasa trabajos exitosos      */
			(SELECT IdEstudiante, COUNT(Distinct VIEW_TRABAJO.IdTrabajo) AS ProyectosExitosos
			FROM VIEW_TRABAJO
			WHERE VIEW_TRABAJO.Exitoso = 1 AND VIEW_TRABAJO.EstadoTrabajo = 'T'
			GROUP BY IdEstudiante) AS C
		ON G.Id=C.IdEstudiante
		
		JOIN              /*    tasa trabajos terminados      */
			(SELECT IdEstudiante, COUNT(Distinct VIEW_TRABAJO.IdTrabajo) AS ProyectosTerminados
			FROM VIEW_TRABAJO
			WHERE VIEW_TRABAJO.EstadoTrabajo = 'T'
			GROUP BY IdEstudiante) AS D
		On G.Id=D.IdEstudiante
		
		JOIN			/*    cursos exitosos (proyecto)      */
			(SELECT IdEstudiante, COUNT(Distinct ESTUDIANTE_POR_CURSO.IdCurso) AS CursosExitosos
			FROM ESTUDIANTE_POR_CURSO INNER JOIN CURSO ON ESTUDIANTE_POR_CURSO.IdCurso = CURSO.Id
			WHERE (ESTUDIANTE_POR_CURSO.Nota >= CURSO.NotaMinima ) AND ESTUDIANTE_POR_CURSO.Estado = 'T'
			GROUP BY IdEstudiante) AS E
		ON G.Id=E.IdEstudiante
		
		JOIN			/*    cursos terminados  (proyecto)    */
			(SELECT IdEstudiante, COUNT(Distinct ESTUDIANTE_POR_CURSO.IdCurso) AS CursosTerminados
			FROM ESTUDIANTE_POR_CURSO INNER JOIN CURSO ON ESTUDIANTE_POR_CURSO.IdCurso = CURSO.Id
			WHERE ESTUDIANTE_POR_CURSO.Estado = 'T'
			GROUP BY IdEstudiante) AS F
		 ON G.Id=F.IdEstudiante
		
		/*SQL does not compute this again since it큦 made in the select*/
		
		WHERE (ProyectosExitosos/ProyectosTerminados) >=  @tasa
		
		ORDER BY Performance DESC
	GO


	/*-----------------------	BUSQUEDA POR tasa aprobacion de cursos-----------------------------------------------------------*/

CREATE PROCEDURE Sp_get_por_tasa_aprobacion_de_cursos @Top INT, @tasa FLOAT
	AS
		SELECT TOP (@Top) A.IdEstudiante, (NombreContacto+'-'+ G.ApellidoContacto) as NombreContacto, Telefono, Email, 
		(CAST(NotaPromedio*0.3 +PromedioEstrellas*0.3+ (ProyectosExitosos*100/ProyectosTerminados)*0.3 +(CursosExitosos*100/CursosTerminados)*0.1 AS FLOAT)) AS Performance

		FROM
		
		
		(SELECT Id, NombreContacto, Telefono, Email, Pais, ApellidoContacto
			FROM ESTUDIANTE) AS G
		
		JOIN        /*    promedio de notas      */
			(SELECT IdEstudiante, (SUM(Epc.Nota) / COUNT(Epc.IdCurso)) AS NotaPromedio
			FROM ESTUDIANTE_POR_CURSO AS Epc
			WHERE Epc.Estado = 'T'
			GROUP BY IdEstudiante) AS A
		ON G.Id = A.IdEstudiante
		
		JOIN        /*    promedio de estrellas       */
			(SELECT IdEstudiante, CAST((SUM(EstrellasObtenidas) / COUNT(IdTrabajo))*20 AS FLOAT) AS PromedioEstrellas
			FROM VIEW_TRABAJO
			WHERE (EstadoTrabajo = 'T')
			GROUP BY IdEstudiante) AS B
		ON G.Id=B.IdEstudiante
		
		JOIN        /*    tasa trabajos exitosos      */
			(SELECT IdEstudiante, COUNT(Distinct VIEW_TRABAJO.IdTrabajo) AS ProyectosExitosos
			FROM VIEW_TRABAJO
			WHERE VIEW_TRABAJO.Exitoso = 1 AND VIEW_TRABAJO.EstadoTrabajo = 'T'
			GROUP BY IdEstudiante) AS C
		ON G.Id=C.IdEstudiante
		
		JOIN              /*    tasa trabajos terminados      */
			(SELECT IdEstudiante, COUNT(Distinct VIEW_TRABAJO.IdTrabajo) AS ProyectosTerminados
			FROM VIEW_TRABAJO
			WHERE VIEW_TRABAJO.EstadoTrabajo = 'T'
			GROUP BY IdEstudiante) AS D
		On G.Id=D.IdEstudiante
		
		JOIN			/*    cursos exitosos (proyecto)      */
			(SELECT IdEstudiante, COUNT(Distinct ESTUDIANTE_POR_CURSO.IdCurso) AS CursosExitosos
			FROM ESTUDIANTE_POR_CURSO INNER JOIN CURSO ON ESTUDIANTE_POR_CURSO.IdCurso = CURSO.Id
			WHERE (ESTUDIANTE_POR_CURSO.Nota >= CURSO.NotaMinima ) AND ESTUDIANTE_POR_CURSO.Estado = 'T'
			GROUP BY IdEstudiante) AS E
		ON G.Id=E.IdEstudiante
		
		JOIN			/*    cursos terminados  (proyecto)    */
			(SELECT IdEstudiante, COUNT(Distinct ESTUDIANTE_POR_CURSO.IdCurso) AS CursosTerminados
			FROM ESTUDIANTE_POR_CURSO INNER JOIN CURSO ON ESTUDIANTE_POR_CURSO.IdCurso = CURSO.Id
			WHERE ESTUDIANTE_POR_CURSO.Estado = 'T'
			GROUP BY IdEstudiante) AS F
		 ON G.Id=F.IdEstudiante
		
		/*SQL does not compute this again since it큦 made in the select*/
		
		WHERE (CursosExitosos/CursosTerminados) >=  @tasa
		
		ORDER BY Performance DESC
	GO