using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Services;
using Moq;

namespace EditX.Final.Exam.Tests;

[TestClass]
public class Test3
{
    [TestMethod]
    [DataRow("674.88.91.233", "v004OcNee6BEUiqim+Al32AllO8Pm27J8Er5Oq7X3iCR8KKTyTNGR7PrSmuPq5xCWljK43u7lVkvQS1216fKvA==")]
    [DataRow("442.16.53.727", "LHWH6E4FlmW3h6I/NIgSSB0o6bnGcD12sIoIkh0PSR7jEK8LVsKZdaWrQK3qgSQEXmJmP/FCH4ptVpNDGbq1OA==")]
    public void GetSHA512HashForPatient_ShouldReturnCorrectHash_WhenGivenAnIdentificationNumber(string socialSecurityNumber, string expectedSHA512Hash)
    {
        //TestTip: we do things safely around here; Would you pass me the salt & pepper please?
        //private readonly string _securityKey = "iL0veS3cretz";

        //Arrange
        ISecurityService _sut = new SecurityService();

        var patientMock = new Mock<IPatient>();
        patientMock.Setup(m => m.SocialSecurityNumber).Returns(socialSecurityNumber);

        //Act
        var sha512Bytes = _sut.GetSHA512HashForPatient(patientMock.Object);

        //Assert
        var base64Hash = Convert.ToBase64String(sha512Bytes);
        Assert.AreEqual(expectedSHA512Hash, base64Hash, $"Output does not match expected output for social security number {socialSecurityNumber}");
    }
}