
IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'Valida_Correo' AND type = 'P')
   DROP PROCEDURE Valida_Correo
GO

CREATE PROCEDURE Valida_Correo
   @ii_email			varchar(150)

AS 
	if exists (select id_Tercero_Email from EMAIL where Email=@ii_email)
		SELECT '|EE:ESTE CORREO YA ESTA REGISTRADO|'
	else
		SELECT '|00:DISPONIBLE|'

		
GO

grant all on Valida_Correo to public

IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'ITercero' AND type = 'P')
   DROP PROCEDURE ITercero
GO

CREATE PROCEDURE ITercero
   @ii_nombre			varchar(100),
   @ii_sexo				char(1),
   @ii_email			varchar(150)

AS 
	BEGIN TRY
		BEGIN TRANSACTION
			Declare @cod int =(select isnull(max(id_Tercero),0) as Cod from Tercero);
			INSERT INTO Tercero VALUES((select @cod+1),@ii_Nombre,1,'','2020-01-01','A',@ii_sexo)
			INSERT INTO EMAIL values(@cod+1,@ii_email,1)
		COMMIT TRANSACTION;
		Select '|00:'+ TRIM(STR(@cod+1))+'|'
	END TRY
	BEGIN CATCH
		Select 'EE:ERROR AL INSERTAR DATOS'
		ROLLBACK TRANSACTION;
	END CATCH

	
GO

grant all on ITercero to public

IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'IUSUARIO' AND type = 'P')
   DROP PROCEDURE IUSUARIO
GO

CREATE PROCEDURE IUSUARIO
   @ii_Tercero			int,
   @ii_usuario			char(20),
   @ii_id_Tipo_u		int,
   @ii_passw			varchar(MAX)
   
AS 
	  
	BEGIN TRY
		BEGIN TRANSACTION
			Declare @Encrypt varbinary(MAX)  
			Select @Encrypt = EncryptByPassPhrase('key', @ii_passw )
			INSERT INTO Usuario VALUES(@ii_usuario,@ii_Tercero,@ii_id_Tipo_u,(select @Encrypt),'A')
			Select '|00:REGISTRADO|'
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		Select '|EE:ERROR AL INSERTAR DATOS|'
		ROLLBACK TRANSACTION;
	END CATCH
GO

grant all on IUSUARIO to public

IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'ValidaPass' AND type = 'P')
   DROP PROCEDURE ValidaPass
GO

CREATE PROCEDURE ValidaPass
   @ii_usuario			char(20),
   @ii_passw			varchar(MAX)
   
AS 
	if (Select convert(varchar(MAX),DecryptByPassPhrase('key',clave_usuario )) from USUARIO  where id_usuario=@ii_usuario)=@ii_passw
		SELECT '|00:Clave Concuerda|'
	else
		SELECT '|EE:Clave Incorrecta|'
	
GO

grant all on ValidaPass to public
