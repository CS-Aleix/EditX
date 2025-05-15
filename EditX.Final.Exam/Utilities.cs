using EditX.Final.Exam.Models;
using EditX.Final.Exam.Models.Warehouse;
using System.Drawing;
using System.Reflection;
using System.Text.Json;

namespace EditX.Final.Exam
{
    internal static class Utilities
    {
        internal static Stream ReadResourceContentToStream(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"EditX.Final.Exam.Resources.{filename}";
            string expectedOutput = string.Empty;

            return assembly.GetManifestResourceStream(resourceName);
        }

        internal static async Task<List<Patient>?> ReadPatientsFromJSON(string filename)
        {
            Stream inputJSON = ReadResourceContentToStream(filename);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return await JsonSerializer.DeserializeAsync<List<Patient>>(inputJSON, options);
        }

        internal static async Task<List<WarehouseNode>> ReadWarehouseInventoryFromJSON(string filename)
        {
            Stream inputJSON = ReadResourceContentToStream(filename);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return await JsonSerializer.DeserializeAsync<List<WarehouseNode>>(inputJSON, options);
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

        internal static string KeepOnlyDigits(string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }

        internal static double GetDistance(Point p1, Point p2)
        {
            return Math.Round(Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2)), 1);
        }
    }
}