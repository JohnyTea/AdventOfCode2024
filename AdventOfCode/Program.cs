using Common;

namespace AdventOfCodeDay1Star1;

internal class Program
{
	static void Main(string[] args)
	{
		string? inputFilePath = "LocationIds.txt";
		var tuple = GetInputLists(inputFilePath);

		List<int> foo;

		SortedNumberList firstList = tuple.Item1;
		SortedNumberList secondList = tuple.Item2;

		int interations = firstList.Numbers.Count();
		long currentDistance = 0;

		for (int i = 0; i < interations; i++)
		{
			currentDistance += Math.Abs(firstList.Numbers.ElementAt(i) - secondList.Numbers.ElementAt(i));
		}
		
		Console.WriteLine(currentDistance);

	}

	private static (SortedNumberList, SortedNumberList) GetInputLists(string inputFilePath)
	{
		SortedNumberList firstList = new();
		SortedNumberList secondList = new();

		try
		{
			var fileReader = new LineByLineFileReader(inputFilePath);

			string line;
			while ((line = fileReader.GetNextLine()) != null)
			{
				
				var spliitedRow = line.Split("   ");
				firstList.AddNumber(int.Parse(spliitedRow[0]));
				secondList.AddNumber(int.Parse(spliitedRow[1]));
			}

			fileReader.Close();  // Ensure the reader is closed when done
		}
		catch (Exception ex)
		{
			Console.WriteLine($"An error occurred: {ex.Message}");
			throw;
		}

		return (firstList, secondList);
	}
}
