using EditX.Final.Exam.Interfaces.Warehouse;
using System.Text.Json;

namespace EditX.Final.Exam.Models.Warehouse;

internal class InventoryImporterJSON : IInventoryImporter
{
    public async Task<List<WarehouseNode>> Import(string resourceName)
    {
        return await Utilities.ReadWarehouseInventoryFromJSON(resourceName);
    }

    public string Export(List<WarehouseNode> list)
    {
        return Utilities.ConvertWarehouseInventoryToJSON(list);
    }
}