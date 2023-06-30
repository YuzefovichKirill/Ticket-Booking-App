using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketBooking.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcertName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BandName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AmountOfTickets = table.Column<int>(type: "int", nullable: false),
                    AmountOfAvailableTickets = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GeoLong = table.Column<double>(type: "float", nullable: false),
                    GeoLat = table.Column<double>(type: "float", nullable: false),
                    ConcertType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassicalConcerts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoiceType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Composer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassicalConcerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassicalConcerts_Concerts_Id",
                        column: x => x.Id,
                        principalTable: "Concerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenAirs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GettingHere = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HeadLiner = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenAirs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenAirs_Concerts_Id",
                        column: x => x.Id,
                        principalTable: "Concerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgeLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parties_Concerts_Id",
                        column: x => x.Id,
                        principalTable: "Concerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Concerts_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassicalConcerts_Id",
                table: "ClassicalConcerts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_Id",
                table: "Concerts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenAirs_Id",
                table: "OpenAirs",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parties_Id",
                table: "Parties",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ConcertId",
                table: "Tickets",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Id",
                table: "Tickets",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassicalConcerts");

            migrationBuilder.DropTable(
                name: "OpenAirs");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Concerts");
        }
    }
}
