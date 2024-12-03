using Common;

string? inputFilePath = "LocationIds.txt";
var tuple = GetInputLists(inputFilePath);

SortedNumberList firstList = tuple.Item1;
SortedNumberList secondList = tuple.Item2;

int interations = firstList.Numbers.Count();
long similarityScore = 0;

foreach (var number in firstList.Numbers)
{
	similarityScore += number * secondList.Numbers.Count(x => x == number);
}

Console.WriteLine(similarityScore);

static (SortedNumberList, SortedNumberList) GetInputLists(string inputFilePath)
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