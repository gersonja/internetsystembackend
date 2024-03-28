CREATE DATABASE internetsys;
GO

USE internetsys;
GO

CREATE TABLE methodpayment (
	methodpaymentid INT IDENTITY(1,1),
	description VARCHAR(50) NOT NULL, 
	CONSTRAINT PK_METHODPAYMENT PRIMARY KEY CLUSTERED (methodpaymentid)
)
GO

CREATE TABLE statuscontract (
	statusid VARCHAR(3),
	description VARCHAR(50) NOT NULL,
	CONSTRAINT PK_STATUSCONTRACT PRIMARY KEY CLUSTERED (statusid)
)
GO

CREATE TABLE attentiontype (
	attentiontypeid VARCHAR(3),
	description VARCHAR(100) NOT NULL,
	CONSTRAINT PK_ATTENTIONTYPE PRIMARY KEY CLUSTERED (attentiontypeid)
)
GO

CREATE TABLE attentionstatus (
	statusid INT IDENTITY(1,1),
	description VARCHAR(30) NOT NULL,
	CONSTRAINT PK_ATTENTIONSTATUS PRIMARY KEY CLUSTERED (statusid)
)
GO

CREATE TABLE rol (
	rolid INTEGER IDENTITY(1,1),
	rolname VARCHAR(50) NOT NULL,
	CONSTRAINT PK_ROL PRIMARY KEY CLUSTERED (rolid)
)
GO

CREATE TABLE cash (
	cashid INTEGER IDENTITY(1,1),
	cashdescription VARCHAR(50) NOT NULL,
	active VARCHAR(1) NOT NULL,
	CONSTRAINT PK_CASHID PRIMARY KEY CLUSTERED (cashid)
)
GO

CREATE TABLE userstatus (
	statusid VARCHAR(3),
	description VARCHAR(50) NOT NULL,
	CONSTRAINT PK_STATUSID PRIMARY KEY CLUSTERED (statusid)
)
GO

CREATE TABLE service (
	serviceid INT IDENTITY(1,1),
	servicename VARCHAR(100) NOT NULL,
	servicedescription varchar(150) NOT NULL,
	price VARCHAR(10) NOT NULL,
	CONSTRAINT PK_SERVICEID PRIMARY KEY CLUSTERED (serviceid)
)
GO

CREATE TABLE device (
	deviceid INT IDENTITY(1,1),
	devicename VARCHAR(50) NOT NULL,
	serviceid INT NOT NULL,
	CONSTRAINT PK_DEVICEID PRIMARY KEY CLUSTERED (deviceid),
	CONSTRAINT FK_DEVICE_SERVICEID FOREIGN KEY (serviceid) REFERENCES service(serviceid)
)
GO

CREATE TABLE client (
	clientid INT IDENTITY(1,1),
	identification VARCHAR(13) NOT NULL UNIQUE,
	name VARCHAR(50) NOT NULL,
	lastname VARCHAR(50) NOT NULL,
	email VARCHAR(120),
	phonenumber VARCHAR(10),
	address VARCHAR(100) NOT NULL,
	referenceaddress VARCHAR(100) NOT NULL,
	CONSTRAINT PK_CLIENTID PRIMARY KEY CLUSTERED (clientid),
)
GO

CREATE TABLE turn (
	turnid INT IDENTITY(1,1),
	description VARCHAR(7) NOT NULL,
	date DATETIME NOT NULL,
	cash_cashid INT NOT NULL,
	CONSTRAINT PK_TURNID PRIMARY KEY CLUSTERED (turnid),
	CONSTRAINT FK_TURN_CASHID FOREIGN KEY (cash_cashid) REFERENCES cash(cashid),
)
GO

CREATE TABLE attention (
	attentionid INT IDENTITY(1,1),
	turn_turnid INT NOT NULL,
	client_clientid INT NOT NULL,
	attentiontype_attentiontypeid VARCHAR(3) NOT NULL,
	attentionstatus_statusid INT NOT NULL,
	CONSTRAINT PK_ATTENTIONID PRIMARY KEY CLUSTERED (attentionid),
	CONSTRAINT FK_ATTENTION_TURNID FOREIGN KEY (turn_turnid) REFERENCES turn(turnid),
	CONSTRAINT FK_ATTENTION_CLIENTID FOREIGN KEY (client_clientid) REFERENCES client(clientid),
	CONSTRAINT FK_ATTENTION_ATTENTIONTYPEID FOREIGN KEY (attentiontype_attentiontypeid) REFERENCES attentiontype(attentiontypeid),
	CONSTRAINT FK_ATTENTION_ATTENTIONSTATUS FOREIGN KEY (attentionstatus_statusid) REFERENCES attentionstatus(statusid)
)
GO

CREATE TABLE [user] (
	userid INT IDENTITY(1,1),
	username VARCHAR(50) NOT NULL,
	email VARCHAR(100) NOT NULL,
	password VARCHAR(100) NOT NULL,
	creationdate DATETIME NOT NULL,
	rol_rolid INT NOT NULL,
	userstatus_statusid VARCHAR(3),
	CONSTRAINT PK_USERID PRIMARY KEY CLUSTERED (userid),
	CONSTRAINT FK_USER_ROLID FOREIGN KEY (rol_rolid) REFERENCES rol(rolid),
	CONSTRAINT FK_USER_USERSTATUSID FOREIGN KEY (userstatus_statusid) REFERENCES userstatus(statusid)
)
GO

CREATE TABLE usercash (
	user_userid INT NOT NULL,
	cash_cashid INT NOT NULL,
	gestorid INT NOT NULL,
	CONSTRAINT FK_USERCASH_USERID FOREIGN KEY (user_userid) REFERENCES [user](userid),
	CONSTRAINT FK_USERCASH_CASHID FOREIGN KEY (cash_cashid) REFERENCES cash(cashid),
	CONSTRAINT PK_USERCASH PRIMARY KEY (user_userid, cash_cashid)
)
GO
CREATE TABLE menu (
	menuid INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	icon VARCHAR(20),
	description  VARCHAR(50)  NOT NULL,
	rol_rolid  INT NOT NULL,
	CONSTRAINT FK_MENU_ROLID FOREIGN KEY (rol_rolid) REFERENCES rol(rolid),

)
GO
CREATE TABLE contract (
	contractid INT IDENTITY(1,1),
	startdate DATETIME NOT NULL,
	enddate DATETIME NOT NULL,
	service_serviceid INT NOT NULL,
	statuscontract_statusid VARCHAR(3) NOT NULL,
	client_clientid INT NOT NULL,
	methodpayment_methodpaymentid INT NOT NULL,
	CONSTRAINT PK_CONTRACTID PRIMARY KEY CLUSTERED (contractid),
	CONSTRAINT FK_CONTRACT_SERVICEID FOREIGN KEY (service_serviceid) REFERENCES service(serviceid),
	CONSTRAINT FK_CONTRACT_STATUSCONTACTID FOREIGN KEY (statuscontract_statusid) REFERENCES statuscontract(statusid),
	CONSTRAINT FK_CONTRACT_CLIENTID FOREIGN KEY (client_clientid) REFERENCES client(clientid),
	CONSTRAINT FK_CONTRACT_METHODPAYMENTID FOREIGN KEY (methodpayment_methodpaymentid) REFERENCES methodpayment(methodpaymentid)
)
GO

CREATE TABLE payments (
	paymentid INT IDENTITY(1,1),
	paymentdate DATETIME NOT NULL,
	clientid INT NOT NULL,
	amount DECIMAL(10,2) NOT NULL,
	contractid INT NOT NULL,
	CONSTRAINT PK_PAYMENTID PRIMARY KEY CLUSTERED (paymentid),
	CONSTRAINT FK_PAYMENTS_CLIENTID FOREIGN KEY (clientid) REFERENCES client(clientid),
	CONSTRAINT FK_PAYMENTS_CONTRACTID FOREIGN KEY (contractid) REFERENCES contract(contractid)
)
GO

-- INSERT SCRIPTS

-- LOS DOS ROLES PARA LOS USUARIOS (MANAGER Y CASHIER)
INSERT INTO rol(rolname) VALUES
('manager'),
('cashier');
GO

-- LOS DOS ESTADOS DE LOS USUARIOS
INSERT INTO userstatus(statusid, description) VALUES 
('ACT', 'active'),
('INA', 'inactive');
GO

-- LOS DOS METODOS DE PAGO
INSERT INTO methodpayment (description)
VALUES ('cash'), ('card');
GO

-- LOS TRES SERVICIOS
INSERT INTO service (servicename, servicedescription, price) VALUES 
('100MB', 'Plan básico de datos', 25.99), 
('500MB', 'Plan estándar de datos', 37.99), 
('1GB', 'Plan premium de datos', 52.99);
GO

-- LOS TRES DISPOSITIVOS
INSERT INTO device (devicename, serviceid) VALUES 
('basic router', 1),
('advanced router', 2),
('X router', 3);
GO

-- LOS DOS ESTADOS DE CONTRATOS
INSERT INTO statuscontract (statusid, description) VALUES 
('ACT', 'active'),
('END', 'ended');
GO

-- LOS TIPOS DE ATENCION
INSERT INTO attentiontype (attentiontypeid, description) VALUES 
('PAY', 'Pagos'),
('NEW', 'Contratar Servicio'),
('CHS', 'Cambio de Servicio'),
('CMP', 'Cambio de Método de Pago'),
('CAN', 'Cancelación de Servicio');
GO

-- LOS ESTADOS DE ATENCION

INSERT INTO attentionstatus (description) VALUES 
('waiting'),
('taked'),
('ended');
GO
-- LAS OPCIONES DEL MENU

INSERT INTO menu (description, rol_rolid) VALUES 
('Registro Cajero',1),
('Registrar Caja',1),
('Asignar Caja',1),
('Registro Cliente',2),
('Registro Contrato de Servicio',2),
('Pagos',2),
('Cambio del Servicio Contratado',2),
('Cambio de Forma de Pago',2),
('Cancelación de Contrato del Servicio',2);
GO

-- CREAR USUARIO GESTOR SEMILLA

INSERT INTO [user] 
(
    username, 
    email, 
    password, 
    rol_rolid, 
    creationdate,
    userstatus_statusid
) VALUES
(
    'manager', 
    'manager@admin', 
    'admin', 
    1, 
    GETDATE(),
    'ACT'
);
GO

INSERT INTO client
(
	identification,
	name,
	lastname,
	email,
	phonenumber,
	address,
	referenceaddress
) VALUES 
(
	'0000000000',
	'Anonymous',
	'Anonymous',
	'Anonymous',
	'0000000000',
	'Anonymous Address',
	'Anonymous Address'
)
GO

INSERT INTO cash 
(
	cashdescription,
	active
) VALUES 
(
	'Waiting cash',
	'I'
)
GO

-- CREAR CLIENTES INICIALES PARA PRUEBAS

SELECT * FROM [user]
SELECT * FROM rol
SELECT * FROM device
SELECT * FROM service