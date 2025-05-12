using EditX.Final.Exam.Enums;
using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Services;

namespace EditX.Final.Exam.Tests;

[TestClass]
public class Test5
{ 
    /// <summary>
    /// Time to implement an encryption algorithm!
    ///
    /// Our FULL algorithm has the following steps:
    /// 1. Take the input (I) and interleave it with the security key (S)
    ///     a. I1S1I2S2I3S3..IXSX (last letter of result is always from security key)
    ///     b. restart from beginning of security key if word to encrypt is longer
    /// 2. Shift every third character 1 bit to the right and all others 1 bit to the left
    /// 3. XOR every other character with '111' and concatenate the result to the string
    /// 4. Interleave again with the reverse of the current value
    /// 5. Convert to Base64
    /// </summary>

    [TestMethod]
    [DataRow("To Smithereens", EncryptionAlgorithms.Basic, "wqjDkjfCmEAYwqbDrDbDisOSKcOoZjTDhsOKOcOkw4oyw6jDij3DnMOSOcKY")]
    [DataRow("Alpaca Simulator", EncryptionAlgorithms.Basic, "woLDkjbCmMOgGMOCw6wxw4rDgilAZinDhsOSOcOaw4o6w6jDmD3DgsOSOsKYw54Yw6TDrA==")]
    public void Encrypt_ShouldReturnEncryptedString_WhenInputAndBasicAlgorithmProvided(string input, EncryptionAlgorithms algorithm, string expectedOutput)
    {
        //The BASIC encryption only contains steps 1, 2 & 5.

        //Arrange
        SecurityService _sut = new SecurityService();

        //Act
        string encryptedText = _sut.Encrypt(input, algorithm);

        //Assert
        Assert.AreEqual(expectedOutput, encryptedText, $"Output does not match expected output.");
    }

    [TestMethod]
    [DataRow("Natural Wonders", EncryptionAlgorithms.Intermediate, "wpzDkjDCmMOoGMOqw6w5w4rDginDmGYQw4bCrjnDnsOKN8Oow4g9w4rDkjnCmMOmGMOzX8KHwoVWwq3Ct3/DgcKxWMKnwqVWwok=")]
    [DataRow("Aegis", EncryptionAlgorithms.Intermediate, "woLDkjLCmMOOGMOSw6w5w4rDrV3CocK9Vg==")]
    public void Encrypt_ShouldReturnEncryptedString_WhenInputAndIntermediateAlgorithmProvided(string input, EncryptionAlgorithms algorithm, string expectedOutput)
    {
        //The INTERMEDIATE encryption only contains steps 1, 2, 3 & 5.

        //Arrange
        SecurityService _sut = new SecurityService();

        //Act
        string encryptedText = _sut.Encrypt(input, algorithm);

        //Assert
        Assert.AreEqual(expectedOutput, encryptedText, $"Output does not match expected output.");
    }

    [TestMethod]
    [DataRow("PepperoniPizza", EncryptionAlgorithms.Full, "wqBfw5LCmzLCm8KYW8Ogw48Ywr3DoFjDrMKxMsKLw4pdw6TCjynCj8OeXWbDjzfCmMOGMMOSw5I5w7TCoD3DisO0NMOow6g0w7TDij3CoMO0OcOSw5Iww4bCmDfDj2Zdw57CjynCj8OkXcOKwosywrHDrFjDoMK9GMOPw6BbwpjCmzLCm8OSX8Kg")]
    [DataRow("Lumberjack", EncryptionAlgorithms.Full, "wpjCucOSwqk6X8KYwrvDmsKLGF3DhMKrw6zCtTJVw4rDt8Okw4opw5bDlDlmw4Yww4bDhjDDhmY5w5TDlinDisOkw7fDilUywrXDrMKrw4RdGMKLw5rCu8KYXzrCqcOSwrnCmA==")]
    public void Encrypt_ShouldReturnEncryptedString_WhenInputAndFullAlgorithmProvided(string input, EncryptionAlgorithms algorithm, string expectedOutput)
    {
        //The FULL encryption contains ALL the steps; 1, 2, 3, 4 & 5.

        //Arrange
        SecurityService _sut = new SecurityService();

        //Act
        string encryptedText = _sut.Encrypt(input, algorithm);

        //Assert
        Assert.AreEqual(expectedOutput, encryptedText, $"Output does not match expected output.");
    }
}