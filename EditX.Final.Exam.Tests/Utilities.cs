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
            return assembly.GetManifestResourceStream(resourceName);
        }

        internal static string ReadResourceContentToString(string filename)
        {
  
            using var reader = new StreamReader(ReadResourceContentToStream(filename));
            var content = reader.ReadToEnd();
            
          return content;
        }
    }
}