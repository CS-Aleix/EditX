using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Models;
using System.Text;

namespace EditX.Final.Exam.Services;

internal class LocationService
{
    internal LocationService()
    { }

    internal static void SwapPatients(IPatient patient1, IPatient patient2)
    {
        if (patient1 == null
        || patient2 == null)
        {
            return;
        }
        (patient1.Location, patient2.Location) = (patient2.Location, patient1.Location);
    }

    internal static string PrintPatientLocation(IPatient patient)
    {
        if (patient == null)
        {
            return string.Empty;
        }
        // print location of a single patient
        var location = string.IsNullOrWhiteSpace(patient.Location.Room) || string.IsNullOrWhiteSpace(patient.Location.Bed)
       ? $"needs to be assigned a location in {patient.Location.Ward}"
       : $"is located @{patient.Location.Ward}/{patient.Location.Room}/{patient.Location.Bed}";

        return $"{patient.FirstName} {patient.LastName} {location}";
    }

    internal static string PrintPatientLocations(IPatient patient1, IPatient patient2)
    {
        var patient1Location = PrintPatientLocation(patient1);
        var patient2Location = PrintPatientLocation(patient2);
        // print locations of both patients
        return $"{patient1Location} AND {patient2Location}";

    }
}