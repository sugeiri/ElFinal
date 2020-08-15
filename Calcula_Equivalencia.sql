create function Calcula_Equivalencia(@ii_Unidad_O    char(5), 
								     @ii_Unidad_N	  char(5),
									 @ii_cant		  decimal(12,2))
returns @F002 table (cant_f002		 decimal(12,2))
begin
    		--------------------
			declare @cant_equiv_1 decimal(12,2)
			declare @cant_equiv_2 decimal(12,2)
			declare @cant_Nueva decimal(12,2)
			
			
			if exists(select *from equivalencia where id_unidad_1_equiv = @ii_Unidad_O and id_unidad_2_equiv = @ii_Unidad_N)
				BEGIN
					select @cant_equiv_1=cant_equiv_1, 
						   @cant_equiv_2=cant_equiv_2
						from equivalencia where 
								id_unidad_1_equiv = @ii_Unidad_O and 
								id_unidad_2_equiv = @ii_Unidad_N
					set @cant_Nueva=(@ii_cant * @cant_equiv_2) / @cant_equiv_1
					INSERT @F002
						SELECT @cant_Nueva
            
				END
            ELSE
            BEGIN
                	select @cant_equiv_1=cant_equiv_1, 
						   @cant_equiv_2=cant_equiv_2
						from equivalencia where 
								id_unidad_1_equiv = @ii_Unidad_N and 
								id_unidad_2_equiv = @ii_Unidad_O
				    set @cant_Nueva = (@cant_equiv_1 *@ii_cant) / @cant_equiv_2;
                    INSERT @F002
						SELECT @cant_Nueva
            END
			--------------------

	return
end
