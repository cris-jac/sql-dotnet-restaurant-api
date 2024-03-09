# Restaurant API
### .NET API with PostgreSQL as Database


## Requirements
* .NET SDK 8.0+
* PostgreSQL


## Installation
1. Clone from github, using this command:
```git clone https://github.com/cris-jac/restaurantApi-NetSql.git```

2. Navigate to the repository folder:
```cd booksApi-NetSql``` 

3. Build the app: 
```dotnet build```

4. Set up the appsettings.Development.json:\
"ConnectionStrings": {
	"DefaultConnection": "Server=localhost;Database=restaurantDb;Port=5432;User Id=postgres;Password=```Your_Password_Here!```;"
}

* Optional: Use a private key if available:\
"StripeSettings": {
    "SecretKey": "```sk_test_Your_Secret_Key```"
}

5. Create migration and update:
```dotnet ef migrations "Initial_migration"``` \
```dotnet ef database update```

* Optional: If entity framework is not installed:
```dotnet tool install --global dotnet-ef```

6. Run the app:
```dotnet run```


## Port
The default port: 
http://localhost:5277/swagger/index.html


## API endpoints
### Auth
* POST /api/auth/register: Allows users to register by providing necessary information such as username, email, and password.
* POST /api/auth/login: Allows registered users to login by providing their credentials.

### MenuItem
* GET /api/menuItems: Retrieves a list of menu items available.
* POST /api/menuItems: Creates a new menu item.
* GET /api/menuItems/{id}: Retrieves details of a specific menu item identified by its unique ID.
* PUT /api/menuItems/{id}: Updates details of a specific menu item identified by its unique ID.
* DELETE /api/menuItems/{id}: Deletes a specific menu item identified by its unique ID.

### Order
* GET /api/orders: Retrieves a list of orders.
* POST /api/orders: Places a new order.
* GET /api/orders/{id}: Retrieves details of a specific order identified by its unique ID.
* PUT /api/orders/{id}: Updates details of a specific order identified by its unique ID.

### Payment
* POST /api/payment: Initiates the payment process for an order (through Stripe).

### ShoppingCart
* POST /api/shoppingCart: Adds items to the shopping cart, if there is no shoppingCart, add a new one.
* GET /api/shoppingCart: Retrieves the contents of the shopping cart.