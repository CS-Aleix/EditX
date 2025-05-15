using EditX.Final.Exam.Interfaces;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;

namespace EditX.Final.Exam.Services;

internal class SecurityService : ISecurityService
{
    private readonly string pepper = "iL0veS3cretz";
    
    public SecurityService()
    { }

    public byte[] GetSHA512HashForPatient(IPatient patient)
    {
        var hasher = SHA512.Create();
        return hasher.ComputeHash(Encoding.UTF8.GetBytes(patient.SocialSecurityNumber + pepper));
    }

    internal string Add(int idx, string cur, char c, Enums.EncryptionAlgorithms algorithm) {
        if (idx % 3 == 2) {// step 2
            c >>= 1;
        } else {
            c <<= 1;
        }
        return cur + c;
    }

    internal string Step3(string x) {
        string res = string.Copy(x);
        for (int i = 1; i < x.Length; i+=2) {
            res += x[i] ^ (char)111;
        }
        return res;
    }

    public string Encrypt(string input, Enums.EncryptionAlgorithms algorithm)
    {
        string securityKey = "iL0veS3cretz";
        
        string interim = "";
        for (int i = 0; i < input.Length; i++) {
            interim = Add(2 * i, interim, input[i], algorithm);
            interim = Add(2 * i + 1, interim, securityKey[i % securityKey.Length], algorithm);
        }

        if (algorithm != Enums.EncryptionAlgorithms.Basic) {
            interim = Step3(interim);
        }

        string res = "";
        if (algorithm == Enums.EncryptionAlgorithms.Full) {
            for (int i = 0; i < interim.Length; i++) {
                res += interim[i];
                res += interim[interim.Length - 1 - i];
            }
        } else {
            res = interim;
        }

        return Convert.ToBase64String(Encoding.UTF8.GetBytes(res));
    }
}