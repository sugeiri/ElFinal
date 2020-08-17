
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
		   id_cat_articulo,id_gart_articulo,descr_g_articulo,id_tart_articulo,descr_t_articulo,aplica_inv_articulo,
		   foto_articulo 
	from Formula_receta 
			inner join ARTICULO  ON
				id_articulo=id_articulo_fr 
			INNER JOIN Unidad_Medida on 
				id_unidad_fr=id_unidad_m 
			INNER JOIN TIPO_ARTICULO ON 
				id_tart_articulo=id_t_articulo
			INNER JOIN GRUPO_ARTICULO ON 
				id_gart_articulo=id_g_articulo
	where id_receta_fr=@ii_id
	
		
GO
grant all on Busca_Formula_Receta to public


IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'ICarrito' AND type = 'P')
   DROP PROCEDURE ICarrito
GO

CREATE PROCEDURE ICarrito
   @ii_usuario		varchar(20),
   @ii_receta		int,
   @ii_articulo		int,
   @ii_cant			decimal(12,2),
   @ii_valor		decimal(12,2)

AS 
	BEGIN TRY
		BEGIN TRANSACTION
		 	Declare @cant_or decimal(12,2) =(select isnull(max(cant_cc),0) as Cod from Carro_compra where id_usuario_cc=@ii_usuario and id_articulo_cc=@ii_articulo);
			declare @sum decimal(12,2)
			DECLARE @CArt int
			select @CArt=cant_f001 from Busca_Cant_art(@ii_receta,@ii_articulo,@ii_cant)
			set @sum=@cant_or+@CArt
			Declare @Importe decimal(12,2) =@sum*@ii_valor 
			if @cant_or<=0 
			BEGIN
				INSERT INTO Carro_compra values(@ii_usuario,@ii_articulo,(select @sum),@ii_valor,(select @Importe))
			END
			ELSE
			BEGIN
			UPDATE Carro_compra SET cant_cc=@sum,monto_cc=@Importe where id_usuario_cc=@ii_usuario and  id_articulo_cc=@ii_articulo
			END
			Select '|00:Insertado|'
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		Select 'EE:ERROR AL INSERTAR DATOS'
		ROLLBACK TRANSACTION;
	END CATCH

	
GO

grant all on ICarrito to public


IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'Consulta_Carro' AND type = 'P')
   DROP PROCEDURE Consulta_Carro
GO

CREATE PROCEDURE Consulta_Carro
   @ii_usuario		varchar(20)

AS 
	select id_usuario_cc,id_articulo_cc,descr_articulo,foto_articulo,cant_cc,valor_cc,monto_cc 
	from Carro_compra inner join ARTICULO 
	on id_articulo=id_articulo_cc
	where id_usuario_cc=@ii_usuario
	
		
GO
grant all on Consulta_Carro to public


IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'UCarrito' AND type = 'P')
   DROP PROCEDURE UCarrito
GO

CREATE PROCEDURE UCarrito
   @ii_usuario		varchar(20),
   @ii_articulo		int,
   @ii_cant			decimal(12,2),
   @ii_valor		decimal(12,2)

AS 
	BEGIN TRY
		BEGIN TRANSACTION
			if @ii_cant>0 
				BEGIN
					UPDATE Carro_compra SET cant_cc=@ii_cant, 
											valor_cc=@ii_valor,
											monto_cc=(@ii_cant*@ii_valor)
					WHERE  id_usuario_cc=@ii_usuario and
						   id_articulo_cc=@ii_articulo
				END
			ELSE
				BEGIN
					delete Carro_compra WHERE id_usuario_cc=@ii_usuario and id_articulo_cc=@ii_articulo
				END
			Select '|00:Modificado|'
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		Select 'EE:ERROR AL MODIFICAR DATOS'
		ROLLBACK TRANSACTION;
	END CATCH

	
GO

grant all on UCarrito to public



IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'Busca_Articulo_XCat' AND type = 'P')
   DROP PROCEDURE Busca_Articulo_XCat
GO

CREATE PROCEDURE Busca_Articulo_XCat
   @ii_id			int

AS 
	if @ii_id>0
		BEGIN
			select distinct id_articulo,descr_articulo,id_cat_articulo,
					id_gart_articulo,id_tart_articulo,aplica_inv_articulo,foto_articulo
			from ARTICULO 
			where id_cat_articulo=@ii_id and estado_articulo='A'
		END
	else
		BEGIN
			select distinct id_articulo,descr_articulo,id_cat_articulo,
					id_gart_articulo,id_tart_articulo,aplica_inv_articulo,foto_articulo
			from ARTICULO 
			where estado_articulo='A' 
		END

		
GO
grant all on Busca_Articulo_XCat to public


IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'IArt_Carrito' AND type = 'P')
   DROP PROCEDURE IArt_Carrito
GO

CREATE PROCEDURE IArt_Carrito
   @ii_usuario		varchar(20),
   @ii_articulo		int,
   @ii_cant			decimal(12,2),
   @ii_valor		decimal(12,2)

AS 
	BEGIN TRY
		BEGIN TRANSACTION
		 	Declare @cant_or decimal(12,2) =(select isnull(max(cant_cc),0) as Cod from Carro_compra where id_usuario_cc=@ii_usuario and id_articulo_cc=@ii_articulo);
			declare @sum decimal(12,2)
			set @sum=@cant_or+@ii_cant
			Declare @Importe decimal(12,2) =@sum*@ii_valor 
			if @cant_or<=0 
			BEGIN
				INSERT INTO Carro_compra values(@ii_usuario,@ii_articulo,(select @sum),@ii_valor,(select @Importe))
			END
			ELSE
			BEGIN
			UPDATE Carro_compra SET cant_cc=@sum,monto_cc=@Importe where id_usuario_cc=@ii_usuario and  id_articulo_cc=@ii_articulo
			END
			Select '|00:Insertado|'
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		Select 'EE:ERROR AL INSERTAR DATOS'
		ROLLBACK TRANSACTION;
	END CATCH

	
GO

grant all on IArt_Carrito to public


IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'Busca_Articulo_Equivalente' AND type = 'P')
   DROP PROCEDURE Busca_Articulo_Equivalente
GO

CREATE PROCEDURE Busca_Articulo_Equivalente
   @ii_id			int

AS 
	declare @cat int
	declare @grupo int
	declare @tipo int

	select @cat=id_cat_articulo,
		   @grupo=id_gart_articulo,
		   @tipo=id_tart_articulo
	from ARTICULO  
	where id_articulo=@ii_id

	select * from ARTICULO
		where id_cat_articulo=@cat and
			  id_gart_articulo=@grupo and
			  id_tart_articulo = @tipo AND
			  id_articulo <>@ii_id
	
	
		
GO
grant all on Busca_Articulo_Equivalente to public


IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'Consulta_ExisteSust' AND type = 'P')
   DROP PROCEDURE Consulta_ExisteSust
GO

CREATE PROCEDURE Consulta_ExisteSust
   @ii_usuario			varchar(20),
   @ii_receta			int

AS 
	if exists(select * from Formula_receta_XUsuario where id_usuario_fru=@ii_usuario and id_receta_fru=@ii_receta)
		select '00'
	ELse
		select '11'
	
		
GO
grant all on Consulta_ExisteSust to public

IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'Consulta_ExisteSust_Art' AND type = 'P')
   DROP PROCEDURE Consulta_ExisteSust_Art
GO

CREATE PROCEDURE Consulta_ExisteSust_Art
   @ii_usuario			varchar(20),
   @ii_receta			int,
   @ii_articulo			int

AS 
	if exists(select * from Formula_receta_XUsuario where id_usuario_fru=@ii_usuario and id_receta_fru=@ii_receta and id_articulo_Sust_fru=@ii_articulo)
		select '00'
	ELse
		select '11'
	
		
GO
grant all on Consulta_ExisteSust_Art to public

IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'Busca_Formula_Receta_XUsuario' AND type = 'P')
   DROP PROCEDURE Busca_Formula_Receta_XUsuario
GO

CREATE PROCEDURE Busca_Formula_Receta_XUsuario
   @ii_usuario			varchar(20),
   @ii_receta			int

AS 
	if exists(select * from Formula_receta_XUsuario where id_usuario_fru=@ii_usuario and id_receta_fru=@ii_receta)
		BEGIN
			select id_articulo_Sust_fru,descr_articulo,id_unidad_fru,descr_unidad_m,cant_art_fru,sust_art_fru,
				   id_cat_articulo,id_gart_articulo,descr_g_articulo,id_tart_articulo,descr_t_articulo,aplica_inv_articulo,
				   foto_articulo 
			from Formula_receta_XUsuario 
					inner join ARTICULO  ON
						id_articulo=id_articulo_Sust_fru 
					INNER JOIN Unidad_Medida on 
						id_unidad_fru=id_unidad_m 
					INNER JOIN TIPO_ARTICULO ON 
						id_tart_articulo=id_t_articulo
					INNER JOIN GRUPO_ARTICULO ON 
						id_gart_articulo=id_g_articulo
			where id_receta_fru=@ii_receta
		END
	ELse
		BEGIN
			select id_articulo_fr,descr_articulo,id_unidad_fr,descr_unidad_m,cant_art_fr,no_sust_art_fr,
				   id_cat_articulo,id_gart_articulo,descr_g_articulo,id_tart_articulo,descr_t_articulo,aplica_inv_articulo,
				   foto_articulo 
			from Formula_receta 
					inner join ARTICULO  ON
						id_articulo=id_articulo_fr 
					INNER JOIN Unidad_Medida on 
						id_unidad_fr=id_unidad_m 
					INNER JOIN TIPO_ARTICULO ON 
						id_tart_articulo=id_t_articulo
					INNER JOIN GRUPO_ARTICULO ON 
						id_gart_articulo=id_g_articulo
			where id_receta_fr=@ii_receta
		END
	
		
GO
grant all on Busca_Formula_Receta_XUsuario to public


IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'ICarrito_esp' AND type = 'P')
   DROP PROCEDURE ICarrito_esp
GO

CREATE PROCEDURE ICarrito_esp
   @ii_usuario		varchar(20),
   @ii_receta		int,
   @ii_articulo		int,
   @ii_cant			decimal(12,2),
   @ii_valor		decimal(12,2)

AS 
	BEGIN TRY
		BEGIN TRANSACTION
		 	Declare @cant_or decimal(12,2) =(select isnull(max(cant_cc),0) as Cod from Carro_compra where id_usuario_cc=@ii_usuario and id_articulo_cc=@ii_articulo);
			declare @sum decimal(12,2)
			DECLARE @CArt int
			select @CArt=cant_f003 from Busca_Cant_art_Sust(@ii_receta,@ii_articulo,@ii_cant,@ii_usuario)
			set @sum=@cant_or+@CArt
			Declare @Importe decimal(12,2) =@sum*@ii_valor 
			if @cant_or<=0 
			BEGIN
				INSERT INTO Carro_compra values(@ii_usuario,@ii_articulo,(select @sum),@ii_valor,(select @Importe))
			END
			ELSE
			BEGIN
			UPDATE Carro_compra SET cant_cc=@sum,monto_cc=@Importe where id_usuario_cc=@ii_usuario and  id_articulo_cc=@ii_articulo
			END
			Select '|00:Insertado|'
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		Select 'EE:ERROR AL INSERTAR DATOS'
		ROLLBACK TRANSACTION;
	END CATCH

	
GO

grant all on ICarrito_esp to public



IF EXISTS (SELECT name FROM sysobjects 
         WHERE name = 'ISustituto' AND type = 'P')
   DROP PROCEDURE ISustituto
GO

CREATE PROCEDURE ISustituto
   @ii_usuario			varchar(20),
   @ii_receta			int,
   @ii_articulo_Ori		int,
   @ii_articulo_sust	int

AS 
	if exists(select * from Formula_receta_XUsuario where id_usuario_fru=@ii_usuario and id_receta_fru=@ii_receta and id_articulo_Ori_fru=@ii_articulo_Ori)
		BEGIN
			update Formula_receta_XUsuario set 
				id_articulo_Sust_fru=@ii_articulo_sust
			where id_usuario_fru=@ii_usuario and
				  id_receta_fru=@ii_receta and
				  id_articulo_Ori_fru=@ii_articulo_Ori
			Select '|00:Modificado|'
		END
	ELSE
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO Formula_receta_XUsuario
		 		select @ii_usuario,@ii_receta,id_articulo_fr,id_articulo_fr,id_unidad_fr,cant_art_fr,no_sust_art_fr
					from Formula_receta
				where id_receta_fr=@ii_receta

				update Formula_receta_XUsuario set 
						id_articulo_Sust_fru=@ii_articulo_sust
					where id_usuario_fru=@ii_usuario and
						  id_receta_fru=@ii_receta and
						  id_articulo_Ori_fru=@ii_articulo_Ori
			Select '|00:Modificado|'
				Select '|00:Insertado|'
			COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			Select 'EE:ERROR AL INSERTAR DATOS'
			ROLLBACK TRANSACTION;
	END CATCH

	
GO

grant all on ISustituto to public


