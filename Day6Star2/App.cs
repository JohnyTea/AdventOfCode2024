using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day6Star1;

namespace Day6Star2;
internal class App
{
	private string[] inputData;
	private Cell[,] mainMap;
	private Guard mainGuard;
	private Cell mainGuardStartingCell;

	public App(string[] inputData)
	{
		this.inputData = inputData;

	}

	internal void Start()
	{
		mainMap = CreateMap(inputData);
		mainGuard = new Guard(GuardLocation(inputData), Dir.Top);
		MainSimulation();
		int countOfCellsWhereGuardCanLoop = 0;
		for (int i = 0; i < mainMap.GetLength(0); i++)
		{
			for (int j = 0; j < mainMap.GetLength(1); j++)
			{
				if (mainMap[i, j].IsPossibleLoopObstacle)
				{
					countOfCellsWhereGuardCanLoop++;
				}
			}
		}
		Console.WriteLine(countOfCellsWhereGuardCanLoop);
	}

	private Cell GuardLocation(string[] inputData)
	{
		for (int i = 0; i < inputData.Length; i++)
		{
			for (int j = 0; j < inputData[i].Length; j++)
			{
				if (inputData[i][j] == '^')
				{
					Cell cellWithGuard = mainMap[i,j];
					mainGuardStartingCell = cellWithGuard;
					cellWithGuard.GuardPositions.Add(Dir.Top);
					return cellWithGuard;
				}
			}
		}
		throw new ArgumentException();
	}

	private Cell[,] CreateMap(string[] inputData)
	{
		Cell[,] map = new Cell[inputData[0].Length, inputData.Length];
		for (int i = 0; i < inputData.Length; i++)
		{
			for (int j = 0; j < inputData[i].Length; j++)
			{
				bool isObstacle = inputData[i][j] == '#';
				map[i, j] = new(i, j, isObstacle);
			}
		}
		return map;
	}

	private void MainSimulation()
	{
		int count = 0;
		do
		{
			count++;
			Point nextCellCoords = mainGuard.GetNextCellCoords();
			if (!IsInsideMainMap(nextCellCoords))
			{
				return;
			}

			Cell nextCell = mainMap[nextCellCoords.X, nextCellCoords.Y];
			if (nextCell.IsObstacle)
			{
				mainGuard.Turn();
				continue;
			}

			nextCell.IsPossibleLoopObstacle = TryLoopGuard(nextCell);

			mainGuard.GoToNextCell(nextCell);

			
		} while (true);
	}

	private bool TryLoopGuard(Cell nextMainGuardCell)
	{
		if (nextMainGuardCell.Equals(mainGuardStartingCell))
		{
			return false;
		}
		Cell[,] cloneMap = CreateMap(inputData);
		cloneMap[nextMainGuardCell.Coords.X, nextMainGuardCell.Coords.Y].IsObstacle = true;

		Guard cloneGuard = new(cloneMap[mainGuard.CurrentCell.Coords.X, mainGuard.CurrentCell.Coords.Y], mainGuard.FacingDirection);

		int count = 0;
		do
		{
			count++;
			Point nextCellCoords = cloneGuard.GetNextCellCoords();
			if (!IsInsideMainMap(nextCellCoords))
			{
				return false;
			}

			Cell nextCell = cloneMap[nextCellCoords.X, nextCellCoords.Y];
			if (nextCell.GuardPositions.Any(x=> x == cloneGuard.FacingDirection))
			{
				return true;
			}
			if (nextCell.IsObstacle)
			{
				cloneGuard.Turn();
				continue;
			}

			cloneGuard.GoToNextCell(nextCell);

			if(count < 3 || count % 20 == 0)
			{
				var foo = 0;
			}
		} while (true);

	}

	private void PrintMap(Cell[,] cloneMap)
	{
		Console.Clear();
		for (int i = 0; i < cloneMap.GetLength(0); i++)
		{ 
			for(int j = 0; j < cloneMap.GetLength(1); j++)
			{
				Cell currentCell = cloneMap[i, j];
				if (currentCell.IsObstacle)
				{
					Console.Write("#");
				}
				else if (currentCell.GuardWasHere)
				{
					Console.BackgroundColor = ConsoleColor.Green;
					Console.Write("X");
					Console.BackgroundColor = ConsoleColor.Black;
				}
				else
				{
					Console.Write(".");
				}
			}
			Console.Write("\n");

		}
		Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");

	}

	internal bool IsInsideMainMap(Point point)
	{
		if (point.X < 0 || point.Y < 0 || point.X >= mainMap.GetLength(0) || point.Y >= mainMap.GetLength(1))
		{
			return false;
		}
		return true;
	}
}
