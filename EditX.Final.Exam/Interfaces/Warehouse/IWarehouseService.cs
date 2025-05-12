using EditX.Final.Exam.Enums;
using EditX.Final.Exam.Models;

namespace EditX.Final.Exam.Interfaces.Warehouse;

internal interface IWarehouseService
{
    void ProcessOrder(SingleMedicationOrder order, PickingAlgorithms algorithm);

    Task Import(string resourceName);

    string Export();
}