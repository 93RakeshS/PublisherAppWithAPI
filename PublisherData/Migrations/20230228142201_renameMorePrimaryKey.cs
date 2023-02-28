using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherData.Migrations
{
    public partial class renameMorePrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Artists_ArtistsArtistId",
                table: "ArtistCover");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Covers_CoversCoverId",
                table: "ArtistCover");

            migrationBuilder.RenameColumn(
                name: "CoverId",
                table: "Covers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Artists",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CoversCoverId",
                table: "ArtistCover",
                newName: "CoversId");

            migrationBuilder.RenameColumn(
                name: "ArtistsArtistId",
                table: "ArtistCover",
                newName: "ArtistsId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistCover_CoversCoverId",
                table: "ArtistCover",
                newName: "IX_ArtistCover_CoversId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistCover_Artists_ArtistsId",
                table: "ArtistCover",
                column: "ArtistsId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistCover_Covers_CoversId",
                table: "ArtistCover",
                column: "CoversId",
                principalTable: "Covers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Artists_ArtistsId",
                table: "ArtistCover");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistCover_Covers_CoversId",
                table: "ArtistCover");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Covers",
                newName: "CoverId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Artists",
                newName: "ArtistId");

            migrationBuilder.RenameColumn(
                name: "CoversId",
                table: "ArtistCover",
                newName: "CoversCoverId");

            migrationBuilder.RenameColumn(
                name: "ArtistsId",
                table: "ArtistCover",
                newName: "ArtistsArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistCover_CoversId",
                table: "ArtistCover",
                newName: "IX_ArtistCover_CoversCoverId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistCover_Artists_ArtistsArtistId",
                table: "ArtistCover",
                column: "ArtistsArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistCover_Covers_CoversCoverId",
                table: "ArtistCover",
                column: "CoversCoverId",
                principalTable: "Covers",
                principalColumn: "CoverId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
