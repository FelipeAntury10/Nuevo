CREATE DATABASE TDASUBASTAS;
GO

USE TDASUBASTAS;
GO

CREATE TABLE Clientes (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Cedula NVARCHAR(20) UNIQUE NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Telefono NVARCHAR(20) NOT NULL
);

CREATE TABLE Categorias (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NOT NULL
);

CREATE TABLE Productos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    PrecioInicial DECIMAL(18,2) NOT NULL,
    CategoriaID INT NOT NULL,
    FOREIGN KEY (CategoriaID) REFERENCES Categorias(ID)
);

CREATE TABLE Vendedores (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Cedula NVARCHAR(20) UNIQUE NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Telefono NVARCHAR(20) NOT NULL
);

CREATE TABLE Estados (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Subastas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    VendedorID INT NOT NULL,
    EstadoID INT NOT NULL,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL,
    FOREIGN KEY (ProductoID) REFERENCES Productos(ID),
    FOREIGN KEY (VendedorID) REFERENCES Vendedores(ID),
    FOREIGN KEY (EstadoID) REFERENCES Estados(ID)
);

CREATE TABLE Pujas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT NOT NULL,
    SubastaID INT NOT NULL,
    Monto DECIMAL(18,2) NOT NULL,
    Fecha DATETIME NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ID),
    FOREIGN KEY (SubastaID) REFERENCES Subastas(ID)
);

CREATE TABLE MetodosPagos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TipoPago NVARCHAR(100) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(100) NOT NULL
);

CREATE TABLE Pagos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Referencia NVARCHAR(100) UNIQUE NOT NULL,
    ClienteID INT NOT NULL,
    SubastaID INT NOT NULL,
    MetodoPagoID INT NOT NULL,
    Monto DECIMAL(18,2) NOT NULL, -- agregado
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ID),
    FOREIGN KEY (SubastaID) REFERENCES Subastas(ID),
    FOREIGN KEY (MetodoPagoID) REFERENCES MetodosPagos(ID)
);


INSERT INTO Clientes (Nombre, Cedula, Email, Telefono) VALUES
('Juan Pérez', '123456789', 'juanP@gmail.com', '555-1234'),
('María Gómez', '987654321', 'mariaG@gmail.com', '555-5678'),
('Pedro Martínez', '456789123', 'pedroM@gmail.com', '555-7890');

INSERT INTO Categorias (Nombre, Descripcion) VALUES
('Electrónica', 'Productos electrónicos como televisores, teléfonos, etc.'),
('Hogar', 'Artículos para el hogar y decoración'),
('Deportes', 'Equipos y accesorios deportivos');

INSERT INTO Productos (Nombre, Descripcion, PrecioInicial, CategoriaID) VALUES
('Televisor Samsung', 'Televisor LED de 50 pulgadas', 1200.00, 1),
('Sofá de Cuero', 'Sofá reclinable de cuero para sala', 800.00, 2),
('Bicicleta Montañera', 'Bicicleta para montaña de 21 velocidades', 500.00, 3);

INSERT INTO Vendedores (Nombre, Cedula, Email, Telefono) VALUES
('Carlos López', '321654987', 'carlosL@gmail.com', '555-3456'),
('Ana Torres', '789123456', 'anaT@gamil.com', '555-9012'),
('Luis Ramírez', '159357258', 'luisR@gamil.com', '555-6543');

INSERT INTO Estados (Nombre) VALUES
('Activa'),
('Finalizada'),
('Cancelada');

INSERT INTO Subastas (ProductoID, VendedorID, EstadoID, FechaInicio, FechaFin) VALUES
(1, 1, 1, '2025-05-01', '2025-05-10'),
(2, 2, 2, '2025-04-15', '2025-04-25'),
(3, 3, 3, '2025-03-20', '2025-03-30');

INSERT INTO Pujas (ClienteID, SubastaID, Monto, Fecha) VALUES
(1, 1, 1250.00, '2025-05-02'),
(2, 1, 1300.00, '2025-05-03'),
(3, 2, 850.00, '2025-04-16');

INSERT INTO MetodosPagos (TipoPago, Nombre, Descripcion) VALUES
('Tarjeta de Crédito', 'Visa', 'Pago con tarjeta Visa'),
('Transferencia Bancaria', 'Bancolombia', 'Transferencia desde cuenta Bancolombia'),
('Efectivo', 'Pago en Efectivo', 'Pago contra entrega');

INSERT INTO Pagos (Referencia, ClienteID, SubastaID, MetodoPagoID, Monto) VALUES
('REF12345', 1, 1, 1, 1300.00),
('REF67890', 3, 2, 2, 850.00),
('REF11121', 2, 1, 3, 1250.00);

SELECT * FROM Clientes;
SELECT * FROM Categorias;
SELECT * FROM MetodosPagos;
SELECT * FROM Vendedores;
SELECT * FROM Estados;

SELECT * FROM Productos;

SELECT * FROM Subastas;

SELECT * FROM Pagos; --
SELECT * FROM Pujas; --