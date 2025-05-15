using EditX.Final.Exam.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditX.Final.Exam.Models;
internal class Patient : IPatient
{
    public DateOnly BirthDate { get; set; }
    public string City{ get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SocialSecurityNumber{ get; set; }
    public Location Location { get; set; }
}
