using EditX.Final.Exam.Models;

namespace EditX.Final.Exam.Interfaces;

public interface IPatient
{
    DateOnly BirthDate { get; set; }
    string City { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string SocialSecurityNumber { get; set; }
    Location Location { get; set; }
}