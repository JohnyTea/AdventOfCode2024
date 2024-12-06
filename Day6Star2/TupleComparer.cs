
internal class TupleComparer : IEqualityComparer<Tuple<int, int>>
{
	public bool Equals(Tuple<int, int> x, Tuple<int, int> y)
	{
		if (x == null || y == null)
			return false;
		return x.Item1 == y.Item1 && x.Item2 == y.Item2;
	}

	public int GetHashCode(Tuple<int, int> obj)
	{
		if (obj == null)
			return 0;

		return HashCode.Combine(obj.Item1, obj.Item2);
	}
}