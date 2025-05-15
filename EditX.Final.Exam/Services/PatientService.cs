using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Models;
using System.Text.Json.Nodes;

namespace EditX.Final.Exam.Services;
internal class PatientService : IPatientService
{
    private List<IPatient> _patients = [];
    public PatientService()
    { }
        
    internal async Task ImportData()
    {
        //Import the embedded resource Patients.json
        var result = await Utilities.ReadPatientsFromJSON<Patient>("Patients.json");

        foreach (var res in result)
        {
            _patients.Add(res);
        }
    }

    internal string PrintAll()
    {
        return string.Join('-', _patients.Select(x => x.LastName));
    }

    internal string PrintX(int amount)
    {
        return PrintXWithSkip(amount, 0);
    }

    internal string PrintXWithSkip(int amount, int skip)
    {
        return string.Join('-', _patients.Skip(skip).Take(amount).Select(x => x.LastName));
    }

    internal string PrintPatients(Func<IPatient, bool> value)
    {
        return string.Join('-', _patients.Where(value).Select(x => x.LastName));
    }

    internal IPatient GetPatientBySocialSecurityNumber(string patientnr1)
    {
        // must be able to work with string XXXXXX and should turn into xxx.xx.xx
        if (patientnr1.Contains('$'))
        {
            patientnr1 = patientnr1.Replace('$', '.');
            return _patients.Single(x => x.SocialSecurityNumber == patientnr1);
        }
        else if(patientnr1.Contains('.'))
        {
            return _patients.Single(x => x.SocialSecurityNumber == patientnr1);
        }
        patientnr1 = $"{patientnr1.Substring(0, 3)}.{patientnr1.Substring(3, 2)}.{patientnr1.Substring(5, 2)}.{patientnr1.Substring(7,3)}";
        return _patients.Single(x => x.SocialSecurityNumber == patientnr1);
    }
}