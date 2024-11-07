namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Labwork : BasePrototype
{
    public int Points { get; internal set; }

    public string LabworkPointsRequirements { get; internal set; }

    public Labwork(int id, int authorId, string name, string description, int points, string labworkPointsRequirements)
        : base(id, authorId, name, description)
    {
        Points = points;
        LabworkPointsRequirements = labworkPointsRequirements;
    }

    public override Labwork Clone(int newId)
    {
        var labworkClone = new Labwork(newId, AuthorID, Name, Description, Points, LabworkPointsRequirements);
        labworkClone.BaseID = Id;
        return labworkClone;
    }

    public void EditPoints(int newPoints, int myId)
    {
        if (AuthorID != myId)
        {
            return;
        }

        Points = newPoints;
    }

    public void EditPointsRequirements(string newPointsRequirements, int myId)
    {
        if (AuthorID != myId)
        {
            return;
        }

        LabworkPointsRequirements = newPointsRequirements;
    }
}
