# BookLibrary

BookLibrary is a simple ASP.NET Core MVC application for managing a collection
of books. It supports listing, viewing, creating, editing, and deleting books.
Book data is stored in PostgreSQL through Entity Framework Core.

## Tech stack

- **.NET 10**
- **ASP.NET Core MVC**
- **C#**
- **Entity Framework Core 10**
- **PostgreSQL**
- **Npgsql Entity Framework Core provider**
- **Razor Views**

## Project structure

- `Models/Book.cs` - Book entity and validation rules.
- `Controllers/BooksController.cs` - Handles browser requests for books.
- `Services/BookService.cs` - Contains book data operations.
- `Data/BookLibraryContext.cs` - Entity Framework Core database context.
- `Views/Books/` - Razor pages for the book screens.
- `Migrations/` - Entity Framework Core database migrations.

## Requirements

- .NET 10 SDK
- PostgreSQL database

## Configuration

Set the `DefaultConnection` connection string in `appsettings.json`,
`appsettings.Development.json`, or user secrets:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=booklibrary;Username=postgres;Password=your-password"
  }
}
```

Do not commit real database passwords or other secrets to source control.

## Run the application

From the project directory, restore dependencies and start the application:

```bash
dotnet restore
dotnet run
```

Open the HTTPS URL shown in the terminal. The default route opens the books
index page:

```text
/
```

To build without starting the application:

```bash
dotnet build
```

## Endpoints

The application uses conventional ASP.NET Core MVC routes:

| Method | Route | Description |
|---|---|---|
| `GET` | `/` or `/Books/Index` | Display all books |
| `GET` | `/Books/Details/{id}` | Display one book |
| `GET` | `/Books/Create` | Display the create-book form |
| `POST` | `/Books/Create` | Validate and create a book |
| `GET` | `/Books/Edit/{id}` | Display the edit-book form |
| `POST` | `/Books/Edit/{id}` | Validate and update a book |
| `GET` | `/Books/Delete/{id}` | Display the delete confirmation page |
| `POST` | `/Books/Delete/{id}` | Delete a book |

The create, edit, and delete POST actions use antiforgery validation and are
intended to be submitted from the Razor forms.

## Book fields

| Field | Type | Rules |
|---|---|---|
| `Id` | Integer | Generated primary key |
| `Title` | String | Required, maximum 255 characters |
| `Author` | String | Required, maximum 255 characters |
| `ISBN` | String | Required, maximum 10 characters |
| `Description` | String | Optional, maximum 1000 characters |
| `Price` | Decimal | From `0` to `999999.99` |
| `Quantity` | Integer | From `0` to `10000` |
| `Genre` | String | Optional, maximum 100 characters |
| `PublishedDate` | Date/time | Use an ISO 8601 UTC value |
| `CreatedAt` | Date/time | Set by the application |
| `UpdatedAt` | Date/time | Set by the application |

Example book data:

```json
{
  "title": "Clean Code",
  "author": "Robert C. Martin",
  "isbn": "9780132350",
  "description": "A handbook of agile software craftsmanship.",
  "price": 39.99,
  "quantity": 25,
  "genre": "Programming",
  "publishedDate": "2008-08-01T00:00:00Z"
}
```

`PublishedDate` should include `Z` or another explicit UTC offset so it can be
stored correctly by PostgreSQL.
