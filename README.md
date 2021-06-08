# ServiceSchedulerApp

Instructions to Startup Application

Requirements :
1) Visual Studio 2019 Community
2) Blazor Framework Installed
3) Entity Framework Installed
4) MS SQL Installed

Steps :
1) Open the solution using visual studio 2019
2) Batch Build whole solution, so it will install all the required packages
3) Verify your MS SQL Management Studio connection using Server Name : localhost and authenticate it using windows authentication
4) In Visual Studio, Go To package manager console run command -> update-database -verbose 
   This will execute all the migrations present in the project.
5) Start the project using IIS Express

Application's functionality :
1) Service Operators are mentioned in SeedData Method in ApplicationDbContext Class.
2) As Database is new, so no user is registered yet, You need to register your own email to verify the application. Go to registeration page and do the process.
3) After login, 2 tabs will be displayed i.e My Appointments & Create Appointment

Thank You

