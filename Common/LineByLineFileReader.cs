namespace Common;

public class LineByLineFileReader
{
	private readonly StreamReader reader;
	private bool isDisposed = false;

	// Constructor to initialize the StreamReader with the file path
	public LineByLineFileReader(string filePath)
	{
		if (!File.Exists(filePath))
		{
			throw new FileNotFoundException($"Error: The file '{filePath}' does not exist.");
		}

		reader = new StreamReader(filePath);
	}

	// Method to get the next line from the file
	public string? GetNextLine()
	{
		if (isDisposed)
		{
			ObjectDisposedException.ThrowIf(isDisposed, this);
		}

		return reader.ReadLine();  // Returns null if end of file is reached
	}

	// Method to close the reader and release resources
	public void Close()
	{
		if (!isDisposed)
		{
			reader.Close();
			isDisposed = true;
		}
	}
}