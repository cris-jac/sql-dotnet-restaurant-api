using RestaurantAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<OrderHeader> OrderHeaders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }

    // Seed
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { Id = 1, Name= "Sopa de Verduras", Description = "Este plato presenta una variedad de vegetales cocinados en un caldo sabroso. Es una opción saludable y nutritiva, a la vez reconfortante y deliciosa.", Image = "images/items/vinitha-v-aApxuprXL_4-unsplash.jpg", PriceInUSD = 8.99, Category = "Sopas", SpecialTag = "Especialidad de la casa" },
            new MenuItem { Id = 2, Name= "Ensalada de Remolacha Roja con Crema Vistaña", Description = "Patatas rojas asadas, palta, frijoles negros y col rizada cruda se mezclan con una deliciosa vestidura de limón en esta ensalada de remolacha roja vegetariana.", Image = "images/items/kostiantyn-vierkieiev-86L7IAWiNLE-unsplash.jpg", PriceInUSD = 12.99, Category = "Ensaladas", SpecialTag = "" },
            new MenuItem { Id = 3, Name= "Ensalada de Lechuga Rallada con Crema Vistaña y Miel", Description = "Cargada con nueces, así como frutas secas y frescas, esta ensalada vegetariana es ideal como un delicioso almuerzo ligero.", Image = "images/items/monika-grabkowska-pCxJvSeSB5A-unsplash.jpg", PriceInUSD = 9.49, Category = "Ensaladas", SpecialTag = "" },
            new MenuItem { Id = 4, Name= "Burrito Vegetariano con Crema de Palta", Description = "Los vegetales asados, las frijoles sabrosos y la crema de palta limón-ajo se colocan sobre una cama de arroz de cilantro-limón en este delicioso burrito bowl vegetariano.", Image = "images/items/eugen-kucheruk-TvcjBk5y0wU-unsplash.jpg", PriceInUSD = 11.49, Category = "Platos principales", SpecialTag = "Mejor valorado" },
            new MenuItem { Id = 5, Name= "Curry Verde para Buda", Description = "Finado con una deliciosa salsa de curry verde, este plato vegetal es el más saludable que jamás hayas probado.", Image = "images/items/pirata-studio-film-78t6dVjtJl8-unsplash.jpg", PriceInUSD = 13.99, Category = "Platos principales", SpecialTag = "" },
            new MenuItem { Id = 6, Name= "Polenta de Queso de Cabra con Ratatouille", Description = "La ratatouille -una combinación clásica de verduras tardías veranos-, cocinada hasta la perfección, es un ideal compañero para la polenta de queso de cabra cremoso.", Image = "images/items/max-griss-x_ObRUc51S0-unsplash.jpg", PriceInUSD = 15.99, Category = "Guarniciones", SpecialTag = "Especialidad del Chef" },
            new MenuItem { Id = 7, Name= "Ensalada Curry con Quinoa", Description = "Esta ensalada cargada está llena hasta el borde y es ideal para comer.", Image = "images/items/sonny-mauricio-yhc4pSbl01A-unsplash.jpg", PriceInUSD = 10.49, Category = "Ensaladas", SpecialTag = "" },
            new MenuItem { Id = 8, Name= "Caldo de Calabaza con Curry", Description = "Suave y brillantemente colorido, este caldo vegano curry es profundamente amado en nuestros hogares.", Image = "images/items/matthew-hamilton-RA4mwm9_jKA-unsplash.jpg", PriceInUSD = 8.99, Category = "Sopas", SpecialTag = "" },
            new MenuItem { Id = 9, Name= "Ensalada Primaveral con Trigo y Vistaña Limón-Cebolla", Description = "Vestida con una deliciosa vestidura limón-cebolla, las semillas de girasol crudas y las frambuesas secas dan vida a esta receta de ensalada primaveral.", Image = "images/items/farhad-ibrahimzade-59lfMHMZugY-unsplash.jpg", PriceInUSD = 12.49, Category = "Ensaladas", SpecialTag = "" },
            new MenuItem { Id = 10, Name = "Caldo de Calabaza con Manzanas", Description= "La sopa cremosa hecha con manzanas dulces, ajo y romero es la perfecta sopa cómoda para el otoño.", Image = "images/items/cala-w6ftFbPCs9I-unsplash.jpg", PriceInUSD = 14.99, Category="Sopas", SpecialTag = "" },
            new MenuItem { Id = 11, Name = "Mac & Cheese", Description= "Mac & Cheese es un plato vegetariano totalmente cómodo. Está listo en solo quince minutos.", Image = "images/items/tina-witherspoon-A8Gze997X-E-unsplash.jpg", PriceInUSD = 9.99, Category="Platos principales", SpecialTag = "" },
            new MenuItem { Id = 12, Name = "Ramen Sésamo-Ajo con Fideos", Description= "Ramen Noodles Sésamo-Ajo es una versión única del clásico plato de fideos ramen, con sabores de sésamo y ajo.", Image = "images/items/ikhsan-baihaqi-RwAXb8Hv_sU-unsplash.jpg", PriceInUSD = 7, Category="Sopas", SpecialTag = "" },
            new MenuItem { Id = 13, Name = "Queso asado", Description= "Vuelve siempre al queso asado. Almuerzo, cena o merienda -este es un plato vegetariano totalmente cómodo para todos los momentos del día.", Image = "images/items/asnim-ansari-SqYmTDQYMjo-unsplash.jpg", PriceInUSD = 5.99, Category="Guarniciones", SpecialTag = "Mejor valorado" },
            new MenuItem { Id = 14, Name = "Rollos De Tofu ", Description= "La salsa de soja-limón-chile picante hace que estos rollitos vegetarianos sean simplemente deliciosos. ", Image = "images/items/max-griss-Spp1G283dow-unsplash.jpg", PriceInUSD = 10.49, Category="Platos principales", SpecialTag = "Especialidad del Chef" },
            new MenuItem { Id = 15, Name= "Salsa de Nueces y Lentejas Boloñesa", Description = "Sabrosa y extraordinariamente nutritiva, esta receta de salsa de nueces y lentejas Boloñesa es ideal para los comensales vegetarianos.", Image = "images/items/homescreenify-sA3wymYqyaI-unsplash.jpg", PriceInUSD = 10.99, Category = "Guarniciones", SpecialTag = "Especialidad de la casa" }
        );
    }
}
