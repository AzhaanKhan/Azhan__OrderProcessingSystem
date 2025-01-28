# Azhan__OrderProcessingSystem

# This is the Readme file for Order Processing System task

# I have used the ASP.NET Core Web API project for RestFul Web api

-----------Below are the Technologies I used for the web service-----------
--> ASP.NET Core: Framework for building the application.
--> Entity Framework Core :  for data access.
--> Serilog : Logging library for logging purpose.

#######################################################################

------------------------------------------Project Setup Instructions--------------------------------------------
1. Clone the repository:    
2. Ensure you have the .NET SDK installed.
3. Compile the project and restore or update any dependencies
4. Run the application:
5. Access the application at : http://localhost:5000

------------------------------------------Assumptions or Design Decisions------------------------------------------
- The application assumes a SQLite database is used for simplicity.
- The design follows a typical MVC pattern with separation of concerns.

------------------------------------------API Endpoints Documentation------------------------------------------
-  GET /api/orders: Retrieve all orders.
-  GET /api/orders/{id} : Retrieve a specific order by ID.
-  GET /api/orders/customers : Retrieve all customers.
-  GET /api/orders/customers/{id} : Retrieve a specific customer by ID.
-  POST /api/orders : Create a new order. The request body must include order details and products.

------------------------------------------Additional Notes for Reviewers------------------------------------------
- Ensure the database is properly set up before running the application.
- Review the logging configuration in 'Program.cs' for log file management.
- I have used Swagger API

##################################   Thank you   #####################################
