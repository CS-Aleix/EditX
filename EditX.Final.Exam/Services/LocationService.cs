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
        Location location1 = patient1.Location;
        Location location2 = patient2.Location;

        patient1.Location = location2;
        patient2.Location = location1;
    }

    internal static string PrintPatientLocations(IPatient patient1, IPatient patient2)
    {
        return $"{patient1.FirstName} {patient1.LastName} is located @{patient1.Location.Ward}{'/' + patient1.Location.Room ?? null}{'/' + patient1.Location.Bed ?? null} AND {patient2.FirstName} {patient2.LastName} is located @{patient2.Location.Ward}{(patient2.Location.Room != String.Empty ? '/' + patient2.Location.Room : String.Empty)}{(patient2.Location.Room != String.Empty ? '/' + patient2.Location.Bed : String.Empty)}\r\n";
    }
}