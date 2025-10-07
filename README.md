# Bar Pinguino

Bar Pinguino is a web-based point-of-sale (POS) and management system for a bar. It allows staff to manage sales, inventory, customers, and suppliers. The system is built with ASP.NET Core MVC and uses a SQL Server database.

## Features

*   **Point of Sale (POS):** Process sales, calculate totals, and apply discounts.
*   **Inventory Management:** Track product stock levels, set critical stock alerts, and manage product information.
*   **Customer Management:** Keep a record of customer information and track their purchase history.
*   **Supplier Management:** Store supplier details and manage relationships.
*   **User Management:** Different user roles (Admin, Sales) with different levels of access.
*   **Reporting:** Generate reports on sales, stock, and discounts.
*   **Email Notifications:** Automatically send receipts to customers via email.
*   **Database Backups:** Automated background service for database backups.

## Technologies Used

*   **Backend:** ASP.NET Core 8.0, C#
*   **Database:** Microsoft SQL Server, Entity Framework Core
*   **Frontend:** HTML, CSS, JavaScript, jQuery
*   **Authentication:** Cookie-based authentication
*   **Email:** MailKit, MimeKit

## Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

*   [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
*   [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1.  Clone the repo
    ```sh
    git clone https://github.com/your_username/Proyecto-Pinguino.git
    ```
2.  Navigate to the project directory
    ```sh
    cd Proyecto-Pinguino/BarPinguino
    ```
3.  Restore NuGet packages
    ```sh
    dotnet restore
    ```

### Configuration

1.  Open `appsettings.json` and update the `SqlConnec` connection string with your SQL Server details.
2.  Apply Entity Framework Core migrations to create the database schema.
    ```sh
    dotnet ef database update
    ```

### Running the Application

```sh
dotnet run
```

The application will be available at `https://localhost:5001` (or a similar port).

## Usage

The application has two main user roles:

*   **Admin:** Has full access to all features, including user management, financial reports, and system settings.
*   **Ventas (Sales):** Can process sales, manage customers, and view inventory.

The default login credentials are:

*   **Username:** admin
*   **Password:** admin

## Database

The application uses Entity Framework Core to manage the database. The data models are defined in the `Models` directory.

To create a new migration, use the following command:

```sh
dotnet ef migrations add YourMigrationName
```

To apply migrations to the database, use the following command:

```sh
dotnet ef database update
```

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m '''Add some AmazingFeature'''`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request
