BACKUP DATABASE [MyLearnDB] TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\Backup\DifferentialBackup' WITH  DIFFERENTIAL , NOFORMAT, NOINIT,  NAME = N'MyLearnDB-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
GO
