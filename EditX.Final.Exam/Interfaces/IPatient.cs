using EditX.Final.Exam.Models;

namespace EditX.Final.Exam.Interfaces;

internal interface IPatient
{
    DateOnly BirthDate { get; set; }
    string City { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string SocialSecurityNumber { get; set; }
    Location Location { get; set; }
}

class Patient : IPatient
{
    public DateOnly BirthDate { get; set; }
    public string City { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SocialSecurityNumber { get; set; }
    public Location Location { get; set; }
}