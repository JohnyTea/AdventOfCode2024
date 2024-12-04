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

for (int i = 1; i < matrix.GetLength(0) - 1; i++)
{
	for(int j = 1;j < matrix.GetLength(1) - 1; j++)
	{
		if (matrix[i, j] != 'A')
		{
			continue;
		}

		char topLeft = matrix[i - 1, j - 1];
		char bottomRight = matrix[i + 1, j + 1];
		char topRight = matrix[i + 1, j - 1];
		char bottomLeft = matrix[i - 1, j + 1];

		bool TLBR = (topLeft == 'M' && bottomRight == 'S') || (topLeft == 'S' && bottomRight == 'M');
		bool TRBL = (topRight == 'M' && bottomLeft == 'S') || (topRight == 'S' && bottomLeft == 'M');


		if (TLBR && TRBL)
		{
			currentSum++;
		}
	}
}

Console.WriteLine(currentSum);