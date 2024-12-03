using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common;
public class SortedNumberList
{
	private readonly List<int> numbers = [];
	public IEnumerable<int> Numbers => numbers;

    // Method to add a number in increasing order
    public void AddNumber(int newNumber)
	{
		// Find the correct position to insert the new number
		int index = numbers.BinarySearch(newNumber);

		if (index < 0)  // BinarySearch returns negative if the item is not found
		{
			index = ~index;  // This gives the correct insertion point
		}

		numbers.Insert(index, newNumber);  // Insert the number at the correct position
	}

}
