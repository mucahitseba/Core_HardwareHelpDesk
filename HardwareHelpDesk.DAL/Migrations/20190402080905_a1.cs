using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareHelpDesk.DAL.Migrations
{
    public partial class a1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faults",
                columns: table => new
                {
                    FaultID = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<string>(nullable: false),
                    OperatorId = table.Column<string>(nullable: true),
                    TechnicianId = table.Column<string>(nullable: true),
                    FaultNotifyDate = table.Column<DateTime>(nullable: false),
                    FaultResultDate = table.Column<DateTime>(nullable: true),
                    FaultState = table.Column<int>(nullable: false),
                    AssignedOperator = table.Column<bool>(nullable: false),
                    FaultPath = table.Column<string>(nullable: true),
                    InvoicePath = table.Column<string>(nullable: true),
                    FaultDescription = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    haveJob = table.Column<bool>(nullable: false),
                    TechnicianDescription = table.Column<string>(nullable: true),
                    TechnicianState = table.Column<int>(nullable: false),
                    TeknisyenBilgiPuani = table.Column<int>(nullable: false),
                    TeknisyenDavranisPuani = table.Column<int>(nullable: false),
                    DavranisPuani = table.Column<int>(nullable: false),
                    OMNetHizmetPuanı = table.Column<int>(nullable: false),
                    OMNetHakkindakiGorusler = table.Column<int>(nullable: false),
                    SurveyCode = table.Column<string>(nullable: true),
                    AnketYapildimi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faults", x => x.FaultID);
                });

            migrationBuilder.CreateTable(
                name: "FaultsLog",
                columns: table => new
                {
                    FaultLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FaultId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    TechnicianId = table.Column<string>(nullable: true),
                    History = table.Column<DateTime>(nullable: false),
                    Operation = table.Column<string>(nullable: true),
                    OperationDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultsLog", x => x.FaultLogId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faults");

            migrationBuilder.DropTable(
                name: "FaultsLog");
        }
    }
}
