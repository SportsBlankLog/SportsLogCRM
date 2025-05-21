using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DbPostgreLib.Migrations.SportsLogs
{
    /// <inheritdoc />
    public partial class SportsLogsContext001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImportedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdateddAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MasterAgent = table.Column<string>(type: "text", nullable: true),
                    CustomerID = table.Column<string>(type: "text", nullable: true),
                    AgentID = table.Column<string>(type: "text", nullable: true),
                    CasinoBalance = table.Column<int>(type: "integer", nullable: false),
                    SuspendHorses = table.Column<string>(type: "text", nullable: true),
                    SuspendSportsbook = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    CurrentBalance = table.Column<int>(type: "integer", nullable: false),
                    CreditLimit = table.Column<int>(type: "integer", nullable: false),
                    WagerLimit = table.Column<int>(type: "integer", nullable: false),
                    CasinoActive = table.Column<string>(type: "text", nullable: true),
                    SportbookActive = table.Column<string>(type: "text", nullable: true),
                    SettleFigure = table.Column<int>(type: "integer", nullable: false),
                    TempCreditAdj = table.Column<int>(type: "integer", nullable: false),
                    PendingWagerBalance = table.Column<int>(type: "integer", nullable: false),
                    AvailableBalance = table.Column<int>(type: "integer", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: true),
                    ReadOnlyFlag = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<string>(type: "text", nullable: true),
                    AgentLogin = table.Column<string>(type: "text", nullable: true),
                    AgentType = table.Column<string>(type: "text", nullable: true),
                    FreePlayBalance = table.Column<int>(type: "integer", nullable: false),
                    ParlayMaxBet = table.Column<int>(type: "integer", nullable: false),
                    ParlayMaxPayout = table.Column<int>(type: "integer", nullable: false),
                    TeaserMaxBet = table.Column<int>(type: "integer", nullable: false),
                    ContestMaxBet = table.Column<int>(type: "integer", nullable: false),
                    MaxContestPrice = table.Column<int>(type: "integer", nullable: false),
                    MaxPropPayout = table.Column<int>(type: "integer", nullable: false),
                    MaxSoccerBet = table.Column<int>(type: "integer", nullable: false),
                    MaxMoneyLine = table.Column<int>(type: "integer", nullable: false),
                    LastVerDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SuspectedBot = table.Column<string>(type: "text", nullable: true),
                    OpenDateTime = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PlayerNotes = table.Column<string>(type: "text", nullable: true),
                    SuspectedBotType = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers",
                schema: "public");
        }
    }
}
