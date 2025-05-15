using EditX.Final.Exam.Interfaces;

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
        return $"{PrintPatientLocation(patient1)} AND {PrintPatientLocation(patient2)}";
    }

    internal static string PrintPatientLocation(IPatient patient)
    {
        if (string.IsNullOrEmpty(patient.Location.Room) || string.IsNullOrEmpty(patient.Location.Bed))
        {
            return $"{patient.FirstName} {patient.LastName} needs to be assigned a location in {patient.Location.Ward}";
        }
        return $"{patient.FirstName} {patient.LastName} is located @{patient.Location.ToFormattedString()}";
    }
}