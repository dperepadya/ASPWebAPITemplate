// <copyright file="ToDoMigration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

#pragma warning disable SA1600
#pragma warning disable SA1601
    public partial class ToDoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskName",
                table: "ToDoTasks",
                type: "ncahr(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ncahr(10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
               name: "TaskName",
               table: "ToDoTasks",
               type: "ncahr(10)",
               nullable: true,
               oldClrType: typeof(string),
               oldType: "ncahr(25)");
        }
    }
#pragma warning restore SA1600
#pragma warning restore SA1601
}
