using Lab5.Application.Contracts.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface ISystemPasswordRepository
{
     AuthorisationResult CheckPassword(string password);
}