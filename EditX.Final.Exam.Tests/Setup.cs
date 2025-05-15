using System.Globalization;

namespace EditX.Final.Exam.Tests;

[TestClass]
public class AssemblySetup
{
    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
    }
}