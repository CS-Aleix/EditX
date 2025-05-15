using EditX.Final.Exam.Interfaces;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;

namespace EditX.Final.Exam.Services;

internal class SecurityService : ISecurityService
{
    private readonly string _securityKey = "iL0veS3cretz";

    public SecurityService()
    { }

    public byte[] GetSHA512HashForPatient(IPatient patient)
    {
        if (patient == null || string.IsNullOrEmpty(patient.SocialSecurityNumber))
            throw new ArgumentException("Patient or Social Security Number is null or empty.");

        string input = patient.SocialSecurityNumber + _securityKey;
        using var sha512 = SHA512.Create();
        return sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
    }

    public string Encrypt(string input, Enums.EncryptionAlgorithms algorithm)
    {
        return string.Empty;
    }
}