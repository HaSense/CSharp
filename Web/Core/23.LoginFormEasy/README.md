Session 기능 정리

Session
1. Step1
	- Add below line before build
		- builder.Services.AddSession()
	- Add blelow line after build
		- app.UseSession()
2. Step2
	- Create Session Variable
		- HttpContext.Session.SetString("MyKey", "Value")
	- We can set different type of values in a session
3. Step3
	- Access Session Variable
		- HttpContext.Session.GetString("MyKey")
4. Step4
	- If you want to access session directly in view, not in action method then you have to use HttpContextAccessor

What is Session
- It is state management technique
- Session state is an ASP.NET Core scenario for stroage of user data whie the user browses a web app
- Session state uses a store maintained by the app to persist data across requests from a client
- The session data is backed by cache and considered ephemeral data
- Critical application data should be stored in the user database and cached in session only as a performance optimization
- The session is specific to the browser, Sessions aren't shared access browsers
- Session are deleted when the browser session ends
- Sessions are Sever-Side
- Session is also used to pass data within the ASP.NET Core MVC application and unlike TempData
- It persist for its expiration time (default time is 20 minutes but it can be increaed or decreased)
- Session is valid for all requests, not for a single redirect
- A session state stores application-specific data in key-value pairs
- A session state stores user-specific information for an ASP.NET MVC application
- However, the scope of session state is limited to the current browser session
- When many users access an application simultaneously, then, each of these users will have a different session state
- Every session has a unique session id

Creating Login Form with DB Using Session & Logout 
- Phases(단계)
	1. Setup Session in ASP.NET Core App in Program.cs
		- builder.Services.AddSession()
		- app.UseSession()
	2. Implementing Database First Approach
		1. install 3 Package
			- Microsoft.EntityFrameworkCore.SqlServer
			- Microsoft.EntityFrameworkCore.Tools
			- Microsoft.EntityFrameworkCore.Design
		2. Execute a command for scaffold DbContext
			- Scaffold-DbContext "server=ServerName;database=DatabaseName;trusted_connection=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
			- Above command will generate model class and DbContext class automatically
		3. Move Connection String from DbContext Class to appsettings.json file
		4. Registering Connection String in Program.cs file
	3. Login & Logout Task
		- Create action methods for login and logout
		- Create session variable in login action method and how we can access it
