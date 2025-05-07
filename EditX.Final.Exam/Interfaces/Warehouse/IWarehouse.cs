using EditX.Final.Exam.Enums;
using EditX.Final.Exam.Models;

namespace EditX.Final.Exam.Interfaces.Warehouse;

internal interface IWarehouse
{
    void ProcessOrder(SingleMedicationOrder order, PickingAlgorithms algorithm);

    void Import(string resourceName);

    string Export();
}