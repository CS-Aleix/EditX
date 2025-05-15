using EditX.Final.Exam.Interfaces.Warehouse;
using System.Text.Json;

namespace EditX.Final.Exam.Models.Warehouse;

internal class InventoryImporterJSON : IInventoryImporter
{
    public async Task<IEnumerable<WarehouseNode>> Import(string resourceName)
    {
        return await Utilities.ReadWarehouseInventoryFromJSON(resourceName);
    }

    public string Export(List<WarehouseNode> list)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(list, options);
    }
}