using EditX.Final.Exam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditX.Final.Exam.Models;
public class Patient : IPatient
{
    public DateOnly BirthDate { get; set; }
    public string City { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SocialSecurityNumber { get; set; }
    public Location Location { get; set; }

    public Patient(DateOnly BirthDate, string City, string FirstName, string LastName, string SocialSecurityNumber, Location Location)
    {
        this.BirthDate = BirthDate;
        this.City = City;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.SocialSecurityNumber = SocialSecurityNumber;
        this.Location = Location;
    }
}
