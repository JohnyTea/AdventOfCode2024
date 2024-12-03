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
	string[] inputDataLineSplitted = inputDataLine.Split(" ");
	if(inputDataLineSplitted.Length < 2)
	{
		throw new UnreachableException();
	}
	else if(inputDataLineSplitted.Length == 2)
	{
		throw new UnreachableException(); // I hope
	}
	else // all raports longer then 2
	{
		bool isSafe = true;
		for (int i = 2; i < inputDataLineSplitted.Length; i++)
		{
			int previousNumber = int.Parse(inputDataLineSplitted[i - 2]);
			int currentNumber = int.Parse(inputDataLineSplitted[i-1]);
			int nextNumber = int.Parse(inputDataLineSplitted[i]);
			bool decreasingOrder = previousNumber < currentNumber && currentNumber < nextNumber;
			bool increasingOrder = previousNumber > currentNumber && currentNumber > nextNumber;
			if (!decreasingOrder && !increasingOrder)
			{
				isSafe = false;
				break;
			}

			int distanceToPreviousNumber = Math.Abs(previousNumber - currentNumber);
			int distanceToNextNumber = Math.Abs(nextNumber - currentNumber);
			if (distanceToPreviousNumber > maxDistance || distanceToNextNumber > maxDistance)
			{
				isSafe = false;
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

