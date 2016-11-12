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
