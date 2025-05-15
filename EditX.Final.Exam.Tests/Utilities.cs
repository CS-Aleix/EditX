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
            string pathBase = GetResourcesPath(filename);

            return File.ReadAllText(pathBase);
        }

        internal static string GetResourcesPath(string? subPath = null)
        {
            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var basePath = Path.GetFullPath($"{exeDir}//Output");

            if (!string.IsNullOrWhiteSpace(subPath))
            {
                basePath = Path.Combine(basePath, subPath);
            }

            return basePath;
        }


    }
}