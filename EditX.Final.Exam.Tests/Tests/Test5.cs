using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Services;

namespace EditX.Final.Exam.Tests;

[TestClass]
public class Test5
{ 
    /// <summary>
    /// Time to implement an encryption algorithm!
    ///
    /// Our algorithm has the following steps:
    /// 1. Take the input (I) and interleave it with the security key (S)
    ///     a. I1S1I2S2I3S3..IXSX (last letter of result is always from security key)
    ///     b. restart from beginning of security key if word to encrypt is longer
    /// 2. Shift every third character 1 bit to the right and all others 1 bit to the left
    /// 3. XOR every other character with '111' and concatenate the result to the string
    /// 4. Interleave again with the reverse of the current value
    /// 5. Convert to Base64
    /// </summary>
    /// <param name="input">the string to be encrypted</param>
    /// <param name="expectedOutput">the string expected after it has gone through the encryption</param>

    [TestMethod]
    [DataRow("PepperoniPizza", "wqBfw5LCmzLCm8KYW8Ogw48Ywr3DoFjDrMKxMsKLw4pdw6TCjynCj8OeXWbDjzfCmMOGMMOSw5I5w7TCoD3DisO0NMOow6g0w7TDij3CoMO0OcOSw5Iww4bCmDfDj2Zdw57CjynCj8OkXcOKwosywrHDrFjDoMK9GMOPw6BbwpjCmzLCm8OSX8Kg")]
    //[DataRow("Lumberjack", "LHWH6E4FlmW3h6I/NIgSSB0o6bnGcD12sIoIkh0PSR7jEK8LVsKZdaWrQK3qgSQEXmJmP/FCH4ptVpNDGbq1OA==")]
    public void EncryptionMachine(string input, string expectedOutput)
    {
        //Arrange
        ISecurityService _sut = new SecurityService();

        //Act
        string encryptedText = _sut.Encrypt(input);

        //Assert
        Assert.AreEqual(expectedOutput, encryptedText, $"Output does not match expected output.");
    }
}