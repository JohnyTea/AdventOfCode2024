string[] inputData = File.ReadAllLines("Data.txt");
double currentSum = 0;

List<List<double>> lines = [];

foreach (string line in inputData)
{
	int colonIndex = line.IndexOf(':');
	double equasitionResult = double.Parse(line.Substring(0, colonIndex));
	List<double> numbers = line[(colonIndex + 2)..].Split(" ").Select(double.Parse).ToList();
	var combinedList = new List<double> { equasitionResult };
	combinedList.AddRange(numbers);
	lines.Add(combinedList);
}

foreach (var line in lines)
{
	currentSum += TrySolve(line);
}

Console.WriteLine(currentSum);

double TrySolve(List<double> numbers)
{
	double result = numbers[0];

	int symbolsNumber = 0;
	int bits = numbers.Count - 1;

	do
	{
		double currentResult = 0;
		string binaryString = Convert.ToString(symbolsNumber, 2).PadLeft(bits, '0');

		for(int i = 1; i < numbers.Count; i++)
		{
			if (binaryString[i - 1]=='0')
			{
				currentResult += numbers[i];
			}
			else
			{
				currentResult *= numbers[i];
			}
		}

		if (currentResult == result)
		{
			return result;
		}
		symbolsNumber++;

	} while (symbolsNumber<Math.Pow(2, bits));

	return 0;
}
