using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Q5.Migrations
{
    /// <inheritdoc />
    public partial class SeedContasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO contas (saldo) VALUES 
                (1000.0),
                (500.0);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM contas 
                WHERE id > 0;
            ");
        }
    }
}
