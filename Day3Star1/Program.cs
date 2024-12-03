using System.Text.RegularExpressions;

string filePath = "Data.txt";
string inputData = File.ReadAllText(filePath);
string regexPattern = @"mul\((\d{1,3}),(\d{1,3})\)";

var matches = Regex.Matches(inputData, regexPattern);
long sum = 0;
foreach (Match match in matches)
{
	int firstNumber = int.Parse(match.Groups[1].Value);
	int secondNumber = int.Parse(match.Groups[2].Value);
	sum += firstNumber * secondNumber;

}
Console.WriteLine(sum);