
Use MyLearnDB ;

CREATE PROCEDURE sp_insert_estudiante
	@Contrasena CHAR(15), @Cedula CHAR(19), @Nombre CHAR(15), @Apellidos CHAR(30), @IdRol tinyINT
	AS
		DECLARE @IdEmpleado INT
		INSERT INTO EMPLEADO (Contrasena,Cedula,Nombre,Apellidos) VALUES (@Contrasena,@Cedula,@Nombre,@Apellidos)
		SELECT @IdEmpleado=@@IDENTITY

		INSERT INTO EMPLEADO_POR_ROL (IdRol, IdEmpleado) VALUES (@IdRol, @IdEmpleado)
		RETURN @IdEmpleado
	GO