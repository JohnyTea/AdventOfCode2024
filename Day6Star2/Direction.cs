using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6Star1;
internal class Direction
{
	public Dir currentDirection { get; private set; } = Dir.Left;
    public Direction()
    {
        
    }

    public Direction(Dir startDirection)
    {
		currentDirection = startDirection;
	}
    public (int x, int y) Turn()
	{
		switch (currentDirection)
		{
			default:
				throw new InvalidOperationException();
			case Dir.Right:
				currentDirection = Dir.Bottom;
				return (1, 0);
			case Dir.Bottom:
				currentDirection = Dir.Left;
				return (0, -1);
			case Dir.Left:
				currentDirection = Dir.Top;
				return (-1, 0);
			case Dir.Top:
				currentDirection = Dir.Right;
				return (0, 1);
		}
	}

	public (int x, int y) GetMoveVector()
	{
		switch (currentDirection)
		{
			default:
				throw new InvalidOperationException();
			case Dir.Bottom:
				return (1, 0);
			case Dir.Left:
				return (0, -1);
			case Dir.Top:
				return (-1, 0);
			case Dir.Right:
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