using Domain.Entities;
using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(1)]
public class M0001_AddRegistrationTokens: Migration
{
    public override void Up()
    {
        Create.Table("registration_tokens")
            .WithColumn("id").AsInt64().Identity().NotNullable().Unique().PrimaryKey()
            .WithColumn("email").AsString().NotNullable()
            .WithColumn("token").AsGuid().NotNullable()
            .WithColumn("expiration").AsDateTime().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("registration_tokens");
    }
}