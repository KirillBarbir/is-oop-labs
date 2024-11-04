using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public record EducationalProgram(int Id, string Name, int DirectorId, Collection<Subject>[] Subjects)
    : IStoredType;