using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(2)]
public class M0002_AddImageId : Migration
{
    public override void Up()
    {
        Alter.Table("book_elements")
            .AddColumn("image_id").AsString().Nullable();
    }

    public override void Down()
    {
    }
}