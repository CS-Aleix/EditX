using EditX.Final.Exam.Interfaces;
using System.Text;

namespace EditX.Final.Exam.Services;

internal class LocationService
{
    internal LocationService()
    { }

    internal static void SwapPatients(IPatient patient1, IPatient patient2)
    {
        var tmp = patient1.Location;
        patient1.Location = patient2.Location;
        patient2.Location = tmp;
    }

    internal static string PrintPatientLocations(IPatient patient1, IPatient patient2)
    {
        return $"{patient1.Describe()} AND {patient2.Describe()}";
    }
}