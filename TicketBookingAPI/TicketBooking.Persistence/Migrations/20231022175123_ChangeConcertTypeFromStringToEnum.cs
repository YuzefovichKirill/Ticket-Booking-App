using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketBooking.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConcertTypeFromStringToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcertType",
                table: "Concerts");

            migrationBuilder.RenameColumn(
                name: "HeadLiner",
                table: "OpenAirs",
                newName: "Headliner");

            migrationBuilder.RenameColumn(
                name: "GeoLong",
                table: "Concerts",
                newName: "GeoLng");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Concerts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsedCoupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CouponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedCoupons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_Id",
                table: "Coupons",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_Name",
                table: "Coupons",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsedCoupons_Id",
                table: "UsedCoupons",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsedCoupons_UserId_CouponId",
                table: "UsedCoupons",
                columns: new[] { "UserId", "CouponId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "UsedCoupons");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Concerts");

            migrationBuilder.RenameColumn(
                name: "Headliner",
                table: "OpenAirs",
                newName: "HeadLiner");

            migrationBuilder.RenameColumn(
                name: "GeoLng",
                table: "Concerts",
                newName: "GeoLong");

            migrationBuilder.AddColumn<string>(
                name: "ConcertType",
                table: "Concerts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
