using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Models;
using System;
using System.Text.RegularExpressions;

namespace EditX.Final.Exam.Services;
internal class PatientService : IPatientService
{
    private List<IPatient> _patients = [];
    public PatientService()
    { }
        
    internal async Task ImportData()
    {
        IEnumerable<IPatient>? patients = await Utilities.ReadPatientsFromJSON("Patients.json");
        if (patients != null)
        {
            _patients = patients.Select(d => new Patient
            {
                BirthDate = d.BirthDate,
                City = d.City,
                FirstName = d.FirstName,
                LastName = d.LastName,
                SocialSecurityNumber = d.SocialSecurityNumber,
                Location = new Location
                {
                    Id = d.Location.Id,
                    Ward = d.Location.Ward,
                    Room = d.Location.Room,
                    Bed = d.Location.Bed
                }
            }).ToList<IPatient>();
        }
    }

    internal string PrintAll()
    {
        return _patients.Select(p => p.LastName)
            .Aggregate((current, next) => $"{current}-{next}");
    }

    internal string PrintX(int amount)
    {
        return _patients.Take(amount).Select(p => p.LastName)
            .Aggregate((current, next) => $"{current}-{next}");
    }

    internal string PrintXWithSkip(int amount, int skip)
    {
        return _patients.Skip(skip).Take(amount).Select(p => p.LastName)
            .Aggregate((current, next) => $"{current}-{next}");
    }

    internal string PrintPatients(Func<IPatient, bool> value)
    {
        IEnumerable<string> filtered = _patients.Where(value).Select(p => p.LastName);
        return filtered.Any() ? filtered.Aggregate((current, next) => $"{current}-{next}") : string.Empty;
    }

    internal IPatient GetPatientBySocialSecurityNumber(string patientnr1)
    {
        string correctPatientNr = ConvertToCorrectPatientNr(patientnr1);
        return _patients.FirstOrDefault(p => p.SocialSecurityNumber == correctPatientNr);
    }

    private string ConvertToCorrectPatientNr(string patientnr)
    {
        if (patientnr.Contains("$"))
        {
            string correctPatientNr = patientnr.Replace("$", ".");
            return correctPatientNr;
        }

        if (Regex.IsMatch(patientnr, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"))
        {
            return patientnr;
        }

        string digits = new string(patientnr.Where(char.IsDigit).ToArray());

        return
            $"{digits[0]}{digits[1]}{digits[2]}.{digits[3]}{digits[4]}.{digits[5]}{digits[6]}.{digits[7]}{digits[8]}{digits[9]}";
        
    }
}