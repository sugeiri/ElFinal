
IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'IUSUARIO' AND type = 'P')
   DROP PROCEDURE IUSUARIO
GO

CREATE PROCEDURE IUSUARIO
   @ii_usuario			char(20),
   @ii_nombre			varchar(100),
   @ii_id_Tipo_u		int,
   @ii_passw			varchar(MAX),
   @ii_sexo				char(1),
   @ii_email			varchar(150)

AS 
	Declare @cod int =(select isnull(max(id_Tercero),0) as Cod from Tercero);
	Declare @Encrypt varbinary(MAX)  
	Select @Encrypt = EncryptByPassPhrase('key', @ii_passw )  
	
	if exists (select id_Tercero_Email from EMAIL where Email=@ii_email)
		BEGIN
			SELECT 'EE:ESTE CORREO YA ESTA REGISTRADO'
		END
	else
		BEGIN
			INSERT INTO Tercero VALUES(@cod+1,@ii_Nombre,1,'','2020-01-01','A',@ii_sexo)
			INSERT INTO EMAIL values(@cod+1,@ii_email,1)
			INSERT INTO Usuario VALUES(@ii_usuario,@cod+1,@ii_id_Tipo_u,(select @Encrypt),'A')
			Select '00:REGISTRADO'
		END
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
		SELECT '00:Clave Concuerda'
	else
		SELECT 'EE:Clave Incorrecta'
	
GO

grant all on ValidaPass to public
