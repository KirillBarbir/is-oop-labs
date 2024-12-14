using Lab5.Application.Models.SystemPasswords;

namespace Lab5.Application.Contracts.Admins;

public interface ICurrentPasswordService
{
    SystemPassword? Password { get; }
}