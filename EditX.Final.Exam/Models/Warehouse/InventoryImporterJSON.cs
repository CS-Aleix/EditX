using EditX.Final.Exam.Interfaces.Warehouse;

namespace EditX.Final.Exam.Models.Warehouse;

internal class InventoryImporterJSON : IInventoryImporter
{
    public async Task<List<WarehouseNode>> Import(string resourceName)
    {
        return await Utilities.ReadWarehouseInventoryFromJSON(resourceName);
    }

    public string Export(object list)
    {
        return string.Empty; //Something is missing here
    }
}