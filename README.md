# 🍕 Pizzeria Ordering & Management System

A Windows desktop application for a pizzeria. **Customers place their own orders** through an order window, while the **admin** logs in to manage the menu, inventory, staff, expenses, transactions and sales reports.

Built with **VB.NET (Windows Forms)** and **MySQL/MariaDB**.

> Final project for FDS – Computer Programming
> **Author:** Isidro Dumagcao *(add your groupmates here)*

---

## Features

### Customer side
- Order window to browse the menu with product photos
- Add items to an order and see the running order total
- Enter name (first name required, last name optional) when ordering
- Receipt generated after the order (Crystal Reports / PDF)

### Admin side (login required)
- **Product inventory:** manage the products menu, product details and photos
- **Ingredient inventory:** ingredient batches, expiry dates and an adjustment history log
- **Suppliers:** record supplier deliveries
- **Staff management:** add, edit and delete staff
- **Customers:** view and search customer records
- **Expenses:** track expenses by category
- **Transactions:** view and filter all orders by date
- **Reports:** compute income and export PDF reports (e.g., Best Selling Products, Sales Summary by Date)

---

## Tech Stack

| Part | Technology |
|------|-----------|
| Language | VB.NET |
| Framework | .NET Framework 4.7.2 (Windows Forms) |
| Database | MySQL 8 / MariaDB 10.4 (e.g., via XAMPP) |
| Libraries | MySql.Data, iTextSharp, Crystal Reports runtime |
| IDE | Visual Studio 2019 or newer |

---

## Requirements

- Windows 10 / 11
- Visual Studio 2019+ with the **.NET desktop development** workload
- MySQL or MariaDB (XAMPP is the easiest)
- SAP Crystal Reports runtime for .NET Framework (needed for receipts)

---

## Installation

### 1. Clone the repository
```bash
git clone https://github.com/<your-username>/<repo-name>.git
```

### 2. Set up the database
1. Start **MySQL** in the XAMPP Control Panel.
2. Open phpMyAdmin at http://localhost/phpmyadmin.
3. Create a database named `pizzeria_db`.
4. Click **Import** and choose `database/pizzeria_db.sql`.

Or use the terminal:
```bash
mysql -u root -e "CREATE DATABASE pizzeria_db;"
mysql -u root pizzeria_db < database/pizzeria_db.sql
```

### 3. Open and run the project
1. Open `FDS-COMPROG PROJ.sln` in Visual Studio.
2. Right-click the solution → **Restore NuGet Packages**.
3. Press **F5** to run.

### 4. Database connection
The app connects using:
```
Server=localhost;Database=pizzeria_db;Uid=root;Pwd=;
```
If your MySQL uses a different username or password, update the connection string in the source code.

---

## How to Use

**As a customer**
1. Launch the app and open the order window.
2. Enter your name, pick items from the menu, and place the order.
3. Get your receipt.

**As an admin**
1. Choose the admin login from the start screen.
2. Log in with your admin credentials.
3. Use the dashboard buttons: **Product Inventory**, **Transactions**, **Expenses**, and more.

> 🔐 Default admin credentials are set in the `credentials` table of the database. Ask the author, or change them after importing.

---

## Database

`database/pizzeria_db.sql` creates these tables:

`categories` · `products` · `ingredients` · `ingredientbatches` · `productingredients` · `batch_adjustments` · `suppliers` · `supplier_deliveries` · `customers` · `employees` · `positions` · `credentials` · `transactions` · `transactiondetails` · `expensecategories` · `expenses`

---

## Project Structure

```
FDS-COMPROG PROJ/
├── FDS-COMPROG PROJ.sln
├── FDS-COMPROG PROJ/            # VB.NET source code
│   ├── Form1.vb                 # Start screen
│   ├── Form2.vb                 # Admin login
│   ├── Form3.vb                 # Admin dashboard
│   ├── frmCustomerOrder.vb      # Customer order window
│   ├── frmInventory.vb          # Products & ingredient inventory
│   ├── frmAdjustmentHistory.vb  # Batch adjustment log
│   ├── frmStaffs.vb             # Staff management
│   ├── frmCustomer.vb           # Customer records
│   ├── frmTransactions.vb       # Transactions
│   ├── Form7.vb                 # Expenses
│   ├── Form9.vb                 # Income & reports
│   ├── frmReceiptViewer.vb      # Receipt viewer
│   └── rptReceipt.rpt           # Crystal Report receipt
├── database/
│   └── pizzeria_db.sql
├── .gitignore
└── README.md
```

---

## Screenshots

| Customer Order Window | Admin Dashboard |
|---|---|
| *(add screenshot)* | *(add screenshot)* |

To add one: create a `screenshots` folder, put your image in it, then use `![Order window](screenshots/order.png)`.

---

## Troubleshooting

- **"Unable to connect to any of the specified MySQL hosts":** MySQL isn't running. Start it in XAMPP.
- **"Unknown database 'pizzeria_db'":** you haven't imported the SQL file yet.
- **Receipt won't open:** install the Crystal Reports runtime for .NET Framework.
- **Missing references:** restore NuGet packages in Visual Studio.

---

## License

Made for academic purposes only.
