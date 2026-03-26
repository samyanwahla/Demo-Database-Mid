-- ============================================================
-- PhoneBook Demo Database Schema
-- Run this script FIRST before opening the Visual Studio project
-- ============================================================

-- Create and use the database
CREATE DATABASE IF NOT EXISTS PhoneBookDB;
USE PhoneBookDB;

-- Create Contacts table
CREATE TABLE IF NOT EXISTS Contacts (
    ContactId   INT AUTO_INCREMENT PRIMARY KEY,
    FirstName   VARCHAR(50)  NOT NULL,
    LastName    VARCHAR(50)  NOT NULL,
    PhoneNumber VARCHAR(20)  NOT NULL,
    Email       VARCHAR(100) NULL,
    Address     VARCHAR(200) NULL,
    CreatedAt   DATETIME     DEFAULT CURRENT_TIMESTAMP
);

-- Sample data
INSERT INTO Contacts (FirstName, LastName, PhoneNumber, Email, Address) VALUES
('Ali',    'Khan',   '0300-1234567', 'ali.khan@email.com',    'House 1, Street 5, Lahore'),
('Sara',   'Ahmed',  '0321-7654321', 'sara.ahmed@email.com',  'Flat 3, Block B, Karachi'),
('Usman',  'Raza',   '0333-1122334', 'usman.raza@email.com',  'Street 10, Islamabad'),
('Fatima', 'Malik',  '0345-9988776', 'fatima.malik@email.com','Colony Road, Faisalabad'),
('Hassan', 'Butt',   '0311-5566778', 'hassan.butt@email.com', 'Main Bazaar, Multan');
