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
        var temp = new Patient
        {
            BirthDate = patient1.BirthDate,
            City = patient1.City,
            FirstName = patient1.FirstName,
            LastName = patient1.LastName,
            SocialSecurityNumber = patient1.SocialSecurityNumber,
            Location = new Location
            {
                Id = patient1.Location.Id, Ward = patient1.Location.Ward, Room = patient1.Location.Room, Bed = patient1.Location.Bed
            }
        };

        patient1.Location = patient2.Location;
        patient2.Location = temp.Location;
    }

    internal static string PrintPatientLocations(IPatient patient1, IPatient patient2)
    {
        if (patient2.Location.Room == string.Empty)
        {
            return
                $"{patient1.FirstName} {patient1.LastName} is located @{patient1.Location.Ward}/{patient1.Location.Room}/{patient1.Location.Bed} AND {patient2.FirstName} {patient2.LastName} needs to be assigned a location in {patient2.Location.Ward}";
        }

        return
            $"{patient1.FirstName} {patient1.LastName} is located @{patient1.Location.Ward}/{patient1.Location.Room}/{patient1.Location.Bed} AND {patient2.FirstName} {patient2.LastName} is located @{patient2.Location.Ward}/{patient2.Location.Room}/{patient2.Location.Bed}";
    }
}