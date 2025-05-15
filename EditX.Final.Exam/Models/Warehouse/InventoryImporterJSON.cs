using EditX.Final.Exam.Interfaces.Warehouse;

namespace EditX.Final.Exam.Models.Warehouse;

internal class InventoryImporterJSON : IInventoryImporter
{
    public async Task<IEnumerable<WarehouseNode>> Import(string resourceName)
    {
        return await Utilities.ReadWarehouseInventoryFromJSON(resourceName);
    }

    public string Export(IEnumerable<WarehouseNode> list)
    {
        return Utilities.ConvertWarehouseInventoryToJSON(list.ToList()); //Something is missing here
    }
}