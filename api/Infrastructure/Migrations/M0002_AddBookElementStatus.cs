using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(2)]
public class M0002_AddBookElementStatus : Migration
{
    public override void Up()
    {
        Alter.Table("book_elements")
            .AddColumn("status").AsString().NotNullable();
    }

    public override void Down()
    {
    }
}