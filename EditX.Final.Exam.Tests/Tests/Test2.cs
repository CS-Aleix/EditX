using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Services;

namespace EditX.Final.Exam.Tests;

[TestClass]
public class Test2
{
    [TestMethod]
    [DataRow("674.88.91.233", "442.16.53.727", "Test2Output1.txt")]
    [DataRow("345.67.89.012", "1234567890", "Test2Output2.txt")]
    [DataRow("567$89$01$234", "456.78.90.123", "Test2Output3.txt")]
    public async Task SwapPatients_ChangesLocations_WhenGiven2Patients(string patientnr1, string patientnr2, string outputPath)
    {
        //Arrange
        LocationService _sut = new();
        PatientService patientService = new();
        await patientService.ImportData();
        IPatient patient1 = patientService.GetPatientBySocialSecurityNumber(patientnr1);
        IPatient patient2 = patientService.GetPatientBySocialSecurityNumber(patientnr2);

        //Act
        LocationService.SwapPatients(patient1, patient2);
        string locationsString = LocationService.PrintPatientLocations(patient1, patient2).Trim();

        //Assert
        string expectedOutput = Utilities.ReadResourceContentToString(filename: outputPath).Trim();
        Assert.AreEqual(expectedOutput, locationsString, "Output does not match expected output for Test2");
    }
}