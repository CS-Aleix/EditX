using EditX.Final.Exam.Interfaces.Warehouse;
using System.Drawing;

namespace EditX.Final.Exam.Models.Warehouse;

internal class WarehouseLocation : WarehouseNode, IWarehouseLocation
{
    public Item HeldItem { get; set; }
    public int Amount { get; set; }

}