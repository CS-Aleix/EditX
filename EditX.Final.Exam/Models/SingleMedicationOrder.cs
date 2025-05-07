using EditX.Final.Exam.Models.Warehouse;

namespace EditX.Final.Exam.Models;

public class SingleMedicationOrder
{
    public Medication Item { get; set; }
    public WarehouseDestination Destination { get; set; }
    public int Amount { get; set; }
}