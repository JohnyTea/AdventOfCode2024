using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6Star1;
internal class Direction
{
	public Dir currentDirection { get; private set; } = Dir.Left;
	public Dir nextDirection { get; private set; } = Dir.Top;
	public (int x, int y) Turn()
	{
		switch (currentDirection)
		{
			default:
				throw new InvalidOperationException();
			case Dir.Right:
				currentDirection = Dir.Bottom;
				nextDirection = Dir.Left;
				return (1, 0);
			case Dir.Bottom:
				currentDirection = Dir.Left;
				nextDirection = Dir.Top;
				return (0, -1);
			case Dir.Left:
				currentDirection = Dir.Top;
				nextDirection = Dir.Right;
				return (-1, 0);
			case Dir.Top:
				currentDirection = Dir.Right;
				nextDirection = Dir.Bottom;
				return (0, 1);
		}
	}
}

internal enum Dir
{
	Top = 'T',
	Right = 'R', 
	Bottom = 'B', 
	Left = 'L'
}