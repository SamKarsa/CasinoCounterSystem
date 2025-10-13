PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS Role (
    roleId INTEGER PRIMARY KEY,
    roleName TEXT NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS Users (
    userId INTEGER PRIMARY KEY,
    userName TEXT NOT NULL,
    userPassword TEXT NOT NULL,
    userStatus INTEGER NOT NULL DEFAULT 1,
    roleId INTEGER NOT NULL,
    FOREIGN KEY (roleId) REFERENCES Role(roleId)
);

CREATE TABLE IF NOT EXISTS Route (
    routeId INTEGER PRIMARY KEY,
    routeName TEXT NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS TypeMachine (
    typeMachineId INTEGER PRIMARY KEY,
    nameTypeMachine TEXT NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS CoinType (
    coinTypeId INTEGER PRIMARY KEY,
    numCoin INTEGER NOT NULL UNIQUE,
    CHECK (numCoin > 0)
);

CREATE TABLE IF NOT EXISTS Machine (
    machineId INTEGER PRIMARY KEY,
    numberMachine TEXT NOT NULL UNIQUE,
    typeMachineId INTEGER NOT NULL,
    coinTypeId INTEGER NOT NULL,
    routeId INTEGER NOT NULL,
    FOREIGN KEY (typeMachineId) REFERENCES TypeMachine(typeMachineId),
    FOREIGN KEY (coinTypeId) REFERENCES CoinType(coinTypeId),
    FOREIGN KEY (routeId) REFERENCES Route(routeId)
);

-- infoMachineId = machineId (1:1)
CREATE TABLE IF NOT EXISTS InfoMachine (
    infoMachineId INTEGER PRIMARY KEY,
    nameClient TEXT,
    phone TEXT,
    address TEXT,
    FOREIGN KEY (infoMachineId) REFERENCES Machine(machineId)
);

CREATE TABLE IF NOT EXISTS CounterRecord (
    counterRecordId INTEGER PRIMARY KEY,
    recordDate TEXT NOT NULL,           -- 'YYYY-MM-DD'
    counterIn INTEGER NOT NULL,
    counterOut INTEGER NOT NULL,
    totalDelivered REAL NOT NULL,       -- dinero: REAL para avanzar rápido
    machineId INTEGER NOT NULL,
    FOREIGN KEY (machineId) REFERENCES Machine(machineId),
    CHECK (counterIn >= 0 AND counterOut >= 0),
    CHECK (totalDelivered >= 0)
);

-- Datos iniciales
INSERT OR IGNORE INTO Role (roleId, roleName) VALUES 
(1, 'Admin'),
(2, 'Counter Operator');

INSERT OR IGNORE INTO Users (userId, userName, userPassword, userStatus, roleId) 
VALUES (1, 'admin', 'admin123', 1, 1);

INSERT OR IGNORE INTO Users (userId, userName, userPassword, userStatus, roleId) 
VALUES (2, 'operator', 'operator123', 1, 2);

INSERT OR IGNORE INTO TypeMachine (typeMachineId, nameTypeMachine) VALUES 
(1, 'Poker'),
(2, 'MultiGame'),
(3, 'Pimball'),
(4, 'MultiPoker'),
(5, 'Duende'),
(6, 'Pikachu');

INSERT OR IGNORE INTO CoinType (coinTypeId, numCoin) VALUES 
(1,10)
(2, 50),
(3, 100),
(4, 200),
(5, 500),
(6, 1000);
