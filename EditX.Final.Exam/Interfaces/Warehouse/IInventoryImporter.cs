using EditX.Final.Exam.Models.Warehouse;

namespace EditX.Final.Exam.Interfaces.Warehouse;

internal interface IInventoryImporter
{
    Task<object> Import(string resourceName);
    string Export(object list);
}