using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Models;
using EditX.Final.Exam.Models.Warehouse;
using System.Text.Json;

namespace EditX.Final.Exam.Services;
internal class PatientService : IPatientService
{
    private List<Patient> _patients = [];
    public PatientService()
    { }
        
    internal async Task ImportData()
    {
        //Import the embedded resource Patients.json
        _patients = await Utilities.ReadPatientsFromJSON("Patients.json");
    }

    internal string Print(List<Patient> patients)
    {
        string patientsText = String.Empty;

        foreach (IPatient patient in patients)
        {
            patientsText += $"{patient.LastName}-";
        }

        return patientsText.Remove(patientsText.Length - 1);
    }

    internal string PrintAll()
    {
        return Print(_patients);
    }

    internal string PrintX(int amount)
    {
        List<Patient> patients = _patients;
        patients.RemoveRange(amount, (_patients.Count - amount));
        return Print(patients);
    }

    internal string PrintXWithSkip(int amount, int skip)
    {
        List<Patient> patients = _patients;
        patients.RemoveRange(0, skip);
        patients.RemoveRange(amount, (_patients.Count - amount));
        return Print(patients);
    }

    internal string PrintPatients(Func<Patient, bool> value)
    {
        List<Patient> patients = _patients.Where(value).ToList();
        return Print(patients);
    }

    internal IPatient GetPatientBySocialSecurityNumber(string patientnr1)
    {
        string nr = String.Empty;
        patientnr1 = patientnr1.Replace('$', '.');

        if (!patientnr1.Contains('.'))
            nr = $"{patientnr1.Substring(0, 3)}.{patientnr1.Substring(3, 2)}.{patientnr1.Substring(5, 2)}.{patientnr1.Substring(7, 3)}";
        else
            nr = patientnr1;

        return _patients.First(p => p.SocialSecurityNumber == patientnr1);
    }
}