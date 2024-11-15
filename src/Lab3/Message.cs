namespace Itmo.ObjectOrientedProgramming.Lab3;

public enum Importance
{
    NotImportant,
    Important,
    VeryImportant,
}

public record Message(string Title, string Body, Importance Importance);