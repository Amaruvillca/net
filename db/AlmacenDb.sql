
CREATE DATABASE AlmacenDB;
GO

USE AlmacenDB;
GO


CREATE TABLE Categorias (
    id_categoria INT PRIMARY KEY IDENTITY(1,1),
    nombre_categoria VARCHAR(100) NOT NULL,
    descripcion TEXT
);
GO


CREATE TABLE Productos (
    id_producto INT PRIMARY KEY IDENTITY(1,1),
    nombre_producto VARCHAR(150) NOT NULL,
    imagen VARCHAR(500),
    descripcion TEXT,
    id_categoria INT NOT NULL,
    precio_unitario DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL DEFAULT 0,
    fecha_registro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria)
);
GO


CREATE TABLE Almacenes (
    id_almacen INT PRIMARY KEY IDENTITY(1,1),
    nombre_almacen VARCHAR(100) NOT NULL,
    ubicacion VARCHAR(200)
);
GO


CREATE TABLE MovimientosStock (
    id_movimiento INT PRIMARY KEY IDENTITY(1,1),
    id_producto INT NOT NULL,
    id_almacen INT NOT NULL,
    tipo_movimiento VARCHAR(10) CHECK (tipo_movimiento IN ('ENTRADA', 'SALIDA')),
    cantidad INT NOT NULL,
    fecha_movimiento DATETIME DEFAULT GETDATE(),
    observacion TEXT,
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto),
    FOREIGN KEY (id_almacen) REFERENCES Almacenes(id_almacen)
);
GO