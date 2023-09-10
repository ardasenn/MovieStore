using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cabb810b-18e5-4125-ba3c-11740867c9d7");

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "CreationDate", "DeleteDate", "FirstName", "IsDirector", "LastName", "Status", "UpdateDate" },
                values: new object[] { new Guid("a4e8e599-5546-4d34-acba-0b7cba0e659d"), new DateTime(2023, 9, 10, 13, 3, 38, 524, DateTimeKind.Local).AddTicks(3158), null, "Cem", true, "Yılmaz", 1, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreationDate", "DeleteDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[] { "09776b75-0241-4149-ad7c-3c9341966510", 0, "1b410cfb-f801-4e9d-8493-1e2a6b8fad3f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ardasen.96@gmail.com", true, "admin", "admin", false, null, "ARDASEN.96@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAECg6f0/tC/kbk70RGXAquYaFgyzsWl8hLjLuA5+eQIHwCAKW0oJtm38wYRjhTNsuvw==", null, false, "cbc78197-7861-4d6b-bf7e-1fb6582222ef", 0, false, null, "admin" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "CreationDate", "DeleteDate", "Name", "Status", "UpdateDate" },
                values: new object[] { new Guid("9cb05da3-88c3-4d35-bfa4-71a47ca8e590"), new DateTime(2023, 9, 10, 13, 3, 38, 524, DateTimeKind.Local).AddTicks(3131), null, "Komedi", 1, null });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreationDate", "DeleteDate", "DirectorId", "Imdb", "Name", "Price", "ReleaseDate", "SalesQuantity", "Status", "UpdateDate" },
                values: new object[] { new Guid("660386b4-e320-4266-b086-b69a15ad81c1"), new DateTime(2023, 9, 10, 13, 3, 38, 524, DateTimeKind.Local).AddTicks(3161), null, "a4e8e599-5546-4d34-acba-0b7cba0e659d", 7.2999999999999998, "Arog", 28.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, null });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorsId", "MoviesId" },
                values: new object[] { new Guid("a4e8e599-5546-4d34-acba-0b7cba0e659d"), new Guid("660386b4-e320-4266-b086-b69a15ad81c1") });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenresId", "MoviesId" },
                values: new object[] { new Guid("9cb05da3-88c3-4d35-bfa4-71a47ca8e590"), new Guid("660386b4-e320-4266-b086-b69a15ad81c1") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumns: new[] { "ActorsId", "MoviesId" },
                keyValues: new object[] { new Guid("a4e8e599-5546-4d34-acba-0b7cba0e659d"), new Guid("660386b4-e320-4266-b086-b69a15ad81c1") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09776b75-0241-4149-ad7c-3c9341966510");

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { new Guid("9cb05da3-88c3-4d35-bfa4-71a47ca8e590"), new Guid("660386b4-e320-4266-b086-b69a15ad81c1") });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("a4e8e599-5546-4d34-acba-0b7cba0e659d"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("9cb05da3-88c3-4d35-bfa4-71a47ca8e590"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("660386b4-e320-4266-b086-b69a15ad81c1"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreationDate", "DeleteDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[] { "cabb810b-18e5-4125-ba3c-11740867c9d7", 0, "de3cecbb-99ef-4a3a-b6ca-75d8989b53bf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ardasen.96@gmail.com", true, "admin", "admin", false, null, "ARDASEN.96@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAECg6f0/tC/kbk70RGXAquYaFgyzsWl8hLjLuA5+eQIHwCAKW0oJtm38wYRjhTNsuvw==", null, false, "198a8f29-5bf1-4ccb-b901-c4b3ea9aec16", 0, false, null, "admin" });
        }
    }
}
