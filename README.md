# EYERUSALEM HABTEGEBREAL 1501186
# MyLibrary Desktop Application


"MyLibrary" is a C# Windows desktop application designed to manage a small library's book inventory and member borrowing records. This application demonstrates core concepts of **event-driven programming**, **WinForms UI design**, and **database integration** using ADO.NET.

---

## Features

* **User Authentication:** Secure login system with a `Users` table.
* **Books Management:**
    * View all books in a DataGridView.
    * Add new books.
    * Edit existing book details.
    * Delete books.
    * Input validation for book details.
* **Borrowers Management:**
    * View all registered borrowers in a DataGridView.
    * Add new borrowers.
    * Edit existing borrower details.
    * Delete borrowers.
    * Input validation for borrower details (including email format).
* **Book Issue/Return System:**
    * Issue books to borrowers, decrementing available copies.
    * Record issued books with issue and due dates.
    * Return books, incrementing available copies and marking the issue as returned.
* **Reports/Filtering (Bonus):**
    * Filter books by author or year range.
    * Generate a report of overdue books.

---

## Technical Details

* **Language:** C#
* **Framework:** .NET (WinForms)
* **Database:** SQL Server LocalDB
* **Data Access:** ADO.NET with parameterized queries for security.
* **Error Handling:** Robust `try-catch` blocks for database operations and user-friendly error messages.

---

## Setup and Installation

Follow these steps to set up and run the MyLibrary application:

1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/YourUsername/MyLibrary.git](https://github.com/YourUsername/MyLibrary.git)
    cd MyLibrary
    ```

2.  **Database Setup:**
    * Ensure you have **SQL Server Express or LocalDB** installed.
    * Open SQL Server Management Studio (SSMS) or Visual Studio's SQL Server Object Explorer.
    * Execute the `database/MyLibrary_Schema.sql` script to create the database and tables. This script also seeds the `Users` table with default login credentials.

3.  **Open in Visual Studio:**
    * Open the `MyLibrary.sln` solution file in Visual Studio (2019 or later recommended).

4.  **Restore NuGet Packages:**
    * Right-click on the "MyLibrary" solution in the Solution Explorer and select "Restore NuGet Packages" if prompted.

5.  **Configure Database Connection String:**
    * Open `App.config` within the main project.
    * Locate the `<connectionStrings>` section and ensure the connection string is correctly configured for your SQL Server LocalDB instance:
        ```xml
        <connectionStrings>
            <add name="MyLibraryDB" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyLibrary.mdf;Integrated Security=True;Connect Timeout=30" providerName="System.Data.SqlClient" />
        </connectionStrings>
        ```
        **Note:** The `|DataDirectory|` placeholder points to the application's executable directory. Ensure your `MyLibrary.mdf` database file is copied to the debug/release output directory after building.

6.  **Build the Application:**
    * Go to `Build` > `Build Solution` in Visual Studio.

7.  **Run the Application:**
    * Press `F5` or click the `Start` button in Visual Studio.

---

## Default Login Credentials

* **Username:** `admin`
* **Password:** `password123`

---

## Screenshots

Below are screenshots illustrating the key features of the MyLibrary application:

* **Login Form:**
    ![Login Form](docs/screenshots/login_form.png)

* **Main Window (Books Management Tab):**
    ![Books Management](docs/screenshots/books_management.png)

* **Add/Edit Book Form:**
    ![Add/Edit Book](docs/screenshots/add_edit_book.png)

* **Borrowers Management Tab:**
    ![Borrowers Management](docs/screenshots/borrowers_management.png)

* **Add/Edit Borrower Form:**
    ![Add/Edit Borrower](docs/screenshots/add_edit_borrower.png)

* **Issue Book Flow:**
    ![Issue Book](docs/screenshots/issue_book_flow.png)

* **Return Book Flow:**
    ![Return Book](docs/screenshots/return_book_flow.png)

* **(Bonus) Overdue Books Report:**
    ![Overdue Books Report](docs/screenshots/overdue_report.png)

---

## Database Schema (`database/MyLibrary_Schema.sql`)

```sql
-- SQL Server LocalDB Schema

-- Users Table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL -- Store hashed passwords, not plain text!
);

-- Books Table
CREATE TABLE Books (
    BookID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(100) NOT NULL,
    PublicationYear INT NOT NULL,
    AvailableCopies INT NOT NULL DEFAULT 1
);

-- Borrowers Table
CREATE TABLE Borrowers (
    BorrowerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE,
    Phone NVARCHAR(20)
);

-- IssuedBooks Table
CREATE TABLE IssuedBooks (
    IssueID INT PRIMARY KEY IDENTITY(1,1),
    BookID INT NOT NULL,
    BorrowerID INT NOT NULL,
    IssueDate DATE NOT NULL,
    DueDate DATE NOT NULL,
    ReturnDate DATE NULL, -- Null if not returned, or a specific date if returned
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
    FOREIGN KEY (BorrowerID) REFERENCES Borrowers(BorrowerID)
);

-- Seed Data
INSERT INTO Users (Username, PasswordHash) VALUES
('admin', 'password123'); -- In a real application, always use proper password hashing (e.g., BCrypt)

INSERT INTO Books (Title, Author, PublicationYear, AvailableCopies) VALUES
('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 5),
('To Kill a Mockingbird', 'Harper Lee', 1960, 3),
('1984', 'George Orwell', 1949, 7),
('Pride and Prejudice', 'Jane Austen', 1813, 4);

INSERT INTO Borrowers (Name, Email, Phone) VALUES
('Alice Smith', 'alice.s@example.com', '123-456-7890'),
('Bob Johnson', 'bob.j@example.com', '987-654-3210'),
('Charlie Brown', 'charlie.b@example.com', '555-123-4567');
