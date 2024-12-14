namespace Lab5.Application.Models.SystemPasswords;

public class SystemPassword
{
    private readonly string _password;

    public SystemPassword(string password)
    {
        _password = password;
    }

    public bool CheckPassword(string password)
    {
        return _password == password;
    }
}