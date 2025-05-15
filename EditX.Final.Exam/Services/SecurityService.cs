using EditX.Final.Exam.Interfaces;
using System.Buffers.Text;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace EditX.Final.Exam.Services;

internal class SecurityService : ISecurityService
{
    private PatientService patientService;

    public SecurityService()
    {
        patientService = new PatientService();
    }

    public byte[] GetSHA512HashForPatient(IPatient patient)
    {
        var data = Encoding.UTF8.GetBytes(Encrypt(patient.SocialSecurityNumber, Enums.EncryptionAlgorithms.None));
        using (SHA512 shaM = new SHA512Managed())
        {
            return shaM.ComputeHash(data);
        }
    }


    public string Encrypt(string input, Enums.EncryptionAlgorithms algorithm)
    {
        string securityKey = "iL0veS3cretz";
        if (algorithm == Enums.EncryptionAlgorithms.None)
        {
            return input + securityKey;
        }

        var interleaved = Interleave(input, securityKey);

        var bytes = Encoding.UTF8.GetBytes(interleaved);
        //shift every third byte by 1 bit to the left, others by 1 bit to the right
        for (int i = 0; i < bytes.Length; i++)
        {
            if ((i + 1) % 3 == 0)
            {
                bytes[i] = (byte)(bytes[i] << 1);
            }
            else
            {
                bytes[i] = (byte)(bytes[i] >> 1);
            }
        }

        if (algorithm == Enums.EncryptionAlgorithms.Basic)
        {
            return Convert.ToBase64String(bytes);
        }

        //XOR every other byte with 111
        for (int i = 0; i < bytes.Length; i++)
        {
            if ((i + 1) % 2 == 0)
            {
                bytes[i] ^= 111;
            }
        }

        // concatenate the result to the string
        var xorResult = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            xorResult.Append((char)bytes[i]);
        }

        if (algorithm == Enums.EncryptionAlgorithms.Intermediate)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(xorResult.ToString()));
        }

        interleaved = Interleave(xorResult.ToString(), new string(securityKey.Reverse().ToArray()));

        return input + securityKey;
    }

    private static string Interleave(string input, string securityKey)
    {
        var interleaved = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            interleaved.Append(input[i]);
            interleaved.Append(securityKey[i % securityKey.Length]);
        }
        Console.WriteLine(interleaved.ToString());
        return interleaved.ToString();
    }
}