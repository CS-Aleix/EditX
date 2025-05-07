namespace EditX.Final.Exam.Interfaces;
internal interface ISecurityService
{
    string? Encrypt(string input);
    byte[] GetSHA512HashForPatient(IPatient patient);
}