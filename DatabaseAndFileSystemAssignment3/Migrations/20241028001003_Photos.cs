using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseAndFileSystemAssignment3.Migrations
{
    public partial class Photos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Kenneth_GalleryItems",
                newName: "ImageMimeType");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Kenneth_GalleryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Kenneth_GalleryItems",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Kenneth_GalleryItems");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Kenneth_GalleryItems");

            migrationBuilder.RenameColumn(
                name: "ImageMimeType",
                table: "Kenneth_GalleryItems",
                newName: "ImagePath");
        }
    }
}
