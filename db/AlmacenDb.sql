-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- AlmacenDB.dbo.Almacenes definition

-- Drop table

-- DROP TABLE AlmacenDB.dbo.Almacenes;

CREATE TABLE AlmacenDB.dbo.Almacenes (
	id_almacen int IDENTITY(1,1) NOT NULL,
	nombre_almacen varchar(100) COLLATE Modern_Spanish_CI_AS NOT NULL,
	ubicacion varchar(200) COLLATE Modern_Spanish_CI_AS NULL,
	CONSTRAINT PK__Almacene__098D5D13EBC0350E PRIMARY KEY (id_almacen)
);


-- AlmacenDB.dbo.Categorias definition

-- Drop table

-- DROP TABLE AlmacenDB.dbo.Categorias;

CREATE TABLE AlmacenDB.dbo.Categorias (
	id_categoria int IDENTITY(1,1) NOT NULL,
	nombre_categoria varchar(100) COLLATE Modern_Spanish_CI_AS NOT NULL,
	descripcion text COLLATE Modern_Spanish_CI_AS NULL,
	CONSTRAINT PK__Categori__CD54BC5A230E5946 PRIMARY KEY (id_categoria)
);


-- AlmacenDB.dbo.Productos definition

-- Drop table

-- DROP TABLE AlmacenDB.dbo.Productos;

CREATE TABLE AlmacenDB.dbo.Productos (
	id_producto int IDENTITY(1,1) NOT NULL,
	nombre_producto varchar(150) COLLATE Modern_Spanish_CI_AS NOT NULL,
	imagen varchar(500) COLLATE Modern_Spanish_CI_AS NULL,
	descripcion text COLLATE Modern_Spanish_CI_AS NULL,
	id_categoria int NOT NULL,
	precio_unitario decimal(10,2) NOT NULL,
	stock int DEFAULT 0 NOT NULL,
	fecha_registro datetime DEFAULT getdate() NULL,
	CONSTRAINT PK__Producto__FF341C0D87F4E2E0 PRIMARY KEY (id_producto),
	CONSTRAINT FK__Productos__id_ca__4E88ABD4 FOREIGN KEY (id_categoria) REFERENCES AlmacenDB.dbo.Categorias(id_categoria)
);


-- AlmacenDB.dbo.MovimientosStock definition

-- Drop table

-- DROP TABLE AlmacenDB.dbo.MovimientosStock;

CREATE TABLE AlmacenDB.dbo.MovimientosStock (
	id_movimiento int IDENTITY(1,1) NOT NULL,
	id_producto int NOT NULL,
	id_almacen int NOT NULL,
	tipo_movimiento varchar(10) COLLATE Modern_Spanish_CI_AS NULL,
	cantidad int NOT NULL,
	fecha_movimiento datetime DEFAULT getdate() NULL,
	observacion text COLLATE Modern_Spanish_CI_AS NULL,
	CONSTRAINT PK__Movimien__2A071C24820AB3B9 PRIMARY KEY (id_movimiento),
	CONSTRAINT FK__Movimient__id_al__5629CD9C FOREIGN KEY (id_almacen) REFERENCES AlmacenDB.dbo.Almacenes(id_almacen),
	CONSTRAINT FK__Movimient__id_pr__5535A963 FOREIGN KEY (id_producto) REFERENCES AlmacenDB.dbo.Productos(id_producto)
);
ALTER TABLE AlmacenDB.dbo.MovimientosStock WITH NOCHECK ADD CONSTRAINT CK__Movimient__tipo___534D60F1 CHECK (([tipo_movimiento]='SALIDA' OR [tipo_movimiento]='ENTRADA'));