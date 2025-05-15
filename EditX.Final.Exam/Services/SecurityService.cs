using EditX.Final.Exam.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace EditX.Final.Exam.Services;

internal class SecurityService : ISecurityService
{
    public SecurityService()
    { }

    public byte[] GetSHA512HashForPatient(Patient patient)
    {
        return SHA512
            .Create()
            .ComputeHash(Encoding.UTF8.GetBytes(patient.SocialSecurityNumber));
    }

    public string Encrypt(string input, Enums.EncryptionAlgorithms algorithm)
    {
        string securityKey = "iL0veS3cretz";

        return string.Empty;
    }
}