using Day6Star1;

string[] inputData = File.ReadAllLines("Data.txt");
int currentSum = 0;

char[,] matrix = new char[inputData[0].Length, inputData.Length];

(int x, int y) = Tuple.Create(0,0);

for (int i = 0; i < inputData.Length; i++)
{
	for (int j = 0; j < inputData[0].Length; j++)
	{
		matrix[i, j] = inputData[i][j];
		if(matrix[i, j] == '^')
		{
			x = i;
			y = j;
		}
	}
}

Direction currentDirection = new();
var nextMoveVector = currentDirection.Turn();
while (true)
{
	Tuple<int,int> nextSpaceCoords = Tuple.Create(x + nextMoveVector.x, y + nextMoveVector.y);
	if (nextSpaceCoords.Item1 < 0 || nextSpaceCoords.Item2 < 0 || nextSpaceCoords.Item1 >= matrix.GetLength(0) || nextSpaceCoords.Item2 >= matrix.GetLength(1))
	{
		matrix[x, y] = 'X';
		break;
	}

	if (matrix[nextSpaceCoords.Item1, nextSpaceCoords.Item2] == '#')
	{
		nextMoveVector = currentDirection.Turn();
	}
	else
	{
		matrix[x, y] = 'X';
		x = nextSpaceCoords.Item1;
		y = nextSpaceCoords.Item2;
	}

}

for (int i = 0; i < inputData.Length; i++)
{
	for (int j = 0; j < inputData[0].Length; j++)
	{
		if (matrix[i, j] == 'X')
		{
			currentSum++;
		}
	}

}

for (int i = 0; i < inputData.Length; i++)
{
	for (int j = 0; j < inputData[0].Length; j++)
	{
		if (matrix[i, j] == 'X')
		{
			Console.BackgroundColor = ConsoleColor.Green;
		}
		else if (i == x && j == y)
		{
			Console.BackgroundColor = ConsoleColor.Red;
		}
		else
		{
			Console.BackgroundColor = ConsoleColor.Black;
		}
		Console.Write(matrix[i, j]);

	}
	Console.WriteLine();
}

Console.WriteLine(currentSum);