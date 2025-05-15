using EditX.Final.Exam.Interfaces;
using System.Text;

namespace EditX.Final.Exam.Services;

internal class LocationService
{
    internal LocationService()
    { }

    internal static void SwapPatients(IPatient patient1, IPatient patient2)
    {
        var locationPatient1 = patient1.Location;
        patient1.Location = patient2.Location;
        patient2.Location = locationPatient1;
    }

    internal static string PrintPatientLocations(IPatient patient1, IPatient patient2)
    {
        if(string.IsNullOrWhiteSpace(patient2.Location.Room))
        {
          return   $"{patient1.FirstName} {patient1.LastName} is located @{patient1.Location.Ward}/{patient1.Location.Room}/{patient1.Location.Bed} AND {patient2.FirstName} {patient2.LastName} needs to be assigned a location in {patient2.Location.Ward}";
            
        }
        return $"{patient1.FirstName} {patient1.LastName} is located @{patient1.Location.Ward}/{patient1.Location.Room}/{patient1.Location.Bed} AND {patient2.FirstName} {patient2.LastName} is located @{patient2.Location.Ward}/{patient2.Location.Room}/{patient2.Location.Bed}";
    }
}