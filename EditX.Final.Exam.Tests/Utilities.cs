using System.Reflection;

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
            Stream input = ReadResourceContentToStream(filename);
            StreamReader reader = new(input);
            return reader.ReadToEnd();
        }
    }
}