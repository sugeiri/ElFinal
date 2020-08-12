

Create table Tipo_Identificacion(
	Id_Tipo_Ident		int NOT NULL PRIMARY KEY,
	Descr_Tipo_Ident	varchar(30) NOT NULL,
	Estado_Tipo_Ident	char(1) NOT NULL
)
grant all on  Tipo_Identificacion to public;

CREATE TABLE Tercero(
	id_Tercero				int NOT NULL PRIMARY KEY,
	Nombre_Tercero			varchar(100) NOT NULL,
	ID_T_Identif_Tercero	int Not null Constraint FK_Tercero_T_Identif FOREIGN KEY REFERENCES Tipo_Identificacion(Id_Tipo_Ident),
	Cedula_Tercero			varchar(20) NOT NULL,
	Fecha_Nac_Tercero		date NOT NULL,
	Estado_Tercero			char(1) NOT NULL,
	Sexo_Tercero			char(1) NOT NULL
)
grant all on  Tercero to public;
create table Tipo_usuario
(
	id_t_usuario int not null primary key,
	descr_t_usuario varchar(30) not null,
	estado_t_usuario char(1) not null
)
grant all on  Tipo_usuario to public;

create table USUARIO(
	id_usuario varchar(20) not null primary key,
	id_tercero_usuario int not null constraint fk_tercero_usuario foreign key references Tercero(id_Tercero),
	id_Tipo_usuario int not null  constraint fk_tipo_usuario foreign key references Tipo_usuario(id_t_usuario),
	clave_usuario varbinary(200) not null,
	estado_usuario char(1) not null
)
grant all on  USUARIO to public;
CREATE TABLE PAIS(
	id_pais		INT NOT NULL PRIMARY KEY,
	descr_pais	VARCHAR(50) NOT NULL,
	estado_pais CHAR(1) NOT NULL

)
grant all on  PAIS to public;
CREATE TABLE PROVINCIA(
	id_provincia		INT NOT NULL PRIMARY KEY,
	descr_provincia		VARCHAR(50) NOT NULL,
	estado_provincia	CHAR(1) NOT NULL,
	id_pais_provincia	INT NOT NULL Constraint FK_PROVINCIA_PAIS FOREIGN KEY REFERENCES PAIS(id_pais)
)
grant all on  PROVINCIA to public;
CREATE TABLE MUNICIPIO(
	id_municipio		INT NOT NULL PRIMARY KEY,
	descr_municipio		VARCHAR(50) NOT NULL,
	estado_municipio	CHAR(1) NOT NULL,
	id_prov_municipio	INT NOT NULL Constraint FK_MUNICIPIO_PROV FOREIGN KEY REFERENCES PROVINCIA(ID_PROVINCIA)

)
grant all on  MUNICIPIO to public;
CREATE TABLE TIPO_DIRECCION(
	ID_TIPO_D CHAR(2) NOT NULL PRIMARY KEY,
	DESCR_TIPO_D VARCHAR(50) NOT NULL,
	ESTADO_TIPO_D CHAR(1) NOT NULL
)
grant all on  TIPO_DIRECCION to public;
CREATE TABLE TIPO_EMAIL(
	ID_TIPO_E CHAR(2) NOT NULL PRIMARY KEY,
	DESCR_TIPO_E VARCHAR(50) NOT NULL,
	ESTADO_TIPO_E CHAR(1) NOT NULL
)
grant all on  TIPO_EMAIL to public;
CREATE TABLE TIPO_TELEFONO(
	ID_TIPO_T CHAR(2) NOT NULL PRIMARY KEY,
	DESCR_TIPO_T VARCHAR(50) NOT NULL,
	ESTADO_TIPO_T CHAR(1) NOT NULL
)
grant all on  TIPO_TELEFONO to public;
CREATE TABLE DIRECCION(
	id_Tercero_Direccion	INT NOT NULL Constraint FK_Tercero_Direccion FOREIGN KEY REFERENCES Tercero(id_Tercero),
	id_mun_Direccion		INT NOT NULL Constraint FK_MUNICIPIO_Direccion FOREIGN KEY REFERENCES MUNICIPIO(id_municipio),
	Direccion				varchar(MAX) NOT NULL,
	ESTADO_DIRECCION		CHAR(1) NOT NULL,
	TIPO_DIRECCION			CHAR(2) NOT NULL Constraint FK_T_Direccion FOREIGN KEY REFERENCES TIPO_DIRECCION(ID_TIPO_D),
	N_LINEA_DIRECCION		INT NOT NULL,
	DEFECTO_C_DIRECCION	    CHAR(1) NOT NULL
	PRIMARY KEY(id_Tercero_Direccion,TIPO_DIRECCION,N_LINEA_DIRECCION)	
)
grant all on  DIRECCION to public;
CREATE TABLE EMAIL(
	id_Tercero_Email	INT NOT NULL Constraint FK_Tercero_Email FOREIGN KEY REFERENCES Tercero(id_Tercero),
	Email				varchar(150) NOT NULL,
	TIPO_Email			CHAR(2) NOT NULL Constraint FK_T_EMAIL FOREIGN KEY REFERENCES TIPO_EMAIL(ID_TIPO_E),
	PRIMARY KEY(id_Tercero_Email,Email)	
)
grant all on  EMAIL to public;
CREATE TABLE TELEFONO(
	id_Tercero_Tel	INT NOT NULL Constraint FK_Tercero_Tel FOREIGN KEY REFERENCES Tercero(id_Tercero),
	Numero_Tel		varchar(20) NOT NULL,
	TIPO_Tel		CHAR(2) NOT NULL Constraint FK_T_TELEFONO FOREIGN KEY REFERENCES TIPO_TELEFONO(ID_TIPO_T),
	n_linea_tel		int not null,
	PRIMARY KEY(id_Tercero_Tel,n_linea_tel)	
)
grant all on  TELEFONO to public;
--CREATE TABLE CLIENTE
--(
--	id_cliente int not null primary key,
--	id_tercero_cliente int not null Constraint FK_Tercero_cliente FOREIGN KEY REFERENCES Tercero(id_Tercero),
--	estado_cliente char(1) NOT NULL,
--	f_ingreso_cliente date not null
--)
CREATE TABLE DELIVERY
(
	id_delivery int not null primary key,
	id_tercero_delivery int not null Constraint FK_Tercero_delivery FOREIGN KEY REFERENCES Tercero(id_Tercero),
	estado_delivery char(1) NOT NULL,
	f_ingreso_delivery date not null

)
grant all on DELIVERY to public;
CREATE TABLE  BANCO
(
	id_banco INT NOT NULL PRIMARY KEY,
	descr_banco VARCHAR(200) NOT NULL,
	email_banco varchar(100)  not null,
	tel_banco	varchar(30) not null
)
grant all on  BANCO to public;
CREATE TABLE EMPRESA
(
	id_empresa int not null primary key,
	descr_empresa varchar(200) not null,
	email_empresa varchar(100) not null,
	tel_empresa varchar(15) not null,
	url_empresa varchar(200) not null,
	estado_empresa char(1) not null,
	coordenadas_empresa varchar(100) not null,
)
grant all on  EMPRESA to public;
--PRODUCTOS

create table Unidad_Medida
(
	id_unidad_m char(5) not null primary key,
	descr_unidad_m varchar(100) not null,
	estado_unidad_m char(1) not null
)
grant all on  Unidad_Medida to public;
CREATE TABLE CATEGORIA_ARTICULO
(
	id_cat_articulo int not null primary key,
	descr_cat_articulo varchar(100) not null,
	estado_cat_articulo char(1) not null
)
grant all on  CATEGORIA_ARTICULO to public;
CREATE TABLE GRUPO_ARTICULO
(
	id_g_articulo int not null primary key,
	descr_g_articulo varchar(100) not null,
	estado_g_articulo char(1) not null
)
grant all on  GRUPO_ARTICULO to public;
CREATE TABLE TIPO_ARTICULO
(
	id_t_articulo int not null primary key,
	descr_t_articulo varchar(100) not null,
	estado_t_articulo char(1) not null,
	id_unidad_t_articulo char(5) not null  Constraint FK_UnidadM_TArt FOREIGN KEY REFERENCES Unidad_Medida(id_unidad_m),
)
grant all on  TIPO_ARTICULO to public;

CREATE TABLE ARTICULO
(	
	id_articulo int not null primary key,
	descr_articulo varchar(500) not null,
	estado_articulo char(1) not null,
	id_cat_articulo int not null Constraint FK_cat_Articulo FOREIGN KEY REFERENCES CATEGORIA_ARTICULO(id_cat_articulo),
	id_gart_articulo int not null Constraint FK_GArt_Articulo FOREIGN KEY REFERENCES GRUPO_ARTICULO(id_g_articulo),
	id_tart_articulo int not null Constraint FK_TArt_Articulo FOREIGN KEY REFERENCES TIPO_ARTICULO(id_t_articulo),
	aplica_inv_articulo char(1) not null,
	foto_articulo		varbinary(MAX),
	creado_p_articulo varchar(20) not null,
	fecha_c_articulo datetime not null,
	mod_p_articulo varchar(20) not null,
	fecha_m_articulo datetime not null,
)
grant all on  ARTICULO to public;
create table tipo_receta
(
	id_t_receta int not null primary key,
	descr_t_receta varchar(500) not null,
	estado_t_receta char(1) not null
)
grant all on  tipo_receta to public;

create table receta
(
	id_receta int not null primary key,
	descr_receta varchar(500) not null,
	estado_receta char(1) not null,
	id_tipo_receta int not null constraint FK_treceta FOREIGN KEY REFERENCES tipo_receta(id_t_receta),
	foto_receta		varbinary(MAX),
	porcion_receta int not null,
	tiempo_receta	decimal(6,2) not null
)
grant all on  receta to public;

create table Formula_receta
(
	id_receta_fr   int not null constraint FK_receta_fr FOREIGN KEY REFERENCES receta(id_receta),
	id_articulo_fr int not null constraint FK_Art_fr FOREIGN KEY REFERENCES articulo(id_articulo),
	id_unidad_fr char(5) not null  Constraint FK_Unidad_fr FOREIGN KEY REFERENCES Unidad_Medida(id_unidad_m),
	cant_art_fr	   decimal(6,2) not null,
	no_sust_art_fr char(1) not null
	primary key(id_receta_fr,id_articulo_fr)
)
grant all on  Formula_receta to public;
create table Carro_compra
(
	id_usuario_cc varchar(20) not null constraint FK_usuario_carro FOREIGN KEY REFERENCES usuario(id_usuario),
	id_articulo_cc int not null Constraint FK_Articulo_cc FOREIGN KEY REFERENCES ARTICULO(id_articulo),
	cant_cc decimal(4,2) not null,
	valor_cc	decimal(12,2) not null,
	monto_cc decimal(12,2) not null
	primary key(id_usuario_cc,id_articulo_cc)
)
grant all on  Carro_compra to public;
create table Compra
(
	Id_compra int not null primary key,
	id_empresa_compra int not null constraint FK_empresa_compra FOREIGN KEY REFERENCES empresa(id_empresa),
	id_usuario_compra varchar(20) not null constraint FK_usuario_compra FOREIGN KEY REFERENCES usuario(id_usuario),
	fecha_compra datetime not null,
	monto_compra decimal(12,2) not null,
	estado_compra char(1) not null,
	fecha_m_compra	datetime not null
)
grant all on  Compra to public;

create table Compra_Articulo
(
	id_compra_ca int not null constraint FK_Compra_ca FOREIGN KEY REFERENCES Compra(Id_compra),
	id_articulo_ca int not null Constraint FK_Articulo_ca FOREIGN KEY REFERENCES ARTICULO(id_articulo),
	cant_ca decimal(4,2) not null,
	valor_ca	decimal(12,2) not null,
	monto_ca decimal(12,2) not null,
	primary key(id_compra_ca,id_articulo_ca)
)
grant all on  Compra_Articulo to public;

create table Compra_Envio
(
	id_compra int not null primary key constraint FK_CompEnvio_Comp FOREIGN KEY REFERENCES Compra(Id_compra),
	fecha_envio	datetime not null,
	n_linea_dir_envio int not null,
	n_linea_tel_envio int not null,
	entregado_por  int not null constraint FK_delivery_Comp FOREIGN KEY REFERENCES Delivery(id_delivery),
	
)
grant all on Compra_Envio to public;

create table equivalencia
(
	id_unidad_1_equiv char(5) not null  Constraint FK_Unidad_1_eqv FOREIGN KEY REFERENCES Unidad_Medida(id_unidad_m),
	cant_equiv_1  decimal(12,5) not null,
	id_unidad_2_equiv char(5) not null  Constraint FK_Unidad_2_eqv FOREIGN KEY REFERENCES Unidad_Medida(id_unidad_m),
	cant_equiv_2 decimal(12,5) not null
	primary key(id_unidad_1_equiv,id_unidad_2_equiv)
)
grant all on equivalencia to public;
----ESTADOS COMPRA
----      	 A=PENDIENTE O ACTIVO, 
----		 F=FINALIZADO O ENTREGADO, 
----         E=ENVIADO, 
----         P=PROCESANDO O PREPARANDO, 
----         C=CANCELADO)
