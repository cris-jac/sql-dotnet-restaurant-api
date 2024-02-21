using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAPI.Migrations
{
    /// <inheritdoc />
    public partial class Update_Seed_Images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "/src/assets/items/vinitha-v-aApxuprXL_4-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "/src/assets/items/kostiantyn-vierkieiev-86L7IAWiNLE-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "/src/assets/items/monika-grabkowska-pCxJvSeSB5A-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "/src/assets/items/eugen-kucheruk-TvcjBk5y0wU-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "/src/assets/items/pirata-studio-film-78t6dVjtJl8-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "/src/assets/items/max-griss-x_ObRUc51S0-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "/src/assets/items/sonny-mauricio-yhc4pSbl01A-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "/src/assets/items/matthew-hamilton-RA4mwm9_jKA-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "/src/assets/items/farhad-ibrahimzade-59lfMHMZugY-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Image",
                value: "/src/assets/items/cala-w6ftFbPCs9I-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "Image",
                value: "/src/assets/items/tina-witherspoon-A8Gze997X-E-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "Image",
                value: "/src/assets/items/ikhsan-baihaqi-RwAXb8Hv_sU-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "Image",
                value: "/src/assets/items/asnim-ansari-SqYmTDQYMjo-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "Image",
                value: "/src/assets/items/max-griss-Spp1G283dow-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "Image",
                value: "/src/assets/items/homescreenify-sA3wymYqyaI-unsplash.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "images/items/vinitha-v-aApxuprXL_4-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "images/items/kostiantyn-vierkieiev-86L7IAWiNLE-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "images/items/monika-grabkowska-pCxJvSeSB5A-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "images/items/eugen-kucheruk-TvcjBk5y0wU-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "images/items/pirata-studio-film-78t6dVjtJl8-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "images/items/max-griss-x_ObRUc51S0-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "images/items/sonny-mauricio-yhc4pSbl01A-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "images/items/matthew-hamilton-RA4mwm9_jKA-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "images/items/farhad-ibrahimzade-59lfMHMZugY-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Image",
                value: "images/items/cala-w6ftFbPCs9I-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "Image",
                value: "images/items/tina-witherspoon-A8Gze997X-E-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "Image",
                value: "images/items/ikhsan-baihaqi-RwAXb8Hv_sU-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "Image",
                value: "images/items/asnim-ansari-SqYmTDQYMjo-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "Image",
                value: "images/items/max-griss-Spp1G283dow-unsplash.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "Image",
                value: "images/items/homescreenify-sA3wymYqyaI-unsplash.jpg");
        }
    }
}
