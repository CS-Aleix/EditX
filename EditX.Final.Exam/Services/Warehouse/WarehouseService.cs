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
        Inventory = (await inventoryImporter.Import(resourceName)).ToList();
    }

    public string Export()
    {
        return inventoryImporter.Export(Inventory);
    }

    internal void Process(SingleMedicationOrder order, Func<WarehouseLocation, double> cost) {
        var node = Inventory.Where(node => node is WarehouseLocation)
                            .Select(node => (WarehouseLocation)node)
                            .Where(loc => loc.HeldItem.SerialNumber == order.Item.SerialNumber && loc.Amount >= order.Amount)
                            .OrderBy(cost)
                            .First();
        node.Amount -= order.Amount;
    }

    public void ProcessOrder(SingleMedicationOrder order, PickingAlgorithms algorithm)
    {
        switch(algorithm) {
            case PickingAlgorithms.ClosestDistance:
            {
                Process(order, loc => Math.Abs(loc.Location.X - order.Destination.Location.X) + Math.Abs(loc.Location.Y - order.Destination.Location.Y));
                break;
            }
            case PickingAlgorithms.HighestStock:
            {
                Process(order, loc => -loc.Amount);
                break;
            }
            case PickingAlgorithms.FirstInFirstOut:
            {
                Process(order, loc => 0);
                break;
            }
        };
    }
}