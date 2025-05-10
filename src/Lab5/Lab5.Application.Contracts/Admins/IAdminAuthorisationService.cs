using Lab5.Application.Contracts.Accounts;

namespace Lab5.Application.Contracts.Admins;

public interface IAdminAuthorisationService
{
    AuthorisationResult GetAuthorisationResult(string systemPassword);
}