namespace Common
{
	public class FileReader
	{
		public static string? ReadTxtFile(string filePath)
		{
			string content = File.ReadAllText(filePath);
			return content;
		}
	}
}