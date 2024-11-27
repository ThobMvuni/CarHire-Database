# CarHire-Database

## Project Overview

This project provides a **Car Hire Database** designed to manage a fleet of rental cars. The system allows users to create, update, and delete records for individual vehicles in the database. It is intended to facilitate the management of car rental operations, enabling efficient tracking of available cars, their details, and rental statuses.

### Key Features:
- **Create**: Add new vehicles to the rental fleet with essential details.
- **Update**: Modify details of existing vehicles, such as availability, rental status, or condition.
- **Delete**: Remove vehicles from the fleet when they are no longer in service or need to be replaced.

## Table of Contents
- [Installation Instructions](#installation-instructions)
- [Database Schema](#database-schema)
- [Usage](#usage)
- [Endpoints](#endpoints)
- [Contributing](#contributing)
- [License](#license)

## Installation Instructions

Follow these steps to set up the **Car Hire Database** locally:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/YourUsername/CarHire-Database.git
   cd CarHire-Database
Set up the Database:

    You can use MySQL, PostgreSQL, or any database system of your choice.
    For example, using MySQL, create a database:

    CREATE DATABASE car_hire;

Configure Database Connection:

    In the config file (or equivalent), provide your database connection details, such as host, username, password, and database name.
    Example for MySQL in config/db.js (if applicable):

    const mysql = require('mysql');
    const connection = mysql.createConnection({
      host: 'localhost',
      user: 'root',
      password: 'yourpassword',
      database: 'car_hire'
    });
    connection.connect();

Set up Tables:

    Run the SQL schema to create the necessary tables in the database. Here is an example SQL for creating a cars table:

    CREATE TABLE cars (
      id INT AUTO_INCREMENT PRIMARY KEY,
      make VARCHAR(50),
      model VARCHAR(50),
      year INT,
      color VARCHAR(30),
      registration_number VARCHAR(50),
      rental_status ENUM('available', 'rented', 'maintenance') DEFAULT 'available'
    );

Install Required Dependencies:

    If you're using Node.js, for example, run:

        npm install

Database Schema

The database contains the following table:
cars
Column	Type	Description
id	INT	Unique identifier for each car (Primary Key).
make	VARCHAR(50)	The make of the car (e.g., Toyota, Honda).
model	VARCHAR(50)	The model of the car (e.g., Corolla, Civic).
year	INT	The year the car was manufactured.
color	VARCHAR(30)	The color of the car.
registration_number	VARCHAR(50)	The car's registration or license plate number.
rental_status	ENUM	The status of the car: available, rented, maintenance (default: available).
Usage

Once the database is set up, the system allows for basic CRUD (Create, Read, Update, Delete) operations on the cars table.
1. Create a Car Record

To add a new car to the database, you can use the following endpoint (assuming a REST API setup):

POST /cars

{
  "make": "Toyota",
  "model": "Corolla",
  "year": 2020,
  "color": "Blue",
  "registration_number": "ABC123",
  "rental_status": "available"
}

This will insert a new record into the cars table.
2. Update a Car Record

To update an existing car's details (e.g., rental status), use the following endpoint:

PUT /cars/:id

{
  "rental_status": "rented"
}

This will update the rental status of the car with the given id.
3. Delete a Car Record

To remove a car from the fleet, use the following endpoint:

DELETE /cars/:id This will delete the car with the specified id from the database.
Example Queries

Here are a few example SQL queries that match the above operations:

    Create a car:

INSERT INTO cars (make, model, year, color, registration_number, rental_status)
VALUES ('Toyota', 'Corolla', 2020, 'Blue', 'ABC123', 'available');

Update a car (change rental status to rented):

UPDATE cars
SET rental_status = 'rented'
WHERE id = 1;

Delete a car:

    DELETE FROM cars WHERE id = 1;

Endpoints

If you are building a web API for this project, here are some example endpoints for interacting with the car hire database:
HTTP Method	Endpoint	Action	Request Body Example
GET	/cars	List all cars	N/A
GET	/cars/:id	Get details of a car	N/A
POST	/cars	Create a new car	{"make": "Toyota", "model": "Corolla", "year": 2020, "color": "Blue", "registration_number": "ABC123", "rental_status": "available"}
PUT	/cars/:id	Update car details	{"rental_status": "rented"}
DELETE	/cars/:id	Delete a car	N/A
Contributing

We welcome contributions to this project! To contribute, please fork the repository and create a pull request with your changes. Here's how you can get started:

    Fork the repository.
    Create a new branch for your feature or bug fix.
    Make your changes and test them.
    Submit a pull request describing your changes.

Please ensure that all code is properly documented and adheres to the project's style guide.
License

This project is licensed under the MIT License - see the LICENSE file for details.
