

CREATE TABLE IMPUESTO
(
	id_impuesto int not null primary key,
	descr_impuesto varchar(100) not null,
	porc_impuesto decimal(12,2) not null,
	estado_impuesto char(1) not null
)
grant all on IMPUESTO to public;

CREATE TABLE ARTICULO
(
	id_articulo int not null primary key,
	descr_articulo varchar(100) NOT NULL,
	estado_articulo char(1) not null,
	aplica_imp_articulo char(1) not null
)
grant all on ARTICULO to public;


CREATE TABLE ASIGNACION_IMPUESTO
(
	id_articulo_ai int not null constraint fk_articulo_ai foreign key references ARTICULO(id_articulo),
	id_impuesto_ai int not null constraint fk_impuesto_ai foreign key references IMPUESTO(id_impuesto),
	fecha_ini_ai   datetime not null,
	fecha_fin_ai   datetime not null,
	primary key(id_articulo_ai,id_impuesto_ai)
)
grant all on ASIGNACION_IMPUESTO to public;

CREATE TABLE HIST_CAM_IMPUESTO
(
	id_impuesto_hci int not null constraint fk_impuestohci foreign key references IMPUESTO(id_impuesto),
	n_linea int not null, 
	Porc_impuesto_hci decimal(12,2) not null,
	Fecha_Mod_hci   datetime not null,
	Mod_Por_hci    char(10) not null,
	Motivo_hci		varchar(MAX) not null
	primary key(id_impuesto_hci, n_linea)
)
grant all on HIST_CAM_IMPUESTO to public;

