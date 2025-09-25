CREATE DATABASE CasinoCounter_DB;
GO

USE CasinoCounter_DB;
GO

CREATE TABLE Role (
    roleId INT PRIMARY KEY IDENTITY(1,1),
    roleName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Users (
    userId INT PRIMARY KEY IDENTITY(1,1),
    userName NVARCHAR(50) NOT NULL,
    userPassword NVARCHAR(100) NOT NULL,
    userStatus BIT NOT NULL DEFAULT 1,
    roleId INT NOT NULL,

    CONSTRAINT FK_User_Role FOREIGN KEY (roleId) REFERENCES Role(roleId)
);

CREATE TABLE Route (
    routeId INT PRIMARY KEY IDENTITY(1,1),
    routeName NVARCHAR(50) NOT NULL UNIQUE
);	

CREATE TABLE TypeMachine (
    typeMachineId INT PRIMARY KEY IDENTITY(1,1),
    nameTypeMachine NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE CoinType (
    coinTypeId INT PRIMARY KEY IDENTITY(1,1),
    numCoin INT NOT NULL UNIQUE,
    CONSTRAINT CHK_CoinType_PositiveNum CHECK (numCoin > 0) 
);

CREATE TABLE Machine (
    machineId INT PRIMARY KEY IDENTITY(1,1),
    numberMachine NVARCHAR(50) NOT NULL UNIQUE,
    typeMachineId INT NOT NULL,
    coinTypeId INT NOT NULL,
    routeId INT NOT NULL,

    CONSTRAINT FK_Machine_Type FOREIGN KEY (typeMachineId) REFERENCES TypeMachine(typeMachineId),
    CONSTRAINT FK_Machine_Coin FOREIGN KEY (coinTypeId) REFERENCES CoinType(coinTypeId),
    CONSTRAINT FK_Machine_Route FOREIGN KEY (routeId) REFERENCES Route(routeId)
);

CREATE TABLE InfoMachine (
    infoMachineId INT PRIMARY KEY,
    nameClient NVARCHAR(100) NULL,
    phone NVARCHAR(20) NULL,
    address NVARCHAR(150) NULL,

    CONSTRAINT FK_InfoMachine_Machine FOREIGN KEY (infoMachineId) REFERENCES Machine(machineId)
);

CREATE TABLE CounterRecord (
    counterRecordId INT PRIMARY KEY IDENTITY(1,1),
    recordDate DATE NOT NULL,
    counterIn BIGINT NOT NULL,
    counterOut BIGINT NOT NULL,
    totalDelivered MONEY NOT NULL,
    machineId INT NOT NULL,
    CONSTRAINT FK_CounterRecord_Machine FOREIGN KEY (machineId) REFERENCES Machine(machineId),
    CONSTRAINT CHK_CounterRecord_PositiveCounters CHECK (counterIn >= 0 AND counterOut >= 0),
    CONSTRAINT CHK_CounterRecord_PositiveDelivered CHECK (totalDelivered >= 0)
);

INSERT INTO Role (roleName) VALUES 
('Admin'),
('Counter Operator');

INSERT INTO Users (userName, userPassword, userStatus, roleId) 
VALUES ('admin', 'admin123', 1, 1);

INSERT INTO Users (userName, userPassword, userStatus, roleId) 
VALUES ('operator', 'operator123', 1, 2);

INSERT INTO TypeMachine (nameTypeMachine) VALUES 
('Poker'),
('MultiGame'),
('Pimball'),
('MultiPoker');

INSERT INTO CoinType (numCoin) VALUES 
(50),
(100),
(200);



