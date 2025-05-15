using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Models;
using System.Text;

namespace EditX.Final.Exam.Services;

internal class LocationService
{
    internal LocationService()
    { }

    /// <summary>
    /// Swap patient location
    /// </summary>
    /// <param name="patient1"></param>
    /// <param name="patient2"></param>
    internal static void SwapPatients(IPatient patient1, IPatient patient2)
    {
        var location1 = patient1.Location;

        patient1.Location = patient2.Location;

        patient2.Location = location1;
    }

    internal static string PrintPatientLocations(IPatient patient1, IPatient patient2)
    {
        return string.Join(" AND ", new[] { patient1, patient2 }.Select(PrintPatientLocation));
    }
    
    private static string PrintPatientLocation(IPatient patient)
    {
        if (string.IsNullOrWhiteSpace(patient.Location.Room) || string.IsNullOrWhiteSpace(patient.Location.Bed))
        {
            // return Paul McCartney needs to be assigned a location in Ward7
            return $"{patient.FirstName} {patient.LastName} needs to be assigned a location in {patient.Location.Ward}";
        }

        return $"{patient.FirstName} {patient.LastName} is located @{patient.Location.Ward}/{patient.Location.Room}/{patient.Location.Bed}";
    }
}