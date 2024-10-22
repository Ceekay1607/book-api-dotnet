# Bookstore API

## Overview

This project implements a simple RESTful API for managing a bookstore. The API supports CRUD (Create, Read, Update, Delete) operations for a list of books and includes various features such as authentication, logging, and data validation, built with modern best practices.

## Features

- **Routing**: Defined API endpoints under the path `/api/books`.
- **Model Binding**: A `Book` model with properties like `Id`, `Title`, `Author`, and `Price` that binds request data from clients.
- **Dependency Injection**: 
  - A `BookService` for operations on book data.
  - A `LogService` for logging activities using Serilog.
- **Middleware**:
  - Logging middleware for incoming requests.
  - Exception handling middleware for unhandled exceptions.
- **Authentication/Authorization**: Secured with JWT, allowing only authenticated users to modify book data.
- **Data Validation**: Validation attributes on the `Book` model to ensure `Title` and `Author` are not empty and `Price` is a positive number.
- **Entity Framework Core**: For database management of book data.
- **Asynchronous Programming**: Utilizes `async/await` for non-blocking data operations.

## Getting Started

### Prerequisites

- .NET SDK (version 6.0 or later)
- A suitable database (SQL Server, SQLite, etc.)