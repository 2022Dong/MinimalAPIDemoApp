# UserDB
add new project : SQL Server Database Project (UserDB)

not recommend use entity framework
add folder (dbo & Tables-add Table(User.sql))j
add folder (StoreProcedures - add stored proceddures files)
add Script - Script.PostDeployment.sql // dummy data.

Publish - right click UserDB  -- need to recreate UserDB.publish.xml

# Class Library
install 3 NuGet inside the class library (DataAceess - SqlDataAccess.cs) 
Dapper
Microsoft.Extensions.Configuration.Abstractions
System.Data.SqlClient


# API
1. Program.cs -- hiden async Main ie.

namespace MinimalAPI
{
    partial class Program
    {
        static async Task Main(string[] args)
        {
            ...

2. add file GlobalUsing.cs -- less packing Program.cs


# run error
tweak ConnectionStrings error - take out the spaces

# Testing
![image](https://github.com/2022Dong/MinimalAPIDemoApp/assets/110579171/258215a6-35e5-46bd-9e71-800319b80fa9)
