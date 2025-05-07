using EditX.Final.Exam.Interfaces;

namespace EditX.Final.Exam.Models;

public class BaseObject : IBaseObject
{
    public required string Id { get; set; }
}