using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherData.Migrations
{
    /// <inheritdoc />
    public partial class addStoredProc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"Create Procedure dbo.AuthorsPublishedInYearRange
                    @yearStart int,
                    @yearEnd int
                As
                Select * from author 
                LEFT JOIN Books On Author.authorId = books.authorId
                Where Year(books.publishDate) >= @yearStart AND Year(books.publishDate) <= @yearEnd
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP Procedure dbo.AuthorsPublishedInYearRange");
        }
    }
}
