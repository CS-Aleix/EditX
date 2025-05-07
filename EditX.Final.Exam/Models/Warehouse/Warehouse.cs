using EditX.Final.Exam.Enums;
using EditX.Final.Exam.Interfaces.Warehouse;

namespace EditX.Final.Exam.Models.Warehouse;

internal class Warehouse(IInventoryImporter inventoryImporter) : IWarehouse
{
    public List<WarehouseNode> Inventory { get; set; } = [];

    public void Import(string resourceName)
    {
        var result = inventoryImporter.Import(resourceName).Result;
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