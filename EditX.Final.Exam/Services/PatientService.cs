using EditX.Final.Exam.Interfaces;
using System.Text.Json;

namespace EditX.Final.Exam.Services;
internal class PatientService : IPatientService
{
    private List<IPatient> _patients = [];
    public PatientService()
    { }
        
    internal async Task ImportData()
    {
        //Import the embedded resource Patients.json
        foreach (var patient in await Utilities.ReadPatientsFromJSON("Patients.json")) {
            _patients.Add(patient);
        }
    }

    internal string PrintAll()
    {
        return PrintX(_patients.Count);
    }

    internal string PrintX(int amount)
    {
        return PrintXWithSkip(amount, 0);
    }

    internal string PrintXWithSkip(int amount, int skip)
    {
        String res = String.Join("-", _patients.Select(x => x.LastName).Skip(skip).Take(amount).ToArray());
        return res;
    }

    internal string PrintPatients(Func<IPatient, bool> value)
    {
        String res = String.Join("-", _patients.Where(x => value(x)).Select(x => x.LastName).ToArray());
        return res;
    }

    internal IPatient GetPatientBySocialSecurityNumber(string patientnr1)
    {
        var ssn = patientnr1.Replace("$", ".").Replace(".", "");
        return _patients.Where(x => x.SocialSecurityNumber.Replace(".", "") == ssn).First();
    }
}