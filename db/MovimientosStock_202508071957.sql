INSERT INTO AlmacenDB.dbo.MovimientosStock (id_producto,id_almacen,tipo_movimiento,cantidad,fecha_movimiento,observacion) VALUES
	 (1,1,N'ENTRADA',50,'2025-08-07 03:52:25.86',N'Recepción de proveedor'),
	 (2,1,N'ENTRADA',100,'2025-08-07 03:52:25.86',N'Producción local'),
	 (3,2,N'ENTRADA',60,'2025-08-07 03:52:25.86',N'Reposición mensual'),
	 (4,3,N'ENTRADA',40,'2025-08-07 03:52:25.86',N'Compra mayorista'),
	 (5,1,N'ENTRADA',5,'2025-08-07 03:52:25.86',N'Importación desde Chile'),
	 (3,2,N'SALIDA',20,'2025-08-07 03:52:25.86',N'Venta mayorista'),
	 (2,1,N'SALIDA',30,'2025-08-07 03:52:25.86',N'Consumo interno'),
	 (9,3,N'ENTRADA',80,'2025-08-07 03:52:25.86',N'Recepción desde planta Fino'),
	 (9,3,N'SALIDA',10,'2025-08-07 18:50:00.0',N'ninguna');
