CREATE TABLE Contact (
  ContactId int NOT NULL AUTO_INCREMENT,
  CarrierId int NOT NULL,
  Name varchar(50) DEFAULT NULL,
  Title varchar(50) DEFAULT NULL,
  Location varchar(50) DEFAULT NULL,
  CreatedDate datetime NOT NULL,
  CreatedBy varchar(50) NOT NULL,
  ModifiedDate datetime DEFAULT NULL,
  ModifiedBy varchar(50) DEFAULT NULL,
  PRIMARY KEY (ContactId)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
SELECT * FROM carriers_db.Contact;

CREATE TABLE ContactAddresses (
  AddressId int NOT NULL AUTO_INCREMENT,
  ContactId int NOT NULL,
  CarrierId int NOT NULL,
  Address varchar(50) DEFAULT NULL,
  AddressType varchar(10) DEFAULT NULL,
  CreatedDate datetime NOT NULL,
  CreatedBy varchar(50) NOT NULL,
  ModifiedDate datetime DEFAULT NULL,
  ModifiedBy varchar(50) DEFAULT NULL,
  PRIMARY KEY (AddressId)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE ContactPhones (
  PhoneId int NOT NULL AUTO_INCREMENT,
  ContactId int NOT NULL,
  CarrierId int NOT NULL,
  PhoneNumber varchar(20) DEFAULT NULL,
  PhoneType varchar(10) DEFAULT NULL,
  CreatedDate datetime NOT NULL,
  CreatedBy varchar(50) NOT NULL,
  ModifiedDate datetime DEFAULT NULL,
  ModifiedBy varchar(50) DEFAULT NULL,
  PRIMARY KEY (PhoneId)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
