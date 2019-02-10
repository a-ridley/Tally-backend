using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TwoCents.Data.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Petitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UpVotes = table.Column<int>(nullable: false),
                    DownVotes = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Petitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetitionCommentEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    PetitionEntityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetitionCommentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetitionCommentEntity_Petitions_PetitionEntityId",
                        column: x => x.PetitionEntityId,
                        principalTable: "Petitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetitionCommentEntity_PetitionEntityId",
                table: "PetitionCommentEntity",
                column: "PetitionEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetitionCommentEntity");

            migrationBuilder.DropTable(
                name: "Petitions");
        }
    }
}
