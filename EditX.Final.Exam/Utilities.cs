using EditX.Final.Exam.Interfaces;
using EditX.Final.Exam.Models.Warehouse;
using System.Reflection;
using System.Text.Json;

namespace EditX.Final.Exam
{
    internal static class Utilities
    {
        internal static Stream ReadResourceContentToStream(string filename)
        {
            string pathBase = Exam.Utilities.GetResourcesPath(filename);

            return new MemoryStream(File.ReadAllBytes(pathBase));
        }

        internal static async Task<IEnumerable<IPatient>?> ReadPatientsFromJSON(string filename)
        {
            Stream inputJSON = ReadResourceContentToStream(filename);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<Patient>>(inputJSON, options);
        }

        internal static async Task<object> ReadWarehouseInventoryFromJSON(string filename)
        {
            Stream inputJSON = ReadResourceContentToStream(filename);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return await JsonSerializer.DeserializeAsync<object>(inputJSON, options);
        }

        internal static string ConvertWarehouseInventoryToJSON(List<WarehouseNode> list)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(list, options);

            return jsonString;
        }

        internal static string GetResourcesPath(string? subPath = null)
        {
            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var basePath = Path.GetFullPath($"{exeDir}//Resources");

            if (!string.IsNullOrWhiteSpace(subPath))
            {
                basePath = Path.Combine(basePath, subPath);
            }

            return basePath;
        }

    }
}