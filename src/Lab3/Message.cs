namespace Itmo.ObjectOrientedProgramming.Lab3;

public record Message(string Title, string Body, Importance Importance) : IEquatable<Message>;