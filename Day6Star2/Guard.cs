using System.Diagnostics;
using System.Drawing;
using Day6Star1;

namespace Day6Star2;

internal class Guard
{
	public Cell CurrentCell { get; set; }
	public Dir FacingDirection { get; private set; }

	public Guard(Cell cell, Dir facingDirection)
	{
		this.CurrentCell = cell;
		FacingDirection = facingDirection;
	}

	internal Point GetNextCellCoords()
	{
		var moveVector = GetMoveVector();
		return new(CurrentCell.Coords.X + moveVector.X, CurrentCell.Coords.Y + moveVector.Y);
	}

	internal void Turn()
	{
		CurrentCell.GuardPositions.Add(FacingDirection);
		FacingDirection = FacingDirection switch
		{
			Dir.Top => Dir.Right,
			Dir.Right => Dir.Bottom,
			Dir.Bottom => Dir.Left,
			Dir.Left => Dir.Top,
			_ => throw new UnreachableException(),
		};
	}

	private Point GetMoveVector()
	{
		return FacingDirection switch
		{
			Dir.Top => new Point(-1, 0),
			Dir.Right => new Point(0, 1),
			Dir.Bottom => new Point(1, 0),
			Dir.Left => new Point(0, -1),
			_ => throw new UnreachableException(),
		};
	}

	internal void GoToNextCell(Cell nextCell)
	{
		CurrentCell.GuardPositions.Add(FacingDirection);
		CurrentCell = nextCell;
	}
}