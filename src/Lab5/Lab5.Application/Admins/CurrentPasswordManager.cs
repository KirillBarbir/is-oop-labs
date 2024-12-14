using Lab5.Application.Contracts.Admins;
using Lab5.Application.Models.SystemPasswords;

namespace Lab5.Application.Admins;

public class CurrentPasswordManager : ICurrentPasswordService
{
    public SystemPassword? Password { get; init; } = new SystemPassword("123"); // TODO : fix this
}