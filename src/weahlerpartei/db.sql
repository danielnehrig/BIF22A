DROP DATABASE IF EXISTS POLITIK;
CREATE DATABASE POLITIK;
USE POLITIK;

CREATE TABLE tbl_partei (id int AUTO_INCREMENT primary key, name varchar(40));
CREATE TABLE tbl_weahler (id int AUTO_INCREMENT primary key, name varchar(40), nachname varchar(40));
