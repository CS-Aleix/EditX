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
        Inventory = await inventoryImporter.Import(resourceName);
    }

    public string Export()
    {
        return inventoryImporter.Export(Inventory);
    }

    public void ProcessOrder(SingleMedicationOrder order, PickingAlgorithms algorithm)
    {
        // Find the closest location to the destination
        switch (algorithm)
        {
            case PickingAlgorithms.ClosestDistance:
                ProcessClosestOrder(order);
                break;
            case PickingAlgorithms.HighestStock:
                ProcessHighestStockOrder(order);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm, null);
        }

    }

    public void ProcessClosestOrder(SingleMedicationOrder order)
    {
        var destination = order.Destination;
        var item = order.Item;
        var amount = order.Amount;
        var closestLocation = Inventory
                .OfType<WarehouseLocation>()
                .OrderBy(location => Utilities.GetDistance(location.Location, destination.Location))
                .FirstOrDefault();
        if (closestLocation != null && (closestLocation.HeldItem as Medication).SerialNumber == item.SerialNumber)
        {
            closestLocation.Amount -= amount;
            if (closestLocation.Amount < 0)
            {
                throw new InvalidOperationException("Not enough stock available.");
            }
        }
    }

    public void ProcessHighestStockOrder(SingleMedicationOrder order)
    {
        var destination = order.Destination;
        var item = order.Item;
        var amount = order.Amount;
        var highestStockLocation = Inventory
                .OfType<WarehouseLocation>()
                .OrderByDescending(location => location.Amount)
                .FirstOrDefault();
        if (highestStockLocation != null && (highestStockLocation.HeldItem as Medication).SerialNumber == item.SerialNumber)
        {
            highestStockLocation.Amount -= amount;
            if (highestStockLocation.Amount < 0)
            {
                throw new InvalidOperationException("Not enough stock available.");
            }
        }
    }
}