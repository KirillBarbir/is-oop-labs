namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Lecture : BasePrototype
{
    public string Content { get; internal set; }

    public Lecture(int id, int authorId, string name, string description, string content)
        : base(id, authorId, name, description)
    {
        Content = content;
    }

    public override Lecture Clone(int newId)
    {
        var lectureClone = new Lecture(newId, AuthorID, Name, Description, Content);
        lectureClone.BaseID = Id;
        return lectureClone;
    }

    public void EditContent(string newContent, int myId)
    {
        if (AuthorID != myId)
        {
            return;
        }

        Content = newContent;
    }
}