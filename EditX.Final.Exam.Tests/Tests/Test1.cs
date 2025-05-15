using EditX.Final.Exam.Services;

namespace EditX.Final.Exam.Tests;

/// NameCard - Please fill in the following data
/// Name: De Reu Thibo

/// <summary>
/// Welcome to the ChipSoft coding challenge!
/// 
/// The purpose of this challenge is to put your skills on display!
/// All the necessary data to complete this test (and the following ones) can be found in this solution.
/// Some parts you will have to make yourself, some might be already (partially) available.
/// Go through the structure and files and see if you can make sense of it.
/// 
/// You can use the internet to look things up, but please refrain from using AI to solve these problems.
/// Feel free to ask questions about the challenge, we will answer as we see fit :)
/// 
/// The goal: to make sure all the provided tests are green, whilst showing off your hard earned programming prowess.
/// However, this is not just a race, the quality of your code will play an important part in the scoring aswell! 
/// 
/// Important note: THE TESTS THEMSELVES ARE NOT TO BE TOUCHED. 
/// All other code is merely suggestive and is free to be changed as you see fit.
/// </summary>


[TestClass]
public sealed class Test1
{
    [TestMethod]
    public async Task PrintAll_ShouldPrintAllPatients_WhenJSONRead()
    {
        //Arrange
        PatientService _sut = new();
        await _sut.ImportData();

        //Act
        string patientsString = _sut.PrintAll();

        //Assert
        string expectedOutput = Utilities.ReadResourceContentToString(filename: "Test1Output1.txt");
        Assert.AreEqual(expectedOutput, patientsString, "Output does not match expected output for Test1");
    }

    [TestMethod]
    public async Task PrintX_ShouldPrintTheFirstXPatients_WhenProvidedAnAmount()
    {
        //Arrange
        PatientService _sut = new();
        await _sut.ImportData();

        //Act
        string patientsString = _sut.PrintX(3);

        //Assert
        string expectedOutput = Utilities.ReadResourceContentToString(filename: "Test1Output2.txt");
        Assert.AreEqual(expectedOutput, patientsString, "Output does not match expected output for Test1");
    }

    [TestMethod]
    public async Task PrintX_ShouldPrintXPatientsAfterSkippingY_WhenProvidedWithValues()
    {
        //Arrange
        PatientService _sut = new();
        await _sut.ImportData();

        //Act
        string patientsString = _sut.PrintXWithSkip(3, 2);

        //Assert
        string expectedOutput = Utilities.ReadResourceContentToString(filename: "Test1Output2bis.txt");
        Assert.AreEqual(expectedOutput, patientsString, "Output does not match expected output for Test1");
    }

    [TestMethod]
    public async Task PrintPatients_ShouldPrintAccordingToPredicate_WhenProvidedAValidPredicate()
    {
        //Arrange
        PatientService _sut = new();
        await _sut.ImportData();

        //Act
        string patientsString = _sut.PrintPatients(p => p.City.Equals("Liverpool"));

        //Assert
        string expectedOutput = Utilities.ReadResourceContentToString(filename: "Test1Output3.txt");
        Assert.AreEqual(expectedOutput, patientsString, "Output does not match expected output for Test1");
    }
}