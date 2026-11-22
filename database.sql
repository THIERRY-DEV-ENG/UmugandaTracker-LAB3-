-- Umuganda Tracker Database Setup Script
-- Compatible with MySQL / MariaDB (XAMPP)

CREATE DATABASE IF NOT EXISTS UmugandaDB;
USE UmugandaDB;

-- Drop existing tables in reverse dependency order
DROP TABLE IF EXISTS Attendance;
DROP TABLE IF EXISTS UmugandaEvents;
DROP TABLE IF EXISTS Zones;
DROP TABLE IF EXISTS Users;

-- 1. Users Table
CREATE TABLE Users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,
    Role VARCHAR(20) NOT NULL DEFAULT 'Member'
);

-- 2. Zones Table
CREATE TABLE Zones (
    ZoneID INT AUTO_INCREMENT PRIMARY KEY,
    ZoneName VARCHAR(100) NOT NULL,
    Location VARCHAR(100) NOT NULL
);

-- 3. Umuganda Events Table
CREATE TABLE UmugandaEvents (
    EventID INT AUTO_INCREMENT PRIMARY KEY,
    EventName VARCHAR(100) NOT NULL,
    EventDate DATE NOT NULL,
    ZoneID INT NOT NULL,
    CONSTRAINT FK_Events_Zones FOREIGN KEY (ZoneID) REFERENCES Zones(ZoneID) ON DELETE CASCADE
);

-- 4. Attendance Table
CREATE TABLE Attendance (
    AttendanceID INT AUTO_INCREMENT PRIMARY KEY,
    EventID INT NOT NULL,
    UserID INT NOT NULL,
    Status VARCHAR(50) NOT NULL,
    CONSTRAINT FK_Attendance_Events FOREIGN KEY (EventID) REFERENCES UmugandaEvents(EventID) ON DELETE CASCADE,
    CONSTRAINT FK_Attendance_Users FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
);

-- Sample Data Seeding

-- Administrators & Citizens
INSERT INTO Users (FullName, Username, Password, Role) VALUES
('Administrator', 'admin', 'admin123', 'Admin'),
('Kamanzi Eric', 'kamanzi', 'pass123', 'Member'),
('Masoyinyana Maso', 'masoyinyanna', 'aaa', 'Member');

-- Administrative Community Zones
INSERT INTO Zones (ZoneName, Location) VALUES
('Gasabo Zone', 'Kigali - Gasabo District'),
('Kicukiro Zone', 'Kigali - Kicukiro District'),
('Nyarugenge Zone', 'Kigali - Nyarugenge District'),
('Rubavu Zone', 'Western Province - Gisenyi');

-- Scheduled Umuganda Activities
INSERT INTO UmugandaEvents (EventName, EventDate, ZoneID) VALUES
('Monthly Community Clean-up & Road Maintenance', CURDATE(), 1),
('Water Canal & Drainage Clearing', CURDATE(), 2),
('Tree Planting & Anti-Erosion Terracing', CURDATE(), 3);

-- Sample Initial Attendance
INSERT INTO Attendance (EventID, UserID, Status) VALUES
(1, 2, 'Checked-In (08:15 AM)');
