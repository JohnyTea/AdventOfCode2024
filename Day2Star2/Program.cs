using System.Diagnostics;
using Common;

string fileName = "Data.txt";
LineByLineFileReader lineByLineReader = new(fileName);
string? inputDataLine;
int safeReports = 0;
int maxDistance = 3;

inputDataLine = lineByLineReader.GetNextLine();
while (inputDataLine != null)
{
	List<int> inputDataLineSplitted = inputDataLine.Split(" ").Select(x => int.Parse(x)).ToList();
	if (inputDataLineSplitted.Count < 2)
	{
		throw new UnreachableException();
	}
	else if (inputDataLineSplitted.Count == 2)
	{
		throw new UnreachableException(); // I hope
	}
	else 
	{
		bool isSafe = false;
		for (int n = 0; n < inputDataLineSplitted.Count; n++)
		{
			List<int> subset = new List<int>();
			subset.AddRange(inputDataLineSplitted);
			subset.RemoveAt(n);

			bool isSubsetSafe = true;

			for (int i = 2; i < subset.Count; i++)
			{
				int previousNumber = subset.ElementAt(i - 2);
				int currentNumber = subset.ElementAt(i - 1);
				int nextNumber = subset.ElementAt(i);
				bool decreasingOrder = previousNumber < currentNumber && currentNumber < nextNumber;
				bool increasingOrder = previousNumber > currentNumber && currentNumber > nextNumber;
				if (!decreasingOrder && !increasingOrder)
				{
					isSubsetSafe = false;
					break;
				}

				int distanceToPreviousNumber = Math.Abs(previousNumber - currentNumber);
				int distanceToNextNumber = Math.Abs(nextNumber - currentNumber);
				if (distanceToPreviousNumber > maxDistance || distanceToNextNumber > maxDistance)
				{
					isSubsetSafe = false;
					break;
				}
			}
			if (isSubsetSafe)
			{
				isSafe = true;
				break;
			}
		}

	if (isSafe)
	{
		safeReports++;
	}

}

inputDataLine = lineByLineReader.GetNextLine();
}

Console.WriteLine($"Ammount of safe reports: {safeReports}");






/*
 * 58 59 60 58 59 63
 *  59 60 58 59 63
 * 58  60 58 59 63
 * 58 59  58 59 63
 * 58 59 60  59 63
 * 58 59 60 58  63
 * 58 59 60 58 59 
 */