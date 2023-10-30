-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema esquizofrenia
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema esquizofrenia
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `esquizofrenia` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `esquizofrenia` ;

-- -----------------------------------------------------
-- Table `esquizofrenia`.`cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `esquizofrenia`.`cliente` (
  `id_cliente` INT NOT NULL AUTO_INCREMENT,
  `nombre_apellido` VARCHAR(45) NULL DEFAULT NULL,
  `dni` VARCHAR(45) NULL DEFAULT NULL,
  `correo` VARCHAR(45) NULL DEFAULT NULL,
  `numTelefono` INT NULL DEFAULT NULL,
  `user` VARCHAR(45) NULL,
  `password` VARCHAR(45) NULL,
  `privilegio` INT NULL DEFAULT 1,
  PRIMARY KEY (`id_cliente`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `esquizofrenia`.`cuenta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `esquizofrenia`.`cuenta` (
  `id_cuenta` INT NOT NULL,
  `detalle` VARCHAR(45) NULL DEFAULT NULL,
  `precio` INT NULL DEFAULT NULL,
  `fecha` DATETIME NULL DEFAULT NULL,
  `CLIENTE_id_cliente` INT NOT NULL,
  PRIMARY KEY (`id_cuenta`, `CLIENTE_id_cliente`),
  INDEX `fk_CUENTA_CLIENTE1_idx` (`CLIENTE_id_cliente` ASC) VISIBLE,
  CONSTRAINT `fk_CUENTA_CLIENTE1`
    FOREIGN KEY (`CLIENTE_id_cliente`)
    REFERENCES `esquizofrenia`.`cliente` (`id_cliente`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `esquizofrenia`.`mesa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `esquizofrenia`.`mesa` (
  `id_mesa` INT NOT NULL AUTO_INCREMENT,
  `estado` VARCHAR(45) NULL DEFAULT 'disponible',
  PRIMARY KEY (`id_mesa`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `esquizofrenia`.`plato`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `esquizofrenia`.`plato` (
  `id_plato` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  `tamaño` VARCHAR(45) NULL DEFAULT 'mediano',
  `precio` DOUBLE NOT NULL,
  PRIMARY KEY (`id_plato`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `esquizofrenia`.`plato_has_cuenta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `esquizofrenia`.`plato_has_cuenta` (
  `plato_id_plato` INT NOT NULL,
  `cuenta_id_cuenta` INT NOT NULL,
  `cuenta_CLIENTE_id_cliente` INT NOT NULL,
  PRIMARY KEY (`plato_id_plato`, `cuenta_id_cuenta`, `cuenta_CLIENTE_id_cliente`),
  INDEX `fk_plato_has_cuenta_cuenta1_idx` (`cuenta_id_cuenta` ASC, `cuenta_CLIENTE_id_cliente` ASC) VISIBLE,
  INDEX `fk_plato_has_cuenta_plato1_idx` (`plato_id_plato` ASC) VISIBLE,
  CONSTRAINT `fk_plato_has_cuenta_cuenta1`
    FOREIGN KEY (`cuenta_id_cuenta` , `cuenta_CLIENTE_id_cliente`)
    REFERENCES `esquizofrenia`.`cuenta` (`id_cuenta` , `CLIENTE_id_cliente`),
  CONSTRAINT `fk_plato_has_cuenta_plato1`
    FOREIGN KEY (`plato_id_plato`)
    REFERENCES `esquizofrenia`.`plato` (`id_plato`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `esquizofrenia`.`recepcionista`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `esquizofrenia`.`recepcionista` (
  `id_recepcionista` INT NOT NULL AUTO_INCREMENT,
  `nombre_apellido` VARCHAR(45) NOT NULL,
  `dni` VARCHAR(45) NOT NULL,
  `user` VARCHAR(45) NULL,
  `password` VARCHAR(45) NULL,
  `privilegio` INT NULL DEFAULT 2,
  PRIMARY KEY (`id_recepcionista`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `esquizofrenia`.`reserva`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `esquizofrenia`.`reserva` (
  `id_reserva` INT NOT NULL AUTO_INCREMENT,
  `fecha` DATE NULL DEFAULT NULL,
  `hora` VARCHAR(5) NULL DEFAULT NULL,
  `num_telefono` INT NULL DEFAULT NULL,
  `correo` VARCHAR(45) NULL DEFAULT NULL,
  `mesa_id_mesa` INT NOT NULL,
  PRIMARY KEY (`id_reserva`, `mesa_id_mesa`),
  INDEX `fk_reserva_mesa1_idx` (`mesa_id_mesa` ASC) VISIBLE,
  CONSTRAINT `fk_reserva_mesa1`
    FOREIGN KEY (`mesa_id_mesa`)
    REFERENCES `esquizofrenia`.`mesa` (`id_mesa`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `esquizofrenia`.`reserva_has_cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `esquizofrenia`.`reserva_has_cliente` (
  `reserva_id_reserva` INT NOT NULL,
  `reserva_mesa_id_mesa` INT NOT NULL,
  `cliente_id_cliente` INT NOT NULL,
  `cliente_user_id_user` INT NOT NULL,
  PRIMARY KEY (`reserva_id_reserva`, `reserva_mesa_id_mesa`, `cliente_id_cliente`, `cliente_user_id_user`),
  INDEX `fk_reserva_has_cliente_cliente1_idx` (`cliente_id_cliente` ASC, `cliente_user_id_user` ASC) VISIBLE,
  INDEX `fk_reserva_has_cliente_reserva1_idx` (`reserva_id_reserva` ASC, `reserva_mesa_id_mesa` ASC) VISIBLE,
  CONSTRAINT `fk_reserva_has_cliente_cliente1`
    FOREIGN KEY (`cliente_id_cliente`)
    REFERENCES `esquizofrenia`.`cliente` (`id_cliente`),
  CONSTRAINT `fk_reserva_has_cliente_reserva1`
    FOREIGN KEY (`reserva_id_reserva` , `reserva_mesa_id_mesa`)
    REFERENCES `esquizofrenia`.`reserva` (`id_reserva` , `mesa_id_mesa`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
