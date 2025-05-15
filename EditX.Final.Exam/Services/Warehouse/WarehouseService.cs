using EditX.Final.Exam.Enums;
using EditX.Final.Exam.Interfaces.Warehouse;
using EditX.Final.Exam.Models;
using EditX.Final.Exam.Models.Warehouse;
using System.Reflection.Metadata.Ecma335;

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

    public void ProcessOrder(SingleMedicationOrder order, PickingAlgorithms algorithm)
    {
        WarehouseLocation location = null;
        switch (algorithm)
        {
            case PickingAlgorithms.ClosestDistance:
                location = Inventory.OfType<WarehouseLocation>().Where(c => c.HeldItem.SerialNumber == order.Item.SerialNumber).MinBy(c => Math.Abs(c.Location.X - order.Destination.Location.X) + Math.Abs(c.Location.Y - order.Destination.Location.Y));
                break;
            case PickingAlgorithms.HighestStock:
                    location = Inventory.OfType<WarehouseLocation>().Where(c => c.HeldItem.SerialNumber == order.Item.SerialNumber).MaxBy(c=> c.Amount);
                break;
        }
        location.Amount -= order.Amount;
    }
}