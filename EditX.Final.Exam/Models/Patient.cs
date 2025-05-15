using EditX.Final.Exam.Interfaces;

namespace EditX.Final.Exam.Models;
internal class Patient : IPatient
{
    public required DateOnly BirthDate { get; set; }
    public required string City { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string SocialSecurityNumber { get; set; }
    public required Location Location { get; set; }
}
