using System.Text.RegularExpressions;

string filePath = "Data.txt";
string inputData = File.ReadAllText(filePath);
string regexPattern = @"\bdo\(\)|\bdon't\(\)|mul\((\d{1,3}),(\d{1,3})\)";

var matches = Regex.Matches(inputData, regexPattern);
long sum = 0;
bool turnedOn = true;
foreach (Match match in matches)
{
	if(match.Value == "do()")
	{
		turnedOn = true;
		continue;
	}
	else if (match.Value == "don't()")
	{
		turnedOn = false;
		continue;
	}

	if (turnedOn)
	{
		int firstNumber = int.Parse(match.Groups[1].Value);
		int secondNumber = int.Parse(match.Groups[2].Value);
		sum += firstNumber * secondNumber;
	}
}
Console.WriteLine(sum);