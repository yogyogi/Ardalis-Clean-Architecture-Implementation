# Ardalis Clean Architecture Implementation
This is the implementation of Clean Architecture by Steve "Ardalis" Smith. Here CRUD operations on a Student Entity is performed. The repository contains the following things:

# Features
1. ASP.NET Core 8.0 version.
2. CRUD Operations on ASP.NET Core MVC.
3. MVC Views for the UI.
4. Number based Paging implementation for razor view.
5. Authentication and Authorization by Identity.
6. Login, Logout, Register features in Razor Pages.
7. Unit, Integration and Functional Tests.

# Running in your PC
1. Download the repository and run it. Then go to /Student/Read uri to start with the CRUD operations. 
2. For Identity you have to perform migrations. This will create Identity database.
Go to the directory of "Web" project where their is `Clean.Architecture.Web.csproj`. From here run the migration commands.


`dotnet ef migrations add MIGRATIONNAME -c AppIdentityDbContext -p ../Clean.Architecture.Infrastructure/Clean.Architecture.Infrastructure.csproj -s Clean.Architecture.Web.csproj -o Data/Migrations`

`dotnet ef database update --context AppIdentityDbContext`

   

## Want to support me ?

<a href="https://www.buymeacoffee.com/YogYogi" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" alt="Buy Me A Coffee" width="200"  style="height: 60px !important;width: 200px !important;" ></a>
