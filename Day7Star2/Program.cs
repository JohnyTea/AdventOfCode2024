string[] inputData = File.ReadAllLines("Data.txt");
double currentSum = 0;

List<List<long>> lines = [];

foreach (string line in inputData)
{
	int colonIndex = line.IndexOf(':');
	long equasitionResult = long.Parse(line.Substring(0, colonIndex));
	List<long> numbers = line[(colonIndex + 2)..].Split(" ").Select(long.Parse).ToList();
	var combinedList = new List<long> { equasitionResult };
	combinedList.AddRange(numbers);
	lines.Add(combinedList);
}

foreach (var line in lines)
{
	currentSum += TrySolve(line);
}

Console.WriteLine(currentSum);

double TrySolve(List<long> numbers)
{
	double result = numbers[0];

	long symbolsNumber = 0;
	int bits = numbers.Count - 1;

	do
	{
		long currentResult = 0;
		string binaryString = ConvertToAnySystem(symbolsNumber, 3).PadLeft(bits, '0');

		for (int i = 1; i < numbers.Count; i++)
		{
			if (binaryString[i - 1] == '0')
			{
				currentResult += numbers[i];
			}
			else if (binaryString[i - 1] == '1')
			{
				currentResult *= numbers[i];
			}
			else
			{
				currentResult = long.Parse($"{currentResult}{numbers[i]}");
			}
		}

		if (currentResult == result)
		{
			return result;
		}
		symbolsNumber++;

	} while (symbolsNumber < Math.Pow(3, bits));

	return 0;
}

string ConvertToAnySystem(long number, long baseSystem)
{
	List<long> ternaryDigits = new List<long>();

	if (number == 0)
	{
		return "0";
	}

	// Perform the conversion
	while (number > 0)
	{
		long remainder = number % baseSystem;
		ternaryDigits.Add(remainder); // Store the remainder
		number /= baseSystem; // Reduce the number
	}
	ternaryDigits.Reverse();
	return string.Join("", ternaryDigits);

}
