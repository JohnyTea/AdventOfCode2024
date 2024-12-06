using System.Drawing;
using Day6Star1;

namespace Day6Star2;

internal class Cell
{
	public  Point Coords { get; init; }
	public bool IsObstacle { get; set; }
	public bool IsPossibleLoopObstacle { get; set; }
	public List<Dir> GuardPositions { get; internal set; } = new();
	public bool GuardWasHere => GuardPositions.Count > 0;

	public Cell(int i, int j, bool isObstacle)
	{
		Coords = new Point(i, j);
		this.IsObstacle = isObstacle;
	}

	public override bool Equals(object? obj)
	{
		return obj is Cell cell &&
			   Coords.Equals(cell.Coords);
	}
}