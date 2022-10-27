CREATE DATABASE Servicios_Agaval

CREATE TABLE TIPOSPERSONA(
IDTipo int identity (1,1) NOT NULL PRIMARY KEY,
Nombre varchar (255)
)

CREATE TABLE CLIENTE(
IDCliente int identity (1,1) NOT NULL PRIMARY KEY,
Nombre varchar (255),
Identificacion varchar (255),
IDTipo int not null,
Telefono varchar (255),
Direccion varchar (255),
Email varchar (255)
)

ALTER TABLE  CLIENTE ADD CONSTRAINT fk_Tipo FOREIGN KEY (IDTipo) REFERENCES TIPOSPERSONA (IDTipo)


CREATE TABLE PROVEEDORES(
IDProveedor int identity (1,1) NOT NULL PRIMARY KEY,
Nombre varchar (255),
Identificacion varchar (255)
)

CREATE TABLE PRODUCTOS(
IDProducto int identity (1,1) NOT NULL PRIMARY KEY,
IDCliente int not null,
Nombre varchar (255),
Descripcion varchar (255)
)

ALTER TABLE  PRODUCTOS ADD CONSTRAINT fk_Cliente FOREIGN KEY (IDCliente) REFERENCES CLIENTE (IDCliente)

CREATE TABLE PROVEEDORES_PRODUCTOS(
IDProveedor int not null,
IDProducto int not null,
DescripcionContrato varchar (255)
)

ALTER TABLE  PROVEEDORES_PRODUCTOS ADD CONSTRAINT fk_Proveedor FOREIGN KEY (IDProveedor) REFERENCES Proveedores(IDProveedor)

ALTER TABLE  PROVEEDORES_PRODUCTOS ADD CONSTRAINT fk_Producto FOREIGN KEY (IDProducto) REFERENCES Productos(IDProducto)

CREATE TABLE SECCIONES(
IDSeccion int identity (1,1) NOT NULL PRIMARY KEY,
IDCliente int not null,
Descripcion varchar (255)
)

ALTER TABLE  SECCIONES ADD CONSTRAINT fk_ClienteSeccion FOREIGN KEY (IDCliente) REFERENCES CLIENTE(IDCliente)



CREATE TABLE EMPLEADOS(
IDEmpleado int identity (1,1) NOT NULL PRIMARY KEY,
Nombre varchar (255),
Identificacion varchar (255),
Direccion varchar (255),
Telefono varchar (255)
)

CREATE TABLE SECCIONES_EMPLEADOS(
IDSeccion int not null,
IDEmpleado int not null,
Cargo varchar (255)
)

ALTER TABLE  SECCIONES_EMPLEADOS ADD CONSTRAINT fk_Seccion FOREIGN KEY (IDSeccion) REFERENCES Secciones(IDSeccion)

ALTER TABLE  SECCIONES_EMPLEADOS ADD CONSTRAINT fk_Empleado FOREIGN KEY (IDEmpleado) REFERENCES Empleados(IDEmpleado)