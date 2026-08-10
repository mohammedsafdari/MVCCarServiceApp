# MVC Car Service App

A car service management web application built with **ASP.NET MVC 5 and C#**. The application demonstrates the use of the MVC architecture, Entity Framework, ASP.NET Identity, RESTful Web APIs, SQL Server LocalDB, and client-side web technologies.

## Overview

**MVCCarServiceApp** is a web-based car service management system designed to manage customers, vehicles, service types, and service requests.

The project combines traditional **ASP.NET MVC controllers and Razor views** with **ASP.NET Web API controllers** for application data operations.

## Features

* Customer management
* Customer search by name, email, and mobile number
* Car registration and management
* Car make and style management
* Service type management
* Service request creation and management
* Customer, car, and service information management
* REST-style Web API endpoints
* User registration and authentication
* Role-based application functionality
* ASP.NET Identity integration
* Entity Framework Code First with database migrations
* SQL Server LocalDB database
* Form validation
* Responsive web interface using Bootstrap
* Application monitoring with Application Insights

## Technology Stack

### Backend

* **C#**
* **ASP.NET MVC 5**
* **ASP.NET Web API 2**
* **.NET Framework 4.6.1**
* **Entity Framework 6.1.3**
* **ASP.NET Identity 2.2**
* **OWIN**

### Database

* **Microsoft SQL Server**
* **SQL Server LocalDB**
* **Entity Framework Code First & Migrations**

### Frontend

* **HTML5**
* **CSS3**
* **JavaScript**
* **jQuery**
* **Bootstrap**
* **Razor Views**

### Other

* **Newtonsoft.Json**
* **Microsoft Application Insights**
* **Visual Studio**
* **Git**

## Application Architecture

The project follows the **Model-View-Controller (MVC)** architectural pattern.

```text
                    ┌───────────────────┐
                    │    Web Browser    │
                    └─────────┬─────────┘
                              │
                              ▼
                    ┌───────────────────┐
                    │   MVC Controllers │
                    └─────────┬─────────┘
                              │
              ┌───────────────┼────────────────┐
              ▼               ▼                ▼
        ┌──────────┐    ┌───────────┐    ┌───────────┐
        │  Models  │    │ ViewModels│    │   Views   │
        └────┬─────┘    └───────────┘    └───────────┘
             │
             ▼
        ┌──────────────────┐
        │ Entity Framework │
        └────────┬─────────┘
                 │
                 ▼
        ┌──────────────────┐
        │ SQL Server /     │
        │ LocalDB          │
        └──────────────────┘
```

The application also exposes Web API controllers for operations involving cars, customers, services, service requests, car makes, and car styles.

## Main Components

### MVC Controllers

The application contains controllers for major application areas, including:

* `HomeController`
* `AccountController`
* `CustomerController`
* `CarController`
* `ServiceController`
* `AdminController`
* `ManageController`

For example, the `CustomerController` handles customer listing, searching, editing, and deletion. Customer searches can be performed using name, email, or mobile number.

### Web API

The application includes dedicated Web API controllers for:

* Cars
* Customers
* Car makes
* Car styles
* Services
* Service types
* Service requests

The car API supports retrieving, creating, updating, and deleting vehicle records.

Service requests can be retrieved, created, and deleted through the corresponding API controller.

## Data Models

The core domain models include:

* `Car`
* `CarMake`
* `CarStyle`
* `CarService`
* `ServiceType`
* `ServiceRequest`
* `ApplicationUser`

The project also contains dedicated ViewModels for combining customer, car, and service-related data for the MVC views.

## Authentication

User authentication is implemented using **ASP.NET Identity and OWIN**.

The application uses cookie-based authentication and supports external authentication providers through the OWIN authentication middleware.

## Database

The project uses **Entity Framework Code First** with SQL Server LocalDB.

The default configuration uses a LocalDB database and includes Entity Framework migrations for database schema management.

## Getting Started

### Prerequisites

Install the following:

* Visual Studio with ASP.NET/.NET Framework development tools
* .NET Framework 4.6.1
* SQL Server LocalDB
* IIS Express
* Git

### Clone the Repository

```bash
git clone https://github.com/mohammedsafdari/MVCCarServiceApp.git
```

### Open the Project

1. Open `MVCCarServiceApp.sln` in Visual Studio.
2. Restore the NuGet packages.
3. Build the solution.
4. Ensure SQL Server LocalDB is available.
5. Run the application using IIS Express.

### Database

The application is configured to use SQL Server LocalDB by default.

If required, update the connection string in:

```text
MVCCarServiceApp/Web.config
```

Entity Framework migrations included in the project can be used to create/update the database schema.

## Project Structure

```text
MVCCarServiceApp/
│
├── APIs/
│   ├── APICarController.cs
│   ├── APICarMakeController.cs
│   ├── APICarStyleController.cs
│   ├── APICustomerController.cs
│   ├── APIServiceController.cs
│   ├── APIServiceRequestController.cs
│   └── APIServiceTypeController.cs
│
├── Controllers/
│   ├── AccountController.cs
│   ├── AdminController.cs
│   ├── CarController.cs
│   ├── CustomerController.cs
│   ├── HomeController.cs
│   ├── ManageController.cs
│   └── ServiceController.cs
│
├── Models/
│   ├── Car.cs
│   ├── CarMake.cs
│   ├── CarStyle.cs
│   ├── CarService.cs
│   ├── ServiceRequest.cs
│   ├── ServiceType.cs
│   └── IdentityModels.cs
│
├── ViewModels/
│
├── Views/
│
├── App_Start/
│
├── Migrations/
│
├── Content/
│
├── Scripts/
│
├── Global.asax
├── Web.config
└── MVCCarServiceApp.csproj
```

## Learning Objectives

This project demonstrates practical implementation of:

* MVC architecture
* Object-oriented programming with C#
* ASP.NET MVC application development
* REST API development
* Entity Framework Code First
* Database migrations
* CRUD operations
* Authentication and authorization
* Model and ViewModel design
* Server-side and client-side validation
* SQL Server database integration
* Frontend and backend integration

## Project Status

This is a **legacy ASP.NET MVC / .NET Framework project** created as a practical demonstration of .NET web application development.

For modern production applications, the project could be further evolved using **ASP.NET Core, modern .NET, asynchronous APIs, dependency injection, and modern authentication practices**.

## Author

**Mohammed Safdari**

GitHub: [@mohammedsafdari](https://github.com/mohammedsafdari)

## License

This project is available for educational and demonstration purposes.
