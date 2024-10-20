using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ProgramConstructor
{
    public string CurrentUserName { get; private set; } = string.Empty;

    public int CurrentUserId { get; private set; } = 0;

    private BaseRepository<Labwork> LabworkRepository { get; } = new BaseRepository<Labwork>();

    private BaseRepository<Lecture> LectureRepository { get; } = new BaseRepository<Lecture>();

    private BaseRepository<Subject> SubjectRepository { get; } = new BaseRepository<Subject>();

    private BaseRepository<Program> ProgramRepository { get; } = new BaseRepository<Program>();

    private int DistributedId { get; set; } = 1;

    private List<User> Users { get; set; } = new List<User>();

    public void AddLabwork(Labwork labwork)
    {
        LabworkRepository.Add(labwork);
    }

    public void AddLecture(Lecture lecture)
    {
        LectureRepository.Add(lecture);
    }

    public void AddSubject(Subject subject)
    {
        SubjectRepository.Add(subject);
    }

    public bool CloneLabwork(string name, string newName)
    {
        if (!CheckAuthorisation())
        {
            return false;
        }

        ReturnType<int> foundKey = LabworkRepository.FindKeyByName(name);
        if (foundKey.ResultType != ResultType.Success)
        {
            return false;
        }

        int currentKey = foundKey.Value;
        Labwork currentLabwork = LabworkRepository.FindItem(currentKey);
        Labwork clonedLabwork = currentLabwork.Clone(DistributeId());
        clonedLabwork.Name = newName;
        clonedLabwork.AuthorID = CurrentUserId;
        LabworkRepository.Add(clonedLabwork);
        return true;
    }

    public bool CloneLecture(string name, string newName)
    {
        if (!CheckAuthorisation())
        {
            return false;
        }

        ReturnType<int> foundKey = LectureRepository.FindKeyByName(name);
        if (foundKey.ResultType != ResultType.Success)
        {
            return false;
        }

        int currentKey = foundKey.Value;
        Lecture currentLecture = LectureRepository.FindItem(currentKey);
        Lecture clonedLecture = currentLecture.Clone(DistributeId());
        clonedLecture.Name = newName;
        clonedLecture.AuthorID = CurrentUserId;
        LectureRepository.Add(clonedLecture);
        return true;
    }

    public bool CloneZachyotSubject(string name, string newName)
    {
        if (!CheckAuthorisation())
        {
            return false;
        }

        ReturnType<int> foundKey = SubjectRepository.FindKeyByName(name);
        if (foundKey.ResultType != ResultType.Success)
        {
            return false;
        }

        int currentKey = foundKey.Value;
        Subject currentSubject = SubjectRepository.FindItem(currentKey);
        var zachyotSubject = (ZachyotSubject)currentSubject;
        ZachyotSubject clonedSubject = zachyotSubject.Clone(DistributeId());
        clonedSubject.Name = newName;
        clonedSubject.AuthorID = CurrentUserId;
        SubjectRepository.Add(clonedSubject);
        return true;
    }

    public bool CloneExamSubject(string name, string newName)
    {
        if (!CheckAuthorisation())
        {
            return false;
        }

        ReturnType<int> foundKey = SubjectRepository.FindKeyByName(name);
        if (foundKey.ResultType != ResultType.Success)
        {
            return false;
        }

        int currentKey = foundKey.Value;
        Subject currentSubject = SubjectRepository.FindItem(currentKey);
        var examSubject = (ExamSubject)currentSubject;
        ExamSubject clonedSubject = examSubject.Clone(DistributeId());
        clonedSubject.Name = newName;
        clonedSubject.AuthorID = CurrentUserId;
        SubjectRepository.Add(clonedSubject);
        return true;
    }

    public bool CreateProgram(string name, int[] subjectSemesters, string[] subjectNames)
    {
        if (!CheckAuthorisation())
        {
            return false;
        }

        if (subjectSemesters.Length != subjectNames.Length)
        {
            return false;
        }

        int maxSemesters = subjectSemesters.Max();
        int minSemesters = subjectSemesters.Min();
        if (minSemesters < 1)
        {
            // invalid semester number
            return false;
        }

        var subjectIds = new Collection<int>[maxSemesters];
        for (int i = 0; i < subjectSemesters.Length; ++i)
        {
            ReturnType<int> foundResult = SubjectRepository.FindKeyByName(subjectNames[i]);
            if (foundResult.ResultType != ResultType.Success)
            {
                return false;
            }

            subjectIds[subjectSemesters[i]].Add(foundResult.Value);
        }

        var newProgram = new Program(DistributeId(), name, CurrentUserId, subjectIds);
        ProgramRepository.Add(newProgram);
        return true;
    }

    public void SignIn(string username)
    {
        var newUser = new User(DistributeId(), username);
        Users.Add(newUser);
        CurrentUserId = newUser.Id;
        CurrentUserName = newUser.Name;
    }

    public bool Authorise(string name)
    {
        int id = 0;
        foreach (User user in Users)
        {
            if (name == user.Name)
            {
                id = user.Id;
            }
        }

        if (id == 0)
        {
            return false;
        }

        CurrentUserId = id;
        CurrentUserName = name;
        return true;
    }

    public void Logout()
    {
        CurrentUserId = 0;
        CurrentUserName = string.Empty;
    }

    public bool CreateLabwork(string name, string description, int points, string labworkPointsRequirements)
    {
        if (!CheckAuthorisation())
        {
            return false;
        }

        var newLabwork = new Labwork(DistributeId(), CurrentUserId, name, description, points, labworkPointsRequirements);
        LabworkRepository.Add(newLabwork);
        return true;
    }

    public bool EditLabworkName(string name, string newName)
    {
        ReturnType<Labwork?> foundResult = GetLabwork(name);
        if (foundResult.ResultType != ResultType.Success)
        {
            return false;
        }

        Labwork? currentLabwork = foundResult.Value;
        if (currentLabwork == null)
        {
            return false;
        }

        currentLabwork.Name = newName;
        LabworkRepository.Add(currentLabwork);
        return true;
    }

    public bool EditLabworkDescription(string name, string description)
    {
        ReturnType<Labwork?> foundResult = GetLabwork(name);
        if (foundResult.ResultType != ResultType.Success)
        {
            return false;
        }

        Labwork? currentLabwork = foundResult.Value;
        if (currentLabwork == null)
        {
            return false;
        }

        currentLabwork.Description = description;
        LabworkRepository.Add(currentLabwork);
        return true;
    }

    public bool EditLabworkPointsRequirements(string name, string pointsRequirements)
    {
        ReturnType<Labwork?> foundResult = GetLabwork(name);
        if (foundResult.ResultType != ResultType.Success)
        {
            return false;
        }

        Labwork? currentLabwork = foundResult.Value;
        if (currentLabwork == null)
        {
            return false;
        }

        currentLabwork.LabworkPointsRequirements = pointsRequirements;
        LabworkRepository.Add(currentLabwork);
        return true;
    }

    public bool CreateLecture(string name, string description, string content)
    {
        if (!CheckAuthorisation())
        {
            return false;
        }

        var newLecture = new Lecture(DistributeId(), CurrentUserId, name, description, content);
        LectureRepository.Add(newLecture);
        return true;
    }

    public bool EditLectureName(string name, string newName)
    {
        ReturnType<Lecture?> foundResult = GetLecture(name);
        if (foundResult.ResultType != ResultType.Success)
        {
            return false;
        }

        Lecture? currentLecture = foundResult.Value;
        if (currentLecture == null)
        {
            return false;
        }

        currentLecture.Name = newName;
        LectureRepository.Add(currentLecture);
        return true;
    }

    public bool EditLectureDescription(string name, string description)
    {
        ReturnType<Lecture?> foundResult = GetLecture(name);
        if (foundResult.ResultType != ResultType.Success)
        {
            return false;
        }

        Lecture? currentLecture = foundResult.Value;
        if (currentLecture == null)
        {
            return false;
        }

        currentLecture.Description = description;
        LectureRepository.Add(currentLecture);
        return true;
    }

    public bool EditLectureContent(string name, string content)
    {
        ReturnType<Lecture?> foundResult = GetLecture(name);
        if (foundResult.ResultType != ResultType.Success)
        {
            return false;
        }

        Lecture? currentLecture = foundResult.Value;
        if (currentLecture == null)
        {
            return false;
        }

        currentLecture.Content = content;
        LectureRepository.Add(currentLecture);
        return true;
    }

    public bool EditSubjectName(string name, string newName)
    {
        ReturnType<Subject?> foundResult = GetSubject(name);
        if (foundResult.ResultType != ResultType.Success)
        {
            return false;
        }

        Subject? currentSubject = foundResult.Value;
        if (currentSubject == null)
        {
            return false;
        }

        currentSubject.Name = newName;
        SubjectRepository.Add(currentSubject);
        return true;
    }

    public bool EditSubjectPointThreshold(string name, int pointThreshold)
    {
        ReturnType<Subject?> foundResult = GetSubject(name);
        if (foundResult.ResultType != ResultType.Success)
        {
            return false;
        }

        Subject? currentSubject = foundResult.Value;
        if (currentSubject == null)
        {
            return false;
        }

        var currentZachyotSubject = (ZachyotSubject)currentSubject;
        currentZachyotSubject.PointThreshold = pointThreshold;
        SubjectRepository.Add(currentZachyotSubject);
        return true;
    }

    public bool EditSubjectLectures(string name, string[] lectureNames)
    {
        ReturnType<Subject?> foundResult = GetSubject(name);
        if (foundResult.ResultType != ResultType.Success)
        {
            return false;
        }

        Subject? currentSubject = foundResult.Value;
        if (currentSubject == null)
        {
            return false;
        }

        var lectureIDs = new Collection<int>();
        foreach (string lectureName in lectureNames)
        {
            ReturnType<int> foundLecture = LectureRepository.FindKeyByName(lectureName);
            if (foundLecture.ResultType != ResultType.Success)
            {
                return false;
            }

            int currentLectureKey = foundLecture.Value;
            Lecture currentLecture = LectureRepository.FindItem(currentLectureKey);
            lectureIDs.Add(currentLecture.Id);
        }

        currentSubject.LectureIDs = lectureIDs;
        SubjectRepository.Add(currentSubject);
        return true;
    }

    public bool CreateExamSubject(
        string name,
        string description,
        Collection<string> labworkNames,
        Collection<string> lectureNames,
        int points)
    {
        var currentCreator = new ExamSubjectCreator();
        return CreateSubject(name, description, labworkNames, lectureNames, points, currentCreator);
    }

    public bool CreateZachyotSubject(
        string name,
        string description,
        Collection<string> labworkNames,
        Collection<string> lectureNames,
        int points)
    {
        var currentCreator = new ZachyotSubjectCreator();
        return CreateSubject(name, description, labworkNames, lectureNames, points, currentCreator);
    }

    public BaseRepository<Labwork> ReturnLabworkRepository()
    {
        return LabworkRepository;
    }

    public BaseRepository<Lecture> ReturnLectureRepository()
    {
        return LectureRepository;
    }

    public BaseRepository<Subject> ReturnSubjectRepository()
    {
        return SubjectRepository;
    }

    public BaseRepository<Program> ReturnProgramRepository()
    {
        return ProgramRepository;
    }

    private ReturnType<Labwork?> GetLabwork(string name)
    {
        if (!CheckAuthorisation())
        {
            return new ReturnType<Labwork?>(null, ResultType.Failure);
        }

        ReturnType<int> foundResult = LabworkRepository.FindKeyByName(name);
        if (foundResult.ResultType != ResultType.Success)
        {
            return new ReturnType<Labwork?>(null, ResultType.Failure);
        }

        int currentKey = foundResult.Value;
        Labwork currentLabwork = LabworkRepository.ExtractItem(currentKey);
        if (currentLabwork.AuthorID != CurrentUserId)
        {
            LabworkRepository.Add(currentLabwork);
            return new ReturnType<Labwork?>(null, ResultType.Failure);
        }

        return new ReturnType<Labwork?>(currentLabwork, ResultType.Success);
    }

    private ReturnType<Lecture?> GetLecture(string name)
    {
        if (!CheckAuthorisation())
        {
            return new ReturnType<Lecture?>(null, ResultType.Failure);
        }

        ReturnType<int> foundResult = LectureRepository.FindKeyByName(name);
        if (foundResult.ResultType != ResultType.Success)
        {
            return new ReturnType<Lecture?>(null, ResultType.Failure);
        }

        int currentKey = foundResult.Value;
        Lecture currentLecture = LectureRepository.ExtractItem(currentKey);
        if (currentLecture.AuthorID != CurrentUserId)
        {
            LectureRepository.Add(currentLecture);
            return new ReturnType<Lecture?>(null, ResultType.Failure);
        }

        return new ReturnType<Lecture?>(currentLecture, ResultType.Success);
    }

    private ReturnType<Subject?> GetSubject(string name)
    {
        if (!CheckAuthorisation())
        {
            return new ReturnType<Subject?>(null, ResultType.Failure);
        }

        ReturnType<int> foundResult = SubjectRepository.FindKeyByName(name);
        if (foundResult.ResultType != ResultType.Success)
        {
            return new ReturnType<Subject?>(null, ResultType.Failure);
        }

        int currentKey = foundResult.Value;
        Subject currentSubject = SubjectRepository.ExtractItem(currentKey);
        if (currentSubject.AuthorID != CurrentUserId)
        {
            SubjectRepository.Add(currentSubject);
            return new ReturnType<Subject?>(null, ResultType.Failure);
        }

        return new ReturnType<Subject?>(currentSubject, ResultType.Success);
    }

    private bool CreateSubject(
        string name,
        string description,
        Collection<string> labworkNames,
        Collection<string> lectureNames,
        int points,
        SubjectCreator subjectCreator)
    {
        if (!CheckAuthorisation())
        {
            return false;
        }

        var labworkIDs = new Collection<int>();
        int sumOfPoints = points;
        foreach (string labworkName in labworkNames)
        {
            ReturnType<int> foundResult = LabworkRepository.FindKeyByName(labworkName);
            if (foundResult.ResultType != ResultType.Success)
            {
                return false;
            }

            int currentLabworkKey = foundResult.Value;
            Labwork currentLabwork = LabworkRepository.FindItem(currentLabworkKey);
            labworkIDs.Add(currentLabwork.Id);
            sumOfPoints += currentLabwork.Points;
        }

        if (sumOfPoints != 100)
        {
            return false;
        }

        var lectureIDs = new Collection<int>();
        foreach (string lectureName in lectureNames)
        {
            ReturnType<int> foundResult = LectureRepository.FindKeyByName(lectureName);
            if (foundResult.ResultType != ResultType.Success)
            {
                return false;
            }

            int currentLectureKey = foundResult.Value;
            Lecture currentLecture = LectureRepository.FindItem(currentLectureKey);
            lectureIDs.Add(currentLecture.Id);
        }

        Subject currentSubject = subjectCreator.CreateSubject(DistributeId(), CurrentUserId, name, description, labworkIDs, lectureIDs, points);
        SubjectRepository.Add(currentSubject);
        return true;
    }

    private int DistributeId()
    {
        return DistributedId++;
    }

    private bool CheckAuthorisation()
    {
        if (CurrentUserId == 0 && string.IsNullOrEmpty(CurrentUserName))
        {
            return false;
        }

        return true;
    }
}