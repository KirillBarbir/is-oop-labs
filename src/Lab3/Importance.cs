namespace Itmo.ObjectOrientedProgramming.Lab3;

public struct Importance
{
    public int ImportanceLevel { get; } = 1;

    public Importance(int level)
    {
        if (level > 0)
        {
            ImportanceLevel = level;
        }
    }
}