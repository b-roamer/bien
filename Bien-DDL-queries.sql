CREATE SCHEMA `f1` ;

CREATE TABLE status(
   statusId INTEGER  NOT NULL PRIMARY KEY AUTO_INCREMENT
  ,status   VARCHAR(50) NOT NULL
);

CREATE TABLE seasons(
   year INTEGER  NOT NULL PRIMARY KEY 
  ,url  VARCHAR(255) NOT NULL
);

CREATE TABLE drivers(
   driverId    INTEGER  NOT NULL PRIMARY KEY AUTO_INCREMENT
  ,driverRef   VARCHAR(50) NOT NULL
  ,number      INTEGER  
  ,code        VARCHAR(3) 
  ,forename    VARCHAR(255) NOT NULL
  ,surname     VARCHAR(255) NOT NULL
  ,dob         DATE  NOT NULL
  ,nationality VARCHAR(255) NOT NULL
  ,url         VARCHAR(255)
);

CREATE TABLE constructors(
   constructorId  INTEGER  NOT NULL PRIMARY KEY AUTO_INCREMENT
  ,constructorRef VARCHAR(20) NOT NULL
  ,name           VARCHAR(255) NOT NULL
  ,nationality    VARCHAR(255) NOT NULL
  ,url            VARCHAR(255) NOT NULL
);

CREATE TABLE circuits(
   circuitId  INTEGER  NOT NULL PRIMARY KEY AUTO_INCREMENT
  ,circuitRef VARCHAR(20) NOT NULL
  ,name       VARCHAR(255) NOT NULL
  ,location   VARCHAR(255) NOT NULL
  ,country    VARCHAR(255) NOT NULL
  ,lat        NUMERIC(10,5) NOT NULL
  ,lng        NUMERIC(10,6) NOT NULL
  ,url        VARCHAR(255) NOT NULL
);

CREATE TABLE races(
   raceId    INTEGER  NOT NULL PRIMARY KEY AUTO_INCREMENT
  ,year      INTEGER  NOT NULL
  ,round     INTEGER  NOT NULL
  ,circuitId INTEGER  NOT NULL
  ,name      VARCHAR(255) NOT NULL
  ,date      DATE  NOT NULL
  ,time      VARCHAR(8) 
  ,url       VARCHAR(255) NOT NULL
  ,FOREIGN KEY (circuitId) REFERENCES circuits(circuitId)
);

CREATE TABLE driver_standings(
   driverStandingsId INTEGER  NOT NULL PRIMARY KEY AUTO_INCREMENT
  ,raceId            INTEGER  NOT NULL
  ,driverId          INTEGER  NOT NULL
  ,points            NUMERIC(5,2) NOT NULL
  ,position          INTEGER  NOT NULL
  ,positionText      INTEGER  NOT NULL
  ,wins              INTEGER  NOT NULL
  ,FOREIGN KEY (raceId) REFERENCES races(raceId)
  ,FOREIGN KEY (driverId) REFERENCES drivers(driverId)
);

CREATE TABLE constructor_results(
   constructorResultsId INTEGER  NOT NULL PRIMARY KEY AUTO_INCREMENT
  ,raceId               INTEGER  NOT NULL
  ,constructorId        INTEGER  NOT NULL
  ,points               NUMERIC(3,1) NOT NULL
  ,status               VARCHAR(2) 
  ,FOREIGN KEY (raceId) REFERENCES races(raceId)
  ,FOREIGN KEY (constructorId) REFERENCES constructors(constructorId)
);

CREATE TABLE constructor_standings(
   constructorStandingsId INTEGER  NOT NULL PRIMARY KEY AUTO_INCREMENT
  ,raceId                 INTEGER  NOT NULL
  ,constructorId          INTEGER  NOT NULL
  ,points                 NUMERIC(5,1) NOT NULL
  ,position               INTEGER  NOT NULL
  ,positionText           INTEGER  NOT NULL
  ,wins                   INTEGER  NOT NULL
  ,FOREIGN KEY (raceId) REFERENCES races(raceId)
  ,FOREIGN KEY (constructorId) REFERENCES constructors(constructorId)
);

CREATE TABLE lap_times(
   raceId       INTEGER  NOT NULL
  ,driverId     INTEGER  NOT NULL
  ,lap          INTEGER  NOT NULL
  ,position     INTEGER  
  ,time         VARCHAR(11) 
  ,milliseconds INTEGER  
  ,FOREIGN KEY (raceId) REFERENCES races(raceId)
  ,FOREIGN KEY (driverId) REFERENCES drivers(driverId)
);

CREATE TABLE pit_stops(
   raceId       INTEGER  NOT NULL
  ,driverId     INTEGER  NOT NULL
  ,stop         INTEGER  NOT NULL
  ,lap          INTEGER  NOT NULL
  ,time         VARCHAR(8) 
  ,duration     NUMERIC(9,3) 
  ,milliseconds INTEGER  
  ,FOREIGN KEY (raceId) REFERENCES races(raceId)
  ,FOREIGN KEY (driverId) REFERENCES drivers(driverId)
);

CREATE TABLE qualifying(
   qualifyId     INTEGER  NOT NULL PRIMARY KEY AUTO_INCREMENT
  ,raceId        INTEGER  NOT NULL
  ,driverId      INTEGER  NOT NULL
  ,constructorId INTEGER  NOT NULL
  ,number        INTEGER  
  ,position      INTEGER  
  ,q1            VARCHAR(9)
  ,q2            VARCHAR(9)
  ,q3            VARCHAR(9)
  ,FOREIGN KEY (raceId) REFERENCES races(raceId)
  ,FOREIGN KEY (driverId) REFERENCES drivers(driverId)
  ,FOREIGN KEY (constructorId) REFERENCES constructors(constructorId)
);

CREATE TABLE results(
   resultId        INTEGER  NOT NULL PRIMARY KEY AUTO_INCREMENT
  ,raceId          INTEGER  NOT NULL
  ,driverId        INTEGER  NOT NULL
  ,constructorId   INTEGER  NOT NULL
  ,number          INTEGER  
  ,grid            INTEGER  
  ,position        INTEGER  
  ,positionText    VARCHAR(2) 
  ,positionOrder   INTEGER  
  ,points          NUMERIC(4,2) 
  ,laps            INTEGER  
  ,time            VARCHAR(11) 
  ,milliseconds    INTEGER  
  ,fastestLap      INTEGER  
  ,ranks           INTEGER  
  ,fastestLapTime  VARCHAR(8) 
  ,fastestLapSpeed NUMERIC(7,3) 
  ,statusId        INTEGER  NOT NULL
  ,FOREIGN KEY (raceId) REFERENCES races(raceId)
  ,FOREIGN KEY (driverId) REFERENCES drivers(driverId)
  ,FOREIGN KEY (constructorId) REFERENCES constructors(constructorId)
  ,FOREIGN KEY (statusId) REFERENCES status(statusId)
);