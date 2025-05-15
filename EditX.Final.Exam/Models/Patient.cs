using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Models;

class Patient : IPatient
{
    public DateOnly BirthDate { get; set; }
    public string City { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SocialSecurityNumber { get; set; }
    public Location Location { get; set; }

}