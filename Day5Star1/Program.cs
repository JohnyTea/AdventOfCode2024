string[] inputData = File.ReadAllLines("Data.txt");
List<string> firstSection = new List<string>();
List<string> secondSection = new List<string>();

int result = 0;

foreach (string line in inputData)
{
	if(line == string.Empty)
	{
		break;
	}
	firstSection.Add(line);
}

for (int i = firstSection.Count + 1; i < inputData.Length; i++)
{
	secondSection.Add(inputData[i]);
}
Dictionary<int, List<int>> rules = new Dictionary<int, List<int>>();

foreach (string line in firstSection)
{
	string[] lineSplit = line.Split("|"); 
	int key = int.Parse(lineSplit[0]);
	int newValue = int.Parse(lineSplit[1]);

	if (rules.TryGetValue(key, out var value))
	{
		value.Add(newValue);
	}
	else
	{
		rules.Add(key, [newValue]);
	}
}

foreach (string line in secondSection)
{
	string[] update = line.Split(",");
	int[] updateNumbers = update.Select(x => int.Parse(x)).ToArray();
	bool isCorrectUpdate = true;
	for (int i = 0; i < updateNumbers.Length; i++)
	{
		int currentNumber = updateNumbers[i];
		List<int> currentNumberRules = rules[currentNumber];

		foreach (int number in updateNumbers.Take(i))
		{
			if (currentNumberRules.Contains(number))
			{
				isCorrectUpdate = false;
			}
		}
	}

	if (updateNumbers.Length % 2 == 0)
	{
		Console.WriteLine("no middle number");
	}
	if (isCorrectUpdate)
	{
		result += updateNumbers[updateNumbers.Length / 2];

	}
}

Console.WriteLine(result);
