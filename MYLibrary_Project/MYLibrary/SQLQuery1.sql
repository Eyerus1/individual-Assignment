CREATE DATABASE LibraryManagementSystem;
GO
USE LibraryManagementSystem;
GO

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL -- Ideally hashed, but plain text for simplicity
);

CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Author NVARCHAR(100) NOT NULL,
    Year INT CHECK (Year BETWEEN 1000 AND 9999),
    AvailableCopies INT CHECK (AvailableCopies >= 0)
);

CREATE TABLE Borrowers (
    BorrowerID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20)
);

CREATE TABLE IssuedBooks (
    IssueID INT IDENTITY(1,1) PRIMARY KEY,
    BookID INT FOREIGN KEY REFERENCES Books(BookID),
    BorrowerID INT FOREIGN KEY REFERENCES Borrowers(BorrowerID),
    IssueDate DATE NOT NULL,
    DueDate DATE NOT NULL,
    Returned BIT DEFAULT 0
);

-- Insert default user
INSERT INTO Users (Username, Password) VALUES ('etsub', 'admin123');
select *from Users;
select *from Books;
select *from Borrowers;
select *from IssuedBooks;

