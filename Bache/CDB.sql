

Create table Tipo_Identificacion(
	Id_Tipo_Ident		int NOT NULL PRIMARY KEY,
	Descr_Tipo_Ident	varchar(30) NOT NULL,
	Estado_Tipo_Ident	char(1) NOT NULL
)

create table Persona
(
	id_persona				int not null primary key,
	nombre_persona			varchar(100) not null,
	ID_T_Identif_persona	int Not null Constraint FK_Persona_T_Identif FOREIGN KEY REFERENCES Tipo_Identificacion(Id_Tipo_Ident),
	identif_persona			char(11) not null,
	estado_persona			char(1) not null
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
CREATE TABLE DISTRITO(
	id_distrito		INT NOT NULL PRIMARY KEY,
	descr_distrito		VARCHAR(50) NOT NULL,
	estado_distrito	CHAR(1) NOT NULL,
	id_mun_distrito	INT NOT NULL Constraint FK_Distrito_Mun FOREIGN KEY REFERENCES MUNICIPIO(id_municipio)
)

CREATE TABLE SECCION(
	id_seccion		INT NOT NULL PRIMARY KEY,
	descr_seccion		VARCHAR(50) NOT NULL,
	estado_seccion	CHAR(1) NOT NULL,
	id_distrito_seccion	INT NOT NULL Constraint FK_Seccion_distrito FOREIGN KEY REFERENCES DISTRITO(id_distrito)
)
CREATE TABLE PARAJE(
	id_paraje		INT NOT NULL PRIMARY KEY,
	descr_paraje		VARCHAR(50) NOT NULL,
	estado_paraje	CHAR(1) NOT NULL,
	id_secc_paraje	INT NOT NULL Constraint FK_Paraje_Seccion FOREIGN KEY REFERENCES SECCION(id_seccion)
)
CREATE TABLE CALLE(
	id_calle		INT NOT NULL PRIMARY KEY,
	descr_calle		VARCHAR(50) NOT NULL,
	estado_calle	CHAR(1) NOT NULL,
	id_paraje_calle	INT NOT NULL Constraint FK_Calle_Paraje FOREIGN KEY REFERENCES PARAJE(id_paraje)
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
	id_Persona_Direccion	INT NOT NULL Constraint FK_Persona_Direccion FOREIGN KEY REFERENCES Persona(id_persona),
	id_calle_Direccion		INT NOT NULL Constraint FK_calle_Direccion FOREIGN KEY REFERENCES CALLE(id_calle),
	Direccion				varchar(MAX) NOT NULL,
	ESTADO_DIRECCION		CHAR(1) NOT NULL,
	TIPO_DIRECCION			CHAR(2) NOT NULL Constraint FK_T_Direccion FOREIGN KEY REFERENCES TIPO_DIRECCION(ID_TIPO_D),
	N_LINEA_DIRECCION		INT NOT NULL
	PRIMARY KEY(id_Persona_Direccion,TIPO_DIRECCION,N_LINEA_DIRECCION)	
)

CREATE TABLE EMAIL(
	id_Persona_Email	INT NOT NULL Constraint FK_Persona_Email FOREIGN KEY REFERENCES Persona(id_Persona),
	Email				varchar(150) NOT NULL,
	TIPO_Email			CHAR(2) NOT NULL Constraint FK_T_EMAIL FOREIGN KEY REFERENCES TIPO_EMAIL(ID_TIPO_E),
	PRIMARY KEY(id_Persona_Email,Email)	
)
CREATE TABLE TELEFONO(
	id_Persona_Tel	INT NOT NULL Constraint FK_Persona_Tel FOREIGN KEY REFERENCES Persona(id_Persona),
	Numero_Tel		varchar(20) NOT NULL,
	TIPO_Tel		CHAR(2) NOT NULL Constraint FK_T_TELEFONO FOREIGN KEY REFERENCES TIPO_TELEFONO(ID_TIPO_T),
	PRIMARY KEY(id_Persona_Tel,Numero_Tel)	
)
create table posicion
(	
	id_posicion int not null primary key,
	descr_posicion varchar(20) not null,
	estado_posicion char(1) not null
)
create table bache( --> numero de ident, calle,tamano,posicion, distrito, prioridad,coste
	id_bache int not null primary key,
	id_calle_bache int not null Constraint FK_calle_bache FOREIGN KEY REFERENCES CALLE(id_calle),
	tamano_bache int not null,
	id_posicion_bache int not null Constraint FK_pos_bache FOREIGN KEY REFERENCES posicion(id_posicion),
	prioridad_bache	 int not null,-- 1 a 3 (1 = Maxima, 2=Media,3=Menor)
	estado_bache char(1) not null,
	reportado_por_bache int not null Constraint FK_bache_persona FOREIGN KEY REFERENCES Persona(id_persona),
	fecha_rep_bache datetime not null
)
create table empleado(
	id_empleado int not null primary key,
	id_persona_empleado  int not null Constraint FK_emp_persona FOREIGN KEY REFERENCES Persona(id_persona),
	fecha_ing_empleado datetime not null,
	estado_empleado char(1) not null,
	sueldo_x_hora_empleado decimal(12,2) not null
)
create table peticion_obra(
	id_peticion int not null primary key,
	id_bache_peticion int not null,
	duracion_peticion decimal(6,2) not null,
	estado_peticion char(1) not null,
	costo_repa_peticion decimal(12,2) not null

)
create table material
(
	id_material int not null primary key,
	descr_material varchar(200) not null,
	estado_material char(1) not null,
	costo_u_material	decimal(12,2) not null
)
create  table Material_TamanoBache
(
	id_material_mtb int not null Constraint FK_material_mtb FOREIGN KEY REFERENCES material(id_material),
	tamano_bache_mtb int not null,
	cant_usar_mtb decimal(6,2) not null,
	costo_t_mtb	decimal(12,2) not null,
	primary key(id_material_mtb,tamano_bache_mtb)
)
create table material_peticion
(
	id_peticion_mp int not null Constraint FK_peticion_mp FOREIGN KEY REFERENCES peticion_obra(id_peticion),
	id_material_mp int not null Constraint FK_material_mp FOREIGN KEY REFERENCES material(id_material),
)	
create table tipo_equipo
(
	id_tipo_equipo int not null primary key,
	descr_tipo_equipo varchar(100) not null,
	estado_tipo_equipo char(1) not null
)
create table Equipo
(
	id_equipo int not null primary key,
	descr_equipo varchar(100) not null,
	estado_equipo char(1) not null,
	id_t_equipo int not null Constraint FK_t_equipo FOREIGN KEY REFERENCES tipo_equipo(id_tipo_equipo),
	costo_uso_x_h_equipo decimal(12,2) not null
)
create table peticion_brigada(
	id_peticion_pb int not null Constraint FK_peticion_pb FOREIGN KEY REFERENCES peticion_obra(id_peticion),
	id_empleado_pb int not null Constraint FK_empleaod_pb FOREIGN KEY REFERENCES empleado(id_empleado),
	primary key(id_peticion_pb,id_empleado_pb)
)
create table peticion_equipo(
	id_peticion_pe int not null Constraint FK_peticion_pe FOREIGN KEY REFERENCES peticion_obra(id_peticion),
	id_equipo_pe int not null Constraint FK_equipo_pe FOREIGN KEY REFERENCES Equipo(id_equipo),
	primary key(id_peticion_pe,id_equipo_pe)
)
create table tipo_dano
(
	id_tipo_dano int not null primary key,
	descr_tipo_dano varchar(100) not null,
	estado_tipo_dano char(1) not null
)
create table danos
(
	id_danos int not null primary key,
	id_bache int not null Constraint FK_bache_danos FOREIGN KEY REFERENCES Bache(id_bache),
	id_t_dano int not null Constraint FK_tdano FOREIGN KEY REFERENCES tipo_dano(id_tipo_dano),
	descr_dano varchar(max) not null,
	subsanamiento_dano decimal(12,2) not null
)