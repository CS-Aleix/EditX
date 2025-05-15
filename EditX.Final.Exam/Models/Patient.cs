using EditX.Final.Exam.Interfaces;

namespace EditX.Final.Exam.Models;

internal class Patient : IPatient
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public string City { get; set; } = string.Empty;
    public string SocialSecurityNumber { get; set; } = string.Empty;
    public Location Location { get; set; }

    public Patient() { }

    public Patient(string firstName, string lastName, DateOnly birthDate, string city, string socialSecurityNumber, Location location)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        City = city;
        SocialSecurityNumber = socialSecurityNumber;
        Location = location;
    }
}