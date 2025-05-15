using EditX.Final.Exam.Interfaces;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace EditX.Final.Exam.Services;

internal class PatientService : IPatientService
{
    private List<IPatient> _patients = [];
    public PatientService()
    { }

    internal async Task ImportData()
    {
        var patiensEnumerable = await Utilities.ReadPatientsFromJSON("Patients.json");
        _patients = patiensEnumerable?.Cast<IPatient>().ToList() ?? new List<IPatient>();
    }

    //define a propoerty selector to use in print functuions
    internal Func<IPatient, string> printProperty = p => p.LastName;

    internal string PrintAll()
    {
        return string.Join("-", _patients.Select(p => p.LastName));
    }

    internal string PrintX(int amount)
    {
        return string.Join("-", _patients.Take(amount).Select(printProperty));
    }

    internal string PrintXWithSkip(int amount, int skip)
    {
        return string.Join("-", _patients.Skip(skip).Take(amount).Select(printProperty));
    }

    internal string PrintPatients(Func<IPatient, bool> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null");
        }
        return string.Join("-", _patients.Where(predicate).Select(printProperty));
    }


    public IPatient? GetPatientBySocialSecurityNumber(string ssn)
    {
        if (string.IsNullOrWhiteSpace(ssn))
        {
            throw new ArgumentNullException(nameof(ssn), "Social Security Number cannot be null or empty");
        }
        var regex = new Regex(@"[^\d]");
        return _patients.FirstOrDefault(p => regex.Replace(p.SocialSecurityNumber, "").Equals(regex.Replace(ssn, "")));
    }
}