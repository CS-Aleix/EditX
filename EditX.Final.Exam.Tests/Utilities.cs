using EditX.Final.Exam.Models.Warehouse;
using System.Reflection;
using System.Text.Json;

namespace EditX.Final.Exam.Tests
{
    internal static class Utilities
    {
        internal static Stream ReadResourceContentToStream(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"EditX.Final.Exam.Tests.Output.{filename}";
            string expectedOutput = string.Empty;                 

            return assembly.GetManifestResourceStream(resourceName);
        }

        internal static string ReadResourceContentToString(string filename)
        {
            return File.ReadAllText($"./Output/{filename}");
            //return string.Empty; //Something is missing here
        }
    }
}