Use MyLearnDB ;
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_insert_estudiante   ')
DROP PROCEDURE sp_insert_estudiante   
GO




CREATE PROCEDURE sp_insert_estudiante   
	@Id CHAR(100), @Contrasena CHAR(8), @Sal CHAR(20), @RepositorioArchivos CHAR(100),@CredencialDrive CHAR(100),

	@Nombre CHAR(30), @Apellido CHAR(30), @Carne CHAR(15), @Email CHAR(50), @Telefono CHAR(15), @Pais CHAR(30),
	@Region CHAR(30), @FechaInscripcion DATE, @RepositorioCodigo CHAR(100), @LinkHojaDeVida CHAR(100)  
	AS
		INSERT INTO USUARIO (Id,Contrasena,Sal, RepositorioArchivos, CredencialDrive,Estado) 
		VALUES (@Id, @Contrasena,@Sal, @RepositorioArchivos ,@CredencialDrive, 'A' )
		INSERT INTO ESTUDIANTE (Id,NombreContacto, ApellidoContacto, Carne, Email, Telefono, Pais, Region,
		FechaInscripcion, RepositorioCodigo, LinkHojaDeVida) 
		VALUES (@Id, @Nombre, @Apellido, @Carne, @Email, @Telefono,@Pais,@Region, @FechaInscripcion, @RepositorioCodigo,
		 @LinkHojaDeVida)
		
	GO