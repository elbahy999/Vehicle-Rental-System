CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(100)
);

CREATE TABLE Vehicles (
    VehicleID INT PRIMARY KEY IDENTITY(1,1),
    Plate NVARCHAR(20) UNIQUE NOT NULL,
    VehicleType NVARCHAR(50),
    Brand NVARCHAR(50),
    DailyRate DECIMAL(10, 2) NOT NULL,
    IsAvailable BIT DEFAULT 1
);

CREATE TABLE Rentals (
    RentalID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    VehicleID INT NOT NULL,
    RentalStartDate DATE NOT NULL,
    RentalEndDate DATE NOT NULL,
    Status NVARCHAR(20),
    TotalCost DECIMAL(10, 2),
    
    CONSTRAINT FK_Rental_Customer FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    CONSTRAINT FK_Rental_Vehicle FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID)
);
