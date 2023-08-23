Model

- View <--> Controller <--> Model --> Application data
- Model --> c# classes --> Data Source --> Database
                                                                            --> Manual List or Collection
- A Model is a class with .cs as an extension having both properties and method
- If application has No data. does 't need the model
- If application has data. Need the Model 
- The models in ASP.net Core MVC Application are used to manage the data
- Model --> Student.cs --> View(Table화면)
- Controller <--> Repository <--> Data Access layer -> Model
- Controller <--> Repository <---> DBContext(Data Access Layer) -> DB
- Repository Pattern
	- with the Repository pattern, we create an abstraction layer between the data access and the business logic layer of an application
	- By using it, we are promoting a more loosely coupled approach to access our data from the database
	- Also, the code is cleaner and eaiser to maintaiin and reuse.
