using Lab5.Application.Models.Operations;

namespace Lab5.Application.Abstractions.Repositories;

public interface IOperationRepository
{
    ICollection<Operation> GetOperationHistoryById(long id);
}