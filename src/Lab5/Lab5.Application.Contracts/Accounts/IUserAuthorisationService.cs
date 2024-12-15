namespace Lab5.Application.Contracts.Accounts;

public interface IUserAuthorisationService
{
    AuthorisationResult Authorise(long accountNumber, long pin);
}