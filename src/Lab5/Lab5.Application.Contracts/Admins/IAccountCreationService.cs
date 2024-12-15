namespace Lab5.Application.Contracts.Admins;

public interface IAccountCreationService
{
    void CreateAccount(long id, long pin);
}