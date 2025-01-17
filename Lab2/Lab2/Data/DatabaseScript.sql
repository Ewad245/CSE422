-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DeviceManagementDB')
BEGIN
    CREATE DATABASE DeviceManagementDB;
END
GO

USE DeviceManagementDB;
GO

-- Create Tables
CREATE TABLE DeviceStatus (
    StatusId INT IDENTITY(1,1) PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL
);

CREATE TABLE DeviceCategory (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL
);

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(200) NOT NULL,
    Email NVARCHAR(200) NOT NULL,
    PhoneNumber NVARCHAR(50)
);

CREATE TABLE Device (
    DeviceId INT IDENTITY(1,1) PRIMARY KEY,
    DeviceName NVARCHAR(200) NOT NULL,
    DeviceCode NVARCHAR(100) NOT NULL,
    CategoryId INT NOT NULL,
    StatusId INT NOT NULL,
    DateOfEntry DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (CategoryId) REFERENCES DeviceCategory(CategoryId),
    FOREIGN KEY (StatusId) REFERENCES DeviceStatus(StatusId)
);

CREATE TABLE DeviceAssignment (
    AssignmentId INT IDENTITY(1,1) PRIMARY KEY,
    DeviceId INT NOT NULL,
    UserId INT NOT NULL,
    AssignmentDate DATETIME NOT NULL DEFAULT GETDATE(),
    ReturnDate DATETIME NULL,
    FOREIGN KEY (DeviceId) REFERENCES Device(DeviceId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
GO

-- Insert Mock Data

-- Device Statuses
INSERT INTO DeviceStatus (StatusName) VALUES
('In use'),
('Broken'),
('Under maintenance');
GO

-- Device Categories
INSERT INTO DeviceCategory (CategoryName) VALUES
('Computer'),
('Printer'),
('Phone'),
('Network Equipment'),
('Projector');
GO

-- Users
INSERT INTO Users (FullName, Email, PhoneNumber) VALUES
('John Smith', 'john.smith@example.com', '555-0101'),
('Sarah Johnson', 'sarah.j@example.com', '555-0102'),
('Michael Brown', 'michael.b@example.com', '555-0103'),
('Emily Davis', 'emily.d@example.com', '555-0104'),
('David Wilson', 'david.w@example.com', '555-0105');
GO

-- Devices
INSERT INTO Device (DeviceName, DeviceCode, CategoryId, StatusId, DateOfEntry) VALUES
('Dell XPS 15', 'COMP001', 1, 1, '2024-01-10'),
('HP LaserJet Pro', 'PRN001', 2, 1, '2024-01-11'),
('iPhone 14 Pro', 'PHN001', 3, 1, '2024-01-12'),
('Cisco Switch', 'NET001', 4, 1, '2024-01-13'),
('Epson Projector', 'PRJ001', 5, 1, '2024-01-14'),
('Lenovo ThinkPad', 'COMP002', 1, 2, '2024-01-15'),
('Canon ImageRunner', 'PRN002', 2, 3, '2024-01-16'),
('Samsung Galaxy S23', 'PHN002', 3, 1, '2024-01-17'),
('Dell Latitude', 'COMP003', 1, 1, '2024-01-17'),
('HP OfficeJet', 'PRN003', 2, 2, '2024-01-17');
GO

-- Device Assignments
INSERT INTO DeviceAssignment (DeviceId, UserId, AssignmentDate, ReturnDate) VALUES
(1, 1, '2024-01-10', NULL),
(2, 2, '2024-01-11', NULL),
(3, 3, '2024-01-12', NULL),
(4, 4, '2024-01-13', NULL),
(5, 5, '2024-01-14', NULL),
(8, 1, '2024-01-15', NULL);
GO

-- Create Indexes for better performance
CREATE INDEX IX_Device_CategoryId ON Device(CategoryId);
CREATE INDEX IX_Device_StatusId ON Device(StatusId);
CREATE INDEX IX_DeviceAssignment_DeviceId ON DeviceAssignment(DeviceId);
CREATE INDEX IX_DeviceAssignment_UserId ON DeviceAssignment(UserId);
GO
