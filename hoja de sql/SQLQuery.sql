create database creditos2
use creditos2

---------------------

create table clientes(
id varchar(50) primary key,
nombre varchar(50),
tel varchar(50),
dir varchar(50),
correo varchar(50),
f_regi date
)


create table cuentas (
numCuenta varchar(50) primary key,
f_ap date,
condiCuen varchar(50),
saldoApagar decimal,
monLimit decimal,
mondispo decimal ,
id varchar(50) foreign key (id) references clientes (id)
)

create table movimiento (
numCuenta varchar(50) foreign key (numCuenta) references cuentas (numCuenta),
f_mov date,
tipoMov varchar(50),
montoMov decimal,
nomRespon varchar(50),
detalle varchar(50),
numMov int identity (1,1) primary key
)



create table detalleCom(
numMov int,
f_compra date,
decrip varchar(50),
montoComp varchar(50),
NumCuenta varchar (50) foreign key (numCuenta) references cuentas (numCuenta),
foreign key (numMov) references movimiento (numMov)
)

create table niveles(
codNiv varchar(50) primary key,
nomNiv varchar(50)
)

create table funciones(
codFun varchar(50) primary key,
nomFun varchar(50)
)

create table funnivs(
codFunNiv varchar(50) primary key,
codNiv varchar (50) foreign key (codNiv) references niveles (codNiv),
codFun varchar (50) foreign key (codFun) references funciones (codFun),
estado varchar (50) 
)

create table bitacora(
numMov int identity (1,1) primary key,
f_mov date,
detalle varchar(50) ,
loginUS varchar(50) 
)

create table usuarios (
loginUS varchar(50) primary key,
nombreUS varchar(50),
apellidoUS varchar(50),
f_regiUS date,
passworUS varchar(50),
idUS varchar(50),
codNivUS varchar(50),
condiUS varchar(50)
)








