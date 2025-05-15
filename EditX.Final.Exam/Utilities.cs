using EditX.Final.Exam.Models;
using EditX.Final.Exam.Models.Warehouse;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace EditX.Final.Exam
{
    internal static class Utilities
    {
        internal static Stream ReadResourceContentToStream(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"EditX.Final.Exam.Resources.{filename}";
            var stream = assembly.GetManifestResourceStream(resourceName);
            
            if (stream == null)
                throw new FileNotFoundException($"Resource {resourceName} not found.");
                
            if (stream.Length == 0)
                throw new InvalidOperationException($"Resource {resourceName} is empty.");

            return stream;
        }

        internal static async Task<IEnumerable<Patient>> ReadPatientsFromJSON(string filename)
        {
            try
            {
                using var inputJSON = ReadResourceContentToStream(filename);
                using var reader = new StreamReader(inputJSON);
                var jsonContent = await reader.ReadToEndAsync();

                if (string.IsNullOrWhiteSpace(jsonContent))
                    throw new InvalidOperationException("JSON content is empty.");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return await JsonSerializer.DeserializeAsync<IEnumerable<Patient>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(jsonContent)), 
                    options) ?? throw new JsonException("Failed to deserialize patients data.");
            }
            catch (JsonException ex)
            {
                throw new JsonException($"Error parsing patients JSON: {ex.Message}", ex);
            }
        }

        internal static async Task<List<WarehouseNode>> ReadWarehouseInventoryFromJSON(string filename)
        {
            try
            {
                using var inputJSON = ReadResourceContentToStream(filename);
                using var reader = new StreamReader(inputJSON);
                var jsonContent = await reader.ReadToEndAsync();

                if (string.IsNullOrWhiteSpace(jsonContent))
                    throw new InvalidOperationException("JSON content is empty.");

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };

                return await JsonSerializer.DeserializeAsync<List<WarehouseNode>>(
                    new MemoryStream(Encoding.UTF8.GetBytes(jsonContent)), 
                    options) ?? throw new JsonException("Failed to deserialize warehouse inventory data.");
            }
            catch (JsonException ex)
            {
                throw new JsonException($"Error parsing warehouse inventory JSON: {ex.Message}", ex);
            }
        }

        internal static string ConvertWarehouseInventoryToJSON(List<WarehouseNode> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return JsonSerializer.Serialize(list, options);
        }
    }
}