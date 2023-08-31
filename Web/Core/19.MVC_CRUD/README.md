Code First (EntityFramework]
Steps
1. Install 3 Packages in your application
	1. Microsoft.EntityFrameworkCore.SqlServer
	2. Microsoft.EntityFrameworkCore.Tools
		- They're primarily used to manage Migrations and to scaffold a DbContext
	3. Microsoft.EntityFrameworkCore.Design
		- Contains all the design-time logic for EntityFramework Core
2. Create a Model Class
3. Create a DbContext class
	- The DbContext class is an integral part of Entity Framework.
	- This is the class that we use in out application code to interact with the underlying database
	- It is this class that manages the database connection and is used to retrieve and save data in the database.
	- An instance of DbContext represents a session with the database which can be used to query and save instances of your entities to a database
	- DbContext is a combination of the Unit of Work and Repository patterns
	- DbContext can be used to define the database context class after creating a model class
4. Create a Connection String in appsettings.json file
5. Registering Connection String In Program.cs File
6. Add a migration and run the migration
	- PM> add-migration CodefirstCreateDB
	- PM> update-database
	- PM> add-migration CodeFirstAddClass
