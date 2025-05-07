using EditX.Final.Exam.Interfaces.Warehouse;
using System.Drawing;
using System.Text.Json.Serialization;

namespace EditX.Final.Exam.Models.Warehouse;

[JsonDerivedType(typeof(WarehouseDestination), typeDiscriminator: "Destination")]
[JsonDerivedType(typeof(WarehouseLocation), typeDiscriminator: "Location")]
public abstract class WarehouseNode : IWarehouseNode
{
    public Point Location { get; set; }
}