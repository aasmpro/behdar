# Behdar_DrugStore
drug store managment system, windows application (C#, SQLServer) 

# Requirements
### Production
this project had been written with `C#` using `.net framework v4` tools and use `SQL Server` as database engine. so you just need sql server installed.
1. create a database with `BehdarDrugStore` name
2. from directory `Behdar DrugStore SQL files` execute `dbo.tables.sql` to create needed tables

### Debuging
again `SQL Server` is needed with configurations like production, and a `C#` debuging tool. i would recommend using `Visual Studio` as it is the default Microsoft IDE for developing windows applications.

# Sample Data
after creating database in `SQL Server` if you need sample data to test the program, from directory `Behdar DrugStore SQL files` execute `dbo.sample.data.sql`.

__attention : this sample data contains unicode characters, in 'FA-IR' language code.__

### Repository Files
this project had been written for __Analysis and Design__ university course, so needed documentaions and extra files are included.
* directory `Behdar DrugStore` >> contains project code.
* directory `Behdar DrugStore Docs` >> contains Documentation files in `.Docx` and `.PDF` formats.
* directory `Behdar DrugStore EER Diagrams` >> contains EER diagram of project.
* directory `Behdar DrugStore Graphics` >> contains all the pictures, logos and any other graphic files used in this project, with `.PSD` files for editing.
* directory `Behdar DrugStore SQL files` >> contains `.SQL` files needed for creating database tables, and a sample data file, also in each subdirectory you can find sql code needed for operations like Delete, Update, ... on that table.
