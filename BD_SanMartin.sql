USE [SanMartin]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 05/09/2023 06:20:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreProducto] [varchar](50) NULL,
	[DescripcionProducto] [varchar](200) NULL,
	[Precio] [decimal](18, 4) NULL,
	[Existencia] [decimal](18, 4) NULL,
	[IdTipoProducto] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaEliminado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 05/09/2023 06:20:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProducto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipoProducto] [varchar](50) NULL,
	[DescripcionTipoProducto] [varchar](200) NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaEliminado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_TipoProducto] FOREIGN KEY([IdTipoProducto])
REFERENCES [dbo].[TipoProducto] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_TipoProducto]
GO
/****** Object:  StoredProcedure [dbo].[sp_productos_actualizar]    Script Date: 05/09/2023 06:20:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_productos_actualizar]
	@IdProducto INT,
	@NombreProducto VARCHAR(100),
	@DescripcionProducto VARCHAR(200),
	@Precio Decimal(18,4),
	@Existencia Decimal(18,4),
	@IdTipoProducto INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		UPDATE Producto 
		SET NombreProducto = @NombreProducto,
			DescripcionProducto = @DescripcionProducto,
			Precio = @Precio,
			Existencia = @Existencia,
			IdTipoProducto = @IdTipoProducto
		WHERE Id = @IdProducto;
		COMMIT;

		SELECT 1 AS status, 'Producto actualizado correctamente' AS message;
	END TRY
	BEGIN CATCH
		SELECT 0 AS status, 'No se puedo actualizar el producto' AS message;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_productos_crear]    Script Date: 05/09/2023 06:20:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_productos_crear]
	@NombreProducto VARCHAR(100),
	@DescripcionProducto VARCHAR(200),
	@Precio Decimal(18,4),
	@Existencia Decimal(18,4),
	@IdTipoProducto INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		
		INSERT INTO Producto (NombreProducto,DescripcionProducto,Precio,Existencia,IdTipoProducto,FechaRegistro) VALUES (@NombreProducto,@DescripcionProducto,@Precio,@Existencia,@IdTipoProducto,GETDATE());

		COMMIT;
		
		SELECT 1 AS status, 'Producto creado correctamente' AS message;
	END TRY
	BEGIN CATCH
		SELECT 0 AS status, 'No se pudo crear el producto' AS message;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_productos_eliminar]    Script Date: 05/09/2023 06:20:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_productos_eliminar]
	@IdProducto INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION; -- Iniciar una transacción

		-- Intentar eliminar el producto
		DELETE FROM Producto WHERE Id = @IdProducto;

		COMMIT; -- Confirmar la transacción si la eliminación fue exitosa

		SELECT 1 AS status, 'Producto eliminado correctamente' AS message;
	END TRY
	BEGIN CATCH
		SELECT 0 AS status, 'No se puedo eliminar el producto' AS message;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_productos_leer]    Script Date: 05/09/2023 06:20:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_productos_leer]
	@IdProducto INT
AS
BEGIN
	DECLARE @Query AS NVARCHAR(4000);

	SET @Query = N'SELECT
		P.Id,
		P.NombreProducto,
		P.DescripcionProducto,
		P.Precio,
		P.Existencia,
		P.IdTipoProducto,
		TP.NombreTipoProducto AS TipoProducto,
		P.FechaRegistro
	FROM Producto AS P
	INNER JOIN TipoProducto AS TP ON TP.Id = P.IdTipoProducto';

	IF @IdProducto <> 0 BEGIN
		SET @Query = @Query + N' WHERE P.Id = @IdProducto';
	END
	
	SET @Query = @Query + N' ORDER BY P.Id';

	EXEC sp_executesql @Query, N'@IdProducto INT', @IdProducto;
	PRINT @Query;
END
GO
