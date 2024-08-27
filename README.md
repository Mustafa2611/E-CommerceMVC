# E-CommerceMVC

**E-CommerceMVC** is a comprehensive online shopping platform built using the .NET MVC framework. This project showcases a full-fledged e-commerce website with features like product management, shopping cart, user authentication, and secure order processing. The platform is designed to provide a seamless shopping experience with a focus on scalability, maintainability, and performance.

## Table of Contents

- [Features](#features)
- [Technology Stack](#technology-stack)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Product Management**: Add, update, and manage product details including categories and images.
- **Shopping Cart**: Users can add products to their cart, modify quantities, and proceed to checkout.
- **Order Processing**: Secure order placement and payment processing with order history tracking.
- **User Authentication**: Secure login, registration, and profile management using ASP.NET Identity.
- **Responsive Design**: Fully responsive interface built with Bootstrap for a consistent experience across devices.

## Technology Stack

- **Frontend**: HTML5, CSS3, Bootstrap, jQuery
- **Backend**: .NET MVC, ASP.NET Identity, Entity Framework
- **Database**: SQL Server
- **Version Control**: Git

## Installation

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Steps

1. **Clone the repository**:
   ```bash
   git clone https://github.com/Mustafa2611/E-CommerceMVC.git
   cd E-CommerceMVC
   ```

2. **Setup the database**:
   - Update the connection string in `appsettings.json` to point to your SQL Server instance.
   - Run the following commands to apply migrations and seed the database:
     ```bash
     dotnet ef database update
     ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

4. Open your browser and navigate to `https://localhost:5001` to view the website.

## Usage

- **Product Management**: Admins can manage product listings, categories, and inventory through the admin dashboard.
- **User Interaction**: Users can browse products, add them to their cart, and proceed to checkout after registering or logging in.
- **Order Tracking**: Users can view their order history and track the status of their purchases.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes. Make sure to follow the established code style and include tests for new features or bug fixes.

