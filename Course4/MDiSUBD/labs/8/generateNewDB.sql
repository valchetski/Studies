DROP SCHEMA IF EXISTS `mynewdb` ;

-- -----------------------------------------------------
-- Schema mynewdb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mynewdb` DEFAULT CHARACTER SET utf8 ;
USE `mynewdb` ;


DROP TABLE IF EXISTS `mynewdb`.`Adress` ;

CREATE TABLE IF NOT EXISTS `mynewdb`.`Adress` (
  `idAdress` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Street` VARCHAR(45) NULL COMMENT '',
  `House` VARCHAR(45) NULL COMMENT '',
  `City` VARCHAR(45) NULL COMMENT '',
  `Country` VARCHAR(45) NULL COMMENT '',
  PRIMARY KEY (`idAdress`)  COMMENT ''  )
ENGINE = InnoDB;



DROP TABLE IF EXISTS `mynewdb`.`Company` ;

CREATE TABLE IF NOT EXISTS `mynewdb`.`Company` (
  `idCompany` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(45) NULL COMMENT '',
  `Adress_idAdress` INT NOT NULL COMMENT '',
  PRIMARY KEY (`idCompany`, `Adress_idAdress`)  COMMENT '',
  INDEX `fk_Company_Adress1_idx` (`Adress_idAdress` ASC)  COMMENT '',
  CONSTRAINT `fk_Company_Adress1`
    FOREIGN KEY (`Adress_idAdress`)
    REFERENCES `mynewdb`.`Adress` (`idAdress`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;



DROP TABLE IF EXISTS `mynewdb`.`Client` ;

CREATE TABLE IF NOT EXISTS `mynewdb`.`Client` (
  `idClient` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Firstname` VARCHAR(45) NULL COMMENT '',
  `Surname` VARCHAR(45) NULL COMMENT '',
  `BirthDate` DATE NULL COMMENT '',
  PRIMARY KEY (`idClient`)  COMMENT '')
ENGINE = InnoDB;



DROP TABLE IF EXISTS `mynewdb`.`TypeOfTour` ;

CREATE TABLE IF NOT EXISTS `mynewdb`.`TypeOfTour` (
  `idTypeOfTour` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(45) NULL COMMENT '',
  PRIMARY KEY (`idTypeOfTour`)  COMMENT '')
ENGINE = InnoDB;


DROP TABLE IF EXISTS `mynewdb`.`Insurance` ;

CREATE TABLE IF NOT EXISTS `mynewdb`.`Insurance` (
  `idInsurance` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(45) NULL COMMENT '',
  `Cost` DOUBLE NULL COMMENT '',
  `Insurancecol` VARCHAR(45) NULL COMMENT '',
  PRIMARY KEY (`idInsurance`)  COMMENT '')
ENGINE = InnoDB;



DROP TABLE IF EXISTS `mynewdb`.`Tour` ;

CREATE TABLE IF NOT EXISTS `mynewdb`.`Tour` (
  `idTour` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(45) NULL COMMENT '',
  `Cost` DOUBLE NULL COMMENT '',
  `TypeOfTour_idTypeOfTour` INT NOT NULL COMMENT '',
  `Company_idCompany` INT NOT NULL COMMENT '',
  `Insurance_idInsurance` INT NOT NULL COMMENT '',
  PRIMARY KEY (`idTour`, `TypeOfTour_idTypeOfTour`, `Company_idCompany`, `Insurance_idInsurance`)  COMMENT '',
  INDEX `fk_Tour_TypeOfTour1_idx` (`TypeOfTour_idTypeOfTour` ASC)  COMMENT '',
  INDEX `fk_Tour_Company1_idx` (`Company_idCompany` ASC)  COMMENT '',
  INDEX `fk_Tour_Insurance1_idx` (`Insurance_idInsurance` ASC)  COMMENT '',
  CONSTRAINT `fk_Tour_TypeOfTour1`
    FOREIGN KEY (`TypeOfTour_idTypeOfTour`)
    REFERENCES `mynewdb`.`TypeOfTour` (`idTypeOfTour`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Tour_Company1`
    FOREIGN KEY (`Company_idCompany`)
    REFERENCES `mynewdb`.`Company` (`idCompany`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Tour_Insurance1`
    FOREIGN KEY (`Insurance_idInsurance`)
    REFERENCES `mynewdb`.`Insurance` (`idInsurance`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;



DROP TABLE IF EXISTS `mynewdb`.`Company_has_Client` ;

CREATE TABLE IF NOT EXISTS `mynewdb`.`Company_has_Client` (
  `Company_idCompany` INT NOT NULL COMMENT '',
  `Client_idClient` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Company_idCompany`, `Client_idClient`)  COMMENT '',
  INDEX `fk_Company_has_Client_Client1_idx` (`Client_idClient` ASC)  COMMENT '',
  INDEX `fk_Company_has_Client_Company1_idx` (`Company_idCompany` ASC)  COMMENT '',
  CONSTRAINT `fk_Company_has_Client_Company1`
    FOREIGN KEY (`Company_idCompany`)
    REFERENCES `mynewdb`.`Company` (`idCompany`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Company_has_Client_Client1`
    FOREIGN KEY (`Client_idClient`)
    REFERENCES `mynewdb`.`Client` (`idClient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;



DROP TABLE IF EXISTS `mynewdb`.`Hotel` ;

CREATE TABLE IF NOT EXISTS `mynewdb`.`Hotel` (
  `idHotel` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(45) NULL COMMENT '',
  `StarsCount` INT NULL COMMENT '',
  `Adress_idAdress` INT NOT NULL COMMENT '',
  PRIMARY KEY (`idHotel`, `Adress_idAdress`)  COMMENT '',
  INDEX `fk_Hotel_Adress1_idx` (`Adress_idAdress` ASC)  COMMENT '',
  CONSTRAINT `fk_Hotel_Adress1`
    FOREIGN KEY (`Adress_idAdress`)
    REFERENCES `mynewdb`.`Adress` (`idAdress`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;



DROP TABLE IF EXISTS `mynewdb`.`Room` ;

CREATE TABLE IF NOT EXISTS `mynewdb`.`Room` (
  `idRoom` VARCHAR(20) NOT NULL COMMENT '',
  `CostPerDay` DOUBLE NULL COMMENT '',
  `Hotel_idHotel` INT NOT NULL COMMENT '',
  PRIMARY KEY (`idRoom`, `Hotel_idHotel`)  COMMENT '',
  INDEX `fk_Room_Hotel1_idx` (`Hotel_idHotel` ASC)  COMMENT '',
  CONSTRAINT `fk_Room_Hotel1`
    FOREIGN KEY (`Hotel_idHotel`)
    REFERENCES `mynewdb`.`Hotel` (`idHotel`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mynewdb`.`RoomReservation`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mynewdb`.`RoomReservation` ;

CREATE TABLE IF NOT EXISTS `mynewdb`.`RoomReservation` (
  `idRoomReservation` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `From` DATE NULL COMMENT '',
  `To` DATE NULL COMMENT '',
  `CurrentCostPerDay` DOUBLE NULL COMMENT '',
  `Room_idRoom` VARCHAR(20) NOT NULL COMMENT '',
  `Client_idClient` INT NOT NULL COMMENT '',
  PRIMARY KEY (`idRoomReservation`, `Room_idRoom`, `Client_idClient`)  COMMENT '',
  INDEX `fk_RoomReservation_Room1_idx` (`Room_idRoom` ASC)  COMMENT '',
  INDEX `fk_RoomReservation_Client1_idx` (`Client_idClient` ASC)  COMMENT '',
  CONSTRAINT `fk_RoomReservation_Room1`
    FOREIGN KEY (`Room_idRoom`)
    REFERENCES `mynewdb`.`Room` (`idRoom`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RoomReservation_Client1`
    FOREIGN KEY (`Client_idClient`)
    REFERENCES `mynewdb`.`Client` (`idClient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mynewdb`.`TourReservation`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mynewdb`.`TourReservation` ;

CREATE TABLE IF NOT EXISTS `mynewdb`.`TourReservation` (
  `idTourReservation` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `From` DATE NULL COMMENT '',
  `To` DATE NULL COMMENT '',
  `CurrentCost` DOUBLE NULL COMMENT '',
  `Tour_idTour` INT NOT NULL COMMENT '',
  `Client_idClient` INT NOT NULL COMMENT '',
  PRIMARY KEY (`idTourReservation`, `Tour_idTour`, `Client_idClient`)  COMMENT '',
  INDEX `fk_TourReservation_Tour1_idx` (`Tour_idTour` ASC)  COMMENT '',
  INDEX `fk_TourReservation_Client1_idx` (`Client_idClient` ASC)  COMMENT '',
  CONSTRAINT `fk_TourReservation_Tour1`
    FOREIGN KEY (`Tour_idTour`)
    REFERENCES `mynewdb`.`Tour` (`idTour`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TourReservation_Client1`
    FOREIGN KEY (`Client_idClient`)
    REFERENCES `mynewdb`.`Client` (`idClient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mynewdb`.`Tour_has_City`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mynewdb`.`Tour_has_City` ;

CREATE TABLE IF NOT EXISTS `mynewdb`.`Tour_has_City` (
  `Tour_idTour` INT NOT NULL COMMENT '',
  `City_idCity` INT NOT NULL COMMENT '',
  PRIMARY KEY (`Tour_idTour`, `City_idCity`)  COMMENT '',
  INDEX `fk_Tour_has_City_City1_idx` (`City_idCity` ASC)  COMMENT '',
  INDEX `fk_Tour_has_City_Tour1_idx` (`Tour_idTour` ASC)  COMMENT '',
  CONSTRAINT `fk_Tour_has_City_Tour1`
    FOREIGN KEY (`Tour_idTour`)
    REFERENCES `mynewdb`.`Tour` (`idTour`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Tour_has_City_City1`
    FOREIGN KEY (`City_idCity`)
    REFERENCES `mynewdb`.`City` (`idCity`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


