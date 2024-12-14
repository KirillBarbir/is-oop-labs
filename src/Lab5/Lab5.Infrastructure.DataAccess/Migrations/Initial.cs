using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider)
    {
        throw new NotImplementedException();
    }
}