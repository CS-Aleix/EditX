using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EditX.Final.Exam.Services;
internal class PatientService : IPatientService
{
    private List<IPatient> _patients = [];
    public PatientService()
    { }

    internal async Task ImportData()
    {
        //Import the embedded resource Patients.json
        _patients = new List<IPatient>(await Utilities.ReadPatientsFromJSON("Patients.json") ?? []);
    }

    internal string PrintAll()
    {
        return string.Join("-", _patients.Select(p => p.LastName));
    }

    internal string PrintX(int amount)
    {
         return string.Join("-", _patients.Take(amount).Select(p => p.LastName));
    }

    internal string PrintXWithSkip(int amount, int skip)
    {
       return string.Join("-", _patients.Skip(skip).Take(amount).Select(p => p.LastName));
    }

    internal string PrintPatients(Func<IPatient, bool> value)
    {
  return string.Join("-", _patients.Where(p=> value?.Invoke(p) ?? false).Select(p => p.LastName));
    }

    internal IPatient GetPatientBySocialSecurityNumber(string patientnr1)
    {
        return _patients.FirstOrDefault(c => GetSSNText(c.SocialSecurityNumber)
        .Equals(GetSSNText(patientnr1), StringComparison.OrdinalIgnoreCase)) ?? new Patient();
    }

    private string GetSSNText(string rrn)
    {
        return new string(rrn.Where(char.IsNumber).ToArray());
    }
}