# Restaurant API

## Description

### EN:

.NET API designed for online restaurant orders, in which users can register and login. Users can add menu items into their shopping cart, then complete a payment and check their orders.

### ES:

API de .NET diseñada para pedidos de restaurante online, en la que los usuarios pueden registrarse e iniciar sesión. Los usuarios pueden agregar platos del menú a su carrito de compras, luego completar el pago y verificar sus pedidos.

## Features

### EN:

- Authentication credentials verified with json web tokens (JWT)
- Users management with Identity Framework
- Role-based authorization for some actions
- DAL management with Entity Framework
- Logger implemented
- Payment service with Stripe
- Repository design pattern

### ES:

- Credenciales de autenticación verificadas con json web tokens (JWT)
- Gestión de usuarios con Identity Framework
- Autorización basada en roles para acciones.
- Gestión de DAL con Entity Framework
- Logger implementado
- Servicio de pago con Stripe
- Patrón de diseño del repositorio.

## Requirements

- .NET SDK 8.0+
- PostgreSQL

## Extra Resources

![api-diagram-restaurant](https://github.com/cris-jac/sql-dotnet-restaurant-api/assets/57887225/6519f9f5-58c4-4ec9-a755-a1cb15e8309a)

## Installation

### Steps:

1. Clone from github, using this command:<br>
   `git clone https://github.com/cris-jac/sql-dotnet-restaurant-api.git`

2. Navigate to the repository folder:<br>
   `cd sql-dotnet-restaurant-api`

3. Build the app:<br>
   `dotnet build`

4. Set up the appsettings.Development.json:<br>

```
"ConnectionStrings": {
	"DefaultConnection": "Server=localhost;Database=restaurantDb;Port=5432;User Id=postgres;Password={Your_Password_Here!};"
}
```

- Optional: Use a private key if available:<br>

```
"StripeSettings": {
    "SecretKey": "{sk_test_Your_Secret_Key}"
}
```

5. Create migration and update:<br>
   `dotnet ef migrations "Initial_migration"`<br>
   `dotnet ef database update`

- Optional: If entity framework is not installed:<br>
  `dotnet tool install --global dotnet-ef`

6. Run the app:<br>
   `dotnet run`

### Pasos:

1. Clonar el repositorio de github, usando este comando:<br>
   `git clone https://github.com/cris-jac/sql-dotnet-restaurant-api.git`

2. Navegar al directorio:<br>
   `cd sql-dotnet-restaurant-api`

3. Levantar app:<br>
   `dotnet build`

4. Configurar appsettings.Development.json:<br>

```
"ConnectionStrings": {
	"DefaultConnection": "Server=localhost;Database=restaurantDb;Port=5432;User Id=postgres;Password={Your_Password_Here!};"
}
```

- Opcional: Secret Key de Stripe:<br>

```
"StripeSettings": {
    "SecretKey": "{sk_test_Your_Secret_Key}"
}
```

5. Crear migracion y actualizar BD:<br>
   `dotnet ef migrations "Initial_migration"`<br>
   `dotnet ef database update`

- Opcional: Si Entity Framework no esta instalado:<br>
  `dotnet tool install --global dotnet-ef`

6. Correr la app:<br>
   `dotnet run`

## Port

The default local port:<br>
http://localhost:5277/

To preview with Swagger:<br>
http://localhost:5277/swagger/index.html

## API endpoints

### Authentication

#### Register (Registrar)

```http
POST /Auth/register
```

#### Login (Iniciar sesión)

```http
POST /Auth/Login
```

---

### MenuItem

#### Get MenuItems (Obtener todos los elementos de menú)

```http
GET /MenuItem
```

#### Create MenuItem (Crear elemento de menú)

```http
POST /MenuItem
```

#### Get MenuItem (Obtener elemento de menú)

```http
GET /MenuItem/{id}
```

| Parameter | Type     | Description                                 |
| :-------- | :------- | :------------------------------------------ |
| `id`      | `string` | **Required**. ID of the menu item to update |

#### Update MenuItem (Actualizar elemento de menú)

```http
PUT /MenuItem/{id}
```

| Parameter | Type     | Description                                 |
| :-------- | :------- | :------------------------------------------ |
| `id`      | `string` | **Required**. ID of the menu item to update |

#### Delete MenuItem (Eliminar elemento de menú)

```http
DELETE /MenuItem/{id}
```

| Parameter | Type     | Description                                 |
| :-------- | :------- | :------------------------------------------ |
| `id`      | `string` | **Required**. ID of the menu item to delete |

---

### Order

#### Get Orders (Obtener órdenes)

```http
GET /Order
```

#### Get Order by ID (Obtener orden por ID)

```http
GET /Order/{id}
```

| Parameter | Type     | Description                            |
| :-------- | :------- | :------------------------------------- |
| `id`      | `string` | **Required**. ID of the order to fetch |

#### Create Order (Crear orden)

```http
POST /Order
```

#### Update Order (Actualizar orden)

```http
PUT /Order/{id}
```

| Parameter | Type     | Description                             |
| :-------- | :------- | :-------------------------------------- |
| `id`      | `string` | **Required**. ID of the order to update |

---

### Payment

#### Process Payment (Procesar pago)

```http
POST /Payment
```

---

### ShoppingCart

#### Create ShoppingCart (Crear carrito de compras)

```http
POST /ShoppingCart
```

#### Get ShoppingCart (Obtener carrito de compras)

```http
GET /ShoppingCart
```
