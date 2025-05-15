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
        // Check Inventory for closest location
        var locationsOrderedByRange = Inventory.OrderBy(x =>
            Math.Abs(x.Location.X - order.Destination.Location.X) +
            Math.Abs(x.Location.Y - order.Destination.Location.Y))
            .Select(x => new { x.Location.X, x.Location.Y})
            .ToList();

        // Check Inventory for order
        foreach(var location in locationsOrderedByRange)
        {
            var node = Inventory.Where(x => x.Location.X == location.X && x.Location.Y == location.Y).FirstOrDefault();

            if (node is WarehouseLocation loc &&
                loc.HeldItem.Name == order.Item.Name)
            {
                loc.Amount -= order.Amount;
                return;
            }
        }
    }
}