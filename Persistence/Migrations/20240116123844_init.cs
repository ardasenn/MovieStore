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
                    { new Guid("057cea6d-7762-4d3f-ae63-039492fee274"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5247), null, "Rasim", false, "Öztekin", 0, null },
                    { new Guid("1ecd834d-8215-432f-bd6f-fe4224fafacd"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5252), null, "Cengiz", false, "Bozkurt", 0, null },
                    { new Guid("243cbeba-9a15-464b-8da9-d3e479ba50b2"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5256), null, "Melisa", false, "Aslı Pamuk", 0, null },
                    { new Guid("3611a6d8-1516-4318-bbc7-63aac373eb5a"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5262), null, "Rasim", false, "Öztekin", 0, null },
                    { new Guid("431fd310-c959-4513-b9f8-c0aa3faae286"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5259), null, "Ahmet", false, "Kural", 0, null },
                    { new Guid("9027c4c8-114c-4872-816f-e49111b7121f"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5245), null, "Demet", false, "Evgar", 0, null },
                    { new Guid("9799acb4-bad5-4802-9eac-f066b1b66a63"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5250), null, "Ozan", false, "Güven", 0, null },
                    { new Guid("a42b21c1-bf20-4730-bf32-616637f29f01"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5241), null, "Cem", true, "Yılmaz", 0, null },
                    { new Guid("ba4bfa40-d5e7-4edf-b35b-1f9e3451b5b6"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5254), null, "İlker", false, "Kaleli", 0, null },
                    { new Guid("ed5c0621-adf7-4318-aedf-7d088a913071"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5248), null, "Zafer", false, "Algöz", 0, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreationDate", "DeleteDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[] { "3f4fd215-e301-4b31-9246-19b0834b60ac", 0, "14076ecf-09f6-4d48-a3c1-9c36a7b3c2f0", new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5067), null, "ardasen.96@gmail.com", true, "admin", "admin", false, null, "ARDASEN.96@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAECg6f0/tC/kbk70RGXAquYaFgyzsWl8hLjLuA5+eQIHwCAKW0oJtm38wYRjhTNsuvw==", null, false, "3e65919f-cf91-4a90-bd58-cfe39c01f523", 0, false, null, "admin" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreationDate", "DeleteDate", "Name", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("41030c52-ad3b-4422-999b-d0b737a9e85e"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5229), null, "Komedi", 0, null },
                    { new Guid("4b70cb7e-d77e-4871-9403-986cf5f8b17f"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5204), null, "Aksiyon", 0, null },
                    { new Guid("69e76573-cfab-4405-9649-20b70b8c1c29"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5225), null, "Korku", 0, null },
                    { new Guid("82a20df2-54ef-45ec-9840-0d4deed48856"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5208), null, "Drama", 0, null },
                    { new Guid("8b37b35d-50f6-49c6-9514-dc0851de5426"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5231), null, "Gerilim", 0, null },
                    { new Guid("a190809c-12f0-48b7-a8c4-bd7abb909ddd"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5223), null, "Romantik", 0, null },
                    { new Guid("add742e5-3b65-47fb-9b69-bb7e427ece2f"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5235), null, "Macera", 0, null },
                    { new Guid("bb5eccb8-0857-4dc5-96bd-a33e3fffea8f"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5222), null, "Bilim Kurgu", 0, null },
                    { new Guid("e0a1794b-2def-44bd-ae59-c445bb66e589"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5232), null, "Belgesel", 0, null },
                    { new Guid("ff7b1724-4032-4021-b081-789da90c149c"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5228), null, "Fantastik", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreationDate", "DeleteDate", "DirectorId", "Imdb", "Name", "Price", "ReleaseDate", "SalesQuantity", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("0d4855ff-135a-426c-bb90-a6481c95f346"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5359), null, "a42b21c1-bf20-4730-bf32-616637f29f01", 6.7000000000000002, "Cehennem Melekleri 2", 29.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 0, null },
                    { new Guid("56395ca2-b570-49c3-9ec0-645371db6e4f"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5329), null, "a42b21c1-bf20-4730-bf32-616637f29f01", 8.0999999999999996, "CM101MMXI Fundamentals", 32.50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 0, null },
                    { new Guid("5fc52fd4-092d-4b67-9a33-a0dd7542d967"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5317), null, "a42b21c1-bf20-4730-bf32-616637f29f01", 7.7999999999999998, "G.O.R.A", 25.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 0, null },
                    { new Guid("6d29b93d-e589-436c-b736-52bfd90d60a5"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5349), null, "a42b21c1-bf20-4730-bf32-616637f29f01", 7.5, "Gora + Arog", 40.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 0, null },
                    { new Guid("7c5854b6-7e8a-4127-b06a-8ec34b8a7854"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5334), null, "a42b21c1-bf20-4730-bf32-616637f29f01", 6.2999999999999998, "Pek Yakında", 27.50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 0, null },
                    { new Guid("7f5cc6b3-93dd-41c9-be42-f4eacead8c29"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5341), null, "a42b21c1-bf20-4730-bf32-616637f29f01", 6.7000000000000002, "Arif v 216", 35.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 0, null },
                    { new Guid("917faaaf-8f53-4f68-97d7-7f43706c3d23"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5286), null, "a42b21c1-bf20-4730-bf32-616637f29f01", 7.2999999999999998, "Arog", 28.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 0, null },
                    { new Guid("b0c0706a-5496-4944-a410-b043a6250cd4"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5366), null, "a42b21c1-bf20-4730-bf32-616637f29f01", 6.5, "Fasulye", 26.50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 0, null },
                    { new Guid("bbdefef2-150b-4bfe-9f20-5f9485b0993a"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5354), null, "a42b21c1-bf20-4730-bf32-616637f29f01", 6.2000000000000002, "Ali Baba ve 7 Cüceler", 33.50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 0, null },
                    { new Guid("c1611eeb-4353-4e70-8252-79e0418b0ddf"), new DateTime(2024, 1, 16, 12, 38, 44, 23, DateTimeKind.Utc).AddTicks(5323), null, "a42b21c1-bf20-4730-bf32-616637f29f01", 6.9000000000000004, "Yahşi Batı", 30.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 0, null }
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
