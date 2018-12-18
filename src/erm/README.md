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
- Debian MSSQL, Backend C#, Frontend

## Building the Project

### Requirements
- Mono
- Make
- .NET (=System.data)

### Building
- make (= will build the project)
- make clean (= will clean out the dist folders)
