using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Models;

namespace EditX.Final.Exam.Services;

internal class LocationService
{
    public static void SwapPatients(IPatient patient1, IPatient patient2)
    {
        if (patient1 == null || patient2 == null)
            throw new ArgumentNullException("Patients cannot be null");

        var tempLocation = patient1.Location;
        patient1.Location = patient2.Location;
        patient2.Location = tempLocation;
    }

    public static string PrintPatientLocations(IPatient patient1, IPatient patient2)
    {
        if (patient1 == null || patient2 == null)
            throw new ArgumentNullException("Patients cannot be null");

        string FormatLocation(IPatient p) =>
            string.IsNullOrWhiteSpace(p.Location.Room) || string.IsNullOrWhiteSpace(p.Location.Bed)
                ? $"{p.FirstName} {p.LastName} needs to be assigned a location in {p.Location.Ward}"
                : $"{p.FirstName} {p.LastName} is located @{p.Location.Ward}/{p.Location.Room}/{p.Location.Bed}";

        return $"{FormatLocation(patient1)} AND {FormatLocation(patient2)}";
    }
}