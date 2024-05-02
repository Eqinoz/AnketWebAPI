using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"CREATE VIEW [dbo].[Cevap_tumlec]
                AS
                SELECT dbo.Cevaplar.Id, dbo.Cevaplar.user_name, dbo.Sorular.Question, dbo.Secenekler.[option]
                FROM     dbo.Cevaplar INNER JOIN
                  dbo.Secenekler ON dbo.Cevaplar.option_id = dbo.Secenekler.Id INNER JOIN
                  dbo.Sorular ON dbo.Cevaplar.question_id = dbo.Sorular.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
