using EditX.Final.Exam.Models;
using EditX.Final.Exam.Models.Warehouse;
using System.Reflection;
using System.Text.Json;

namespace EditX.Final.Exam
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
			using (StreamReader reader = new StreamReader(ReadResourceContentToStream(filename)))
			{
				return reader.ReadToEnd(); //Something is missing here
			}
		}

		internal static object ReadWarehouseInventoryFromJSON(string resourceName)
		{
			throw new NotImplementedException();
		}
	}
}