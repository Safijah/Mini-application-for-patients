using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "Appointment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PatientID1",
                table: "Appointment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientID1",
                table: "Appointment",
                column: "PatientID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patient_PatientID1",
                table: "Appointment",
                column: "PatientID1",
                principalTable: "Patient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patient_PatientID1",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PatientID1",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PatientID1",
                table: "Appointment");
        }
    }
}
