using EditX.Final.Exam.Interfaces.Warehouse;

namespace EditX.Final.Exam.Models.Warehouse;

internal class InventoryImporterJSON : IInventoryImporter
{
    public async Task<object> Import(string resourceName)
    {
        return Utilities.ReadWarehouseInventoryFromJSON(resourceName);
    }

    public string Export(object list)
    {
        return string.Empty; //Something is missing here
    }
}