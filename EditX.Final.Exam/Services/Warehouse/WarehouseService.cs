using EditX.Final.Exam.Enums;
using EditX.Final.Exam.Interfaces.Warehouse;
using EditX.Final.Exam.Models;
using EditX.Final.Exam.Models.Warehouse;

namespace EditX.Final.Exam.Services.Warehouse;

internal class WarehouseService(IInventoryImporter inventoryImporter) : IWarehouseService
{
    public List<WarehouseNode> Inventory { get; set; } = [];

    public async Task Import(string resourceName)
    {
        var result = await inventoryImporter.Import(resourceName);
        // ??        
    }

    public string Export()
    {
        return inventoryImporter.Export(Inventory);
    }

    public void ProcessOrder(SingleMedicationOrder order, PickingAlgorithms algorithm)
    {
        throw new NotImplementedException();
    }
}