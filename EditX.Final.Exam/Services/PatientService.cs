using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Models;

namespace EditX.Final.Exam.Services;
internal class PatientService : IPatientService
{
    private List<IPatient> _patients = [];
    public PatientService()
    { }
        
    internal async Task ImportData()
    {
        try
        {
            var patients = await Utilities.ReadPatientsFromJSON("Patients.json");
            if (patients == null || !patients.Any())
            {
                throw new InvalidOperationException("No patients found in the JSON file.");
            }

            foreach (var patientData in patients)
            {
                _patients.Add(new Patient(patientData.FirstName,patientData.LastName,patientData.BirthDate,patientData.City,patientData.SocialSecurityNumber,patientData.Location));
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to import patient data: {ex.Message}", ex);
        }
    }

    internal string PrintAll() => string.Join("-", _patients.Select(p => p.LastName));

    internal string PrintX(int amount) => string.Join("-", _patients.Take(amount).Select(p => p.LastName));

    internal string PrintXWithSkip(int amount, int skip) => string.Join("-", _patients.Skip(skip).Take(amount).Select(p => p.LastName));

    internal string PrintPatients(Func<IPatient, bool> value) => string.Join("-", _patients.Where(value).Select(p => p.LastName));

    internal IPatient GetPatientBySocialSecurityNumber(string patientnr1)
    {
        if (string.IsNullOrWhiteSpace(patientnr1))
            throw new ArgumentException("Social security number cannot be empty.");

        var normalizedInput = patientnr1.Replace(".", "").Replace(" ", "").Replace("$", "").ToLower();

        var patient = _patients.FirstOrDefault(p => 
            p.SocialSecurityNumber.Replace(".", "").Replace(" ", "").Replace("$", "").ToLower() == normalizedInput);

        if (patient == null)
            throw new ArgumentException($"Patient with Social Security Number {patientnr1} not found.");
            
        return patient;
    }
}