create database dotnet
use dotnet
create table Venta
(ID_Venta decimal (15) not null,
Fecha_Venta	date		not null,
Total_Venta	decimal	(5,2)	not null,
primary key (ID_Venta))
SELECT * FROM Venta;

alter table Venta add ID_Usuario	char 	(4)	not null foreign key  references Usuario (ID_Usuario)

create table Pan
(ID_Pan	decimal	(4)	not null,
Nombre_Pan	char	(25)	not null,	
Descripcion_Pan	char	(70)	not null,	
Precio_Pan	decimal	(5,2)	not null	,
Distribuidor_Pan	char	(70)	not null,	
primary key (ID_Pan))

INSERT INTO Pan VALUES(1, 'Concha', 'Concha rellena de chantilly', 18, 'Delicias')
INSERT INTO Pan VALUES(2, 'Cuerno', 'Relleno con chocolate', 15, 'Delicias')
INSERT INTO Pan VALUES(3, 'Rol de canela', 'Rol de canela con pasas', 20, 'Delicias')
select * from Usuario
create table Inventario
(ID_Inventario	decimal 	(15)	not null,
Fecha_Inventario	date		not null,
primary key (ID_Inventario))
ALTER TABLE Inventario DROP COLUMN Fecha_Inventario;

INSERT INTO Inventario VALUES (1)

create table Detalle_Venta
(ID_Venta	decimal	(15)	not null,
Cantidad_Detalle	decimal 	(4)	not null,	
Subtotal_Detalle	decimal	(5,2)	not null,	
ID_Pan	decimal	(4)	not null,
primary key (ID_Venta,ID_Pan),
foreign key (ID_Venta) references Venta (ID_Venta),
foreign key (ID_Pan) references Pan (ID_Pan))

SELECT * FROM Detalle_Venta
SELECT * FROM Venta
SELECT Pan.Nombre_Pan, Pan.Precio_Pan, Detalle_Venta.Cantidad_Detalle, Detalle_Venta.Subtotal_Detalle FROM Detalle_Venta  INNER JOIN Pan  ON Detalle_Venta.ID_Pan = Pan.ID_Pan
WHERE Detalle_Venta.ID_Venta = 6 

SELECT SUM(Subtotal_Detalle) from Detalle_Venta WHERE ID_Venta= 6

DELETE FROM Venta
DELETE FROM Detalle_Venta
create table Usuario
(ID_Usuario	char 	(4)	not null,
Email_Usuario	char 	(16)	not null,	
Contraseña_Usuario	char 	(16)	not null,
primary key (ID_Usuario))

ALTER TABLE Usuario ALTER COLUMN Email_Usuario char(30) not null
SELECT * FROM Usuario
insert into Usuario values('1', 'kiara@gmail.com','kiara.18')
insert into Usuario values('2', 'edgar@gmail.com','edgar06')
insert into Usuario values('3', 'alfredo@gmail.com','alfredogu')
create table Administrador
(ID_Usuario	char 	(4)	not null,
ID_Admin	char 	(4)	not null,
Telefono_Admin	decimal	(10)	null,
Nombre_Admin	char 	(20)	not null,
ApellidoP_Admin	char 	(20)	not null,
ApellidoM_Admin	char 	(20)	not null,
Direccion_Admin	char	(70)	not null,
primary key (ID_Admin),
foreign key (ID_usuario) references Usuario (ID_usuario))


create table Inventario_Existencias
(Cantidad_Existencias	decimal 	(15)	not null,
ID_Inventario	decimal 	(15)	not null,
ID_Pan	decimal	(4)	not null,
primary key (ID_Inventario,ID_Pan),
foreign key (ID_Inventario) references Inventario(ID_Inventario),
foreign key (ID_Pan) references Pan(ID_Pan))

SELECT * FROM Inventario_Existencias
SELECT Inventario_Existencias.ID_Pan, Pan.Nombre_Pan, Inventario_Existencias.Cantidad_Existencias, Pan.Precio_Pan 
FROM Inventario_Existencias JOIN Pan ON Inventario_Existencias.ID_Pan = Pan.ID_Pan

SELECT Inventario_Existencias.ID_Pan, Pan.Nombre_Pan FROM Inventario_Existencias JOIN Pan ON Inventario_Existencias.ID_Pan = Pan.ID_Pan