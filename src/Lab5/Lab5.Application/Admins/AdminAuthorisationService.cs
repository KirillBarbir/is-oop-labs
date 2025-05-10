using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;

namespace Lab5.Application.Admins;

public class AdminAuthorisationService : IAdminAuthorisationService
{
    private readonly ISystemPasswordRepository _systemPasswordRepository;

    public AdminAuthorisationService(ISystemPasswordRepository systemPasswordRepository)
    {
        _systemPasswordRepository = systemPasswordRepository;
    }

    public AuthorisationResult GetAuthorisationResult(string systemPassword)
    {
        if (_systemPasswordRepository.CheckPassword(systemPassword) is AuthorisationResult.Success)
        {
            return new AuthorisationResult.Success();
        }

        return new AuthorisationResult.Failure();
    }
}