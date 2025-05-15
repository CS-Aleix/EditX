namespace EditX.Final.Exam.Interfaces;

internal interface IPatientService
{
    internal IPatient? GetPatientBySocialSecurityNumber(string ssn);
}