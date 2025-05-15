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
        var location1 = patient1.Location;
        var location2 = patient2.Location;

        patient1.Location = location2;
        patient2.Location = location1;
    }

    internal static string PrintPatientLocations(IPatient patient1, IPatient patient2)
    {
        return $"{PatientLocationString(patient1)} AND {PatientLocationString(patient2)}";
    }

    private static string PatientLocationString(IPatient patient)
    {
        if (patient.Location.Room == null || patient.Location.Room == string.Empty)
        {
            return $"{patient.FirstName} {patient.LastName} needs to be assigned a location in {patient.Location.Ward}";
        }
        else
        {
            return $"{patient.FirstName} {patient.LastName} is located @{patient.Location}";
        }
    }
}