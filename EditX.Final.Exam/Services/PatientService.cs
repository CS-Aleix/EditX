using EditX.Final.Exam.Interfaces;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace EditX.Final.Exam.Services;
internal class PatientService : IPatientService
{
    private List<Patient> _patients = [];
    public PatientService()
    { }
        
    internal async Task ImportData()
    {
        //Import the embedded resource Patients.json
        var content = await File.ReadAllTextAsync("./Resources/Patients.json");
        var data = JsonSerializer.Deserialize<List<Patient>>(content, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        })!;
        _patients = data.ToList();
    }

    internal string PrintAll()
    {
        var lastNames = _patients.Select(x => x.LastName).ToList();
        return string.Join("-", lastNames);
    }

    internal string PrintX(int amount)
    {
        var lastNames = _patients.Take(amount).Select(x => x.LastName).ToList();
        return string.Join("-", lastNames);
    }

    internal string PrintXWithSkip(int amount, int skip)
    {
        var lastNames = _patients.Skip(skip).Take(amount).Select(x => x.LastName).ToList();
        return string.Join("-", lastNames);
    }

    internal string PrintPatients(Func<Patient, bool> value)
    {
        
        var lastNames = _patients.Where(value).Select(x => x.LastName).ToList();
        return string.Join("-", lastNames);
    }

    internal Patient GetPatientBySocialSecurityNumber(string patientnr1)
    {
        var pattern = $"[^0-9]";
        var search = Regex.Replace(patientnr1, $"[^0-9]", "");
        var found = _patients.FirstOrDefault(x => Regex.Replace(x.SocialSecurityNumber, $"[^0-9]", "") == search);
        if (found is null) throw new Exception("NOT FOUND");
        return found;
    }
}