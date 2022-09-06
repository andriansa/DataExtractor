// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileManager.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the IFileManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;

using CsvHelper;

namespace DataExtractor.Core;

public interface IFileManager
{
	StreamReader StreamReader(string filePath);

	StreamWriter StreamWriter(string filePath);

	CsvReader CsvReader(StreamReader streamReader, CultureInfo cultureInfo);

	CsvWriter CsvWriter(StreamWriter streamWriter, CultureInfo cultureInfo);

	bool Exists(string filePath);
}

