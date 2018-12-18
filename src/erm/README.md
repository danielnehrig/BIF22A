# School IT Devices/Components Managment System

## Synopsis
Createing a system that has a overview of devices the School owns
- Device Belongs or is in Room X
- Device / Component is broken and has to be rapaired
- Device / Component got repaired and is dated
- Various Informations about Device / Components ; Price, Description etc
- A Login System so Teachers can have a overview

## Planning
- Rules : Backend = c# ; Database = mssql
- Creating a ERM of the Database given by the tasks specifications
- Creating a MSSQL Transact Database by the created ERM
- Creating a Backend Controller Logic that communicates with the MSSQL
- Optional : Possible REST Backend
- Optional : AJAX Like Frontend System : Angular , VueJS , React

## Infrastructure

### Local Dev
- Debian (=Docker : MSSQL)
- Or any other

### Prod Dev
- Debian MSSQL, Backend C# Mono, Frontend NGINX

## Building the Project

### Requirements
- Mono
- Make
- NGINX
- MSSQL
- .NET (= System.data)

#### OSX
- install brew
- brew install mono make nginx docker

#### Linux (= Debian)
- apt-get install make mono nginx mssql

### Building
- cd into root project directory
- edit Config file Credentials for Database ./dist/server/config.example.cfg and save it as config.cfg
- make (= will build the project)
- make clean (= will clean out the dist folders)
- Backend is now good to go

## Run the Project
### Debian System
- Makeing sure Something like GNU Screen or TMUX is installed on the machine (= apt-get install screen tmux)
- Make sure MSSQL is running : systemctl status mssql
- Pull the database into MSSQL : sqlcmd -S localhost -U SA -i ./src/db/db.sql
- Run on one window(or Pane, Split) the Backend mono ./dist/server/Program.exe
- Make Sure NGINX is running : systemctl status nginx
