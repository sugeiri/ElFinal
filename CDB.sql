

Create table Tipo_Identificacion(
	Id_Tipo_Ident		int NOT NULL PRIMARY KEY,
	Descr_Tipo_Ident	varchar(30) NOT NULL,
	Estado_Tipo_Ident	char(1) NOT NULL
)

CREATE TABLE Tercero(
	id_Tercero				int NOT NULL PRIMARY KEY,
	Nombre_Tercero			varchar(100) NOT NULL,
	ID_T_Identif_Tercero	int Not null Constraint FK_Tercero_T_Identif FOREIGN KEY REFERENCES Tipo_Identificacion(Id_Tipo_Ident),
	Cedula_Tercero			varchar(20) NOT NULL,
	Fecha_Nac_Tercero		date NOT NULL,
	Estado_Tercero			char(1) NOT NULL,
	Sexo_Tercero			char(1) NOT NULL
)
CREATE TABLE PAIS(
	id_pais		INT NOT NULL PRIMARY KEY,
	descr_pais	VARCHAR(50) NOT NULL,
	estado_pais CHAR(1) NOT NULL

)
CREATE TABLE PROVINCIA(
	id_provincia		INT NOT NULL PRIMARY KEY,
	descr_provincia		VARCHAR(50) NOT NULL,
	estado_provincia	CHAR(1) NOT NULL,
	id_pais_provincia	INT NOT NULL Constraint FK_PROVINCIA_PAIS FOREIGN KEY REFERENCES PAIS(id_pais)
)
CREATE TABLE MUNICIPIO(
	id_municipio		INT NOT NULL PRIMARY KEY,
	descr_municipio		VARCHAR(50) NOT NULL,
	estado_municipio	CHAR(1) NOT NULL,
	id_prov_municipio	INT NOT NULL Constraint FK_MUNICIPIO_PROV FOREIGN KEY REFERENCES PROVINCIA(ID_PROVINCIA)

)
CREATE TABLE TIPO_DIRECCION(
	ID_TIPO_D CHAR(2) NOT NULL PRIMARY KEY,
	DESCR_TIPO_D VARCHAR(50) NOT NULL,
	ESTADO_TIPO_D CHAR(1) NOT NULL
)
CREATE TABLE TIPO_EMAIL(
	ID_TIPO_E CHAR(2) NOT NULL PRIMARY KEY,
	DESCR_TIPO_E VARCHAR(50) NOT NULL,
	ESTADO_TIPO_E CHAR(1) NOT NULL
)
CREATE TABLE TIPO_TELEFONO(
	ID_TIPO_T CHAR(2) NOT NULL PRIMARY KEY,
	DESCR_TIPO_T VARCHAR(50) NOT NULL,
	ESTADO_TIPO_T CHAR(1) NOT NULL
)
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

CREATE TABLE EMAIL(
	id_Tercero_Email	INT NOT NULL Constraint FK_Tercero_Email FOREIGN KEY REFERENCES Tercero(id_Tercero),
	Email				varchar(150) NOT NULL,
	TIPO_Email			CHAR(2) NOT NULL Constraint FK_T_EMAIL FOREIGN KEY REFERENCES TIPO_EMAIL(ID_TIPO_E),
	PRIMARY KEY(id_Tercero_Email,Email)	
)
CREATE TABLE TELEFONO(
	id_Tercero_Tel	INT NOT NULL Constraint FK_Tercero_Tel FOREIGN KEY REFERENCES Tercero(id_Tercero),
	Numero_Tel		varchar(20) NOT NULL,
	TIPO_Tel		CHAR(2) NOT NULL Constraint FK_T_TELEFONO FOREIGN KEY REFERENCES TIPO_TELEFONO(ID_TIPO_T),
	PRIMARY KEY(id_Tercero_Tel,Numero_Tel)	
)
CREATE TABLE CLIENTE
(
	id_cliente int not null primary key,
	id_tercero_cliente int not null Constraint FK_Tercero_cliente FOREIGN KEY REFERENCES Tercero(id_Tercero),
	estado_cliente char(1) NOT NULL,
	f_ingreso_cliente date not null

)
CREATE TABLE DELIVERY
(
	id_delivery int not null primary key,
	id_tercero_delivery int not null Constraint FK_Tercero_delivery FOREIGN KEY REFERENCES Tercero(id_Tercero),
	estado_delivery char(1) NOT NULL,
	f_ingreso_delivery date not null

)
CREATE TABLE  BANCO
(
	id_banco INT NOT NULL PRIMARY KEY,
	descr_banco VARCHAR(200) NOT NULL,
	email_banco varchar(100)  not null,
	tel_banco	varchar(30) not null
)

CREATE TABLE EMPRESA
(
	id_empresa int not null primary key,
	descr_empresa varchar(200) not null,
	email_empresa varchar(100) not null,
	tel_empresa varchar(15) not null,
	url_empresa varchar(200) not null,
	estado_empresa char(1) not null
)

--PRODUCTOS

create table Unidad_Medida
(
	id_unidad_m char(5) not null primary key,
	descr_unidad_m varchar(100) not null,
	estado_unidad_m char(1) not null
)
CREATE TABLE TIPO_ARTICULO
(
	id_t_articulo int not null primary key,
	descr_t_articulo varchar(100) not null,
	estado_t_articulo char(1) not null,
	id_unidad_m char(5) not null  Constraint FK_UnidadM_TArt FOREIGN KEY REFERENCES Unidad_Medida(id_unidad_m),
)

CREATE TABLE ARTICULO
(	
	id_articulo int not null primary key,
	descr_articulo varchar(500) not null,
	estado_articulo char(1) not null,
	id_tart_articulo int not null Constraint FK_TArt_Articulo FOREIGN KEY REFERENCES TIPO_ARTICULO(id_t_articulo),
	aplica_inv_articulo char(1) not null,
	creado_p_articulo varchar(20) not null,
	fecha_c_articulo datetime not null,
	mod_p_articulo varchar(20) not null,
	fecha_m_articulo datetime not null,
)
create table receta
(
	id_receta int not null primary key,
	descr_receta varchar(500) not null,
	estado_receta char(1) not null
)
create table ingredientes_receta
(
	id_receta_ir   int not null constraint FK_receta_ir FOREIGN KEY REFERENCES receta(id_receta),
	id_articulo_ir int not null constraint FK_articulo_ir FOREIGN KEY REFERENCES ARTICULO(id_articulo),
	cant_art_ir	   decimal(6,2) not null,
	primary key(id_receta_ir,id_articulo_ir)
)

create table Compra
(
	Id_compra int not null primary key,
	id_cliente int not null constraint FK_cliente_compra FOREIGN KEY REFERENCES CLIENTE(id_cliente),
	fecha_compra datetime not null,
	empresa_compra int not null constraint FK_Empresa_compra FOREIGN KEY REFERENCES EMPRESA(id_empresa),
	estado_compra char(1) not null,
	fecha_m_compra	datetime not null

)
create table Compra_Envio
(
	id_compra int not null primary key constraint FK_CompEnvio_Comp FOREIGN KEY REFERENCES Compra(Id_compra),
	fecha_envio	datetime not null,
	n_linea_dir_envio int not null,
	n_linea_tel_envio int not null,
	entregado_por  int not null constraint FK_delivery_Comp FOREIGN KEY REFERENCES Delivery(id_delivery),
	
)

----ESTADOS COMPRA
----      	 A=PENDIENTE O ACTIVO, 
----		 F=FINALIZADO O ENTREGADO, 
----         E=ENVIADO, 
----         P=PROCESANDO O PREPARANDO, 
----         C=CANCELADO)
