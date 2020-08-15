--DROP function Busca_Cant_art

create function Busca_Cant_art(@ii_receta        int, 
								@ii_articulo	  int,
								@ii_cant_f		  decimal(12,2))
returns @F001 table (cant_f001		 decimal(12,2))
begin
    --insert into @F001
		declare @unidad_form char(5)
		declare @unidad_art  char(5)
		declare @contenido_art decimal(12,2)
		SELECT @unidad_form=id_unidad_fr,
			   @unidad_art=id_unidad_t_articulo,
			   @contenido_art=contenido_articulo 
	    FROM ARTICULO 
		     INNER JOIN TIPO_ARTICULO
				ON id_tart_articulo=id_t_articulo 
			  RIGHT OUTER JOIN Formula_receta
				on id_articulo=id_articulo_fr
		WHERE id_receta_fr=@ii_receta AND
			  id_articulo_fr=@ii_articulo
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
						insert into @F001 values(@ii)
					END
				else
				 insert into @F001  VALUES(1)
			END
		else
		BEGIN
			if @ii_cant_f>@contenido_art
				BEGIN
			--			declare @ii_1 int =1
			--			declare @cont decimal(12,2)=@contenido_art
			--			while @ii_cant_f > @contenido_art
			--				BEGIN
			--					set @ii=@ii+1
			--					set @cont=@cont+@cont
			--				END
			--			insert into @F001 values(@ii)
					INSERT INTO @F001
					SELECT @ii_cant_f*@contenido_art
				END
			else
				insert into @F001  VALUES(1)
		END
	return
end
