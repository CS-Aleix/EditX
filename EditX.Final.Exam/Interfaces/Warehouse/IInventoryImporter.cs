using EditX.Final.Exam.Models.Warehouse;

namespace EditX.Final.Exam.Interfaces.Warehouse;

internal interface IInventoryImporter
{
    Task<List<WarehouseNode>> Import(string resourceName);
    string Export(List<WarehouseNode> list);
}