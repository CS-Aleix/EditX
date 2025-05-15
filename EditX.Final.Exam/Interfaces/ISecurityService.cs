namespace EditX.Final.Exam.Interfaces;
internal interface ISecurityService
{
    string? Encrypt(string input, Enums.EncryptionAlgorithms algorithm);
    byte[] GetSHA512HashForPatient(Patient patient);
}