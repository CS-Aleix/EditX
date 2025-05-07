using System.Text.Json.Serialization;

namespace EditX.Final.Exam.Models.Warehouse;

[JsonDerivedType(typeof(Medication), typeDiscriminator: "Medication")]
public abstract class Item
{
    public string SerialNumber { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}