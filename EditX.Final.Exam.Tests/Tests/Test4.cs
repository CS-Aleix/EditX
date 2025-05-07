using EditX.Final.Exam.Enums;
using EditX.Final.Exam.Models;
using EditX.Final.Exam.Models.Warehouse;

namespace EditX.Final.Exam.Tests;

[TestClass]
public class Test4
{
    public static IEnumerable<object[]> AdditionData
    {
        get
        {
            var medication = new Medication() { SerialNumber = "ABC", Name = "TestMed", Description = "ExampleMedication" };
            var destination1 = new WarehouseDestination() { Location = new System.Drawing.Point(5, 0) };
            var destination2 = new WarehouseDestination() { Location = new System.Drawing.Point(5, 10) };
            return
            [
                ["warehouseLayout.json", new SingleMedicationOrder() { Item = medication, Amount = 2, Destination = destination1 }, "warehouse1Output.json", PickingAlgorithms.ClosestDistance],
                ["warehouseLayout.json", new SingleMedicationOrder() { Item = medication, Amount = 2, Destination = destination2 }, "warehouse2Output.json", PickingAlgorithms.ClosestDistance],
                ["warehouseLayout_highest.json", new SingleMedicationOrder() { Item = medication, Amount = 1, Destination = destination1 }, "warehouse3Output.json", PickingAlgorithms.HighestStock],
            ];
        }
    }

    [DataTestMethod]
    [DynamicData(nameof(AdditionData))]
    public void ProcessOrder_TakesFromCorrectLocation_WhenGivenAnOrder(string sourceFileName, SingleMedicationOrder order, string outputFilename, PickingAlgorithms algorithm)
    {
        //Arrange
        InventoryImporterJSON importer = new();
        Warehouse _sut = new(importer);
        _sut.Import(sourceFileName);

        //Act
        _sut.ProcessOrder(order, algorithm);

        //Assert
        string expectedOutput = Utilities.ReadResourceContentToString(filename: outputFilename).Trim();
        string warehouseState = _sut.Export().Trim();
        Assert.AreEqual(expectedOutput, warehouseState, "Output does not match expected output for Test2");
    }
}