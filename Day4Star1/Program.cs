using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
	private static void Main(string[] args)
	{
		string[] inputData = File.ReadAllLines("Data.txt");
		int currentSum = 0;

		char[,] matrix = new char[inputData[0].Length, inputData.Length];

		for (int i = 0; i < inputData.Length; i++)
		{
			for (int j = 0; j < inputData[0].Length; j++)
			{
				matrix[i, j] = inputData[i][j];
			}
		}
		string xmas = @"XMAS";
		string samx = @"SAMX";

		currentSum += GetHorizontal(xmas, inputData);
		currentSum += GetHorizontal(samx, inputData);
		currentSum += GetVertical(xmas, matrix);
		currentSum += GetVertical(samx, matrix);
		currentSum += GetDiagonal(xmas, matrix);
		currentSum += GetDiagonal(samx, matrix);
		Console.WriteLine(currentSum);
		
	}
	static int GetDiagonal(string v, char[,] matrix)
	{
		var mainDiagonals = GetMainDiagonals(v, matrix);
		var antiDiagonals = GetAntiDiagonals(v, matrix);
		return mainDiagonals + antiDiagonals;
	}

	static int GetMainDiagonals(string v, char[,] matrix)
	{
		int size = matrix.GetLength(0);
		var sb = new StringBuilder();
		int sum = 0;
		string pattern = v;

		for (int col = 0; col < size; col++)
		{
			for (int i = 0, j = col; i < size && j < size; i++, j++)
			{
				sb.Append(matrix[i, j]);
			}
			string diagonalLine = sb.ToString();
			sum += Regex.Matches(diagonalLine, pattern).Count;
			sb = new StringBuilder();
		}

		for (int row = 1; row < size; row++)
		{
			for (int i = row, j = 0; i < size && j < size; i++, j++)
			{
				sb.Append(matrix[i, j]);
			}
			string diagonalLine = sb.ToString();
			sum += Regex.Matches(diagonalLine, pattern).Count;
			sb = new StringBuilder();
		}

		return sum;
	}

	static int GetAntiDiagonals(string v, char[,] matrix)
	{
		int size = matrix.GetLength(0);
		var sb = new StringBuilder();
		int sum = 0;
		string pattern = v;

		for (int col = 0; col < size; col++)
		{
			var diagonal = new List<char>();
			for (int i = 0, j = col; i < size && j >= 0; i++, j--)
			{
				sb.Append(matrix[i, j]);
			}
			string diagonalLine = sb.ToString();
			sum += Regex.Matches(diagonalLine, pattern).Count;
			sb = new StringBuilder();
		}

		for (int row = 1; row < size; row++)
		{
			for (int i = row, j = size - 1; i < size && j >= 0; i++, j--)
			{
				sb.Append(matrix[i, j]);
			}
			string diagonalLine = sb.ToString();
			sum += Regex.Matches(diagonalLine, pattern).Count;
			sb = new StringBuilder();
		}

		return sum;
	}

	static int GetVertical(string v, char[,] matrix)
	{
		string pattern = v;
		int sum = 0;
		var sb = new StringBuilder();
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				sb.Append(matrix[j, i]);
			}
			string verticalLine = sb.ToString();
			sum += Regex.Matches(verticalLine, pattern).Count;
			sb = new StringBuilder();
		}
		return sum;
	}

	static int GetHorizontal(string v, string[] inputData)
	{
		string pattern = v;
		int sum = 0;

		foreach (string line in inputData)
		{
			var foo = Regex.Matches(line, pattern);
			sum += Regex.Matches(line, pattern).Count;
		}
		return sum;
	}
}