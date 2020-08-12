
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


IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'Busca_Grupo_xCat' AND type = 'P')
   DROP PROCEDURE Busca_Grupo_xCat
GO

CREATE PROCEDURE Busca_Grupo_xCat
   @ii_cat			int

AS 
		if @ii_cat>0
			BEGIN
				select distinct id_cat_articulo,id_gart_articulo,descr_g_articulo 
					from ARTICULO INNER JOIN GRUPO_ARTICULO 
						ON	id_gart_articulo=id_g_articulo
					where id_cat_articulo=@ii_cat
			END
		else
			BEGIN
				select distinct id_cat_articulo,id_gart_articulo,descr_g_articulo 
					from ARTICULO INNER JOIN GRUPO_ARTICULO 
						ON	id_gart_articulo=id_g_articulo
			END

		
GO

grant all on Busca_Grupo_xCat to public

IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'Busca_Tipo_xGrupo' AND type = 'P')
   DROP PROCEDURE Busca_Tipo_xGrupo
GO

CREATE PROCEDURE Busca_Tipo_xGrupo
   @ii_grup			int

AS 
	if @ii_grup>0
		BEGIN
			select distinct id_gart_articulo,id_tart_articulo,descr_t_articulo
			from ARTICULO INNER JOIN TIPO_ARTICULO 
				ON	id_t_articulo=id_tart_articulo
			where id_gart_articulo=@ii_grup
		END
	else
		BEGIN
			select distinct id_gart_articulo,id_tart_articulo,descr_t_articulo
			from ARTICULO INNER JOIN TIPO_ARTICULO 
				ON	id_t_articulo=id_tart_articulo
		END

		
GO

grant all on Busca_Tipo_xGrupo to public

IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'Busca_Receta_XTipo' AND type = 'P')
   DROP PROCEDURE Busca_Receta_XTipo
GO

CREATE PROCEDURE Busca_Receta_XTipo
   @ii_id			int

AS 
	if @ii_id>0
		BEGIN
			select id_receta,descr_receta,foto_receta,porcion_receta,tiempo_receta 
					from receta  where  estado_receta='A' and id_tipo_receta =@ii_id
		END
	else
		BEGIN
			select id_receta,descr_receta,foto_receta,porcion_receta,tiempo_receta 
					from receta where estado_receta='A' 
		END

		
GO
grant all on Busca_Receta_XTipo to public

IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'Busca_Formula_Receta' AND type = 'P')
   DROP PROCEDURE Busca_Formula_Receta
GO

CREATE PROCEDURE Busca_Formula_Receta
   @ii_id			int

AS 
	select id_articulo_fr,descr_articulo,id_unidad_fr,descr_unidad_m,cant_art_fr,no_sust_art_fr,
		   id_cat_articulo,id_gart_articulo,id_tart_articulo,aplica_inv_articulo,
		   foto_articulo 
	from Formula_receta inner join ARTICULO  ON
			id_articulo=id_articulo_fr INNER JOIN Unidad_Medida
			on id_unidad_fr=id_unidad_m
	where id_receta_fr=@ii_id
	
		
GO
grant all on Busca_Formula_Receta to public

