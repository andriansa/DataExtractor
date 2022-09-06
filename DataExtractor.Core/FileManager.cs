// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileManager.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the FileManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;

using CsvHelper;

namespace DataExtractor.Core;

public sealed class FileManager : IFileManager
{
	public StreamReader StreamReader(string filePath)
	{
		return new StreamReader(filePath);
	}

	public StreamWriter StreamWriter(string filePath)
	{
		return new StreamWriter(filePath);
	}

	public CsvReader CsvReader(StreamReader streamReader, CultureInfo cultureInfo)
	{
		return new CsvReader(streamReader, cultureInfo);
	}

	public CsvWriter CsvWriter(StreamWriter streamWriter, CultureInfo cultureInfo)
	{
		return new CsvWriter(streamWriter, cultureInfo);
	}

	public bool Exists(string filePath)
	{
		return File.Exists(filePath);
	}
}

