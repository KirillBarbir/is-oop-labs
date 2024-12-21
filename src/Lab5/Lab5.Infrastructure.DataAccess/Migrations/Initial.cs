using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type operation_type as enum
        (
            'deposit',
            'withdraw'
        );
        
        create table accounts
        (
            account_id bigint primary key,
            pin bigint not null,
            amount bigint not null,
        );
        
        create table operations
        (
            operation_id bigint primary key generated always as identity,
            account_id bigint not null,
            amount bigint not null,
            operation_type operation_type not null,
        );
        
        create table system_password
        (
        system_password_id bigint primary key generated always as identity,
        system_password text not null,
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table operations
        drop table accounts
        drop table system_password
        drop type operation_type
        """;
}