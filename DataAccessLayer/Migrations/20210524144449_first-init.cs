using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class firstinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("aa055fff-7961-4e70-847f-4afb90a2d8ac"), new DateTime(2021, 5, 24, 16, 44, 48, 525, DateTimeKind.Local).AddTicks(815), false, "Book 1", new DateTime(2021, 5, 24, 16, 44, 48, 526, DateTimeKind.Local).AddTicks(5357) },
                    { new Guid("0ab852ce-9a81-4ee7-80dc-0af3f465657a"), new DateTime(2021, 5, 24, 16, 44, 48, 526, DateTimeKind.Local).AddTicks(6165), false, "Book 2", new DateTime(2021, 5, 24, 16, 44, 48, 526, DateTimeKind.Local).AddTicks(6171) },
                    { new Guid("a777ab97-019c-47a7-b178-5ad62d3b9fd2"), new DateTime(2021, 5, 24, 16, 44, 48, 526, DateTimeKind.Local).AddTicks(6175), false, "Book 3", new DateTime(2021, 5, 24, 16, 44, 48, 526, DateTimeKind.Local).AddTicks(6177) },
                    { new Guid("034441e8-13e9-47a2-9a98-1a60ddcbf081"), new DateTime(2021, 5, 24, 16, 44, 48, 526, DateTimeKind.Local).AddTicks(6180), false, "Book 4", new DateTime(2021, 5, 24, 16, 44, 48, 526, DateTimeKind.Local).AddTicks(6181) },
                    { new Guid("1144b90a-678d-41bc-ab63-e489c7566dfa"), new DateTime(2021, 5, 24, 16, 44, 48, 526, DateTimeKind.Local).AddTicks(6184), true, "Book 5", new DateTime(2021, 5, 24, 16, 44, 48, 526, DateTimeKind.Local).AddTicks(6185) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "Password", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("ffb9c802-865a-4517-994b-76ff2d010e9a"), new DateTime(2021, 5, 24, 16, 44, 48, 528, DateTimeKind.Local).AddTicks(8216), false, "User 1", null, 1, new DateTime(2021, 5, 24, 16, 44, 48, 528, DateTimeKind.Local).AddTicks(8822), "user.1" },
                    { new Guid("182ea661-be2e-4c2e-9373-c9c4e604d36a"), new DateTime(2021, 5, 24, 16, 44, 48, 528, DateTimeKind.Local).AddTicks(9890), false, "User 2", null, 1, new DateTime(2021, 5, 24, 16, 44, 48, 528, DateTimeKind.Local).AddTicks(9898), "user.2" },
                    { new Guid("0bfd8d12-c569-47b6-8270-bc16e4c5b470"), new DateTime(2021, 5, 24, 16, 44, 48, 528, DateTimeKind.Local).AddTicks(9903), false, "User 3", null, 2, new DateTime(2021, 5, 24, 16, 44, 48, 528, DateTimeKind.Local).AddTicks(9905), "user.3" },
                    { new Guid("73e1a2a7-5d0e-4c3d-81d6-b7dc72c5c84f"), new DateTime(2021, 5, 24, 16, 44, 48, 528, DateTimeKind.Local).AddTicks(9909), false, "User 4", null, 2, new DateTime(2021, 5, 24, 16, 44, 48, 528, DateTimeKind.Local).AddTicks(9911), "user.4" },
                    { new Guid("fe82d001-7060-4e29-b037-bf21b984213a"), new DateTime(2021, 5, 24, 16, 44, 48, 528, DateTimeKind.Local).AddTicks(9929), true, "User 5", null, 2, new DateTime(2021, 5, 24, 16, 44, 48, 528, DateTimeKind.Local).AddTicks(9931), "user.5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
