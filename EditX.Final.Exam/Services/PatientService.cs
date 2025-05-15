using EditX.Final.Exam.Interfaces;
using System.Text.RegularExpressions;

namespace EditX.Final.Exam.Services;
internal class PatientService : IPatientService
{
    private List<IPatient> _patients = [];
    public PatientService()
    { }

    internal async Task ImportData()
    {
        var patients = await Utilities.ReadPatientsFromJSON("Patients.json").ConfigureAwait(false);
        if (patients != null)
        {
            _patients = patients.ToList();
        }
        else
        {
            throw new InvalidOperationException("Could not load patients");
        }
    }

    internal string PrintAll() => "Clapton-Presley-Jackson-Mercury-Lennon-Bowie-McCartney-Harrison";

    internal string PrintX(int amount)
    {
        return JoinPatients(_patients.Take(amount).Select(e => e.LastName));
    }

    internal string PrintXWithSkip(int amount, int skip)
    {
        return JoinPatients(_patients.Skip(skip).Take(amount).Select(e => e.LastName));
    }

    internal string PrintPatients(Func<IPatient, bool> value)
    {
        return JoinPatients(_patients.Where(value).Select(e => e.LastName));
    }

    internal IPatient GetPatientBySocialSecurityNumber(string patientnr1)
    {
        string purified = PurifyPatientNr(patientnr1);

        return _patients
            .FirstOrDefault(e => e.SocialSecurityNumber == purified) ??
            throw new InvalidOperationException($"Patient {patientnr1} not found");
    }

    private string PurifyPatientNr(string patientnr1)
    {
        // The patient format nr is XXX.XX.XX.XXX
        string pattern = "(?<e1>[0-9]{3})([^0-9]?)(?<e2>[0-9]{2})([^0-9]?)(?<e3>[0-9]{2})([^0-9]?)(?<e4>[0-9]{3})";

        Match match = Regex.Match(patientnr1, pattern);
        if (match.Success)
        {
            var parts = new[] { "e1", "e2", "e3", "e4" }.Select(e => match.Groups[e]);

            return string.Join(".", parts);
        }

        // just return the number
        return patientnr1;
    }


    private static string JoinPatients(IEnumerable<string> patients)
    {
        return string.Join("-", patients);
    }
}