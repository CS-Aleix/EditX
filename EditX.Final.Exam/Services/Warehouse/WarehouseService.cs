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
        Inventory = result;
        // ??        
    }

    public string Export()
    {
        return inventoryImporter.Export(Inventory);
    }

    public void ProcessOrder(SingleMedicationOrder order, PickingAlgorithms algorithm)
    {
        switch (algorithm)
        {
            case PickingAlgorithms.ClosestDistance:
                Inventory.Sort((a, b) =>
                {
                    var aXDist = Math.Abs(a.Location.X - order.Destination.Location.X);
                    var aYDist = Math.Abs(a.Location.Y - order.Destination.Location.Y);
                    var bXDist = Math.Abs(b.Location.X - order.Destination.Location.X);
                    var bYDist = Math.Abs(b.Location.Y - order.Destination.Location.Y);
                    return (aXDist * aYDist) - (bXDist * bYDist);
                });
                break;
            case PickingAlgorithms.FirstInFirstOut:

                break;
            case PickingAlgorithms.HighestStock:
                throw new NotImplementedException();
                break;
            default:
                throw new Exception("Not supported");
        }
    }
}