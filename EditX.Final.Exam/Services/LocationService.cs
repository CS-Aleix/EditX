using EditX.Final.Exam.Interfaces;
using System.Text;

namespace EditX.Final.Exam.Services;

internal class LocationService
{
    internal LocationService()
    { }

    internal static void SwapPatients(Patient patient1, Patient patient2)
    {
        (patient2.Location, patient1.Location) = (patient1.Location, patient2.Location);
    }

    internal static string PrintPatientLocations(Patient patient1, Patient patient2)
    {
        // Eric Clapton is located @Ward2/204/5 AND Elvis Presley is located @Ward1/100/1
        var str = $"{patient1.GetLocation()} AND {patient2.GetLocation()}";
        return str;
    }
}