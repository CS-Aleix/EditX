using EditX.Final.Exam.Enums;
using EditX.Final.Exam.Interfaces;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace EditX.Final.Exam.Services;

internal class SecurityService : ISecurityService
{
    public SecurityService()
    { }

    public byte[] GetSHA512HashForPatient(IPatient patient)
    {
        const string securityKey = "iL0veS3cretz";
        byte[] patientBytes = Encoding.ASCII.GetBytes(patient.SocialSecurityNumber + securityKey);
        return SHA512.HashData(patientBytes);
    }

    public string Encrypt(string input, EncryptionAlgorithms algorithm)
    {
        string securityKey = "iL0veS3cretz";

        if (algorithm == EncryptionAlgorithms.Basic)
        {
            
            StringBuilder interleaved = new();
            int maxLength = Math.Max(input.Length, securityKey.Length);
            for (int i = 0; i < maxLength; i++)
            {
                if (i < input.Length)
                    interleaved.Append(input[i]);
                if (i < securityKey.Length)
                    interleaved.Append(securityKey[i]);
            }
            
            StringBuilder shifted = new();
            for (int i = 0; i < interleaved.Length; i++)
            {
                char c = interleaved[i];
                if ((i + 1) % 3 == 0)
                    shifted.Append(c);
                else
                    shifted.Insert(i == 0 ? 0 : i-1, c);
            }
            
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(shifted.ToString()));
        }

        return string.Empty;
    }
}