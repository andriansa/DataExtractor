// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvFileWriter.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the CsvFileWriter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data;
using System.Globalization;
using Microsoft.Extensions.Logging;

namespace DataExtractor.Core.FileWriter.Csv;

public sealed class CsvFileWriter : IFileWriter
{
	private readonly ILogger<CsvFileWriter> logger;
	private readonly IFileManager fileManager;

	public CsvFileWriter(ILogger<CsvFileWriter> logger, IFileManager fileManager)
	{
		this.logger = logger;
		this.fileManager = fileManager;
	}

	public void WriteToFile(string filePath, DataTable dataTable)
	{
		using var writer = fileManager.StreamWriter(filePath);
		using var csv = fileManager.CsvWriter(writer, CultureInfo.InvariantCulture);

		var columnNames = dataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
		foreach (var column in columnNames)
		{
			csv.WriteField(column);
		}

		csv.NextRecord();

		foreach (DataRow row in dataTable.Rows)
		{
			foreach (DataColumn column in dataTable.Columns)
			{
				csv.WriteField($"{row[column]}");
			}
			csv.NextRecord();
		}
	}
}

