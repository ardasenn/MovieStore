using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IsDirector = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DirectorId = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Imdb = table.Column<double>(type: "double precision", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    SalesQuantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MoviesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_ActorMovie_Actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MovieId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false),
                    Rate = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenresId = table.Column<Guid>(type: "uuid", nullable: false),
                    MoviesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieOrder",
                columns: table => new
                {
                    MovieListId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrdersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieOrder", x => new { x.MovieListId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_MovieOrder_Movies_MovieListId",
                        column: x => x.MovieListId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "CreationDate", "DeleteDate", "FirstName", "IsDirector", "LastName", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("0b413fcb-665d-481a-8840-605dc79cd9dc"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7216), null, "İlker", false, "Kaleli", 0, null },
                    { new Guid("0ee3ec71-533e-4c8f-8139-6a5fa889962e"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7207), null, "Demet", false, "Evgar", 0, null },
                    { new Guid("29f70065-80ab-4f9a-a208-fc2c3d0df1b3"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7221), null, "Ahmet", false, "Kural", 0, null },
                    { new Guid("334ac3d6-eff0-4bc0-b6f8-ef31dd4648fc"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7210), null, "Zafer", false, "Algöz", 0, null },
                    { new Guid("6eb014d4-fd5b-4cf8-826a-c698ce5bd521"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7209), null, "Rasim", false, "Öztekin", 0, null },
                    { new Guid("8eb63b9e-46c3-464e-a1cb-f02418e65a24"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7223), null, "Rasim", false, "Öztekin", 0, null },
                    { new Guid("b83e3bd9-acce-4e2a-ad9f-82fc0c698d95"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7212), null, "Ozan", false, "Güven", 0, null },
                    { new Guid("c7cf15f4-fade-46db-b389-aa82bd583f9e"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7214), null, "Cengiz", false, "Bozkurt", 0, null },
                    { new Guid("d2a9d6aa-625e-4538-81b3-50301574157e"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7217), null, "Melisa", false, "Aslı Pamuk", 0, null },
                    { new Guid("fdea1ee6-3748-4a12-8177-937e67806ad7"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7204), null, "Cem", true, "Yılmaz", 0, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "CreationDate", "DeleteDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[] { "e2ab6248-a8e0-4ebb-9e63-01fd1ee81943", 0, 100m, "7c98c017-1cb1-46eb-b5e2-bc7a0d2be5a4", new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7088), null, "ardasen.96@gmail.com", true, "admin", "admin", false, null, "ARDASEN.96@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAECg6f0/tC/kbk70RGXAquYaFgyzsWl8hLjLuA5+eQIHwCAKW0oJtm38wYRjhTNsuvw==", null, false, "c73079a1-f81b-43b1-be39-94e540469a51", 0, false, null, "admin" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreationDate", "DeleteDate", "Name", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("1bd5a2e7-71fa-4654-a2e4-205413e880dd"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7187), null, "Korku", 0, null },
                    { new Guid("25a2cbbd-c390-4b9e-9a1c-d41da19686b1"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7192), null, "Komedi", 0, null },
                    { new Guid("32da1d4d-b4ba-4ff2-a2e4-4df38f3c7e76"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7170), null, "Drama", 0, null },
                    { new Guid("38b77ec7-38ad-4ce6-95eb-6f01b0f45a39"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7165), null, "Aksiyon", 0, null },
                    { new Guid("3e2cc64a-c837-4250-8d05-5ca420a2b9de"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7190), null, "Fantastik", 0, null },
                    { new Guid("533b0e2e-42e4-4b60-9c23-95a0b757c556"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7197), null, "Macera", 0, null },
                    { new Guid("85fdc836-300a-4827-a6f6-256449c09040"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7193), null, "Gerilim", 0, null },
                    { new Guid("a567e33b-b204-4aa0-a1c2-77ed5664d98b"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7184), null, "Bilim Kurgu", 0, null },
                    { new Guid("c08aed8f-d363-4fba-af8e-6988a8ce500c"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7186), null, "Romantik", 0, null },
                    { new Guid("ceef3b04-7c4a-40ae-af38-dd9b1857256b"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7195), null, "Belgesel", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreationDate", "DeleteDate", "DirectorId", "Imdb", "Name", "Price", "ReleaseDate", "SalesQuantity", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("4de6f805-5b20-4477-9679-59e9f08ba498"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7263), null, "fdea1ee6-3748-4a12-8177-937e67806ad7", 7.2999999999999998, "Arog", 28.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 0, null },
                    { new Guid("5bc965ee-12a4-4222-84f5-2ff43da3a558"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7275), null, "fdea1ee6-3748-4a12-8177-937e67806ad7", 6.9000000000000004, "Yahşi Batı", 30.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 0, null },
                    { new Guid("75e60cac-1a2b-4318-bf58-ba59b8978c92"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7280), null, "fdea1ee6-3748-4a12-8177-937e67806ad7", 8.0999999999999996, "CM101MMXI Fundamentals", 32.50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 0, null },
                    { new Guid("7cbcc5b6-e8d8-42ee-829a-7707c0dcfbf8"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7299), null, "fdea1ee6-3748-4a12-8177-937e67806ad7", 7.5, "Gora + Arog", 40.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 0, null },
                    { new Guid("8716c451-3694-4c6e-89ee-2cb720f13a47"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7285), null, "fdea1ee6-3748-4a12-8177-937e67806ad7", 6.2999999999999998, "Pek Yakında", 27.50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 0, null },
                    { new Guid("8c363a61-9adb-47cb-8b39-c5cc85494b92"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7304), null, "fdea1ee6-3748-4a12-8177-937e67806ad7", 6.2000000000000002, "Ali Baba ve 7 Cüceler", 33.50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 0, null },
                    { new Guid("b3873176-fd03-496c-abfd-bf33caab5270"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7270), null, "fdea1ee6-3748-4a12-8177-937e67806ad7", 7.7999999999999998, "G.O.R.A", 25.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 0, null },
                    { new Guid("d04d3074-b167-47ad-bad8-24bad2cacd53"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7292), null, "fdea1ee6-3748-4a12-8177-937e67806ad7", 6.7000000000000002, "Arif v 216", 35.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 0, null },
                    { new Guid("e8c8de3c-8943-41d0-a1c1-2359b6741796"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7308), null, "fdea1ee6-3748-4a12-8177-937e67806ad7", 6.7000000000000002, "Cehennem Melekleri 2", 29.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 0, null },
                    { new Guid("f94b0f0f-baff-42e0-a918-c0041378dd1c"), new DateTime(2024, 1, 23, 12, 26, 54, 423, DateTimeKind.Utc).AddTicks(7314), null, "fdea1ee6-3748-4a12-8177-937e67806ad7", 6.5, "Fasulye", 26.50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MoviesId",
                table: "ActorMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesId",
                table: "GenreMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieOrder_OrdersId",
                table: "MovieOrder",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "MovieOrder");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
