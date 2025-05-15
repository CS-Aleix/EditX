using EditX.Final.Exam.Models;
namespace EditX.Final.Exam;
using EditX.Final.Exam.Interfaces;

internal class Patient : IPatient {
    public required DateOnly BirthDate { get; set; }
    public required string City { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string SocialSecurityNumber { get; set; }
    public required Location Location { get; set; }

    public string Describe() {
        if (Location.Room == "" || Location.Bed == "") {
            return $"{FirstName} {LastName} needs to be assigned a location in {Location.Ward}";
        } else {
            return $"{FirstName} {LastName} is located @{Location.Ward}/{Location.Room}/{Location.Bed}";
        }
    }
}
