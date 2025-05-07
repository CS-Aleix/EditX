using EditX.Final.Exam.Interfaces;

namespace EditX.Final.Exam.Services;
internal class PatientService : IPatientService
{
    private List<IPatient> _patients = [];
    public PatientService()
    { }
        
    internal void ImportData()
    {
        //Import the embedded resource Patients.json
    }

    internal string PrintAll()
    {
        throw new NotImplementedException();
    }

    internal string PrintX(int amount)
    {
        throw new NotImplementedException();
    }

    internal string PrintXWithSkip(int amount, int skip)
    {
        throw new NotImplementedException();
    }

    internal string PrintPatients(Func<IPatient, bool> value)
    {
        throw new NotImplementedException();
    }

    internal IPatient GetPatientBySocialSecurityNumber(string patientnr1)
    {
        throw new NotImplementedException();
    }
}