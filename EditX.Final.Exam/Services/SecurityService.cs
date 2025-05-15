using EditX.Final.Exam.Interfaces;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EditX.Final.Exam.Services;

internal class SecurityService : ISecurityService
{
    public SecurityService()
    { }

    public byte[] GetSHA512HashForPatient(IPatient patient)
    {
        using (SHA512 shaM = SHA512.Create())
        {
            return shaM.ComputeHash(Encoding.UTF8.GetBytes(patient.SocialSecurityNumber + "iL0veS3cretz"));
        }
    }

    public string Encrypt(string input, Enums.EncryptionAlgorithms algorithm)
    {
        string securityKey = "iL0veS3cretz";
        string interleaved = CalculateInterleaved(input, securityKey);
        string shifted = BitShift(interleaved);
        switch (algorithm)
        {
            case Enums.EncryptionAlgorithms.Basic:
                return Base64Encode(shifted);
            case Enums.EncryptionAlgorithms.Intermediate:
                string intermediateXor = Xor(shifted);
                return Base64Encode(intermediateXor);
            case Enums.EncryptionAlgorithms.Full:
                string fullXor = Xor(shifted);
                string interleaveRevers = InterleaveWithRevers(fullXor);
                return Base64Encode(interleaveRevers);
        }
        return string.Empty;
    }

    private string InterleaveWithRevers(string input)
    {
        /// 4. Interleave again with the reverse of the current value
        string reverse = new string(input.Reverse().ToArray());
        List<char> chars = new();
        for (int i = 0; i < input.Length; i++)
        {
            chars.Add(input[i]);
            chars.Add(reverse[i]);

        }
        return new string(chars.ToArray());
    }

    private string Xor(string input)
    {
        /// 3. XOR every other character with '111' and 
        /// concatenate the result to the string
        List<char> chars = new();
        for (int i = 0; i < input.Length; i++)
        {
            if ((i) % 2 == 0)
            {
                chars.Add((char)(input[i] ^ 111));
            }
        }
        return input + new string(chars.ToArray());
    }

    private string Base64Encode(string input)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
    }

    private string BitShift(string input)
    {
        /// 2. Shift every third character 1 bit to the right and all others 1 bit to the left
        List<char> chars = new();
        for (int i = 0; i < input.Length; i++)
        {
            if ((i + 1) % 3 == 0)
            {
                chars.Add((char)(input[i] >> 1));
            }
            else
            {
                chars.Add((char)(input[i] << 1));
            }
        }
        return new string(chars.ToArray());
    }

    private string CalculateInterleaved(string input, string securityKey)
    {
        // 1. Take the input (I) and interleave it with the security key (S)
        ///     a. I1S1I2S2I3S3..IXSX (last letter of result is always from security key)
        ///     b. restart from beginning of security key if word to encrypt is longer

        List<char> chars = new();
        for (int i = 0; i < input.Length; i++)
        {
            chars.Add(input[i]);
            chars.Add(securityKey[i % securityKey.Length]);

        }
        return new string(chars.ToArray());
    }
}