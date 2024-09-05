# Simple .Net Core Template with EFCore and SQLite
This is a basic .NET Core web application template, ideal for smaller projects. Following are the features which makes this template a appropriate choice for very small API needs -  
1. No need for database server - This template utilizes SQLite as the database. For smaller projects, a large database may not be necessary, and avoiding a server setup can help save time and reduce costs. Although SQLite can technically store up to 140TB of data as per its documentation, larger files will increase storage requirements, and your deployment must be able to support this. 
2. API and Web components in same project
 
## Technology Stack
1. .NET Core 8.0.X 
2. SQLite 
3. EF Core 8.0.X 
4. Serilog 8.0.X

## Features Included
1. Pre-implemented Repository and Unit of Work patterns with example usage 
2. Dependency injection using .NET Core default dependency injection mechanism
3. Integrated third party file logging using Serilog 
4. Sample seed data for quick setup 
5. Standard .NET Core .gitignore file included 

