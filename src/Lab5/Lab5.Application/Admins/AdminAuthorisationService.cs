using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;

namespace Lab5.Application.Admins;

public class AdminAuthorisationService : IAdminAuthorisationService
{
    private readonly ICurrentPasswordService _systemPassword;

    public AdminAuthorisationService(ICurrentPasswordService systemPassword)
    {
        _systemPassword = systemPassword;
    }

    public AuthorisationResult GetAuthorisationResult(string systemPassword)
    {
        if (_systemPassword.Password is null)
        {
            return new AuthorisationResult.Failure();
        }

        if (_systemPassword.Password.CheckPassword(systemPassword))
        {
            return new AuthorisationResult.Success();
        }

        return new AuthorisationResult.Failure();
    }
}