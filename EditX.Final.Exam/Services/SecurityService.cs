using EditX.Final.Exam.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace EditX.Final.Exam.Services;

internal class SecurityService : ISecurityService
{
    public SecurityService()
    { }

    private string securityKey = "iL0veS3cretz";

    public byte[] GetSHA512HashForPatient(IPatient patient)
    {
        var patientBytes = Encoding.ASCII.GetBytes(patient.SocialSecurityNumber + securityKey);
        return SHA512.HashData(patientBytes);
    }

    public string Encrypt(string input, Enums.EncryptionAlgorithms algorithm)
    {

        return string.Empty;
    }
}