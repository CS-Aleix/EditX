using EditX.Final.Exam.Models.Warehouse;

namespace EditX.Final.Exam.Interfaces.Warehouse;

internal interface IInventoryImporter
{
    Task<IEnumerable<WarehouseNode>> Import(string resourceName);
    string Export(IEnumerable<WarehouseNode> list);
}