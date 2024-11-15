BACKUP LOG [CINES] 
TO DISK = N'C:\MEIA\CINE_LOG.trn' 
WITH NOFORMAT, NOINIT, 
NAME = N'Copia de seguridad de transacciones horaria', 
STATS = 10;
GO