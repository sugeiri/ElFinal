--DROP function Busca_Cant_art_Sust

create function Busca_Cant_art_Sust(@ii_receta        int, 
									@ii_articulo	  int,
									@ii_cant_f		  decimal(12,2),
									@ii_usuario		  varchar(20))
returns @F003 table (cant_f003		 decimal(12,2))
begin
    --insert into @F001
		declare @unidad_form char(5)
		declare @unidad_art  char(5)
		declare @contenido_art decimal(12,2)
		SELECT @unidad_form=id_unidad_fru,
			   @unidad_art=id_unidad_t_articulo,
			   @contenido_art=contenido_articulo 
	    FROM ARTICULO 
		     INNER JOIN TIPO_ARTICULO
				ON id_tart_articulo=id_t_articulo 
			  RIGHT OUTER JOIN Formula_receta_XUsuario
				on id_articulo=id_articulo_Sust_fru
		WHERE id_usuario_fru=@ii_usuario and
			  id_receta_fru=@ii_receta AND
			  id_articulo_Sust_fru=@ii_articulo

		DECLARE @equiv decimal(12,2)
		if @unidad_form <> @unidad_art
			BEGIN
				 select @equiv=cant_f002 from Calcula_Equivalencia(@unidad_form,@unidad_art,@ii_cant_f) as T
				 if @equiv > @contenido_art
					 BEGIN
						declare @ii int =1
						declare @cont_1 decimal(12,2)=@contenido_art
						while @equiv >= @cont_1
							BEGIN
								set @ii=@ii+1
								set @cont_1=@cont_1+@cont_1
							END
						insert into @F003 values(@ii)
					END
				else
				 insert into @F003  VALUES(1)
			END
		else
		BEGIN
			if @ii_cant_f>@contenido_art
				BEGIN
					INSERT INTO @F003
					SELECT @ii_cant_f*@contenido_art
				END
			else
				insert into @F003  VALUES(1)
		END
	return
end
