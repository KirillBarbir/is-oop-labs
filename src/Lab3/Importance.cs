namespace Itmo.ObjectOrientedProgramming.Lab3;

public struct Importance
{
    public Importance(int level)
    {
        if (level > 0)
        {
            ImportanceLevel = level;
        }
    }

    public int ImportanceLevel { get; private set; } = 1;

    public void SetImportanceLevel(int level)
    {
        if (level > 0)
        {
            ImportanceLevel = level;
        }
    }
}