

--Delivery
--Zonas: 
--Asigna_zona: Para asignar zona a delivery
--Conf_TiempoEstimado;
--Pedidos



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
CREATE TABLE DELIVERY
(
	id_delivery int not null primary key,
	id_tercero_delivery int not null Constraint FK_Tercero_delivery FOREIGN KEY REFERENCES Tercero(id_Tercero),
)
grant all on DELIVERY to public;


Create table Tipo_zona(
	Id_Tipo_zona		int NOT NULL PRIMARY KEY
)
grant all on  Tipo_zona to public;

Create table Zona(
	Id_zona		int NOT NULL PRIMARY KEY,
    ID_Tipo_zona	int Not null Constraint FK_Zona_T_Zona FOREIGN KEY REFERENCES Tipo_zona(Id_Tipo_zona),
)
grant all on  zona to public;

Create table Asigna_Zona(
	Id_Delivery		int Not null Constraint FK_Asig_Delivery_Zona1 FOREIGN KEY REFERENCES Delivery(Id_delivery),
    ID_Zona	int Not null Constraint FK_Asig_Delivery_Zona2 FOREIGN KEY REFERENCES Zona(Id_zona),
)
grant all on  Asigna_Zona to public;
create table Compra
(
	Id_compra int not null primary key
)
grant all on  Compra to public;

Create table Compra_Envio(
	Id_compra	int Not null Constraint FK_Pedido_compra FOREIGN KEY REFERENCES COMPRA(Id_compra),
	Id_Delivery		int Not null Constraint FK_Pedido_Delivery FOREIGN KEY REFERENCES Delivery(Id_delivery),
    ID_Zona	int Not null Constraint FK_Compra_Zona FOREIGN KEY REFERENCES Zona(Id_zona),
)
grant all on  Compra_Envio to public;

Create table pago(
	Id_compra	int Not null Constraint FK_Pedio_Pago FOREIGN KEY REFERENCES COMPRA(Id_compra),
    Statu_pago	int Not null ,
)
grant all on  pago to public;
