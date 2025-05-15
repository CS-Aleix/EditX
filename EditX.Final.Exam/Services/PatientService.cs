using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Models;

namespace EditX.Final.Exam.Services;
internal class PatientService : IPatientService
{
    private const char SEPARATOR = '-';
    private const string SOCIAL_SECURITY_NUMBER_SEPARATOR = ".";
    private List<Patient> _patients = [];
    private IEnumerable<string> _patientLastNames = [];
    public PatientService()
    { }

    internal async Task ImportData()
    {
        //Import the embedded resource Patients.json
        _patients = await Utilities.ReadPatientsFromJSON("Patients.json") ?? throw new ArgumentException("Impossible to import data.");
        _patients.ForEach(p => p.SocialSecurityNumber = p.SocialSecurityNumber.Replace(SOCIAL_SECURITY_NUMBER_SEPARATOR, string.Empty));
        _patientLastNames = _patients.Select(p => p.LastName);
    }

    internal string PrintAll()
    {
        return string.Join(SEPARATOR, _patientLastNames);
    }

    internal string PrintX(int amount)
    {
        return string.Join(SEPARATOR, _patientLastNames.Take(amount));
    }

    internal string PrintXWithSkip(int amount, int skip)
    {
        return string.Join(SEPARATOR, _patientLastNames.Skip(skip).Take(amount));
    }

    internal string PrintPatients(Func<IPatient, bool> value)
    {
        return string.Join(SEPARATOR, _patients.Where(value).Select(p => p.LastName));
    }

    internal IPatient? GetPatientBySocialSecurityNumber(string patientnr1)
    {
        return _patients.SingleOrDefault(_patients => _patients.SocialSecurityNumber.Equals(patientnr1));
    }
}