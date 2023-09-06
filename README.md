# UserInterface

step by step
 	1. install the entityFramework core in your project directory
 	  command : dotnet add package Microsoft.EntityFrameworkCore
 	
  2. install the pmysql package for entity framework to beused for the project .
      	 command : dotnet add package Pomelo.EntityFrameworkCore.MySql
       
 3.   the startup Project should reference  Microsoft.EntityFrameworkCore.Design. This package is required for the Entity Framework Core Tools to work.
       		command : dotnet add package Microsoft.EntityFrameworkCore.Design
4.     With the believe you have your database classes .
 	  it time to createa database schema that turn the  code to database and table for use.
 	  command : dotnet ef migrations add InitialMigration
 	  
 	5.  apply the Migrations to your database 
 	  Command : dotnet ef database update

6.  command : dotnet build
7.  command: dotnet run
8.  Type r to register New User
9.  Tyepe l to login or U to Authenticate User. 
