Use MyLearnDB ;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_insert_estudiante   ')
DROP PROCEDURE sp_insert_estudiante   
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
	@FechaInscripcion DATE, @HorarioAtencion CHAR(15), @Pais CHAR(30), @Region CHAR(30)
		AS
		INSERT INTO USUARIO (Id,Contrasena, Sal, RepositorioArchivos, CredencialDrive, Estado) 
		VALUES (@Id, @Contrasena, @Sal, @RepositorioArchivos, @CredencialDrive, 'A')

		INSERT INTO PROFESOR (Id, NombreContacto, ApellidoContacto, Email, Telefono, FechaInscripcion, HorarioAtencion, Pais,
		Region)
		VALUES (@Id, @NombreContacto, @ApellidoContacto, @Email, @Telefono, @FechaInscripcion, @HorarioAtencion, @Pais,
		@Region)

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

CREATE PROCEDURE SP_Insertar_Tecnologia
@Id INT, @Nombre CHAR(30)
	AS
		INSERT INTO TECNOLOGIA (Id, Nombre)
		VALUES (@Id, @Nombre)
	GO

CREATE PROCEDURE SP_Insertar_Universidad
@Id INT, @Nombre CHAR(30)
	AS
		INSERT INTO UNIVERSIDAD (Id, Nombre)
		VALUES (@Id, @Nombre)
	GO

CREATE PROCEDURE SP_Select_Cursos
@UserId INT
	AS
		SELECT Curso, SUM(PuntajeBadge) AS Nota, EstadoCurso
		FROM VIEW_CALIFICACIONES
		WHERE IdEstudiante=@UserId AND EstadoBadge='O'
		GROUP BY Curso, EstadoCurso
	GO

CREATE PROCEDURE SP_Nota_Poyecto
@UserID INT, @ProjectId INT
	AS
		SELECT SUM(PuntajeBadge) AS Nota
		FROM VIEW_CALIFICACIONES
		WHERE IdEstudiante=@UserID AND EstadoBadge='O' AND IdProyecto=@ProjectId
	GO