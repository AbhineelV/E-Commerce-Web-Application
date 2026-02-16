# E-Commerce-Web-Application

📌 Project Overview

This is a backend-driven E-Commerce Web Application developed using ASP.NET Web Forms, C#, and SQL Server.
The application allows users to add products, manage cart items, calculate totals, process payments, and place orders by submitting customer details.

## 🚀 Features
- Product Management (Add & Display Products)
- Add to Cart Functionality
- Quantity Update & Automatic Total Calculation
- Cart Summary with Grand Total
- Payment Page Integration
- Customer Details & Order Placement
- Automatic Cart Clearance After Order

## 🏗️ Modules
1️⃣ Product Module
- Insert product details (Name, Cost, Photo)
- Display products using DataList
- Add selected products to cart

## 2️⃣ Cart Module
- Display cart items using GridView
- Update quantity and calculate total price
- Redirect to payment page

## 3️⃣ Payment Module
- Calculate grand total using SQL SUM() function
- Proceed to customer details page

## 4️⃣ Customer Module
- Capture customer information
- Store order details in database
- Clear cart after successful order placement

## 🛠️ Technologies Used
- Frontend: ASP.NET Web Forms
- Backend: C#
- Database: SQL Server
- Data Access: ADO.NET (SqlConnection, SqlCommand, SqlDataReader)

## 🗄️ Database Tables
- productDB – Stores product details
- cardDB – Stores cart items
- customerDB – Stores customer and order details

## 🔐 Security Features
- Used parameterized SQL queries to prevent SQL Injection
- Implemented proper database connection handling
